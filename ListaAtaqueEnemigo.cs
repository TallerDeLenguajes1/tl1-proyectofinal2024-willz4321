using System;
using System.Collections.Generic;


namespace videoGame
{
     class ListaAtaqueEnemigo: ListaAtaques
    {

        public ListaAtaqueEnemigo(double fuerza, int destreza): base(0, 0) 
        {
            ataques = new List<Ataque>();
            maxAtaques = 3;
            danio = fuerza;
            velAtaque = destreza;
        }

        public void IntentarAnadir(int x, int y)
        {
            if ((DateTime.Now - instanteUltimoAtaque).Milliseconds
                    < milisegundosEntreAtaques)
                return;

            if (ataques.Count >= maxAtaques)
                return;

            AtaqueEnemigo d = new AtaqueEnemigo(velAtaque);
            d.Activar(x, y);
            ataques.Add(d);
            instanteUltimoAtaque = DateTime.Now;
        }

        public void Mover( Enemigo enemigo)
        {
            foreach (AtaqueEnemigo d in ataques)
            {
                d.Mover();
            }

            for (int i = 0; i < ataques.Count; i++)
            {
                if (!ataques[i].GetActivo())
                {
                    ataques.RemoveAt(i);
                    i--;
                }
            }

            if (ataques.Count < maxAtaques)
            {
                    IntentarAnadir(enemigo.GetX() + 20, enemigo.GetY() + 15);
            }
        }

        public bool ImpactoCon(Sprite s, Jugador jugador)
        {
            foreach(AtaqueEnemigo d in ataques)
            {
                if (s.ColisionaCon(d))
                {
                    jugador.Personaje.Salud1 -= danio*1.5;
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
