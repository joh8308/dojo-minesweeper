using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class Minesweeper
    {
        private string mineField;
        public Minesweeper(int colsNb, int rowsNb)
        {
            this.ColsNb = colsNb;
            this.RowsNb = rowsNb;
        }

        public string Current
        {
            get
            {
                return mineField;
            }
        }

        public int ColsNb { get; set; }

        public int RowsNb { get; set; }

        public void AddRow(string row)
        {
            if (row.Length != ColsNb)
                throw new Exception("Mega exception");
            mineField += row;
        }


        public string SolveField()
        {
            if (Current == null || mineField.Length != RowsNb*ColsNb)
                throw new Exception("ca marche pas");

            StringBuilder solve = new StringBuilder();
            for (int i = 0; i < mineField.Length; i++)
            {
                if (mineField[i] == '*')
                    solve.Append('*');
                else
                {
                    int nbMine = 0;
                    if (hasMine(i - ColsNb - 1)) nbMine++;
                    if (hasMine(i - ColsNb)) nbMine++;
                    if (i >= ColsNb && hasMine(i - ColsNb + 1)) nbMine++;
                    if (hasMine(i - 1)) nbMine++;
                    if (i >= ColsNb && hasMine(i + 1)) nbMine++;
                    if (hasMine(i + ColsNb - 1)) nbMine++;
                    if (hasMine(i + ColsNb)) nbMine++;
                    if (i >= ColsNb && hasMine(i + ColsNb + 1)) nbMine++;
                    solve.Append(nbMine);
                }
                if (i> 0 && (i+1) < mineField.Length && (i+1) % ColsNb == 0)
                    solve.Append(Environment.NewLine);
            }
            return solve.ToString();
        }

        private bool hasMine(int position)
        {
            if (position < 0 || position > ColsNb*RowsNb -1)
                return false;
            if (mineField[position] == '*')
                return true;
            return false;
        }

        public static string Resolve(string input)
        {
            var rows = input.Split(new string[]{ Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            Minesweeper current = null;
            StringBuilder sb = new StringBuilder();
            int minesweepCount = 0;
            for (int i = 0; i< rows.Length; i++)
            {
                if (current == null)
                {
                    minesweepCount++;
                    var rowcol = rows[i].Split(' ');
                    if (rows[i] == "0 0") break;
                    current = new Minesweeper(int.Parse(rowcol[1]), int.Parse(rowcol[0]));
                }
                else
                {
                    current.AddRow(rows[i]);
                    if (current.IsComplete)
                    {
                        if (minesweepCount > 1)
                            sb.Append(Environment.NewLine);

                        sb.AppendFormat("Field #{0}:{1}", minesweepCount, Environment.NewLine);
                        sb.Append(current.SolveField());
                        current = null;
                    }
                }
            }
            return sb.ToString();
        }

        public bool IsComplete
        {
            get
            {
                return this.mineField.Length == ColsNb * RowsNb;
            }
        }
    }
}
