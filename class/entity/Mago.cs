namespace videoGame
{
    public class Mago : Personaje
    {
        public Mago(Datos datos)
            : base(datos, velocidad: 7, destreza: 15, fuerza: 8, salud: 100)
        {
             datos.AssetNormal1 = "assets\\magoNormal.png";
             datos.AssetAtaque1 = "assets\\magoAtack.png";
             datos.Ataque1 = "datos\\rasengan.png";
             datos.Alto1 = 120;
             datos.Ancho1 = 68;
             datos.AltoAtaque1 = 35;
             datos.AnchoAtaque1 = 35; 
        }
    }
}    