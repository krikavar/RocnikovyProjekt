using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RocnikovyProjekt
{
    public partial class game : Form
    {
        private PictureBox[,] pole;
        private List<SnakePart> snake;
        private int smer = 0;
        private int x;
        private int y;
        int direction = 1;
        

        public game(int x, int y)
        {

            InitializeComponent();
            
            this.x = x;
            this.y = y;
            pole = new PictureBox[x, y];
            snake = new List<SnakePart>();
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Size = new Size(25, 25);
                    pictureBox.Location = new Point((25 * i) + 50, (25 * j) + 50);
                    Image image = Image.FromFile("../../red.png");
                    pictureBox.Image = image;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    Controls.Add(pictureBox);
                    pole[i, j] = pictureBox;
                    
                }
            }
        }

        private void game_Load(object sender, EventArgs e)
        {
            SnakePart snakePart = new SnakePart(4, 4, "hlava.png");
            SnakePart snakePart2 = new SnakePart(4, 5, "snake.png");
            SnakePart snakePart3 = new SnakePart(4, 6, "snake.png");
            snake.Add(snakePart);
            snake.Add(snakePart2);
            snake.Add(snakePart3);
            timer1.Start();
        }
        private void game_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == 'a')
            {
                if (direction != 3)
                {
                    direction = 4;
                }
            }
            else if (e.KeyChar == 'w')
            {
                direction = 1;
            }
            else if (e.KeyChar == 's')
            {
                direction = 2;
            }
            else if (e.KeyChar == 'd')
            {
                direction = 3;
            }
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            
           
            move(direction);
            draw();
            
        }

        private void draw()
        {
            Random rnd1 = new Random();
            int vyska = rnd1.Next(1, 24);
            Random rnd2 = new Random();
            int sirka = rnd2.Next(1, 24);
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    pole[vyska, sirka].Image = Image.FromFile("../../zradlo.png");
                    pole[i, j].Image = Image.FromFile("../../red.png");
                }
            }
            foreach (SnakePart snakePart in snake)
            {
                pole[snakePart.getX(), snakePart.getY()].Image = Image.FromFile("../../" + snakePart.getCast());
            }
            
        }

        private void move(int smer)
        {
            //MessageBox.Show(snake.Count.ToString());
            SnakePart snakePart = snake[0];
            List<SnakePart> newSnake = new List<SnakePart>();
            foreach (SnakePart s in snake)
            {
                newSnake.Add(new SnakePart(s));
            }
            switch (smer)
            {
                case 1: //nahoru W
                    {
                        snakePart.setY(snakePart.getY() - 1);
                        break;
                    }
                case 2: //dolu S
                    {
                        snakePart.setY(snakePart.getY() + 1);

                        break;
                    }
                case 3: //doprava D
                    {
                        snakePart.setX(snakePart.getX() + 1);

                        break;
                    }
                case 4: //doleva A
                    {
                        snakePart.setX(snakePart.getX() - 1);

                        break;
                    }
            }

            for (int i = 1; i < snake.Count; i++)
            {
                SnakePart part = snake[i];
                part.setX(newSnake[i - 1].getX());
                part.setY(newSnake[i - 1].getY());
            }
        }

        
    }
}