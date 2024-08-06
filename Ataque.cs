using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videoGame
{
     class Ataque: Sprite
    {
        public Ataque(int destreza)
    : base("datos\\disparo.png")
        {
            ancho = 6;
            alto = 15;
            velocX = 0;
            velocY = -destreza;
            activo = false;
        }

        public void Activar(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.activo = true;
        }

        public override void Mover()
        {
            x += velocX;
            y += velocY;

            if ((y <= 0 )|| (y >= 720))
                activo = false;
            if ((x <= 0) || (x >= 1280))
            {
                activo = false;
            }
        }
        public void Atacar(int velocXJugador, int velocYJugador)
        {
            velocX += velocXJugador;
            velocY += velocYJugador;
            
            x += velocX;
            y += velocY;

            if ((y <= 0) || (y >= 720))
                activo = false;
            if ((x <= 0) || (x >= 1280))
                activo = false;
        }

    }
}
