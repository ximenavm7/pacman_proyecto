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
        public enum direction { Left, Right, Up, Down };
        int playerX, playerY;

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(395, 395);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;

            DrawMap();
        }

        private void DrawMap()
        {
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);
            pacmanPos = new Point();

            for (int y = 0; y < Mapas.map0.GetLength(0); y++)
            {
                for (int x = 0; x < Mapas.map0.GetLength(1); x++)
                {
                    if (Mapas.map0[y, x] == 0)
                    {
                        g.FillRectangle(new SolidBrush(Color.FromArgb(35, 35, 35)), x * 20, y * 20, 10, 10);
                    }
                    if (Mapas.map0[y, x] == 1)
                    {
                        g.FillRectangle(new SolidBrush(Color.Green), x * 20, y * 20, 10, 10);
                    }
                    else if (Mapas.map0[y, x] == 5)
                    {
                        playerX = x; playerY = y;
                        pacmanPos.X = 198 + (x * 20);
                        pacmanPos.Y = 12 + (y * 20);
                        pictureBox2.Location = pacmanPos;
                        //pictureBox2.Image = Resource1.pacman_foto;
                        //*/
                       g.FillRectangle(new SolidBrush(Color.Yellow), x * 20, y * 20, 10, 10);
                        g.DrawRectangle(Pens.DarkOrange, x * 20, y * 20, 10, 10);
                    }
                    else if (Mapas.map0[y, x] == 2)
                    {
                        g.DrawRectangle(Pens.Purple, x * 20, y * 20, 10, 10);
                    }
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show("you pressed a key");   
            if(e.KeyCode.Equals(Keys.Up))
            {
                if (Mapas.map0[playerY-1, playerX] != 2)
                {
                    if (Mapas.map0[playerY-1, playerX] == 1)
                        Mapas.map0[playerY, playerX] = 0;
                    playerY--;
                    Mapas.map0[playerY, playerX] = 5;
                    Mapas.map0[playerY + 1, playerX] = 0;
                    Invalidate();
                    DrawMap();
                }
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                if (Mapas.map0[playerY + 1, playerX] != 2)
                {
                    if (Mapas.map0[playerY + 1, playerX] == 1)
                        Mapas.map0[playerY, playerX] = 0;
                    playerY++;
                    Mapas.map0[playerY, playerX] = 5;
                    Mapas.map0[playerY - 1, playerX] = 0;
                    Invalidate();
                    DrawMap();
                }
            }
            if (e.KeyCode.Equals(Keys.Right))
            {
                if (Mapas.map0[playerY, playerX + 1] != 2)
                {
                    if (Mapas.map0[playerY, playerX + 1] == 1)
                        Mapas.map0[playerY, playerX] = 0;
                    playerX++;
                    Mapas.map0[playerY, playerX] = 5;
                    Mapas.map0[playerY, playerX - 1] = 0;
                    Invalidate();
                    DrawMap();
                }
            }
            if (e.KeyCode.Equals(Keys.Left))
            {
                if (Mapas.map0[playerY, playerX - 1] != 2)
                {
                    if (Mapas.map0[playerY, playerX - 1] == 1)
                        Mapas.map0[playerY, playerX] = 0;
                    playerX--;
                    Mapas.map0[playerY, playerX] = 5;
                    Mapas.map0[playerY, playerX + 1] = 0;
                    Invalidate();
                    DrawMap();
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
    }
}
