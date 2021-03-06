﻿using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAGMRC.Core.DB;
using YAGMRC.Core.Model;
using YAGMRC.Core.OS;

namespace YAGMRC.Core.ViewModels
{
    public class CreateGameViewModel : GalaSoft.MvvmLight.ViewModelBase
    {
        #region constructor

        public CreateGameViewModel(IOSSetting settings)
        {
            m_Settings = settings;
        }

        #endregion

        #region nested Classes

        public class CreateGameParam
        {
            public IStorageFactory CreateStorage { get; set; }
            public Game Game { get; set; }
            public FileInfo SavedGame { get; set; }
        }

        public class CreateGameResult
        {
            public CreateGameResult()
            {
                this.IDList = new List<string>();
            }

            public List<string> IDList { get; set; }

            public Guid GameID { get; set; }

            public GameType GameType { get; set; }

            public StorageType StorageType { get; set; }
        }

        #endregion

        private IOSSetting m_Settings;


        private FileInfo GameTableFile(Game game)
        {
            return new FileInfo(Path.Combine(m_Settings.BasePath.FullName, game.ID.ToString(), "game.db3"));
        }

        private FileInfo CreateGameDatabaseFiles(Game game, DirectoryInfo dir)
        {
            FileInfo gameFile = GameTableFile(game);
            var db = CreateSQLLiteConnection.Create(gameFile);

            db.CreateTable<GameTable>();
            db.CreateTable<PlayersTable>();
            db.CreateTable<PlayerTable>();

            GameTable gametable = new GameTable();
            gametable.ID = game.ID;

            int turnID = 0;
            foreach(Player player in game.Players)
            {
                PlayerTable playerTable = new PlayerTable();
                playerTable.ID = player.ID;
                playerTable.Name = player.Name;
                playerTable.Email = player.EMail;
                
                PlayersTable playersTable = new PlayersTable();
                playersTable.GameID = game.ID;
                playersTable.PlayerID = player.ID;
                playersTable.Turn = turnID;
                
                turnID++;

            }

            return gameFile;
        }

        private FileInfo MasterTableFile
        {
            get
            {
                return new FileInfo(Path.Combine(m_Settings.BasePath.FullName, "master.db3"));
            }
        }

        private void CreateOrEditMasterTable(Game game, IStorage storage)
        {  
            var db = CreateSQLLiteConnection.Create(MasterTableFile);
            db.CreateTable<MasterTable>();
            MasterTable master = new MasterTable();
            master.GameGuid = game.ID;
            master.Me = game.Me.ID;
            master.GameType = game.GameType;
            master.StorageType = storage.Type;
            db.Insert(master);

            storage.Accept(db);
        }

        private FileInfo CreateDBFile(Game game, IStorage storage)
        {
           if (!this.m_Settings.BasePath.Exists)
           {
               Directory.CreateDirectory(this.m_Settings.BasePath.FullName);
           }

           this.CreateOrEditMasterTable(game, storage);
           
           DirectoryInfo gameDir =  Directory.CreateDirectory(Path.Combine(this.m_Settings.BasePath.FullName, game.ID.ToString()));

           return this.CreateGameDatabaseFiles(game, gameDir);

        }

       
        public CreateGameResult CreateGame(CreateGameParam param)
        {
            if (!param.SavedGame.Exists)
            {
                throw new YAGMRCException(param.SavedGame + Environment.NewLine + "does not exists");
            }
            IStorage storage = param.CreateStorage.Create();
            FileInfo dbfileToUpload = CreateDBFile(param.Game, storage);
            var storageResult = storage.Upload(param.Game, dbfileToUpload, param.SavedGame);
            return storageResult;
            
        }

    }
}
