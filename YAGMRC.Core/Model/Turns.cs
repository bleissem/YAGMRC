using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAGMRC.Core.Model
{
    public class Turns: IEnumerable<Turn>
    {
        #region constructor

        public Turns()
        {
            this.m_Turns = new List<Turn>();
            this.CurrentTurnIndex = -1;
            
        }

        #endregion

        private List<Turn> m_Turns;

        public void Add(Turn turn)
        {
            m_Turns.Add(turn);
            if (0 > this.CurrentTurnIndex)
            {
                this.CurrentTurnIndex = 0;
            }
        }

        public int CurrentTurnIndex { get; private set; }

        public Turn CurrentTurn
        {
            get
            {
                return m_Turns[this.CurrentTurnIndex];
            }
        }

      
        public IEnumerator<Turn> GetEnumerator()
        {
            return m_Turns.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return m_Turns.GetEnumerator();
        }
    }
}
