    namespace videoGame
{
    public class Caballero : Personaje
    {
        public Caballero(Datos datos)
            : base(datos, velocidad: 7, destreza: 5, fuerza: 8, nivel: 1, salud: 100)
        {
             datos.AssetNormal1 = "assets\\caballeroNormal.png";
             datos.AssetAtaque1 = "assets\\caballeroAtack.png";
        }
    }
}