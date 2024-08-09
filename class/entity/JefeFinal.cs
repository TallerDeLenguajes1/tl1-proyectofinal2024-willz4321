namespace videoGame
{
    public class JefeFinal : Personaje
    {
        public JefeFinal(Datos datos)
            : base(datos, velocidad: 11, destreza: 8, fuerza: 20, salud: 250)
        {
             datos.AssetNormal1 = "assets\\jefe1.png";
             datos.AssetAtaque1 = "assets\\jefe1.png";
             datos.Ataque1 = "datos\\sentencia.png";
             datos.Alto1 = 150;
             datos.Ancho1 = 230;
             datos.AltoAtaque1 = 65;
             datos.AnchoAtaque1 = 75; 
        }
    }
}