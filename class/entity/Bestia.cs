    namespace videoGame
{
    public class Bestia : Personaje
    {
        public Bestia(Datos datos)
            : base(datos, velocidad: 11, destreza: 10, fuerza: 12, nivel: 1, salud: 100)
        {
             datos.AssetNormal1 = "assets\\bestia1Normal.png";
             datos.AssetAtaque1 = "assets\\bestia1Ataque.png";
             datos.Ataque1 = "datos\\meteoro.png";
             datos.Alto1 = 120;
             datos.Ancho1 = 100;
             datos.AltoAtaque1 = 50;
             datos.AnchoAtaque1 = 30; 
        }
    }
}