using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EightQueensSim
{
    public partial class Form1 : Form
    {
        private bool isRunning = true;
        private int steps = 0;

        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = false;
            cmbSize.SelectedIndex = 1;
            cmbType.SelectedIndex = 0;
            Step();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void DrawState(State state)
        {
            DrawGrid();
            string s = state.ToString();
            for (int i = 0; i < s.Length; i++)
            {
                int j = Int32.Parse("" + s[i]);
                dataGridView1[i, j].Value = "Q";
            }
        }

        private void DrawGrid()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = State.SIZE;
            dataGridView1.RowCount = State.SIZE;
            dataGridView1[0, 0].Selected = false;
            for (int i = 0; i < State.SIZE; i++)
            {
                dataGridView1.Columns[i].Name = "" + i;
                dataGridView1.Columns[i].Width = 1;
                dataGridView1.Rows[i].HeaderCell.Value = "" + i;

                bool check = (i % 2 != 0);
                for (int j = 0; j < State.SIZE; j++)
                {
                    if (check)
                        dataGridView1[i, j].Selected = true;
                    check = !check;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Step();
        }

        private void Step()
        {
            if (lbStates.Items.Count == 0)
            {
                isRunning = false;
                return;
            }


            State current = GetNextState();
            DrawState(current);

            steps ++;
            lblStepCount.Text  = ""+steps;

            if (current.IsEnd())
            {
                lbSolutions.Items.Add(current);
                timer1.Enabled = false;
                return;
            }

            foreach (State s in current.GetSuccessors())
            {
                lbStates.Items.Add(s);
            }
        }

        private State GetNextState()
        {
            State s = null;
            if ("DFS".Equals(cmbType.SelectedItem.ToString()))
            {
                s = (State)lbStates.Items[lbStates.Items.Count - 1];
                lbStates.Items.RemoveAt(lbStates.Items.Count - 1);
            }
            else
            {
                s = (State)lbStates.Items[0];
                lbStates.Items.RemoveAt(0);
            }
            return s;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isRunning)
                timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isRunning)
                Step();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            timer1.Enabled = false;
            isRunning = true;
            steps = 0;
            lblStepCount.Text = ""+steps;
            State.SIZE = Int32.Parse(cmbSize.SelectedItem.ToString());
            State start = new State();
            lbSolutions.Items.Clear();
            lbStates.Items.Clear();
            lbStates.Items.Add(start);
            Step();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new AboutBox2().ShowDialog();
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {


            if (e.ColumnIndex == -1 && e.RowIndex > -1)
            {

                e.PaintBackground(e.CellBounds, true);

                using (SolidBrush br = new SolidBrush(Color.Black))
                {

                    StringFormat sf = new StringFormat();

                    Rectangle r = e.CellBounds;
                    r.Width -= 3;
                    sf.Alignment = StringAlignment.Far;

                    sf.LineAlignment = StringAlignment.Center;

                    e.Graphics.DrawString(e.RowIndex.ToString(), e.CellStyle.Font, br, r, sf);

                }

                e.Handled = true;

            }


        }

    }
}
