using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskGame.Domain
{
    class Player
    {


        public int Army { get; private set; }

        public Player(int army)
        {
            Army = army;
        }

        public void DecreaseArmy(int number)
        {
            if (number > Army)
                throw new ArgumentException("Negative value of army");

            Army -= number;
        }
    }
}
