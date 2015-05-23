using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using YAGMRC.Common;
using YAGMRC.Core;
using YAGMRC.Core.Commands;
using YAGMRC.Core.Models.SubmitTurn;
using YAGMRC.Core.OS;
using YAGMRC.GMR.Core.Commands;

namespace YAGMRC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            m_MyTraceListener = new MyTraceListener(WriteTrace, WriteTraceLine);
            Trace.Listeners.Add(m_MyTraceListener);

            m_SettingsForm = new SettingsFormGMR();
            m_MainViewModel = new YAGMRC.Common.ViewModels.MainViewModel();
            m_Config = new MyConfig();

            InitializeComponent();
        }

        private YAGMRC.Common.ViewModels.MainViewModel m_MainViewModel;
        private MyConfig m_Config;
        private MyTraceListener m_MyTraceListener;
        private SettingsFormGMR m_SettingsForm;

        private void WriteTrace(string message)
        {
            if (this.Statuslabel.InvokeRequired)
            {
                this.Invoke(new Action<string>(WriteTrace), new object[] { message });
            }
            else
            {
                this.Statuslabel.Text = message;
                this.Statuslabel.Refresh();
            }
        }

        private void WriteTraceLine(string message)
        {
            if (this.Statuslabel.InvokeRequired)
            {
                this.Invoke(new Action<string>(WriteTraceLine), new object[] { message });
            }
            else
            {
                this.Statuslabel.Text = message;
                this.Statuslabel.Refresh();
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.LoadSettings();

            if (!string.IsNullOrWhiteSpace(this.m_SettingsForm.AuthKeyTextBox.Text))
            {
                this.Authenticate();
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            this.Authenticate();
        }

        private void LoadSettings()
        {
            this.m_SettingsForm.AuthKeyTextBox.Text = m_Config.AuthKey;
        }

        private void SaveSettings()
        {
            string authKeyUI = this.m_SettingsForm.AuthKeyTextBox.Text;
            m_Config.AuthKey = authKeyUI;
        }

        private void Authenticate()
        {
            string authKey = m_Config.AuthKey;
            this.m_SettingsForm.AuthKeyTextBox.Text = authKey;

            if (!string.IsNullOrWhiteSpace(authKey))
            {
                var auth = m_MainViewModel.GMRMainViewModel.Authenticate;
                auth.Execute(new AuthenticateCommandParam(authKey));

                this.UpdateUI();
            }
        }

        private void UpdateUI()
        {
            if (this.MyTurnListBox.InvokeRequired)
            {
                this.Invoke(new Action(UpdateUI), null);
            }
            else
            {
                this.SuspendLayout();

                bool authenticated = m_MainViewModel.GMRMainViewModel.Authenticate.Result.Authenticated;
                this.LoggedInCheckBox.Checked = authenticated;

                this.AllGamesListBox.Items.Clear();
                this.MyTurnListBox.Items.Clear();

                if (authenticated)
                {
                    var getGamesAndPlayers = m_MainViewModel.GMRMainViewModel.GetGamesAndPlayers;
                    getGamesAndPlayers.Execute();
                    var getGamesAndPlayersResult = getGamesAndPlayers.Result;

                    if (getGamesAndPlayersResult.HasResult)
                    {
                        var games = getGamesAndPlayersResult.Result.Games;
                        foreach (var game in games)
                        {
                            this.AllGamesListBox.Items.Add(new GuiGame(game));
                        }

                        IEnumerable<GuiGame> myTurns = from game in games where (null != game.CurrentTurn) && (Convert.ToInt64(game.CurrentTurn.UserId) == this.m_MainViewModel.GMRMainViewModel.Authenticate.Result.PlayerID) select new GuiGame(game);
                        foreach (GuiGame myturn in myTurns)
                        {
                            this.MyTurnListBox.Items.Add(myturn);
                        }
                    }
                }

                this.ResumeLayout(false);
            }
        }

        private void DownloadGame(GuiGame selectedGame)
        {
            if ((null != selectedGame) && (this.m_MainViewModel.GMRMainViewModel.Authenticate.Result.Authenticated))
            {
                var cmd = m_MainViewModel.GMRMainViewModel.GetLatestSaveFileBytes;
                cmd.Execute(new GetLatestSaveFileBytesCommandParam(selectedGame.Game.GameId));
            }
        }

        private void DoFirstTimeTurn(GuiGame guiGame)
        {
            Trace.WriteLine("starting...");

            this.Invoke(new Action(() =>
            {
                var dialogResult = MessageBox.Show("This is your first turn." + Environment.NewLine + "Launch Steam ?", "first turn", MessageBoxButtons.YesNo);
                if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    Trace.WriteLine("launching steam (takes a while)");
                    this.m_MainViewModel.CoreMainViewModel.LaunchSteam.Execute();
                }
            }));

            this.Invoke(new Action(() =>
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();

                    openFileDialog.Filter = "Civ5 files (*.Civ5Save)|*.Civ5Save|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.InitialDirectory = m_MainViewModel.GMRMainViewModel.Resolver.GetInstance<IOSSetting>().CIVSaveGamePath.FullName;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo uploadThisFile = new FileInfo(openFileDialog.FileName);
                        Trace.Assert(uploadThisFile.Exists);

                        //upload and finish
                        Trace.WriteLine("uploading (takes a while)");
                        SubmitTurnCommand submitTurncmd = this.m_MainViewModel.GMRMainViewModel.SubmitTurn;

                        submitTurncmd.Execute(new SubmitTurnCommandParam(guiGame.Game.GameId, m_Config.keepFilesInArchiveFolder, uploadThisFile));

                        SubmitTurnResult submitTurnResult = submitTurncmd.Result;

                        this.Invoke(new Action(() =>
                        {
                            MessageBox.Show("Result: " + submitTurnResult.ResultType.ToString() + " Points: " + submitTurnResult.PointsEarned.ToString());
                        }));
                    }
                }));

            this.Invoke(new Action(() =>
            {
                this.FreezeUI(false);
                this.ResumeLayout(false);
                this.UpdateUI();

                Trace.TraceInformation("finished");
            }));
        }

        private void AnyTurnButTheFirstOne(GuiGame guiGame)
        {
            Trace.WriteLine("starting...");

            Trace.WriteLine("downloading game (takes a while)");
            DownloadGame(guiGame);

            Trace.WriteLine("finished downloading game");

            this.Invoke(new Action(() =>
            {
                var dialogResult = MessageBox.Show("Launch Steam ?", "Launch Steam", MessageBoxButtons.YesNo);
                if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    Trace.WriteLine("launching steam (takes a while)");
                    this.m_MainViewModel.CoreMainViewModel.LaunchSteam.Execute();
                }
            }));

            this.Invoke(new Action(() =>
            {
                SubmitTurnCommand submitTurncmd = this.m_MainViewModel.GMRMainViewModel.SubmitTurn;
                SubmitTurnCommandParam parameter = new SubmitTurnCommandParam(guiGame.Game.GameId, this.m_Config.keepFilesInArchiveFolder);

                var dialogResult = MessageBox.Show("Submit Turn ?", "Submit Turn", MessageBoxButtons.YesNo);
                if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    bool askTheUserAgainAndAgain = false;
                    do
                    {
                        if (submitTurncmd.CanExecute(parameter))
                        {
                            askTheUserAgainAndAgain = false;
                            Trace.WriteLine("submitting turn (takes a while)");

                            submitTurncmd.Execute(parameter);

                            SubmitTurnResult submitTurnResult = submitTurncmd.Result;

                            this.Invoke(new Action(() =>
                            {
                                MessageBox.Show("Result: " + submitTurnResult.ResultType.ToString() + " Points: " + submitTurnResult.PointsEarned.ToString());
                            }));
                        }
                        else
                        {
                            var resultuploadDialog = MessageBox.Show("It is not possible to upload the file." + Environment.NewLine + "Did you overwrite your downloaded game ?", "I will not uploadthe game", MessageBoxButtons.RetryCancel);
                            askTheUserAgainAndAgain = resultuploadDialog == System.Windows.Forms.DialogResult.Retry;                           
                        }
                    }                        
                    while(askTheUserAgainAndAgain);
                }
            }));

            this.Invoke(new Action(() =>
            {
                this.FreezeUI(false);
                this.ResumeLayout(false);
                this.UpdateUI();

                Trace.TraceInformation("finished");
            }));
        }

        private void MyTurnListBox_DoubleClick(object sender, EventArgs e)
        {
            GuiGame selectedGame = MyTurnListBox.SelectedItem as GuiGame;

            if (null == selectedGame)
            {
                return;
            }

            this.SuspendLayout();
            this.FreezeUI(true);

            this.Invoke(new Action(() =>
            {
            }));

            Action<GuiGame> action = null;
            if (!selectedGame.Game.CurrentTurn.IsFirstTurn)
            {
                action = AnyTurnButTheFirstOne;
            }
            else
            {
                action = DoFirstTimeTurn;
            }

            //Task.Factory.StartNew(action, CancellationToken.None, TaskCreationOptions.LongRunning, TaskScheduler.Default);

            using (BackgroundWorker bw = new BackgroundWorker())
            {
                bw.DoWork += (bwsender, bwe) => action(selectedGame);
                bw.RunWorkerAsync();
            }
        }

        private void FreezeUI(bool freeze)
        {
            if (this.PleaseWaitPictureBox.InvokeRequired)
            {
                this.Invoke(new Action<bool>(FreezeUI), new object[] { freeze });
            }
            else
            {
                this.PleaseWaitPictureBox.Visible = freeze;
                this.LoginButton.Enabled = !freeze;
                this.m_SettingsForm.AuthKeyTextBox.Enabled = !freeze;
                this.MyTurnListBox.Enabled = !freeze;
                this.AllGamesListBox.Enabled = !freeze;
                this.ExitButton.Enabled = !freeze;

                this.Refresh();
            }
        }

        private void AuthKeyTextBox_TextChanged(object sender, EventArgs e)
        {
            this.SaveSettings();
        }


       
        private void multiplayerrobotToolStripMenuItem_Click(object sender, EventArgs e)
        {
        

        }

        private void GMRSettings()
        {
            m_SettingsForm.SavedFilesComboBox.DataSource = MoveFilesToGameFolderItems.DataSourceItems(MoveFilesToGameFolderItems.Create(this.m_Config.keepFilesInArchiveFolder));
            m_SettingsForm.SavedFilesComboBox.DisplayMember = "Displayed";
            m_SettingsForm.SavedFilesComboBox.ValueMember = "Item";
            m_SettingsForm.SavedFilesComboBox.SelectedIndex = m_SettingsForm.SavedFilesComboBox.FindStringExact(MoveFilesToGameFolderItems.Create(this.m_Config.keepFilesInArchiveFolder).Displayed);

            m_SettingsForm.ShowDialog();


            this.m_Config.keepFilesInArchiveFolder = (m_SettingsForm.SavedFilesComboBox.SelectedValue as MoveFilesToGameFolderItems).Quantity;
            this.m_Config.AuthKey = m_SettingsForm.AuthKeyTextBox.Text;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.GMRSettings();
        }

        private void GoogleSettings()
        {

        }

        private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void CreateGoogleGame()
        {
            CreateGoogleGameForm cggf = new CreateGoogleGameForm();
            var dialogResult = cggf.ShowDialog();

            if (DialogResult.OK == dialogResult)
            {
                IStorageFactory sf = new YAGMRC.Common.Factories.CreateGoogleStorage("user");

                this.m_MainViewModel.CoreMainViewModel.CreateGame.CreateGame(new Core.ViewModels.CreateGameViewModel.CreateGameParam()
                    {
                        CreateStorage = sf,
                        Game = new Core.Model.Game(),
                        SavedGame = new FileInfo("")
                    });
            }
        }

        private void createGameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.CreateGoogleGame();
        }
    }
}