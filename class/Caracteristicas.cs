using System;
namespace videoGame
{
    public class Caracteristicas
    {
       private int Velocidad;
       private int Destreza;
       private double Fuerza;

       private double Salud;

        public Caracteristicas(int velocidad, int destreza, double fuerza, double salud)
        {
            Velocidad1 = velocidad;
            Destreza1 = destreza;
            Fuerza1 = fuerza;
            Salud1 = salud;
        }

        public int Velocidad1 { get => Velocidad; set => Velocidad = value; }
        public int Destreza1 { get => Destreza; set => Destreza = value; }
        public double Fuerza1 { get => Fuerza; set => Fuerza = value; }
        public double Salud1 { get => Salud; set => Salud = value; }
    }
}