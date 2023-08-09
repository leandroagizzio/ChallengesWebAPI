using ChallengesWebAPI.Challenges.Challenges.SubarrayAverages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengesConsole.Challenges
{
    public class SubarrayAveragesConsole
    {
        public SubarrayAveragesConsole() {
            var subArray = new SubarrayAverages();

            //test 1            
            var result = subArray.GetAverages(new int[] { 7, 4, 3, 9, 1, 8, 5, 2, 6 }, 3);

            Console.WriteLine($"result 1: {string.Join(",", result)}");

            result = subArray.GetAverages(new int[] { 100000 }, 0);
            Console.WriteLine($"result 2: {string.Join(",", result)}");

            result = subArray.GetAverages(new int[] { 8 }, 100000);
            Console.WriteLine($"result 3: {string.Join(",", result)}");

        }

    }
}
