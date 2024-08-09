using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videoGame
{
     class ListaAtaques
    {
        protected List<Ataque> ataques;
        protected int maxAtaques;
        protected DateTime instanteUltimoAtaque;
        protected float milisegundosEntreAtaques;
        protected double danio;
        protected int velAtaque;
        protected string ataque;
        protected int ancho;
        protected int alto;
        public ListaAtaques(double fuerza, int destreza, string ataque, int ancho, int alto)
        {
            ataques = new List<Ataque>();
            maxAtaques = 3;
            instanteUltimoAtaque = DateTime.Now;
            milisegundosEntreAtaques = 200;
            danio = fuerza;
            velAtaque = destreza;
            this.ataque = ataque;
            this.alto = alto;
            this.ancho = ancho;
        }

        public void IntentarAnadir(int x, int y)
        {
            if ((DateTime.Now - instanteUltimoAtaque).Milliseconds < milisegundosEntreAtaques)
                return;

            if (ataques.Count >= maxAtaques)
                return;

            Ataque d = new Ataque(velAtaque, ataque, ancho, alto);
            d.Activar(x, y);
            ataques.Add(d);
            instanteUltimoAtaque = DateTime.Now;
        }

        public void Dibujar()
        {
            foreach (Ataque e in ataques)
            {
                e.Dibujar();
            }
        }

        public void Mover()
        {
            foreach (Ataque d in ataques)
            {
                d.Mover();

            }

            if (true)
            {
                
            }
            for (int i = 0; i < ataques.Count; i++)
            {
                if (!ataques[i].GetActivo())
                {
                    ataques.RemoveAt(i);
                    i--;
                }
            }
        }

        public bool ImpactoCon(Sprite s, Enemigo enemigo)
        {
            foreach (Ataque d in ataques)
            {
                if (s.ColisionaCon(d))
                {
                    enemigo.Personaje.Salud1 -= danio * 1.5;
                    d.SetActivo(false);
                    return true;
                }
            }
            return false;
        }

        public void Vaciar()
        {
            ataques.Clear();
        }
    }
}
