using RiskGame.Domain;
using System;

namespace RiskGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var trialCount = 10000;
            var initialAttackerArmy = 7;
            var initialDefenderArmy = 5;

            var successCount = 0;
            var failureCount = 0;
            
            for (int i = 0; i < trialCount; i++)
            {
                var attackingPlayer = new Player(initialAttackerArmy);
                var defendingPlayer = new Player(initialDefenderArmy);

                var conquest = new ConquestAction(attackingPlayer, defendingPlayer);
                var conquestSuccessfull = conquest.ConquestSuccessful();
                if (conquestSuccessfull)
                    successCount++;
                else
                    failureCount++;
            }

            Console.WriteLine($"Initial attacker: {initialAttackerArmy}. Initial defender: {initialDefenderArmy}. Trials: {trialCount}");
            Console.WriteLine($"Success {successCount}");
            Console.WriteLine($"Failure {failureCount}");
        }
    }
}
