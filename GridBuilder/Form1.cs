using System.Data;
using WFGridBuilder;

namespace GridBuilder
{
    public partial class Form1 : Form
    {
        DataTable DT = new DataTable();
        public Grid grid;

        public Form1()
        {
            InitializeComponent();
            BuildGrid();

        }

        protected void BuildGrid()
        {
            grid = new Grid(15, 15, false);
            DT = grid.GridAsDataTable();
            grvGrid.DataSource = DT;
            grvGrid.AutoSize = true;
            grvGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            grvGrid.BorderStyle = BorderStyle.None;
            grvGrid.AllowUserToResizeColumns = false;
            grvGrid.RowTemplate.Height = 45;
            grvGrid.RowTemplate.MinimumHeight = 45;
            grvGrid.Columns.Cast<DataGridViewColumn>().ToList().ForEach(x => x.Width = 45);
            grvGrid.DefaultCellStyle.Font = new Font("Arial", 15, FontStyle.Bold);
            grvGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}