    namespace videoGame
{
    public class Caballero : Personaje
    {
        public Caballero(Datos datos)
            : base(datos, velocidad: 7, destreza: 8, fuerza: 16, nivel: 1, salud: 100)
        {
             datos.AssetNormal1 = "assets\\caballeroNormal.png";
             datos.AssetAtaque1 = "assets\\caballeroAtack.png";
             datos.Ataque1 = "datos\\flecha.png";
             datos.Alto1 = 120;
             datos.Ancho1 = 62;
             datos.AltoAtaque1 = 40;
             datos.AnchoAtaque1 = 10; 
        }
    }
}