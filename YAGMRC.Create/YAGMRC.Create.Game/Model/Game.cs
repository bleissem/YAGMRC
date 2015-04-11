using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAGMRC.Create.Game.Model
{
    public class Game
    {
        #region constructor

        public Game()
        {
            this.m_Players = new Players();
            this.m_Turn = new Turn();
            this.m_ID = Guid.NewGuid();
        }

        public Game(string name)
            : this()
        {
            this.Name = name;
        }

        #endregion


        public string Name { get; set; }

        private Players m_Players;

        public void AddPlayers(string name, string email)
        {
            Player newPlayer = new Player(name, email);
            this.m_Players.Add(newPlayer);
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

        private Turn m_Turn;
        public Turn Turn
        {
            get
            {
                return m_Turn;
            }
        }

    }
}
