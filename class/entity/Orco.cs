namespace videoGame
{
    public class Orco : Personaje
    {
        public Orco(Datos datos) 
            : base(datos, velocidad: 8, destreza: 6, fuerza: 10, nivel: 1, salud: 100)
        {
             datos.AssetNormal1 = "assets\\orcoNormal.png";
             datos.AssetAtaque1 = "assets\\orcoAtaque.png";
            datos.Ataque1 = "datos\\piedra.png";
        }
    }
}