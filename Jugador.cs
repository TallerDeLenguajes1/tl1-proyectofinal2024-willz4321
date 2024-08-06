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
            ancho = 70;
            alto = 90;
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
            x += velocX;
            SiguienteFotograma();
        }

        public void MoverIzquierda()
        {
            x -= velocX;
            SiguienteFotograma();
        }

        public void MoverArriba()
        {
            y -= velocY;
        }

        public void MoverAbajo()
        {
            y += velocY;
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
