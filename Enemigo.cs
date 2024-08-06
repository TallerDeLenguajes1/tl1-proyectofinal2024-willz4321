using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videoGame
{
     class Enemigo: Sprite 
    {
        public Personaje Personaje { get; private set; }
        public Enemigo(Personaje personaje)
            : base(personaje.DatosPersonaje.AssetNormal1)
        {
            Personaje = personaje;
            ancho = 70;
            alto = 90;
            x = 640;
            y = 100;
            velocX = personaje.Velocidad1;
            velocY = personaje.Velocidad1;

            // Configurar las secuencias según el tipo de personaje.
            CargarSecuencia(Sprite.DERECHA, new string[] {
            personaje.DatosPersonaje.AssetNormal1,
            personaje.DatosPersonaje.AssetAtaque1
              });
            CambiarDireccion(Sprite.DERECHA);
            SetFramesPorFotograma(30);
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
