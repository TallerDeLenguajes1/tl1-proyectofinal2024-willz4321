using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.IO;

namespace videoGame
{
    class PantallaBienvenida
    {
        private List<JObject> victorias;
        private int victoriaActual; // Índice de la victoria actual
      
        
        public void Lanzar()
        {
            bool bienvenidaTerminada = false;
            Fuente tipoDeLetra, tipoDeLetraGrande;
            tipoDeLetra = new Fuente("datos\\joystix.ttf", 18);
            tipoDeLetraGrande = new Fuente("datos\\joystix.ttf", 48);
            victorias = new List<JObject>();
            victoriaActual = 0;
            CargarVictorias();
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
                Hardware.EscribirTextoOculta("Pulsa H para ver el Historial de victorias",
                    350, 400, // Coordenadas
                    160, 160, 160, // Colores
                    tipoDeLetra);
                Hardware.EscribirTextoOculta("Pulsa T para terminar",
                    500, 500, // Coordenadas
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

                    Datos datosPersonaje = new Datos(tipo, nombre, apodo, nacimiento, edad, "", "", 0, 0, 0, 0);
                    Partida partida = new Partida(datosPersonaje);
                    bienvenidaTerminada = false;
                    partida.Lanzar();

                }else if (Hardware.TeclaPulsada(Hardware.TECLA_H))
                {
                     bienvenidaTerminada = false;
                     Victorias();
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
                Hardware.Pausa(70);

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
        private void CargarVictorias()
    {
        // Leer el archivo JSON
        string filePath = "HistorialJson.json";
        if (File.Exists(filePath))
        {
            try
            {
                string jsonString = File.ReadAllText(filePath);
                JArray historialJsonArray = JArray.Parse(jsonString);

                // Limpiar la lista y agregar victorias
                victorias.Clear();
                foreach (var item in historialJsonArray)
                {
                    victorias.Add((JObject)item);
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine("Error al cargar victorias: " + ex.Message);
            }
        }
    }
    private void MostrarVictoria()
    {
        Fuente tipoDeLetra, tipoDeLetraGrande;
        tipoDeLetra = new Fuente("datos\\joystix.ttf", 18);
        tipoDeLetraGrande = new Fuente("datos\\joystix.ttf", 28);

        if (victorias.Count == 0)
        {
            // No hay victorias para mostrar
            Hardware.BorrarPantallaOculta();
            Hardware.EscribirTextoOculta("No hay victorias disponibles",
                50, 150,
                200, 200, 200,
                tipoDeLetraGrande);
            Hardware.VisualizarOculta();

            return;
        }

        // Obtener la victoria actual
        var victoria = victorias[victoriaActual];
        string mensajeJugador = $"Jugador: {victoria["Jugador"]["Nombre"]} - {victoria["Jugador"]["Apodo"]} / Edad: {victoria["Jugador"]["Edad"]} ";
        string mensajeEnemigos = "Enemigos: ";

        var enemigos = victoria["Enemigos"].ToObject<List<JObject>>();

        // Recorrer los enemigos para construir el mensaje
        for (int i = 0; i < enemigos.Count; i++)
        {
            var enemigo = enemigos[i];
            if (i == enemigos.Count - 1)
            {
                // Último enemigo, mostrar como jefe final
                mensajeEnemigos += $"[{enemigo["Nombre"]} (Jefe Final) - {enemigo["Apodo"]}],";
            }
            else
            {
                mensajeEnemigos += $"[{enemigo["Nombre"]} - {enemigo["Apodo"]}],";
            }
        }

        // Mostrar en pantalla
        Hardware.BorrarPantallaOculta();
        Hardware.EscribirTextoOculta(mensajeJugador,
            50, 150,
            200, 200, 200,
            tipoDeLetraGrande);
        Hardware.EscribirTextoOculta(mensajeEnemigos,
            50, 200,
            200, 200, 200,
            tipoDeLetra);
        Hardware.EscribirTextoOculta("Pulsa [S] para siguiente / [Q] para salir",
            50, 300,
            180, 180, 180,
            tipoDeLetra);
        Hardware.VisualizarOculta();
        Hardware.Pausa(50);
    }

    public void Victorias()
    {
        bool cerrar = false;
    
    
        while (!cerrar)
        {
            MostrarVictoria();

            if (Hardware.TeclaPulsada(Hardware.TECLA_S)) 
            {
                victoriaActual = victoriaActual + 1;
                 if (victoriaActual  == victorias.Count)
                 {
                     cerrar = true;
                     victoriaActual = 0;
                 }
            }
            else if (Hardware.TeclaPulsada(Hardware.TECLA_Q)) 
            {
                cerrar = true;
                victoriaActual = 0;
            }
        }
    }
    }
}
