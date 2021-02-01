using RiskGame.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskGame.Domain
{
    public class DiceContest
    {
        public DiceContest(Dice attackerDice, Dice defenderDice)
        {
            AttackerDice = attackerDice;
            DefenderDice = defenderDice;
        }

        public Dice AttackerDice { get; set; }
        public Dice DefenderDice { get; set; }

        public DiceContestResult GetDiceContestResult() => 
            AttackerDice.Number > DefenderDice.Number 
            ? DiceContestResult.AttackerWins 
            : DiceContestResult.DefenderWins;  
    }
}
