using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videoGame
{
     class AtaqueEnemigo: Ataque
    {
        public AtaqueEnemigo(int destreza, string ataque) : base(0, ataque)
        {
            velocX = 0;
            velocY = destreza;
            
        }
    }
}
