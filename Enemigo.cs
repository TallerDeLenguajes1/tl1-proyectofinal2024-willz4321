using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videoGame
{
     class Enemigo: Sprite 
    {
        public Enemigo()
            : base("assets\\bestia2Normal.png")
        {
            ancho = 70;
            alto = 90;
            x = 640;
            y = 100;
            velocX = 10;
            velocY = 10;
        }

        public override void Mover()
        {
            x += velocX;
            y += velocY;

            if ((x <= 100) || (x>=1100))
            {
                velocX = -velocX;
            }
            if ((y <= 0) || (y >= 200))
            {
                velocY = -velocY;
            }
        }

        public void MoverIzquierda()
        {
            x -= velocX;
        }
    }
}
