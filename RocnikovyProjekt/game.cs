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

        public game(int x, int y)
        {
            InitializeComponent();
            
            pole = new PictureBox[x, y];
            snake = new List<SnakePart>();
            for(int i = 0; i < x; i++)
            {
                for(int j = 0; j < y; j++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Size = new Size(25,25);
                    pictureBox.Location = new Point((25 * i)+50, (25 * j)+50);
                    Image image =  Image.FromFile("../../snake.png");
                    pictureBox.Image = image;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    Controls.Add(pictureBox);
                    pole[i, j]= pictureBox;
                }
            }

        }

        private void game_Load(object sender, EventArgs e)
        {
            SnakePart snakePart = new SnakePart(4,4, "Hlava");
            SnakePart snakePart2 = new SnakePart(4, 5, "Tělo");
            SnakePart snakePart3 = new SnakePart(4, 6, "Tělo");
            snake.Add(snakePart);
            snake.Add(snakePart2);
            snake.Add(snakePart3);
            timer1.Start();
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            move(4);
                
        }
        private void move(int smer)
        {
            SnakePart snakePart = snake[0];
            SnakePart last = snake[0];
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
            pole[snakePart.getX(), snakePart.getY()].Image = Image.FromFile("../../red.png");
            //MessageBox.Show(snakePart.getX()+" " + snakePart.getY());
           for (int i = 1; i < snake.Count; i++)
            {

                SnakePart part = snake[i];
                part.setX(snake[i-1].getX());
                part.setY(snake[i - 1].getY());
                pole[part.getX(),part.getY()].Image=Image.FromFile("../../blue.png");
               //MessageBox.Show(part.getX() + " " + part.getY());
                // pole[last.getX(), last.getY()].Image = Image.FromFile("../../snake.png");
                last = part;

            }

        }
    }
}