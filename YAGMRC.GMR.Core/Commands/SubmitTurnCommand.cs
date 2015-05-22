using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using YAGMRC.Core.Models.SubmitTurn;
using YAGMRC.Core.OS;
using YAGMRC.GMR.Core.Commands;
using YAGMRC.GMR.Core.Models.GetGamesAndPlayers;
using YAGMRC.GMR.Core.Web;

namespace YAGMRC.Core.Commands
{
	public class SubmitTurnCommand : ICommand<SubmitTurnCommandParam, SubmitTurnCommandParam>, IResult<SubmitTurnResult>
	{
		#region Constructor

		private SubmitTurnCommand()
		{
		}

		public SubmitTurnCommand(SimpleIoc resolver)
		{
			m_Resolver = resolver;
		}

		#endregion Constructor

		#region nested classes

		private class Archive
		{
			#region Constructor

			private Archive()
			{

			}

			public Archive(IOSSetting setting)
			{
				m_Setting = setting;
			}
		
			#endregion

			private IOSSetting m_Setting;

			private DirectoryInfo GetArchiveDir(int gameId)
			{
				return new DirectoryInfo(Path.Combine(m_Setting.CIVSaveGamePath.FullName, "YAGMRC-archive", gameId.ToString()));
			}

			public void MoveToArchive(FileInfo hotseatfile, int gameId)
			{              
				Trace.Assert(hotseatfile.Exists, "hotseat file: " +hotseatfile.FullName+" does not exists");


				DirectoryInfo archiveDir = GetArchiveDir(gameId);
				if (!archiveDir.Exists)
				{
					archiveDir.Create();
				}
				
				FileInfo destinationFile = null;
				do
				{
					DateTime dt = DateTime.Now;
					destinationFile = new FileInfo(Path.Combine(archiveDir.FullName, hotseatfile.Name +"-"+dt.ToString("yyyy-MM-dd-HH-mm-ss")+ hotseatfile.Extension));
				}
				while(destinationFile.Exists);

				File.Move(hotseatfile.FullName, destinationFile.FullName);
			}


			public void KeepArchivedFiles(int numberOfFilesToKeep, int gameId)
			{

				DirectoryInfo archiveDir = GetArchiveDir(gameId);
				if (!archiveDir.Exists)
				{
					return;
				}

				FileInfo[] allFilesInArchiveDir = archiveDir.GetFiles();

				List<FileInfo> filesToDelete = allFilesInArchiveDir.OrderByDescending(a => a.CreationTimeUtc).Skip(numberOfFilesToKeep).ToList();

				foreach(FileInfo fileToDelete in filesToDelete)
				{
					File.Delete(fileToDelete.FullName);
				}

			}
		}

		#endregion

		private SimpleIoc m_Resolver;

		private void GetObjects(SubmitTurnCommandParam parameter, out Game foundGame, out GetGamesPlayersCommandResult gameresult, out FileInfo fileToUpload)
		{
			gameresult = null;
			foundGame = null;
			fileToUpload = null;

			int gameid = parameter.GameID;
			gameresult = m_Resolver.GetInstance<GetGamesPlayersCommandResult>();

			foundGame = (from id in gameresult.Result.Games where id.GameId == gameid select id).FirstOrDefault();
			if (null == foundGame)
			{
				Trace.Fail("game null");
				return;
			}

            IOSSetting setting = m_Resolver.GetInstance<IOSSetting>();
			fileToUpload = parameter.UseThisFileToUpload ?? Helper.File(foundGame.GameId, setting);

			if (!fileToUpload.Exists)
			{
				Trace.Fail("File to upload: " + fileToUpload.FullName + " does not exitst.");
				return;
			}
		}


		public void Execute(SubmitTurnCommandParam parameter)
		{
			this.Result = new SubmitTurnResult();

			if (!CanExecute(parameter))
			{
				return;
			}

            IWebCommunitcation cmd = m_Resolver.GetInstance<IWebCommunitcation>();        

			GetGamesPlayersCommandResult gameresult;
			Game foundGame;
			FileInfo file;
			GetObjects(parameter, out foundGame, out gameresult, out file);

            AuthenticateCommandResult auth = m_Resolver.GetInstance<AuthenticateCommandResult>();

			
			this.Result = cmd.UploadGame(file, auth.AuthID, foundGame.CurrentTurn.TurnId).Result;

            IOSSetting setting = this.m_Resolver.GetInstance<IOSSetting>();

			Archive archive = new Archive(setting);
			
			archive.MoveToArchive(file, foundGame.GameId);
			archive.KeepArchivedFiles(parameter.ArchivedFiles, foundGame.GameId);

		}

		public bool CanExecute(SubmitTurnCommandParam parameter)
		{
			GetGamesPlayersCommandResult gameresult;
			Game foundGame = null;
			FileInfo fileToUpload;

			GetObjects(parameter, out foundGame, out gameresult, out  fileToUpload);

			if (null == foundGame || null == fileToUpload)
			{
				return false;
			}

			string hashWhenItWasSaved = null;
			if (null == parameter.UseThisFileToUpload)
			{
				if (gameresult.TryGetHash(foundGame.GameId, out hashWhenItWasSaved))
				{
					string hashNow = Helper.GetHashCode(File.ReadAllBytes(fileToUpload.FullName));
					if ((string.Equals(hashWhenItWasSaved, hashNow, StringComparison.InvariantCulture)) && (null != hashWhenItWasSaved))
					{
						return false;
					}
				}
				else
				{
					return false;
				}
			}
			else
			{
				if (!File.Exists(parameter.UseThisFileToUpload.FullName))
				{
					return false;
				}
			}

            AuthenticateCommandResult auth = m_Resolver.GetInstance<AuthenticateCommandResult>();
			if ((null == auth) || (!auth.Authenticated))
			{
				return false;
			}

			return true;
		}

		public SubmitTurnResult Result
		{
			get;
			private set;
		}
	}
}