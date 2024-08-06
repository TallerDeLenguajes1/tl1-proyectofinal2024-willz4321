namespace videoGame
{
    public class Mago : Personaje
    {
        public Mago(Datos datos)
            : base(datos, velocidad: 7, destreza: 15, fuerza: 5, nivel: 1, salud: 100)
        {
             datos.AssetNormal1 = "assets\\magoNormal.png";
             datos.AssetAtaque1 = "assets\\magoAtack.png";
        }
    }
}    