    namespace videoGame
{
    public class Bestia : Personaje
    {
        public Bestia(Datos datos)
            : base(datos, velocidad: 4, destreza: 3, fuerza: 12, nivel: 1, salud: 100)
        {
             datos.AssetNormal1 = "assets\\bestia1Normal.png";
             datos.AssetAtaque1 = "assets\\bestia1Ataque.png";
        }
    }
}