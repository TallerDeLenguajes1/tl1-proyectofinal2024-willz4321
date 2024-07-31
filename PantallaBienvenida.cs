using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace videoGame
{
    class PantallaBienvenida
    {
        public void Lanzar()
        {
            bool bienvenidaTerminada = false;
            Fuente tipoDeLetra, tipoDeLetraGrande;
            tipoDeLetra = new Fuente("datos\\joystix.ttf", 18);
            tipoDeLetraGrande = new Fuente("datos\\joystix.ttf", 48);

            do
            {
                Hardware.BorrarPantallaOculta();

                Hardware.EscribirTextoOculta("Batalla Medieval",
                    400, 150, // Coordenadas
                    200, 200, 200, // Colores
                    tipoDeLetraGrande);
                Hardware.EscribirTextoOculta("Pulsa J para jugar",
                    500, 350, // Coordenadas
                    180, 180, 180, // Colores
                    tipoDeLetra);
                Hardware.EscribirTextoOculta("Pulsa T para terminar",
                    500, 400, // Coordenadas
                    160, 160, 160, // Colores
                    tipoDeLetra);

                Hardware.VisualizarOculta();
                Hardware.Pausa(20);

                if (Hardware.TeclaPulsada(Hardware.TECLA_T))
                {
                    bienvenidaTerminada = true;
                }
                else if (Hardware.TeclaPulsada(Hardware.TECLA_J))
                {
                    // Recolectar los datos del personaje
                    ClasesP tipo = SolicitarTipoPersonaje();
                    string nombre = SolicitarInput("Introduce el nombre del personaje:");
                    string apodo = SolicitarInput("Introduce el apodo del personaje:");
                    DateTime nacimiento = SolicitarFecha("Introduce la fecha de nacimiento (YYYY-MM-DD):");
                    int edad = SolicitarEdad(nacimiento);
                    string assetNormal = ""; 
                    string assetAtaque = ""; 

                    Datos datosPersonaje = new Datos(tipo, nombre, apodo, nacimiento, edad, assetNormal, assetAtaque);
                    Partida partida = new Partida(datosPersonaje);
                    partida.Lanzar();
                }
            }
            while (!bienvenidaTerminada);
        }

        private ClasesP SolicitarTipoPersonaje()
        {
             bool seleccionHecha = false;
            ClasesP tipoSeleccionado = ClasesP.ORCO;

            while (!seleccionHecha)
            {
                Hardware.BorrarPantallaOculta();

                Hardware.EscribirTextoOculta("Seleccione el tipo de personaje:",
                    400, 150, 200, 200, 200, new Fuente("datos\\joystix.ttf", 24));

                Hardware.EscribirTextoOculta("1. Orco",
                    500, 250, 180, 180, 180, new Fuente("datos\\joystix.ttf", 18));
                Hardware.EscribirTextoOculta("2. Caballero",
                    500, 300, 180, 180, 180, new Fuente("datos\\joystix.ttf", 18));
                Hardware.EscribirTextoOculta("3. Mago",
                    500, 350, 180, 180, 180, new Fuente("datos\\joystix.ttf", 18));
                Hardware.EscribirTextoOculta("4. Bestia",
                    500, 400, 180, 180, 180, new Fuente("datos\\joystix.ttf", 18));

                Hardware.VisualizarOculta();
                Hardware.Pausa(50);

                if (Hardware.TeclaPulsada(Hardware.TECLA_1))
                {
                    tipoSeleccionado = ClasesP.ORCO;
                    seleccionHecha = true;
                }
                else if (Hardware.TeclaPulsada(Hardware.TECLA_2))
                {
                    tipoSeleccionado = ClasesP.CABALLERO;
                    seleccionHecha = true;
                }
                else if (Hardware.TeclaPulsada(Hardware.TECLA_3))
                {
                    tipoSeleccionado = ClasesP.MAGO;
                    seleccionHecha = true;
                }
                else if (Hardware.TeclaPulsada(Hardware.TECLA_4))
                {
                    tipoSeleccionado = ClasesP.BESTIA;
                    seleccionHecha = true;
                }
            }

            return tipoSeleccionado;
        }

        private string SolicitarInput(string mensaje)
        {
            Console.WriteLine(mensaje);
            return Console.ReadLine();
        }

        private DateTime SolicitarFecha(string mensaje)
        {
            Console.WriteLine(mensaje);
            DateTime fecha;
            while (!DateTime.TryParse(Console.ReadLine(), out fecha))
            {
                Console.WriteLine("Formato incorrecto. Por favor, introduce la fecha en el formato correcto (YYYY-MM-DD):");
            }
            return fecha;
        }

        private int SolicitarEdad(DateTime nacimiento)
        {
            int edad = DateTime.Now.Year - nacimiento.Year;
            if (DateTime.Now.DayOfYear < nacimiento.DayOfYear)
                edad--;

            return edad;
        }
    }
}
