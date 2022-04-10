using Path_Finder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFGridBuilder
{
    public class Grid
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public Cell[,] grid;

        /// <summary>
        /// Set the option to go through the edge of the grid and come out the other side.
        /// </summary>
        public bool HasEdgeBoundry { get; set; }

        public Grid(int height, int width, bool hasEdgeBoundry)
        {
            Height = height;
            Width = width;
            HasEdgeBoundry = hasEdgeBoundry;
            NewGrid();
        }

        public Cell this[int x, int y]
        {
            get { return grid[x, y]; }
        }
        /// <summary>
        /// Get the x, y of the cell. if it's negative it means it's on the edge so it needs to transition to the otherside of the grid.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        /// 
        public Cell GetCell(int x, int y)
        {
            x = checkXLocation(x);
            y = checkYLocation(y);
            return grid[x, y];
        }

        public int checkXLocation(int x)
        {
            if (x < 0)
                return Width - 1;

            if (x > Width - 1)
                return 0;

            return x;
        }

        public int checkYLocation(int y)
        {
            if (y < 0)
                return Height - 1;

            if (y > Height - 1)
                return 0;

            return y;
        }

        private void NewGrid()
        {

            grid = new Cell[Height, Width];
            for (int i = 0; i < Height; i++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Cell cell = new Cell(grid)
                    {
                        X = i,
                        Y = x
                    };
                    grid[i, x] = cell;
                }
            }
        }

        public void SetCell(Cell cell)
        {
            try
            {
                grid[cell.X, cell.Y] = cell;
            }
            catch (Exception)
            {

            }

        }

        public System.Data.DataTable GridAsDataTable()
        {
            DataTable dt = new DataTable();

            for (int column = 0; column < Width; column++)
            {
                dt.Columns.Add();
            }

            for (int row = 0; row < Height - 1; row++)
            {
                dt.Rows.Add();
            }

            return dt;
        }


    }
}
