using RiskGame.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RiskGameTests
{
    public class FightTests
    {
        [Theory]
        [InlineData(new int[] { 5 }, new int[] { 3 }, 0, 1)]
        [InlineData(new int[] { 2 }, new int[] { 6 }, 1, 0)]
        [InlineData(new int[] { 4 }, new int[] { 4 }, 1, 0)]
        public void Given1AttackerDiceAnd1DefenderDice_WhenGetFightResult_ThenReturnCorrectLoses(int[] attackerDice, int[] defenderDice, int attackerLoses, int defenderLoses)
        {
            // Given
            var convertedAttackerDice = attackerDice.Select(i => new Dice(i)).ToList();
            var convertedDefenderDice = defenderDice.Select(i => new Dice(i)).ToList();

            // When
            var fight = new Fight(convertedAttackerDice, convertedDefenderDice);
            var fightResult = fight.GetFightResult();

            // Then
            Assert.Equal(attackerLoses, fightResult.AttackerLoses);
            Assert.Equal(defenderLoses, fightResult.DefenderLoses);
        }

        [Theory]
        [InlineData(new int[] { 5 }, new int[] { 3, 4 }, 0, 1)]
        [InlineData(new int[] { 2 }, new int[] { 3, 4 }, 1, 0)]
        [InlineData(new int[] { 5 }, new int[] { 3, 6 }, 1, 0)]
        public void Given1AttackerDiceAnd2DefenderDice_WhenGetFightResult_ThenReturnCorrectLoses(int[] attackerDice, int[] defenderDice, int attackerLoses, int defenderLoses)
        {
            // Given
            var convertedAttackerDice = attackerDice.Select(i => new Dice(i)).ToList();
            var convertedDefenderDice = defenderDice.Select(i => new Dice(i)).ToList();

            // When
            var fight = new Fight(convertedAttackerDice, convertedDefenderDice);
            var fightResult = fight.GetFightResult();

            // Then
            Assert.Equal(attackerLoses, fightResult.AttackerLoses);
            Assert.Equal(defenderLoses, fightResult.DefenderLoses);
        }

        [Theory]
        [InlineData(new int[] { 5, 4 }, new int[] { 3 }, 0, 1)]
        [InlineData(new int[] { 2, 4 }, new int[] { 5 }, 1, 0)]
        [InlineData(new int[] { 2, 6 }, new int[] { 5 }, 0, 1)]
        public void Given2AttackerDiceAnd1DefenderDice_WhenGetFightResult_ThenReturnCorrectLoses(int[] attackerDice, int[] defenderDice, int attackerLoses, int defenderLoses)
        {
            // Given
            var convertedAttackerDice = attackerDice.Select(i => new Dice(i)).ToList();
            var convertedDefenderDice = defenderDice.Select(i => new Dice(i)).ToList();

            // When
            var fight = new Fight(convertedAttackerDice, convertedDefenderDice);
            var fightResult = fight.GetFightResult();

            // Then
            Assert.Equal(attackerLoses, fightResult.AttackerLoses);
            Assert.Equal(defenderLoses, fightResult.DefenderLoses);
        }

        [Theory]
        [InlineData(new int[] { 5, 4 }, new int[] { 4, 3 }, 0, 2)]
        [InlineData(new int[] { 5, 4 }, new int[] { 5, 3 }, 1, 1)]
        [InlineData(new int[] { 6, 2 }, new int[] { 4, 5 }, 1, 1)]
        [InlineData(new int[] { 5, 3 }, new int[] { 3, 5 }, 2, 0)]
        public void Given2AttackerDiceAnd2DefenderDice_WhenGetFightResult_ThenReturnCorrectLoses(int[] attackerDice, int[] defenderDice, int attackerLoses, int defenderLoses)
        {
            // Given
            var convertedAttackerDice = attackerDice.Select(i => new Dice(i)).ToList();
            var convertedDefenderDice = defenderDice.Select(i => new Dice(i)).ToList();

            // When
            var fight = new Fight(convertedAttackerDice, convertedDefenderDice);
            var fightResult = fight.GetFightResult();

            // Then
            Assert.Equal(attackerLoses, fightResult.AttackerLoses);
            Assert.Equal(defenderLoses, fightResult.DefenderLoses);
        }

        [Theory]
        [InlineData(new int[] { 5, 4, 1 }, new int[] { 3 }, 0, 1)]
        [InlineData(new int[] { 5, 4, 1 }, new int[] { 4 }, 0, 1)]
        [InlineData(new int[] { 4, 5, 2 }, new int[] { 4 }, 0, 1)]
        [InlineData(new int[] { 5, 4, 1 }, new int[] { 5 }, 1, 0)]
        [InlineData(new int[] { 5, 4, 1 }, new int[] { 6 }, 1, 0)]
        [InlineData(new int[] { 4, 5, 2 }, new int[] { 6 }, 1, 0)]
        public void Given3AttackerDiceAnd1DefenderDice_WhenGetFightResult_ThenReturnCorrectLoses(int[] attackerDice, int[] defenderDice, int attackerLoses, int defenderLoses)
        {
            // Given
            var convertedAttackerDice = attackerDice.Select(i => new Dice(i)).ToList();
            var convertedDefenderDice = defenderDice.Select(i => new Dice(i)).ToList();

            // When
            var fight = new Fight(convertedAttackerDice, convertedDefenderDice);
            var fightResult = fight.GetFightResult();

            // Then
            Assert.Equal(attackerLoses, fightResult.AttackerLoses);
            Assert.Equal(defenderLoses, fightResult.DefenderLoses);
        }

        [Theory]
        [InlineData(new int[] { 5, 4, 1 }, new int[] { 3, 2 }, 0, 2)]
        [InlineData(new int[] { 5, 4, 1 }, new int[] { 3, 4 }, 0, 2)]
        [InlineData(new int[] { 6, 2, 1 }, new int[] { 5, 2 }, 1, 1)]
        [InlineData(new int[] { 1, 2, 3 }, new int[] { 4, 1 }, 1, 1)]
        [InlineData(new int[] { 1, 2, 3 }, new int[] { 3, 2 }, 2, 0)]
        [InlineData(new int[] { 2, 3, 5 }, new int[] { 5, 3 }, 2, 0)]
        public void Given3AttackerDiceAnd2DefenderDice_WhenGetFightResult_ThenReturnCorrectLoses(int[] attackerDice, int[] defenderDice, int attackerLoses, int defenderLoses)
        {
            // Given
            var convertedAttackerDice = attackerDice.Select(i => new Dice(i)).ToList();
            var convertedDefenderDice = defenderDice.Select(i => new Dice(i)).ToList();

            // When
            var fight = new Fight(convertedAttackerDice, convertedDefenderDice);
            var fightResult = fight.GetFightResult();

            // Then
            Assert.Equal(attackerLoses, fightResult.AttackerLoses);
            Assert.Equal(defenderLoses, fightResult.DefenderLoses);
        }
    }
}
