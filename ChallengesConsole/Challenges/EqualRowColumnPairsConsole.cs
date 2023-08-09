using ChallengesWebAPI.Challenges.Challenges.EqualRowColumnPairs;
using ChallengesWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengesConsole.Challenges
{
    public class EqualRowColumnPairsConsole
    {
        public EqualRowColumnPairsConsole() {
            var example1 = new int[][] {
                    new int[] { 3, 2, 1 },
                    new int[] { 1, 7, 6 },
                    new int[] { 2, 7, 7 }
                };
            var example2 = new int[][] {
                    new int[] { 3,1,2,2 },
                    new int[] { 1,4,4,5 },
                    new int[] { 2,4,2,2 },
                    new int[] { 2,4,2,2 }
                };
            var example3 = new int[][] {
                    new int[] { 3,1,2,2 },
                    new int[] { 1,4,4 },
                    new int[] { 2,4,2,2 },
                    new int[] { 2,4,2,2 }
                };

            var input = new EqualRowColumnPairsInput();
            input.Grid = example3;

            ISolution<int> solution = new EqualRowColumnPairsChallenge(input);

            if (!solution.Validate()) {
                foreach (var error in solution.GetErrors()) {
                    Console.WriteLine($"error: {error}");
                }
            } else {
                Console.WriteLine($"result: {solution.Execute()}");
            }
        }
    }
}
