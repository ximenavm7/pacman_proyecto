using Pacman_proyecto;
using Pacman_proyecto.Recursos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pacman_proyecto
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        static Graphics g;
        private Point pacmanPos;
        public int playerX, playerY;
        public int counter = 0;
        bool right, left, up, down, hold = true;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (counter < 20)
            {
                if (right)
                {
                    Movement(Mapas.map1, playerX + 1, playerY);
                    DrawMap(Mapas.map1);
                }

                else if (left)
                {
                    Movement(Mapas.map1, playerX - 1, playerY);
                    DrawMap(Mapas.map1);
                }

                else if (up)
                {
                    Movement(Mapas.map1, playerX, playerY - 1);
                    DrawMap(Mapas.map1);
                }

                else if (down)
                {
                    Movement(Mapas.map1, playerX, playerY + 1);
                    DrawMap(Mapas.map1);
                }

            }
            if (counter >= 20 && counter < 40)
            {
                if (right)
                {
                    Movement(Mapas.map2, playerX + 1, playerY);
                    DrawMap(Mapas.map2);
                }

                else if (left)
                {
                    Movement(Mapas.map2, playerX - 1, playerY);
                    DrawMap(Mapas.map2);
                }

                else if (up)
                {
                    Movement(Mapas.map2, playerX, playerY - 1);
                    DrawMap(Mapas.map2);
                }

                else if (down)
                {
                    Movement(Mapas.map2, playerX, playerY + 1);
                    DrawMap(Mapas.map2);
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(420, 420);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;

            DrawMap(Mapas.map1);            
            label1.Text = counter.ToString();

        }

        private void DrawMap(int[,] map) 
        {    
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);
            pacmanPos = new Point();

            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (map[y, x] == 0) // Blank space
                    {
                        g.FillRectangle(new SolidBrush(Color.FromArgb(0, 0, 0)), x * 20, y * 20, 10, 10);
                    }
                    else if (map[y, x] == 1) // Coins
                    {
                        g.FillEllipse(new SolidBrush(Color.Gray), (x * 20)+5, (y * 20)+5, 7, 7);
                    }
                    else if (map[y, x] == 2) // Wall
                    {
                        if (counter < 20)
                        {
                            g.FillRectangle(new SolidBrush(Color.BlueViolet), (x * 20) + 1, (y * 20) + 1, 18, 18);
                            g.DrawRectangle(Pens.Purple, x * 20, y * 20, 20, 20);
                        }
                        else if (counter >= 20 && counter < 40)
                        {
                            g.FillRectangle(new SolidBrush(Color.IndianRed), (x * 20) + 1, (y * 20) + 1, 18, 18);
                            g.DrawRectangle(Pens.DarkRed, x * 20, y * 20, 20, 20);
                        }
                    }
                    else if (map[y, x] == 3) // Door
                    {
                        g.DrawRectangle(Pens.Gray, x * 20, y * 20, 20, 2);
                    }
                    else if (map[y, x] == 5) // Pacman
                    {
                        playerX = x; playerY = y;
                        pacmanPos.X = 191 + (x * 20);
                        pacmanPos.Y = 12 + (y * 20);
                        pictureBox2.Location = pacmanPos;
                        //g.FillRectangle(new SolidBrush(Color.Yellow), x * 20, y * 20, 10, 10);
                        //g.DrawRectangle(Pens.DarkOrange, x * 20, y * 20, 10, 10);
                    }
                    else if (map[y, x] == 6) // Portal 1
                    {
                        g.DrawEllipse(Pens.Blue, x * 20, y * 20, 15, 20);
                    }
                    else if (map[y, x] == 7) // Portal 2
                    {
                        g.DrawEllipse(Pens.OrangeRed, x * 20, y * 20, 15, 20);
                    }
                }
            }
        }

        private void Movement(int [,] map, int x, int y)
        {
            if (map[y, x] == 6) // Portal 1
            {
                playerX = 19;
                map[playerY, playerX] = 5;
                map[y, x + 1] = 0;
            }
            else if (map[y, x] == 7) // Portal 2
            {
                playerX = 1;
                map[playerY, playerX] = 5;
                map[y, x - 1] = 0;
            }
            else if (map[y, x] != 2 && map[y, x] != 3) // Cannot go through wall
            {
                if (map[y, x] == 1) // Finds a coin
                {
                    map[y, x] = 0;
                    counter++;
                    label1.Text = (counter * 100).ToString();
                }
                map[playerY, playerX] = 0;
                playerY = y;
                playerX = x;
                map[playerY, playerX] = 5;
                Invalidate();
                //DrawMap(map);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Right & hold)
            {
                right = true;
                hold = false;
                pictureBox2.Image = Resource1.PacmanR;
                
            }
            else if (e.KeyData == Keys.Left & hold)
            {
                left = true;
                hold = false;
                pictureBox2.Image = Resource1.PacmanL;
            }
            else if (e.KeyData == Keys.Up & hold)
            {
                up = true;
                hold = false;
                pictureBox2.Image = Resource1.PacmanU;
            }
            else if (e.KeyData == Keys.Down & hold)
            {
                down = true;
                hold = false;
                pictureBox2.Image = Resource1.PacmanD;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Right & !hold)
            {
                right = false;
                hold = true;
            }
            else if (e.KeyData == Keys.Left & !hold)
            {
                left = false;
                hold = true;
            }
            else if (e.KeyData == Keys.Up & !hold)
            {
                up = false;
                hold = true;
            }
            else if (e.KeyData == Keys.Down & !hold)
            {
                down = false;
                hold = true;
            }
        }
    }
}
