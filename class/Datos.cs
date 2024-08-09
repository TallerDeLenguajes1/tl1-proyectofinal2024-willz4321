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
       private int Ancho;
       private int Alto;
       private int AltoAtaque;
       private int AnchoAtaque;

        public Datos(ClasesP tipo, string nombre, string apodo, DateTime nacimiento, int edad, string assetNormal, string assetAtaque, int alto, int ancho, int altoAtaque, int anchoAtaque)
        {
            this.tipo = tipo;
            Nombre = nombre;
            Apodo = apodo;
            Nacimiento = nacimiento;
            Edad = edad;
            AssetNormal = assetNormal;
            AssetAtaque = assetAtaque;
            Alto = alto;
            Ancho = ancho;
            AltoAtaque = altoAtaque;
            AnchoAtaque = anchoAtaque;
        }

        public ClasesP Tipo { get => tipo; set => tipo = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Apodo1 { get => Apodo; set => Apodo = value; }
        public DateTime Nacimiento1 { get => Nacimiento; set => Nacimiento = value; }
        public int Edad1 { get => Edad; set => Edad = value; }
        public string AssetNormal1 { get => AssetNormal; set => AssetNormal = value; }
        public string AssetAtaque1 { get => AssetAtaque; set => AssetAtaque = value; }
        public string Ataque1 { get => Ataque; set => Ataque = value; }
        public int Ancho1 { get => Ancho; set => Ancho = value; }
        public int Alto1 { get => Alto; set => Alto = value; }
        public int AltoAtaque1 { get => AltoAtaque; set => AltoAtaque = value; }
        public int AnchoAtaque1 { get => AnchoAtaque; set => AnchoAtaque = value; }
    }
}