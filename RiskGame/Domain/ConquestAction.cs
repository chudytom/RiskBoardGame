using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskGame.Domain
{
    class ConquestAction
    {
        public ConquestAction(Player attackingPlayer, Player defendingPlayer)
        {
            AttackingPlayer = attackingPlayer;
            DefendingPlayer = defendingPlayer;
        }

        public Player AttackingPlayer { get; }
        public Player DefendingPlayer { get; }

        public bool ConquestSuccessful()
        {
            while (AttackerAbleToFight() && DefenderAbleToFight())
            {
                Fight();
            }

            if (!AttackerAbleToFight() && !DefenderAbleToFight())
                throw new Exception("Someone need to be able to fight");

            if (AttackerAbleToFight() && !DefenderAbleToFight())
                return true;
            else
                return false;
        }

        private void Fight()
        {
            var selectedAttackerArmiesCount = SelectAttackerArmiesByStrategy();
            var selectedDefenderArmiesCount = SelectDefenderArmiesByStrategy();

            var attackerDice = Enumerable.Range(0, selectedAttackerArmiesCount)
                .Select(i => ThrowDice())
                .Select(i => new Dice(i))
                .ToList();

            var defenderDice = Enumerable.Range(0, selectedDefenderArmiesCount)
                .Select(i => ThrowDice())
                .Select(i => new Dice(i))
                .ToList();

            var fight = new Fight(attackerDice, defenderDice);
            var fightResult = fight.GetFightResult();

            AttackingPlayer.DecreaseArmy(fightResult.AttackerLoses);
            DefendingPlayer.DecreaseArmy(fightResult.DefenderLoses);
        }

        private int SelectAttackerArmiesByStrategy()
        {
            var avaiableArmy = AttackingPlayer.Army - 1;
            return Math.Min(3, avaiableArmy);
        }

        private int SelectDefenderArmiesByStrategy()
        {
            int avaiableArmy = DefendingPlayer.Army;
            return Math.Min(2, avaiableArmy);
        }

        private bool AttackerAbleToFight()
        {
            return AttackingPlayer.Army > 1;
        }

        private bool DefenderAbleToFight()
        {
            return DefendingPlayer.Army > 0;
        }

        private int ThrowDice()
        {
            var randomizer = new Random();
            var randomizedNumber = randomizer.Next(1, 7);
            return randomizedNumber;
        }
    }
}
