using ChallengesWebAPI.Challenges.Challenges.EqualRowColumnPairs;
using ChallengesWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengesTest.Challenges
{
    [TestClass]
    public class EqualRowColumnPairsTest
    {
        [TestMethod]
        public void Example1_ShouldReturn_1() {
            //Arrange            
            var solution = GetInstanceWithInput(new int[][] {
                    new int[] { 3, 2, 1 },
                    new int[] { 1, 7, 6 },
                    new int[] { 2, 7, 7 }
            });

            //Act
            var isValid = solution.Validate();
            var result = solution.Execute();

            //Assert
            Assert.IsTrue(isValid);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Example2_ShouldReturn_3() {
            //Arrange            
            var solution = GetInstanceWithInput(new int[][] {
                    new int[] { 3,1,2,2 },
                    new int[] { 1,4,4,5 },
                    new int[] { 2,4,2,2 },
                    new int[] { 2,4,2,2 }
            });

            //Act
            var isValid = solution.Validate();
            var result = solution.Execute();

            //Assert
            Assert.IsTrue(isValid);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void NotNxN_Grid_ShouldReturn_False() {
            //Arrange            
            var solution = GetInstanceWithInput(new int[][] {
                    new int[] { 3,1,2,2 },
                    new int[] { 1,4,4,5 },
                    new int[] { 2,4,2 },
                    new int[] { 2,4,2,2 }
            });

            //Act
            var isValid = solution.Validate();

            //Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Small_Grid_ShouldReturn_False() {
            //Arrange            
            var solution = GetInstanceWithInput(new int[][] {
                    new int[] { 3 }
            });

            //Act
            var isValid = solution.Validate();

            //Assert
            Assert.IsFalse(isValid);
        }

        private ISolution<int> GetInstanceWithInput(int[][] grid) {
            var input = new EqualRowColumnPairsInput();
            input.Grid = grid;
            return new EqualRowColumnPairsChallenge(input);
        }
    }
}
