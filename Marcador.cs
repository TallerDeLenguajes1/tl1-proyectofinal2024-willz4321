using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videoGame
{
    class Marcador
    {
        private string rival;
        private double vidas;
        private static Fuente tipoDeLetra;

        public Marcador()
        {
            tipoDeLetra = new Fuente("datos\\joystix.ttf", 18);
        }

        public void SetNombreRival(string rival)
        {
            this.rival = rival;
        }

        public void SetVidas(double vidas)
        {
            this.vidas = vidas;
        }

        public void Dibujar()
        {
            Hardware.EscribirTextoOculta("Rival: " + rival,
                10, 10, // Coordenadas
                200, 200, 200, // Colores
                tipoDeLetra);
            Hardware.EscribirTextoOculta("Salud: " + vidas,
                1050, 10, // Coordenadas
                200, 200, 200, // Colores
                tipoDeLetra);
        }
    }
}
