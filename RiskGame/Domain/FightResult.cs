using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskGame.Domain
{
    public class FightResult
    {
        public FightResult(int attackerLoses, int defenderLoses)
        {
            AttackerLoses = attackerLoses;
            DefenderLoses = defenderLoses;
        }

        public int AttackerLoses { get; private set; }
        public int DefenderLoses { get; private set; }
    }
}
