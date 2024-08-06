namespace videoGame
{
 public class Personaje : Caracteristicas
    {
        public Datos DatosPersonaje { get; private set; }

        public Personaje(Datos datos, int velocidad, int destreza, double fuerza, int nivel, double salud)
            : base(velocidad, destreza, fuerza, nivel, salud)
        {
            DatosPersonaje = datos;
        }
    }
}