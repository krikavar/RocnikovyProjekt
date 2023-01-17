using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocnikovyProjekt
{
    class SnakePart
    {
        private int x;
        private int y;
        private String cast;

        public SnakePart(int x, int y, String cast)
        {
            this.x = x;
            this.y = y;
            this.cast = cast;

        }
        public SnakePart(SnakePart snakePart)
        {
            this.x = snakePart.getX();
            this.y = snakePart.getY();
            this.cast = snakePart.getCast();

        }
        public int getX()
        {
            return x;
        }

        public void setX(int x)
        {
            this.x = x;
        }

        public int getY()
        {
            return y;
        }

        public void setY(int y)
        {
            this.y = y;
        }

        public String getCast()
        {
            return cast;
        }

        public void setCast(String cast)
        {
            this.cast = cast;
        }


    }
}
