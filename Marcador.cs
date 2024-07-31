using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videoGame
{
    class Marcador
    {
        private int puntos;
        private double vidas;
        private static Fuente tipoDeLetra;

        public Marcador()
        {
            tipoDeLetra = new Fuente("datos\\joystix.ttf", 18);
        }

        public void SetPuntos(int puntos)
        {
            this.puntos = puntos;
        }

        public void SetVidas(double vidas)
        {
            this.vidas = vidas;
        }

        public void Dibujar()
        {
            Hardware.EscribirTextoOculta("Puntos: " + puntos,
                10, 10, // Coordenadas
                200, 200, 200, // Colores
                tipoDeLetra);
            Hardware.EscribirTextoOculta("Salud: " + vidas,
                1150, 10, // Coordenadas
                200, 200, 200, // Colores
                tipoDeLetra);
        }
    }
}
