using System;
using System.Collections.Generic;


namespace videoGame
{
     class ListaAtaqueEnemigo: ListaAtaques
    {

        public ListaAtaqueEnemigo()
        {
            ataques = new List<Ataque>();
            maxAtaques = 3;
        }

        public void IntentarAnadir(int x, int y)
        {
            if ((DateTime.Now - instanteUltimoAtaque).Milliseconds
                    < milisegundosEntreAtaques)
                return;

            if (ataques.Count >= maxAtaques)
                return;

            AtaqueEnemigo d = new AtaqueEnemigo();
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

        public bool ImpactoCon(Sprite s)
        {
            foreach(AtaqueEnemigo d in ataques)
            {
                if (s.ColisionaCon(d))
                {
                    d.SetActivo(false);
                    return true;
                }
            }
            return false;
        }

        //public void ImpactoMutuo(ListaAtaques ataque)
        //{
        //    foreach (var ataq in ataques)
        //    {

        //            if (ataq.ColisionaCon(ataque))
        //            {
        //                ataques.Remove(ataq);
        //                ataquesEnemigo.Remove(ataqE);
        //            }

        //    }
        //}

        public void Vaciar()
        {
            ataques.Clear();
        }
    }
}
