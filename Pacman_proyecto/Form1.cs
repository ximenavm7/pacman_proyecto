using Pacman_proyecto;
using Pacman_proyecto.Recursos;
using System;
using System.CodeDom.Compiler;
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
        bool right, left, up, down;

        struct Ghost
        {
            public Point ghostPos;
            public int ghostX, ghostY, name;
        }

        Ghost[] ghost = new Ghost[4];
        Random random = new Random();

        private void Ghosts_movement(int x, int y, int[,] map, int num)
        {
            if (map[y, x] == 6) // Portal 1
            {
                ghost[num].ghostX = 19;
                map[y, x + 1] = 0;
                map[ghost[num].ghostY, ghost[num].ghostX] = ghost[num].name;
                Invalidate();
                DrawMap(map);
            }
            else if (map[y, x] == 7) // Portal 2
            {
                ghost[num].ghostX = 1;
                map[y, x - 1] = 0;
                map[ghost[num].ghostY, ghost[num].ghostX] = ghost[num].name;
                Invalidate();
                DrawMap(map);

            }
            else if (map[y, x] != 2)
            {
                if (map[y, x] != 5)
                {
                    map[y, x] = ghost[num].name;
                    map[ghost[num].ghostY, ghost[num].ghostX] = 0;
                    ghost[num].ghostY = y;
                    ghost[num].ghostX = x;
                    Invalidate();
                    DrawMap(map);
                }
                else if (map[y, x] == 5)
                {
                    Environment.Exit(0);
                }
            }
        }

        // Timer that controls the ghosts movements
        private void timer2_Tick(object sender, EventArgs e)
        {
            int direction1 = random.Next(0, 5);
            int direction2 = random.Next(0, 5);
            int direction3 = random.Next(0, 5);
            int direction4 = random.Next(0, 5);

            if (counter < 150)
            {
            switch (direction1) // FANTASMA 1
            {
                case 1: //arriba
                    Ghosts_movement(ghost[0].ghostX, ghost[0].ghostY - 1, Mapas.map1, 0);
                    break;

                case 2: //abajo
                    Ghosts_movement(ghost[0].ghostX, ghost[0].ghostY + 1, Mapas.map1, 0);
                    break;

                case 3: //derecha
                    Ghosts_movement(ghost[0].ghostX + 1, ghost[0].ghostY, Mapas.map1, 0);
                    break;

                case 4: //izquierda
                    Ghosts_movement(ghost[0].ghostX - 1, ghost[0].ghostY, Mapas.map1, 0);
                    break;
            }
            switch (direction2) // FANTASMA 2
            {
                case 1: //arriba
                    Ghosts_movement(ghost[0].ghostX, ghost[0].ghostY - 1, Mapas.map1, 1);
                    break;

                case 2: //abajo
                    Ghosts_movement(ghost[0].ghostX, ghost[0].ghostY + 1, Mapas.map1, 1);
                    break;

                case 3: //derecha
                    Ghosts_movement(ghost[0].ghostX + 1, ghost[0].ghostY, Mapas.map1, 1);
                    break;

                case 4: //izquierda
                    Ghosts_movement(ghost[0].ghostX - 1, ghost[0].ghostY, Mapas.map1, 1);
                    break;
            }
            switch (direction3) // FANTASMA 3
            {
                case 1: //arriba
                    Ghosts_movement(ghost[0].ghostX, ghost[0].ghostY - 1, Mapas.map1, 2);
                    break;

                case 2: //abajo
                    Ghosts_movement(ghost[0].ghostX, ghost[0].ghostY + 1, Mapas.map1, 2);
                    break;

                case 3: //derecha
                    Ghosts_movement(ghost[0].ghostX + 1, ghost[0].ghostY, Mapas.map1, 2);
                    break;

                case 4: //izquierda
                    Ghosts_movement(ghost[0].ghostX - 1, ghost[0].ghostY, Mapas.map1, 2);
                    break;
            }
            switch (direction4) // FANTASMA 4
            {
                case 1: //arriba
                    Ghosts_movement(ghost[0].ghostX, ghost[0].ghostY - 1, Mapas.map1, 3);
                    break;

                case 2: //abajo
                    Ghosts_movement(ghost[0].ghostX, ghost[0].ghostY + 1, Mapas.map1, 3);
                    break;

                case 3: //derecha
                    Ghosts_movement(ghost[0].ghostX + 1, ghost[0].ghostY, Mapas.map1, 3);
                    break;

                case 4: //izquierda
                    Ghosts_movement(ghost[0].ghostX - 1, ghost[0].ghostY, Mapas.map1, 3);
                    break;
            }
            }
            else if (counter >= 150 && counter < 300)
            {
                switch (direction1) // FANTASMA 1
                {
                    case 1: //arriba
                        Ghosts_movement(ghost[0].ghostX, ghost[0].ghostY - 1, Mapas.map2, 0);
                        break;

                    case 2: //abajo
                        Ghosts_movement(ghost[0].ghostX, ghost[0].ghostY + 1, Mapas.map2, 0);
                        break;

                    case 3: //derecha
                        Ghosts_movement(ghost[0].ghostX + 1, ghost[0].ghostY, Mapas.map2, 0);
                        break;

                    case 4: //izquierda
                        Ghosts_movement(ghost[0].ghostX - 1, ghost[0].ghostY, Mapas.map2, 0);
                        break;
                }
                switch (direction2) // FANTASMA 2
                {
                    case 1: //arriba
                        Ghosts_movement(ghost[0].ghostX, ghost[0].ghostY - 1, Mapas.map2, 1);
                        break;

                    case 2: //abajo
                        Ghosts_movement(ghost[0].ghostX, ghost[0].ghostY + 1, Mapas.map2, 1);
                        break;

                    case 3: //derecha
                        Ghosts_movement(ghost[0].ghostX + 1, ghost[0].ghostY, Mapas.map2, 1);
                        break;

                    case 4: //izquierda
                        Ghosts_movement(ghost[0].ghostX - 1, ghost[0].ghostY, Mapas.map2, 1);
                        break;
                }
                switch (direction3) // FANTASMA 3
                {
                    case 1: //arriba
                        Ghosts_movement(ghost[0].ghostX, ghost[0].ghostY - 1, Mapas.map2, 2);
                        break;

                    case 2: //abajo
                        Ghosts_movement(ghost[0].ghostX, ghost[0].ghostY + 1, Mapas.map2, 2);
                        break;

                    case 3: //derecha
                        Ghosts_movement(ghost[0].ghostX + 1, ghost[0].ghostY, Mapas.map2, 2);
                        break;

                    case 4: //izquierda
                        Ghosts_movement(ghost[0].ghostX - 1, ghost[0].ghostY, Mapas.map2, 2);
                        break;
                }
                switch (direction4) // FANTASMA 4
                {
                    case 1: //arriba
                        Ghosts_movement(ghost[0].ghostX, ghost[0].ghostY - 1, Mapas.map2, 3);
                        break;

                    case 2: //abajo
                        Ghosts_movement(ghost[0].ghostX, ghost[0].ghostY + 1, Mapas.map2, 3);
                        break;

                    case 3: //derecha
                        Ghosts_movement(ghost[0].ghostX + 1, ghost[0].ghostY, Mapas.map2, 3);
                        break;

                    case 4: //izquierda
                        Ghosts_movement(ghost[0].ghostX - 1, ghost[0].ghostY, Mapas.map2, 3);
                        break;
                }
            }
            else if (counter >= 300 && counter < 450)
            {
                switch (direction1) // FANTASMA 1
                {
                    case 1: //arriba
                        Ghosts_movement(ghost[0].ghostX, ghost[0].ghostY - 1, Mapas.map3, 0);
                        break;

                    case 2: //abajo
                        Ghosts_movement(ghost[0].ghostX, ghost[0].ghostY + 1, Mapas.map3, 0);
                        break;

                    case 3: //derecha
                        Ghosts_movement(ghost[0].ghostX + 1, ghost[0].ghostY, Mapas.map3, 0);
                        break;

                    case 4: //izquierda
                        Ghosts_movement(ghost[0].ghostX - 1, ghost[0].ghostY, Mapas.map3, 0);
                        break;
                }
                switch (direction2) // FANTASMA 2
                {
                    case 1: //arriba
                        Ghosts_movement(ghost[0].ghostX, ghost[0].ghostY - 1, Mapas.map3, 1);
                        break;

                    case 2: //abajo
                        Ghosts_movement(ghost[0].ghostX, ghost[0].ghostY + 1, Mapas.map3, 1);
                        break;

                    case 3: //derecha
                        Ghosts_movement(ghost[0].ghostX + 1, ghost[0].ghostY, Mapas.map3, 1);
                        break;

                    case 4: //izquierda
                        Ghosts_movement(ghost[0].ghostX - 1, ghost[0].ghostY, Mapas.map3, 1);
                        break;
                }
                switch (direction3) // FANTASMA 3
                {
                    case 1: //arriba
                        Ghosts_movement(ghost[0].ghostX, ghost[0].ghostY - 1, Mapas.map3, 2);
                        break;

                    case 2: //abajo
                        Ghosts_movement(ghost[0].ghostX, ghost[0].ghostY + 1, Mapas.map3, 2);
                        break;

                    case 3: //derecha
                        Ghosts_movement(ghost[0].ghostX + 1, ghost[0].ghostY, Mapas.map3, 2);
                        break;

                    case 4: //izquierda
                        Ghosts_movement(ghost[0].ghostX - 1, ghost[0].ghostY, Mapas.map3, 2);
                        break;
                }
                switch (direction4) // FANTASMA 1
                {
                    case 1: //arriba
                        Ghosts_movement(ghost[0].ghostX, ghost[0].ghostY - 1, Mapas.map3, 3);
                        break;

                    case 2: //abajo
                        Ghosts_movement(ghost[0].ghostX, ghost[0].ghostY + 1, Mapas.map3, 3);
                        break;

                    case 3: //derecha
                        Ghosts_movement(ghost[0].ghostX + 1, ghost[0].ghostY, Mapas.map3, 3);
                        break;

                    case 4: //izquierda
                        Ghosts_movement(ghost[0].ghostX - 1, ghost[0].ghostY, Mapas.map3, 3);
                        break;
                }
            }


        }

        // Timer that controls Pacmans movements
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (counter < 150)
            {
                DrawMap(Mapas.map1);
                if (right)
                {
                    PlayerMovement(Mapas.map1, playerX + 1, playerY);
                }

                else if (left)
                {
                    PlayerMovement(Mapas.map1, playerX - 1, playerY);
                }

                else if (up)
                {
                    PlayerMovement(Mapas.map1, playerX, playerY - 1);
                }

                else if (down)
                {
                    PlayerMovement(Mapas.map1, playerX, playerY + 1);
                }

            }
            else if (counter >= 150 && counter < 300)
            {
                DrawMap(Mapas.map2);
                if (right)
                {
                    PlayerMovement(Mapas.map2, playerX + 1, playerY);
                }

                else if (left)
                {
                    PlayerMovement(Mapas.map2, playerX - 1, playerY);
                }

                else if (up)
                {
                    PlayerMovement(Mapas.map2, playerX, playerY - 1);
                }

                else if (down)
                {
                    PlayerMovement(Mapas.map2, playerX, playerY + 1);
                }
            }
            else if (counter >= 300 && counter < 450)
            {
                DrawMap(Mapas.map3);
                if (right)
                {
                    PlayerMovement(Mapas.map3, playerX + 1, playerY);
                }

                else if (left)
                {
                    PlayerMovement(Mapas.map3, playerX - 1, playerY);
                }

                else if (up)
                {
                    PlayerMovement(Mapas.map3, playerX, playerY - 1);
                }

                else if (down)
                {
                    PlayerMovement(Mapas.map3, playerX, playerY + 1);
                }
            }
            else if (counter == 450)
                pictureBox3.Show();
        }

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(420, 420);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;

            pictureBox3.Hide();

            DrawMap(Mapas.map1);            
            label1.Text = counter.ToString();    
        }

        private void DrawMap(int[,] map) 
        {    
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);
            pacmanPos = new Point();
            if (counter == 450)
            {
                pictureBox1.Hide();
                pictureBox2.Hide();
                pictureBox4.Hide();
                pictureBox5.Hide();
                pictureBox6.Hide();
                pictureBox7.Hide();
            }
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
                        g.FillEllipse(new SolidBrush(Color.Gray), (x * 20) + 5, (y * 20) + 5, 7, 7);
                    }
                    else if (map[y, x] == 2) // Wall
                    {
                        if (counter < 150) // Map 1
                        {
                            g.FillRectangle(new SolidBrush(Color.BlueViolet), (x * 20) + 1, (y * 20) + 1, 18, 18);
                            g.DrawRectangle(Pens.Purple, x * 20, y * 20, 20, 20);
                        }
                        else if (counter >= 150 && counter < 300) // Map 2
                        {
                            g.FillRectangle(new SolidBrush(Color.IndianRed), (x * 20) + 1, (y * 20) + 1, 18, 18);
                            g.DrawRectangle(Pens.DarkRed, x * 20, y * 20, 20, 20);
                        }
                        else if (counter >= 300 && counter < 450) // Map 3
                        {
                            g.FillRectangle(new SolidBrush(Color.CadetBlue), (x * 20) + 1, (y * 20) + 1, 18, 18);
                            g.DrawRectangle(Pens.DarkBlue, x * 20, y * 20, 20, 20);
                        }
                    }
                    else if (map[y, x] == 3) // Door
                    {
                        g.DrawRectangle(Pens.Gray, x * 20, y * 20, 20, 2);
                    }
                    else if (map[y, x] == 5) // Pacman
                    {
                        playerX = x; playerY = y;
                        pacmanPos.X = pictureBox1.Location.X + (x * 20);
                        pacmanPos.Y = pictureBox1.Location.Y + (y * 20);
                        pictureBox2.Location = pacmanPos;
                    }
                    else if (map[y, x] == 6) // Portal 1
                    {
                        g.DrawEllipse(Pens.Blue, x * 20, y * 20, 15, 20);
                    }
                    else if (map[y, x] == 7) // Portal 2
                    {
                        g.DrawEllipse(Pens.OrangeRed, x * 20, y * 20, 15, 20);
                    }
                    else if (map[y, x] == 8)  //Ghost 1
                    {
                        ghost[0].name = 8;
                        ghost[0].ghostX = x;
                        ghost[0].ghostY = y;
                        ghost[0].ghostPos.X = pictureBox1.Location.X + (x * 20);
                        ghost[0].ghostPos.Y = pictureBox1.Location.Y + (y * 20);
                        pictureBox4.Location = ghost[0].ghostPos;
                    }

                    else if (map[y, x] == 9)  //Ghost 2
                    {
                        ghost[1].name = 9;
                        ghost[1].ghostX = x;
                        ghost[1].ghostY = y;
                        ghost[1].ghostPos.X = pictureBox1.Location.X + (x * 20);
                        ghost[1].ghostPos.Y = pictureBox1.Location.Y + (y * 20);
                        pictureBox5.Location = ghost[1].ghostPos;
                    }


                    else if (map[y, x] == 10)  //Ghost 3
                    {
                        ghost[2].name = 10;
                        ghost[2].ghostX = x;
                        ghost[2].ghostY = y;
                        ghost[2].ghostPos.X = pictureBox1.Location.X + (x * 20);
                        ghost[2].ghostPos.Y = pictureBox1.Location.Y + (y * 20);
                        pictureBox6.Location = ghost[2].ghostPos;
                    }

                    else if (map[y, x] == 11)  //Ghost 4
                    {
                        ghost[3].name = 11;
                        ghost[3].ghostX = x;
                        ghost[3].ghostY = y;
                        ghost[3].ghostPos.X = pictureBox1.Location.X + (x * 20);
                        ghost[3].ghostPos.Y = pictureBox1.Location.Y + (y * 20);
                        pictureBox7.Location = ghost[3].ghostPos;
                    }
                }
            }
        }

        private void PlayerMovement(int [,] map, int x, int y)
        {
            if (map[y, x] == 6) // Portal 1
            {
                playerX = 19;
                map[y, x + 1] = 0;
                map[playerY, playerX] = 5;
                Invalidate();
                DrawMap(map);
            }
            else if (map[y, x] == 7) // Portal 2
            {
                playerX = 1;
                map[y, x - 1] = 0;
                map[playerY, playerX] = 5;
                Invalidate();
                DrawMap(map);

            }
            else if (map[y, x] != 2 && map[y, x] != 3) // Cannot go through wall or door
            {
                if (map[y, x] == 1) // Finds a coin
                {
                    map[y, x] = 0;                   
                    counter++;
                    label1.Text = (counter * 10).ToString();
                }
                if (map[y, x] == 8 || map[y, x] == 9 || map[y, x] == 10 || map[y, x] == 11)
                {
                    Environment.Exit(0);
                }
                map[playerY, playerX] = 0;
                playerY = y;
                playerX = x;
                map[playerY, playerX] = 5;
                Invalidate();
                DrawMap(map);

            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Right)
            {
                right = true;
                pictureBox2.Image = Resource1.PacmanR;
                
            }
            else if (e.KeyData == Keys.Left)
            {
                left = true;
                pictureBox2.Image = Resource1.PacmanL;
            }
            else if (e.KeyData == Keys.Up)
            {
                up = true;
                pictureBox2.Image = Resource1.PacmanU;
            }
            else if (e.KeyData == Keys.Down)
            {
                down = true;
                pictureBox2.Image = Resource1.PacmanD;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Right)
            {
                right = false;
            }
            else if (e.KeyData == Keys.Left)
            {
                left = false;
            }
            else if (e.KeyData == Keys.Up)
            {
                up = false;
            }
            else if (e.KeyData == Keys.Down)
            {
                down = false;
            }
        }
    }
}
