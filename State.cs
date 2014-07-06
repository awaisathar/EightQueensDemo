using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EightQueensSim 
{
    class State :ICloneable
    {
        public static int SIZE = 6;
        public List<Queen> Queens = new List<Queen>();

        public State()
        {
        }
        public State(string s)
        {

            for (int i=0;i<s.Length;i++)
            {
                Queen q = new Queen();
                q.Row = Int32.Parse(""+s[i]);
                q.Column = i;
                Queens.Add(q);
            }
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder(SIZE);
            foreach (Queen q in Queens)
            {
                s.Append(q.Row);
            }
            return s.ToString() ;
        }

        public bool IsValid()
        {
            Queen[] queens = Queens.ToArray();

            for (int i = 0; i < queens.Length - 1; i++)
                for (int j = i + 1; j < queens.Length; j++)
                    if (queens[i].IsAttacking(queens[j])) return false;
            return true;
        }

        public bool IsEnd()
        {
            return (IsValid() && Queens.Count == SIZE);
        }

        public List<State> GetSuccessors()
        {
            List<State> l = new List<State>();
            for (int i = 0; i < SIZE; i++)
            {
                State s = new State(this.ToString() + i);
                if (s.IsValid()) l.Add(s);
            }

            return l;
        }

        #region ICloneable Members

        public object Clone()
        {
            State s = new State();
            foreach (Queen q in Queens)
            {
                s.Queens.Add((Queen)q.Clone());
            }
            return s;
        }

        #endregion
    }
}
