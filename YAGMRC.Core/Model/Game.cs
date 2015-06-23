using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YAGMRC.Core.Model
{
    public class Game
    {
        #region constructor

        private Game()
        {
            this.Me = null;
            this.m_Players = new Players();
            this.m_Turns = new Turns();
            this.m_ID = Guid.NewGuid();
        }

        public Game(string name, GameType gameType)
            : this()
        {
            this.Name = name;
            this.GameType = gameType;
        }

        #endregion constructor

        public string Name { get; set; }

        public GameType GameType { get; set; }

        public Player Me { get; set; }

        private Players m_Players;

        public void AddPlayers(string name, string email)
        {
            Player newPlayer = new Player(name, email);
            this.m_Players.Add(newPlayer);
            this.m_Turns.Add(new Turn(newPlayer));
            if (null == Me)
            {
                Me = newPlayer;
            }
        }

        private Guid m_ID;

        public Guid ID
        {
            get
            {
                return m_ID;
            }
        }

        public IEnumerable<Player> Players
        {
            get
            {
                return m_Players;
            }
        }

        private Turns m_Turns;

        public Turns Turns
        {
            get
            {
                return m_Turns;
            }
        }

       
    }
}
