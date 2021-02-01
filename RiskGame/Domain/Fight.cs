using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskGame.Domain
{
    public class Fight
    {
        public Fight(List<Dice> attackerDice, List<Dice> defenderDice)
        {
            if (attackerDice.Count < 1 || attackerDice.Count > 3)
                throw new ArgumentException($"Incorrect number of attacker dice - {attackerDice.Count}");
            if (defenderDice.Count < 1 || defenderDice.Count > 2)
                throw new ArgumentException($"Incorrect number of defender duce - {defenderDice.Count}");

            AttackerDice = attackerDice;
            DefenderDice = defenderDice;
        }

        public List<Dice> AttackerDice { get; set; }
        public List<Dice> DefenderDice { get; set; }

        public FightResult GetFightResult() => throw new NotImplementedException();
    }
}
