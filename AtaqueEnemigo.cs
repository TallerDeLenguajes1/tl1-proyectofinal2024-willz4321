using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videoGame
{
     class AtaqueEnemigo: Ataque
    {
        public AtaqueEnemigo(int destreza, string ataque, int anchoA, int AltoA) : base(0, ataque, anchoA, AltoA)
        {
            velocX = 0;
            velocY = destreza;
            
        }
    }
}
