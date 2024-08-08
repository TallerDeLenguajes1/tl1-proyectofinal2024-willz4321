using System;

namespace videoGame
{
    class Jugador : Sprite
    {
    public Personaje Personaje { get; private set; }
        public Jugador(Personaje personaje)
            : base(personaje.DatosPersonaje.AssetNormal1)
        {
            Personaje = personaje;
            ancho = 90;
            alto = 120;
            x = 640;
            y = 560;
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


        public void MoverDerecha()
        {
           
            SiguienteFotograma();
            if (x >= 1100)
            {
                x = x + 0;
            }
            else
            {
                x += velocX;
            }
            SiguienteFotograma();
        }

        public void MoverIzquierda()
        {
           
            SiguienteFotograma();
            if (x <= 100)
            {
                x = x + 0;
            }
            else
            {
                x -= velocX;
            }
        }

        public void MoverArriba()
        {
            
            if (y <= 400)
            {
                y = y + 0;
            }
            else
            {
                y -= velocY;
            }
        }

        public void MoverAbajo()
        {
           
            if (y >= 580)
            {
                y = y + 0;
            }
            else
            {
                y += velocY;
            }
        }

        public int GetVelocX()
        {
            return x;
        }

        public int GetVelocY()
        {
            return y;
        }
    }

    }
