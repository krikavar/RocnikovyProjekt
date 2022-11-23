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
                    Image image = Image.FromFile("../../snake.png");
                    pictureBox.Image = image;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    Controls.Add(pictureBox);
                    pole[i, j] = pictureBox;
                }
            }
        }

        private void game_Load(object sender, EventArgs e)
        {
            SnakePart snakePart = new SnakePart(4, 4, "red.png");
            SnakePart snakePart2 = new SnakePart(4, 5, "blue.png");
            SnakePart snakePart3 = new SnakePart(4, 6, "blue.png");
            snake.Add(snakePart);
            snake.Add(snakePart2);
            snake.Add(snakePart3);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            draw();
            move(1);
        }

        private void draw()
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    pole[i, j].Image = Image.FromFile("../../snake.png");
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
                        snakePart.setX(snakePart.getX() - 1);
                        break;
                    }
                case 2: //dolu S
                    {
                        snakePart.setX(snakePart.getX() + 1);

                        break;
                    }
                case 3: //doprava D
                    {
                        snakePart.setY(snakePart.getY() - 1);

                        break;
                    }
                case 4: //doleva A
                    {
                        snakePart.setY(snakePart.getY() + 1);

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

        private void game_KeyPress(object sender, KeyPressEventArgs e)
        {
            int offset = 10;
            if (e.KeyChar == 'a')
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X - offset, pictureBox1.Location.Y);
            }
            else if (e.KeyChar == 'w')
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - offset);
            }
            else if (e.KeyChar == 's')
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + offset);
            }
            else if (e.KeyChar == 'd')
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X + offset, pictureBox1.Location.Y);
            }

        }
    }
}