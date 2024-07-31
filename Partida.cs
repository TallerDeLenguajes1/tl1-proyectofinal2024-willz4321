using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videoGame
{
     class Partida
    {
        bool partidaTerminada;
        Jugador jugador;
        Enemigo enemigo;
        ListaAtaques ataques;
        ListaAtaqueEnemigo ataquesEnemigo;
        int puntos;
        double vidas;
        Marcador marcador;

        public Partida(Datos datosPersonaje)
        {
            partidaTerminada = false;
 

            switch (datosPersonaje.Tipo)
            {
                case ClasesP.ORCO:
                Orco orco = new Orco(datosPersonaje);
                vidas = orco.Salud1;
                 jugador = new Jugador(orco);
                    break;

                case ClasesP.CABALLERO:
                Caballero caballero = new Caballero(datosPersonaje);
                vidas = caballero.Salud1;
                 jugador = new Jugador(caballero); 
                    break;

                case ClasesP.MAGO:
                Mago mago = new Mago(datosPersonaje);
                vidas = mago.Salud1;
                 jugador = new Jugador(mago);
                    break;

                case ClasesP.BESTIA:
                Bestia bestia = new Bestia(datosPersonaje);
                vidas = 3;
                 jugador = new Jugador(bestia);
                    break;

                default:
                    break;
            }

           
            enemigo = new Enemigo();
            ataques = new ListaAtaques();
            ataquesEnemigo = new ListaAtaqueEnemigo();
            marcador = new Marcador();
            puntos = 0;
            
        }

        public void Lanzar()
        {
            while (!partidaTerminada)
            {
                DibujarPantalla();
                ComprobarEntradaUsuario();
                AnimarElementos();
                ComprobarEstadoDelJuego();
                PausaHastaFinDeFotograma();
            }
        }

        private void DibujarPantalla()
        {
            Hardware.BorrarPantallaOculta();
            marcador.SetVidas(vidas);
            marcador.Dibujar();
            enemigo.Dibujar();
            jugador.Dibujar();
            ataques.Dibujar();
            ataquesEnemigo.Dibujar();
            Hardware.VisualizarOculta();
        }

        private void ComprobarEntradaUsuario()
        {
            if (Hardware.TeclaPulsada(Hardware.TECLA_DER))
                jugador.MoverDerecha();
            if (Hardware.TeclaPulsada(Hardware.TECLA_IZQ))
                jugador.MoverIzquierda();
            if (Hardware.TeclaPulsada(Hardware.TECLA_ARR))
                jugador.MoverArriba();
            if (Hardware.TeclaPulsada(Hardware.TECLA_ABA))
                jugador.MoverAbajo();
            if (Hardware.TeclaPulsada(Hardware.TECLA_Z))
                ataques.IntentarAnadir(jugador.GetX() + 20, jugador.GetY() - 15);

            if (Hardware.TeclaPulsada(Hardware.TECLA_ESC))
                partidaTerminada = true;
        }

        private void AnimarElementos()
        {
            enemigo.Mover();
            ataques.Mover();
            ataquesEnemigo.Mover(enemigo);
        }

        private void ComprobarEstadoDelJuego()
        {
            if (jugador.ColisionaCon(enemigo))
                partidaTerminada = true;

            if (ataquesEnemigo.ImpactoCon(jugador))
                PerderVida();

            //if (ataquesEnemigo.ImpactoCon(ataques))
            //    partidaTerminada = true;


            if (ataques.ImpactoCon(enemigo))
                partidaTerminada = true;
        }

        private static void PausaHastaFinDeFotograma()
        {
            Hardware.Pausa(20);
        }
        public void IncrementarPuntos(int puntos)
        {
            this.puntos += puntos;
            marcador.SetPuntos(this.puntos);
        }

        private void PerderVida()
        {
            vidas--;
            marcador.SetVidas(vidas);
            jugador.MoverA(640, 600);
            ataquesEnemigo.Vaciar();
            if (vidas <= 0)
                partidaTerminada = true;
        }
    }

}
