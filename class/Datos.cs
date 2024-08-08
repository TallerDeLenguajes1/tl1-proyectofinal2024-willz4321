using System;
namespace videoGame
{
    public class Datos
    {
       private ClasesP tipo;
       private string Nombre;
       private string Apodo;
       private DateTime Nacimiento;
       private int Edad;
       
       private string AssetNormal;
       private string AssetAtaque;
       private string Ataque;

        public Datos(ClasesP tipo, string nombre, string apodo, DateTime nacimiento, int edad, string assetNormal, string assetAtaque)
        {
            this.tipo = tipo;
            Nombre = nombre;
            Apodo = apodo;
            Nacimiento = nacimiento;
            Edad = edad;
            AssetNormal = assetNormal;
            AssetAtaque = assetAtaque;
        }

        public ClasesP Tipo { get => tipo; set => tipo = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Apodo1 { get => Apodo; set => Apodo = value; }
        public DateTime Nacimiento1 { get => Nacimiento; set => Nacimiento = value; }
        public int Edad1 { get => Edad; set => Edad = value; }
        public string AssetNormal1 { get => AssetNormal; set => AssetNormal = value; }
        public string AssetAtaque1 { get => AssetAtaque; set => AssetAtaque = value; }
        public string Ataque1 { get => Ataque; set => Ataque = value; }
    }
}