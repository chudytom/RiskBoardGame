using RiskGame.Domain;
using RiskGame.Domain.Enums;
using System;
using Xunit;

namespace RiskGameTests
{
    public class DiceContestTests
    {
        [Theory]
        [InlineData(1, 1, DiceContestResult.DefenderWins)]
        [InlineData(2, 2, DiceContestResult.DefenderWins)]
        [InlineData(3, 3, DiceContestResult.DefenderWins)]
        [InlineData(4, 4, DiceContestResult.DefenderWins)]
        [InlineData(5, 5, DiceContestResult.DefenderWins)]
        [InlineData(6, 6, DiceContestResult.DefenderWins)]
        public void Given2DiceWithEqualNumbers_WhenGetDiceContestResult_ThenDefenderWins(int attackerDiceNumber, int defenderDiceNumber, DiceContestResult expectedDiceContestResult)
        {
            var contest = new DiceContest(new Dice(attackerDiceNumber), new Dice(defenderDiceNumber));

            var result = contest.GetDiceContestResult();

            Assert.Equal(expectedDiceContestResult, result);
        }

        [Theory]
        [InlineData(2, 1, DiceContestResult.AttackerWins)]
        [InlineData(3, 2, DiceContestResult.AttackerWins)]
        [InlineData(4, 3, DiceContestResult.AttackerWins)]
        [InlineData(5, 4, DiceContestResult.AttackerWins)]
        [InlineData(6, 5, DiceContestResult.AttackerWins)]
        [InlineData(6, 1, DiceContestResult.AttackerWins)]
        public void Given2DiceWithHigherAttackerNumber_WhenGetDiceContestResult_ThenAttackerWins(int attackerDiceNumber, int defenderDiceNumber, DiceContestResult expectedDiceContestResult)
        {
            var contest = new DiceContest(new Dice(attackerDiceNumber), new Dice(defenderDiceNumber));

            var result = contest.GetDiceContestResult();

            Assert.Equal(expectedDiceContestResult, result);
        }

        [Theory]
        [InlineData(1, 2, DiceContestResult.DefenderWins)]
        [InlineData(2, 3, DiceContestResult.DefenderWins)]
        [InlineData(3, 4, DiceContestResult.DefenderWins)]
        [InlineData(4, 5, DiceContestResult.DefenderWins)]
        [InlineData(5, 6, DiceContestResult.DefenderWins)]
        [InlineData(1, 6, DiceContestResult.DefenderWins)]
        public void Given2DiceWithHigherDefenderNumber_WhenGetDiceContestResult_ThenDefenderWins(int attackerDiceNumber, int defenderDiceNumber, DiceContestResult expectedDiceContestResult)
        {
            var contest = new DiceContest(new Dice(attackerDiceNumber), new Dice(defenderDiceNumber));

            var result = contest.GetDiceContestResult();

            Assert.Equal(expectedDiceContestResult, result);
        }
    }
}
