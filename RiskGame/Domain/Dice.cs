using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskGame.Domain
{
    public class Dice
    {
        private int _number;

        public Dice(int number)
        {
            Number = number;
        }

        public int Number
        {
            get => _number;
            set
            {
                if (value < 1 || value > 6)
                {
                    throw new InvalidOperationException($"Dice number {value} is invalid");
                }
                _number = value;
            }
        }
    }
}
