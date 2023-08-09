using ChallengesWebAPI.Challenges.Challenges.SubarrayAverages;
using ChallengesWebAPI.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengesTest.Challenges
{
    [TestClass]
    public class SubarrayAveragesTest
    {

        [TestMethod]
        public void Example1_ShouldMatchReturn() {
            Examples_Returnables(
                new int[] { 7, 4, 3, 9, 1, 8, 5, 2, 6 },
                3,
                new int[] { -1, -1, -1, 5, 4, 4, -1, -1, -1 }
            );
        }

        [TestMethod]
        public void Example2_ShouldMatchReturn() {
            Examples_Returnables(new int[] { 100000 }, 0, new int[] { 100000 });
        }

        [TestMethod]
        public void Example3_ShouldMatchReturn() {
            Examples_Returnables(new int[] { 8 }, 100000, new int[] { -1 });
        }

        [TestMethod]
        public void Example4_kIsNegative_False() {
            //Arrange    
            var solution = GetInstanceWithInput(new int[] { 8 }, -1);

            //Act
            var isValid = solution.Validate();

            //Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Example5_kIsBigger_False() {
            //Arrange    
            var solution = GetInstanceWithInput(new int[] { 8 }, 100_001);

            //Act
            var isValid = solution.Validate();

            //Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Example6_numsSizeNotInRange_False() {
            //Arrange    
            var solution = GetInstanceWithInput(new int[] { }, 1);

            //Act
            var isValid = solution.Validate();

            //Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Example7_ValuesNotInRange_False() {
            //Arrange    
            var solution = GetInstanceWithInput(new int[] { 7, 4, 3, 200_001, 1 }, 1);

            //Act
            var isValid = solution.Validate();

            //Assert
            Assert.IsFalse(isValid);
        }

        private void Examples_Returnables(int[] nums, int k, int[] resultToValidate) {
            //Arrange    
            var solution = GetInstanceWithInput(nums, k);

            //Act
            var isValid = solution.Validate();
            var result = solution.Execute();

            var stringResult = JsonConvert.SerializeObject(result);
            var stringExpected = JsonConvert.SerializeObject(resultToValidate);

            //Assert
            Assert.IsTrue(isValid);
            Assert.AreEqual(stringExpected, stringResult);
        }

        private ISolution<int[]> GetInstanceWithInput(int[] nums, int k) {
            var input = new SubarrayAveragesInput() { nums = nums, k = k };
            return new SubarrayAveragesChallenge(input);
        }
    }
}
