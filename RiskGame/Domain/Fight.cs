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
            if (attackerDice.Count < 1 || attackerDice.Count > attackerLimit)
                throw new ArgumentException($"Incorrect number of attacker dice - {attackerDice.Count}");
            if (defenderDice.Count < 1 || defenderDice.Count > defenderLimit)
                throw new ArgumentException($"Incorrect number of defender duce - {defenderDice.Count}");

            AttackerDice = attackerDice;
            DefenderDice = defenderDice;
        }

        private int attackerLimit = 3;
        private int defenderLimit = 2;

        public List<Dice> AttackerDice { get; }
        public List<Dice> DefenderDice { get; }

        public FightResult GetFightResult()
        {
            var (selectedAttackerDice, selectedDefenderDice) = this.GetSelectedDice(AttackerDice, DefenderDice);
            if (selectedAttackerDice.Count != selectedAttackerDice.Count)
                throw new ArgumentException($"Number of dice in contests need to be the same {selectedAttackerDice}, {selectedDefenderDice}");

            var attackerLoses = 0;
            var defenderLoses = 0;

            for (int i = 0; i < selectedAttackerDice.Count; i++)
            {
                var diceContest = new DiceContest(selectedAttackerDice[i], selectedDefenderDice[i]);
                var diceContestResult = diceContest.GetDiceContestResult();
                if (diceContestResult == Enums.DiceContestResult.AttackerWins)
                    defenderLoses++;
                else
                    attackerLoses++;
            }

            var fightResult = new FightResult(attackerLoses, defenderLoses);
            return fightResult;
        }

        private (List<Dice> selectedAttackerDice, List<Dice> selectedDefenderDice) GetSelectedDice(List<Dice> attackerDice, List<Dice> defenderDice)
        {
            int numerOfDiceToSelect = Math.Min(attackerDice.Count, defenderDice.Count);
            var selectedAttackerDice = attackerDice
                .OrderByDescending(n => n.Number)
                .Take(numerOfDiceToSelect)
                .ToList();
            var selectedDefenderDice = defenderDice
                .OrderByDescending(n => n.Number)
                .Take(numerOfDiceToSelect)
                .ToList();
            return (selectedAttackerDice, selectedDefenderDice);
        }
    }
}
