namespace videoGame
{
    public class Orco : Personaje
    {
        public Orco(Datos datos) 
            : base(datos, velocidad: 8, destreza: 6, fuerza: 16, salud: 100)
        {
             datos.AssetNormal1 = "assets\\orcoNormal.png";
             datos.AssetAtaque1 = "assets\\orcoAtaque.png";
             datos.Ataque1 = "datos\\piedra.png";
             datos.Alto1 = 120;
             datos.Ancho1 = 73;
             datos.AltoAtaque1 = 40;
             datos.AnchoAtaque1 = 15; 
        }
    }
}