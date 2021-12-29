using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laberynth
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        Pen myPen = new Pen(Color.Black, 1);
        Graphics g = null;
        SolidBrush myBrush = new SolidBrush(Color.Pink);
        SolidBrush myBrushG = new SolidBrush(Color.LightGreen);
        SolidBrush myBrushR = new SolidBrush(Color.OrangeRed);

        List<Cell> cells = new List<Cell>();
        List<Cell> stack = new List<Cell>();
        int size = 8, cols, rows;
        Cell current;

        int count = 0;
        int backCounterNumber;

        bool laberynth;
        bool pause;

        public Form1()
        {
            InitializeComponent();

            laberynth = false;

            cols = 30;
            rows = 20;

            player.Size = new Size(size - 1, size - 1);

            player.Left = 1;
            player.Top = 1;

            gamePaused.Visible = false;
            pause = false;
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            if (laberynth == false)
            {
                Size = new Size(cols * size + 17, rows * size + 40 + 20);
                canvas.Size = new Size(cols * size + 1, rows * size + 1);
                g = canvas.CreateGraphics();

                int randomColor = random.Next(0, 6);

                if (randomColor == 0)
                {
                    myBrush = new SolidBrush(Color.LightBlue);
                }
                else if (randomColor == 1)
                {
                    myBrush = new SolidBrush(Color.LightGray);
                }
                else if (randomColor == 2)
                {
                    myBrush = new SolidBrush(Color.LightCoral);
                }
                else if (randomColor == 3)
                {
                    myBrush = new SolidBrush(Color.LightPink);
                }
                else if (randomColor == 4)
                {
                    myBrush = new SolidBrush(Color.LightGreen);
                }
                else if (randomColor == 5)
                {
                    myBrush = new SolidBrush(Color.LightYellow);
                }

                backCounterNumber = Convert.ToInt32(Math.Round(Convert.ToDouble((cols * rows) / 4)) - Math.Round(Convert.ToDouble((cols + rows) / 2)) * 0.2);
                secondCounter.Text = "Seconds Left: " + backCounterNumber.ToString();
                count = 0;
                counter.Text = "Moves: " + count.ToString();

                cells = new List<Cell>();

                for (int y = 0; y < rows; y++)
                {
                    for (int x = 0; x < cols; x++)
                    {
                        Cell cell = new Cell(x, y, true, true, true, true, false);
                        cells.Add(cell);
                    }
                }

                current = cells[0];

                //Grid();
                Draw();
            }

            Rectangle rect = new Rectangle(cells[0].GetX() * size + 1, cells[0].GetY() * size + 1, size - 1, size - 1);
            g.FillRectangle(myBrushG, rect);
            rect = new Rectangle(cells[cells.Count - 1].GetX() * size + 1, cells[cells.Count - 1].GetY() * size + 1, size - 1, size - 1);
            g.FillRectangle(myBrushR, rect);

            gamePaused.Left = this.ClientRectangle.Width / 2 - gamePaused.Width / 2;
            gamePaused.Top = (this.ClientRectangle.Height - 20) / 2 - gamePaused.Height / 2;

            laberynth = true;
        }

        private void Draw()
        {
            Cell next;

            do
            {
                current.SetVisited(true);

                Rectangle rect = new Rectangle(current.GetX() * size , current.GetY() * size , size + 1, size + 1);
                if (current.GetVisited())
                {
                    g.FillRectangle(myBrush, rect);
                }

                next = CheckNeighbors(current);
                CellGrid(current);

                if (next.GetX() != -1)
                {
                    next.SetVisited(true);                    
                    RemoveWalls(current, next);
                    stack.Add(current);
                    current = next;                   
                }
                else if (stack.Count > 0)
                {
                    Cell popped = stack[stack.Count - 1];
                    stack.RemoveAt(stack.Count - 1);

                    current = popped;
                }

                //System.Threading.Thread.Sleep(100);
                CellGrid(next);
            } while (stack.Count > 0);
        }

        private Cell CheckNeighbors(Cell cell)
        {
            List<Cell> neighbors = new List<Cell>();
            int index;

            index = Index(cell.GetX(), cell.GetY() - 1);
            Cell top = new Cell();
            if (index != -1)
            {
                top = cells[index];
            }

            index = Index(cell.GetX() + 1, cell.GetY());
            Cell right = new Cell();
            if (index != -1)
            {
                right = cells[index];
            }

            index = Index(cell.GetX(), cell.GetY() + 1);
            Cell bottom = new Cell();
            if (index != -1)
            {
                bottom = cells[index];
            }

            index = Index(cell.GetX() - 1, cell.GetY());
            Cell left = new Cell();
            if (index != -1)
            {
                left = cells[index];
            }

            if (!top.GetVisited() && top.GetX() != -1)
            {
                neighbors.Add(top);
            }
            if (!right.GetVisited() && right.GetX() != -1)
            {
                neighbors.Add(right);
            }
            if (!bottom.GetVisited() && bottom.GetX() != -1)
            {
                neighbors.Add(bottom);
            }
            if (!left.GetVisited() && left.GetX() != -1)
            {
                neighbors.Add(left);
            }

            if (neighbors.Count > 0)
            {
                int r = random.Next(0, neighbors.Count);
                return neighbors[r];
            }
            else
            {
                return new Cell();
            }
        }

        private int Index(int x, int y)
        {
            if (x < 0 || y < 0 || x > cols - 1 || y > rows - 1)
            {
                return -1;
            }

            return x + y * cols;
        }

        private void RemoveWalls(Cell current, Cell next)
        {
            int x = current.GetX() - next.GetX();
            if (x == 1)
            {
                current.SetLeft(false);
                next.SetRight(false);
            }
            else if (x == -1)
            {
                current.SetRight(false);
                next.SetLeft(false);
            }

            int y = current.GetY() - next.GetY();
            if (y == 1)
            {
                current.SetTop(false);
                next.SetBottom(false);
            }
            else if (y == -1)
            {
                current.SetBottom(false);
                next.SetTop(false);
            }
        }

        private void Grid()
        {
            foreach (Cell cell in cells)
            {
                //g.DrawLine(myPen, cell.GetX() * size + size, cell.GetY() * size, cell.GetX() * size, cell.GetY() * size);
                //g.DrawLine(myPen, cell.GetX() * size + size, cell.GetY() * size, cell.GetX() * size + size, cell.GetY() * size + size);
                g.DrawLine(myPen, cell.GetX() * size + size, cell.GetY() * size + size, cell.GetX() * size, cell.GetY() * size + size);
                g.DrawLine(myPen, cell.GetX() * size, cell.GetY() * size + size, cell.GetX() * size, cell.GetY() * size);
            }
        }

        private void CellGrid(Cell cell)
        {
            if (cell.GetTop())
            {
                g.DrawLine(myPen, cell.GetX() * size + size, cell.GetY() * size, cell.GetX() * size, cell.GetY() * size);
            }
            if (cell.GetRight())
            {
                g.DrawLine(myPen, cell.GetX() * size + size, cell.GetY() * size, cell.GetX() * size + size, cell.GetY() * size + size);
            }
            if (cell.GetBottom())
            {
                g.DrawLine(myPen, cell.GetX() * size + size, cell.GetY() * size + size, cell.GetX() * size, cell.GetY() * size + size);
            }
            if (cell.GetLeft())
            {
                g.DrawLine(myPen, cell.GetX() * size, cell.GetY() * size + size, cell.GetX() * size, cell.GetY() * size);
            }
        }


        private void GameTimer_Tick(object sender, EventArgs e)
        {
            
        }

        private void BackCounter_Tick(object sender, EventArgs e)
        {
            if (backCounterNumber > 0 && !pause)
            {
                backCounterNumber--;
            }            
            secondCounter.Text = "Seconds Left: " + backCounterNumber.ToString();
        }

        private void KeyPressed(object sender, KeyEventArgs e)
        {
            Rectangle rect = new Rectangle(player.Left, player.Top, size - 1, size - 1);

            if (e.KeyCode == Keys.Up && !pause)
            {
                if (cells[Index((player.Left - 1) / size, (player.Top - 1) / size)].GetTop() == false)
                {
                    player.Top -= size;
                    count++;
                }
            }
            if (e.KeyCode == Keys.Down && !pause)
            {
                if (cells[Index((player.Left - 1) / size, (player.Top - 1) / size)].GetBottom() == false)
                {
                    player.Top += size;
                    count++;
                }
            }
            if (e.KeyCode == Keys.Left && !pause)
            {
                if (cells[Index((player.Left - 1) / size, (player.Top - 1) / size)].GetLeft() == false)
                {
                    player.Left -= size;
                    count++;
                }
            }
            if (e.KeyCode == Keys.Right && !pause)
            {
                if (cells[Index((player.Left - 1) / size, (player.Top - 1) / size)].GetRight() == false)
                {
                    player.Left += size;
                    count++;
                }
            }

            if (e.KeyCode == Keys.P && !pause)
            {
                pause = true;
                gamePaused.BringToFront();
                gamePaused.Visible = true;
            }
            else if(e.KeyCode == Keys.P && pause)
            {
                pause = false;
                gamePaused.Visible = false;
            }

            if (Index((player.Left - 1) / size, (player.Top - 1) / size) == cells.Count - 1)
            {
                laberynth = false;
                player.Left = 1;
                player.Top = 1;
                cols++;
                rows++;
                canvas.Refresh();
            }

            counter.Text = "Moves: " + count.ToString();

            g.FillRectangle(myBrush, rect);
        }

        private void KeyNotPressed(object sender, KeyEventArgs e)
        {

        }
    }

    class Cell
    {
        private int x, y;
        private bool top, right, bottom, left;
        private bool visited;

        public Cell()
        {
            this.x = -1;
        }

        public Cell(int x, int y, bool top, bool right, bool bottom, bool left, bool visited)
        {
            this.x = x;
            this.y = y;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
            this.left = left;
            this.visited = visited;
        }

        public int GetX()
        {
            return x;
        }
        public int GetY()
        {
            return y;
        }
        public bool GetTop()
        {
            return top;
        }
        public bool GetRight()
        {
            return right;
        }
        public bool GetBottom()
        {
            return bottom;
        }
        public bool GetLeft()
        {
            return left;
        }
        public bool GetVisited()
        {
            return visited;
        }

        public void SetTop(bool top)
        {
            this.top = top;
        }
        public void SetRight(bool right)
        {
            this.right = right;
        }
        public void SetBottom(bool bottom)
        {
            this.bottom = bottom;
        }
        public void SetLeft(bool left)
        {
            this.left = left;
        }
        public void SetVisited(bool visited)
        {
            this.visited = visited;
        }
    }
}
