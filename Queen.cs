using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EightQueensSim
{
    class Queen: ICloneable
    {
        private int row = -1;
        private int column = -1;


        public int Column
        {
            get { return column; }
            set { column = value; }
        }

        public int Row
        {
            get { return row; }
            set { row = value; }
        }

        public bool IsAttacking(Queen q)
        {
            if (this.row == q.row || this.column == q.column) return true;
            if (Math.Abs(this.row-q.row) == Math.Abs(this.column-q.column)) return true;
            return false;
        }

        #region ICloneable Members

        public object Clone()
        {
            Queen obj = new Queen();
            obj.row = this.row;
            obj.column = this.column;
            return obj;
        }

        #endregion
    }
}
