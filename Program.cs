using System;
using videoGame;
namespace videoGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Hardware.Inicializar(1280, 720, 24);

           PantallaBienvenida bienvenida = new PantallaBienvenida();
            bienvenida.Lanzar();

        }
    }

}