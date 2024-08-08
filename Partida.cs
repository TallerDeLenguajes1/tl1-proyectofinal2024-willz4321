using System;
using System.Collections.Generic;

namespace videoGame
{
    class Partida
    {
        bool partidaTerminada;
        Jugador jugador;
        Enemigo enemigo;
        List<Enemigo> enemigoList;
        List<ListaAtaqueEnemigo> listaAtaqueEnemigos;
        ListaAtaques ataques;
        ListaAtaqueEnemigo ataquesEnemigo;
        int puntos;
        double vidas;
        double vidasEnemigo;
        Marcador marcador;
        Random random;

        int contador;

        public int Contador { get => contador; set => contador = value; }

        public Partida(Datos datosPersonaje)
        {
            partidaTerminada = false;
            random = new Random();
            enemigoList = new List<Enemigo>();
            listaAtaqueEnemigos = new List<ListaAtaqueEnemigo>();
            contador = 0;

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
                    vidas = bestia.Salud1;
                    jugador = new Jugador(bestia);
                    break;

                default:
                    break;
            }

            CrearEnemigosAleatorios(datosPersonaje.Tipo);


            ataques = new ListaAtaques(jugador.Personaje.Fuerza1, jugador.Personaje.Destreza1, jugador.Personaje.DatosPersonaje.Ataque1);
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

            enemigoList[Contador].Dibujar();
            jugador.Dibujar();
            ataques.Dibujar();
            listaAtaqueEnemigos[contador].Dibujar();
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

            enemigoList[Contador].Mover();

            ataques.Mover();
            listaAtaqueEnemigos[contador].Mover(enemigoList[Contador]);
        }

        private void ComprobarEstadoDelJuego()
        {

            if (listaAtaqueEnemigos[contador].ImpactoCon(jugador, jugador))
                PerderVida(jugador);


            if (ataques.ImpactoCon(enemigoList[Contador], enemigoList[Contador]))
            {

                PerderVidaEnemigo(enemigoList[Contador]);
                if (Contador == enemigoList.Count)
                {
                    partidaTerminada = true;
                }
            }
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

        private void PerderVida(Jugador jugador)
        {
            vidas = jugador.Personaje.Salud1;
            marcador.SetVidas(vidas);
            jugador.MoverA(640, 600);
            listaAtaqueEnemigos[contador].Vaciar();
            if (vidas <= 0)
                partidaTerminada = true;
        }

        private void PerderVidaEnemigo(Enemigo enemigo)
        {
            bool terminar = false;
            Fuente tipoDeLetra, tipoDeLetraGrande;
            tipoDeLetra = new Fuente("datos\\joystix.ttf", 18);
            tipoDeLetraGrande = new Fuente("datos\\joystix.ttf", 28);

            if (enemigo.Personaje.Salud1 <= 0)
            {
                Console.WriteLine(contador+1);
                if (contador + 1 == enemigoList.Count)
                {
                    do
                    {
                        Hardware.BorrarPantallaOculta();
                        string mensaje = $"Felicidades, haz derrotado a {enemigo.Personaje.DatosPersonaje.Nombre1} - {enemigo.Personaje.DatosPersonaje.Apodo1}";
                        string mensaje2 = $"Es hora de enfrentarte al jefe final!!!!";
                        Hardware.EscribirTextoOculta(mensaje,
                            100, 150, // Coordenadas
                            200, 200, 200, // Colores
                            tipoDeLetraGrande);
                        Hardware.EscribirTextoOculta(mensaje2,
                            200, 250, // Coordenadas
                            200, 200, 200, // Colores
                            tipoDeLetraGrande);
                        Hardware.EscribirTextoOculta("Pulsa J para jugar",
                            500, 350, // Coordenadas
                            180, 180, 180, // Colores
                            tipoDeLetra);

                        Hardware.VisualizarOculta();
                        Hardware.Pausa(20);

                        if (Hardware.TeclaPulsada(Hardware.TECLA_J))
                        {
                            terminar = true;

                        }

                    } while (!terminar);
                }
                else
                {
                    do
                    {
                        Hardware.BorrarPantallaOculta();
                        string mensaje = $"Felicidades, haz derrotado a {enemigo.Personaje.DatosPersonaje.Nombre1} - {enemigo.Personaje.DatosPersonaje.Apodo1}";
                        string mensaje2 = $"Tu siguente rival sera {enemigoList[contador + 1].Personaje.DatosPersonaje.Nombre1} - {enemigoList[contador + 1].Personaje.DatosPersonaje.Apodo1}";
                        Hardware.EscribirTextoOculta(mensaje,
                            100, 150, // Coordenadas
                            200, 200, 200, // Colores
                            tipoDeLetraGrande);
                        Hardware.EscribirTextoOculta(mensaje2,
                            200, 250, // Coordenadas
                            200, 200, 200, // Colores
                            tipoDeLetraGrande);
                        Hardware.EscribirTextoOculta("Pulsa J para jugar",
                            500, 350, // Coordenadas
                            180, 180, 180, // Colores
                            tipoDeLetra);

                        Hardware.VisualizarOculta();
                        Hardware.Pausa(20);

                        if (Hardware.TeclaPulsada(Hardware.TECLA_J))
                        {
                            terminar = true;
                            contador++;
                        }

                    } while (!terminar);
                }
         

            }
            ataques.Vaciar();
        }
        private void CrearEnemigosAleatorios(ClasesP tipoJugador)
        {

            List<ClasesP> rolesDisponibles = new List<ClasesP>
                {
                    ClasesP.ORCO,
                    ClasesP.CABALLERO,
                    ClasesP.MAGO,
                    ClasesP.BESTIA
                };

            rolesDisponibles.Remove(tipoJugador);

            // Crear 4 enemigos aleatorios de los roles disponibles
            for (int i = 0; i < 4; i++)
            {
                ClasesP rolAleatorio = rolesDisponibles[random.Next(rolesDisponibles.Count)];
                Personaje personaje;

                switch (rolAleatorio)
                {
                    case ClasesP.ORCO:
                        personaje = new Orco(new Datos(ClasesP.ORCO, "Torurt", "El Orco", DateTime.Parse("1710-12-01"), 150, "", ""));
                        break;
                    case ClasesP.CABALLERO:
                        personaje = new Caballero(new Datos(ClasesP.CABALLERO, "Arthur Dayne", "La espada del amanecer", DateTime.Parse("1850-08-21"), 30, "", ""));
                        break;
                    case ClasesP.MAGO:
                        personaje = new Mago(new Datos(ClasesP.MAGO, "Gandalf", "El blanco", DateTime.Parse("1810-12-01"), 80, "", ""));
                        break;
                    case ClasesP.BESTIA:
                        personaje = new Bestia(new Datos(ClasesP.BESTIA, "Cthulhu", "Cthulhu", DateTime.Parse("0001-12-01"), 2000, "", ""));
                        break;
                    default:
                        throw new Exception("Rol desconocido");
                }

                Enemigo enemigo = new Enemigo(personaje);
                ataquesEnemigo = new ListaAtaqueEnemigo(enemigo.Personaje.Fuerza1, enemigo.Personaje.Destreza1, enemigo.Personaje.DatosPersonaje.Ataque1);
                listaAtaqueEnemigos.Add(ataquesEnemigo);
                enemigoList.Add(enemigo);

            }
            Console.WriteLine(enemigoList.Count);
        }
    }
}
