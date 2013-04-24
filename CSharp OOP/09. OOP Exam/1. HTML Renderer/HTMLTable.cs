using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTMLRenderer
{
    public class HTMLTable : HTMLElement, ITable
    {
        public int Rows { get; protected set; }

        public int Cols { get; protected set; }

        private IElement[,] innerTable;

        public HTMLTable(int rows, int cols)
            :base("table", null)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.innerTable = new IElement[Rows, Cols];
        }

        public IElement this[int row, int col]
        {
            get
            {
                return this.innerTable[row, col];
            }
            set
            {
                this.innerTable[row, col] = value;
            }
        }

        public override void Render(StringBuilder output)
        {
            if (this.Name!= null)
            {
                output.Append("<");
                output.Append(this.Name);
                output.Append(">");
            }
            

            for (int row = 0; row < this.Rows; row++)
			{
                output.Append("<tr>");
			    for (int col = 0; col < this.Cols; col++)
			    {
                    output.Append("<td>");
                    output.Append(this[row,col]);
                    output.Append("</td>");
			    }

                output.Append("</tr>");
			}

            if (this.Name!= null)
            {
                output.Append("</");
                output.Append(this.Name);
                output.Append(">");
            }
            
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            this.Render(sb);
            return sb.ToString();
        }
    }
}
