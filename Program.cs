using System;
using System.Net;
using videoGame;
using videoGame.api;

namespace videoGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Forzar el uso de TLS 1.2
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            Hardware.Inicializar(1280, 720, 32);

            PantallaBienvenida bienvenida = new PantallaBienvenida();
            bienvenida.Lanzar();
        }
    }
}
