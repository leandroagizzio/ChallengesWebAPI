using ChallengesWebAPI.Challenges.Challenges.AddTwoNumbersLinkedList;
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
    public class AddTwoNumbersLinkedListTest
    {
        [TestMethod]
        public void Example1_ShouldReturn_807() {

            //Arrange
            // TEST CASE 1 - return 807
            //ListNode l1_3 = new ListNode(3, null);
            //ListNode l1_2 = new ListNode(4, l1_3);
            //ListNode l1   = new ListNode(2, l1_2);
            var l1 = GetListNodeFromArray(new int[] { 2, 4, 3 }, 0);

            //ListNode l2_3 = new ListNode(4, null);
            //ListNode l2_2 = new ListNode(6, l2_3);
            //ListNode l2   = new ListNode(5, l2_2);
            var l2 = GetListNodeFromArray(new int[] { 5, 6, 4 }, 0);

            //ListNode r_3 = new ListNode(8, null);
            //ListNode r_2 = new ListNode(0, r_3);
            //ListNode r   = new ListNode(7, r_2);
            var r = GetListNodeFromArray(new int[] { 7, 0, 8 }, 0);

            var solution = GetSolutionInstance(l1, l2);

            //Act
            var isValid = solution.Validate();
            var result = solution.Execute();

            var stringResult = JsonConvert.SerializeObject(result);
            var stringExpected = JsonConvert.SerializeObject(r);

            //Assert
            Assert.IsTrue(isValid);
            Assert.AreEqual(stringExpected, stringResult);

        }

        [TestMethod]
        public void Example2_ShouldReturn_10009998() {

            //Arrange
            var l1 = GetListNodeFromArray(new int[] { 9, 9, 9, 9, 9, 9, 9 }, 0);

            var l2 = GetListNodeFromArray(new int[] { 9, 9, 9, 9 }, 0);

            var r = GetListNodeFromArray(new int[] { 8, 9, 9, 9, 0, 0, 0, 1 }, 0);

            var solution = GetSolutionInstance(l1, l2);

            //Act
            var isValid = solution.Validate();
            var result = solution.Execute();

            var stringResult = JsonConvert.SerializeObject(result);
            var stringExpected = JsonConvert.SerializeObject(r);

            //Assert
            Assert.IsTrue(isValid);
            Assert.AreEqual(stringExpected, stringResult);

        }

        [TestMethod]
        public void Example3_ShouldReturn_0() {

            //Arrange
            var l1 = GetListNodeFromArray(new int[] { 0 }, 0);

            var l2 = GetListNodeFromArray(new int[] { 0 }, 0);

            var r = GetListNodeFromArray(new int[] { 0 }, 0);

            var solution = GetSolutionInstance(l1, l2);

            //Act
            var isValid = solution.Validate();
            var result = solution.Execute();

            var stringResult = JsonConvert.SerializeObject(result);
            var stringExpected = JsonConvert.SerializeObject(r);

            //Assert
            Assert.IsTrue(isValid);
            Assert.AreEqual(stringExpected, stringResult);

        }

        [TestMethod]
        public void Example4_ShouldReturn_17() {

            //Arrange
            var l1 = GetListNodeFromArray(new int[] { 8 }, 0);

            var l2 = GetListNodeFromArray(new int[] { 9 }, 0);

            var r = GetListNodeFromArray(new int[] { 7, 1 }, 0);

            var solution = GetSolutionInstance(l1, l2);

            //Act
            var isValid = solution.Validate();
            var result = solution.Execute();

            var stringResult = JsonConvert.SerializeObject(result);
            var stringExpected = JsonConvert.SerializeObject(r);

            //Assert
            Assert.IsTrue(isValid);
            Assert.AreEqual(stringExpected, stringResult);

        }

        [TestMethod]
        public void Example5_ShouldReturn_81() {

            //Arrange
            var l1 = GetListNodeFromArray(new int[] { 1, 8 }, 0);

            var l2 = GetListNodeFromArray(new int[] { 0 }, 0);

            var r = GetListNodeFromArray(new int[] { 1, 8 }, 0);

            var solution = GetSolutionInstance(l1, l2);

            //Act
            var isValid = solution.Validate();
            var result = solution.Execute();

            var stringResult = JsonConvert.SerializeObject(result);
            var stringExpected = JsonConvert.SerializeObject(r);

            //Assert
            Assert.IsTrue(isValid);
            Assert.AreEqual(stringExpected, stringResult);

        }

        [TestMethod]
        public void Example6_Over10_False() {

            //Arrange
            var l1 = GetListNodeFromArray(new int[] { 1, 8 }, 0);

            var l2 = GetListNodeFromArray(new int[] { 0, 10 }, 0);

            var solution = GetSolutionInstance(l1, l2);

            //Act
            var isValid = solution.Validate();
            var result = solution.Execute();

            //Assert
            Assert.IsFalse(isValid);

        }

        [TestMethod]
        public void Example7_Over10_False() {

            //Arrange
            var l1 = GetListNodeFromArray(new int[] { 12, 8 }, 0);

            var l2 = GetListNodeFromArray(new int[] { 0, 2 }, 0);

            var solution = GetSolutionInstance(l1, l2);

            //Act
            var isValid = solution.Validate();
            var result = solution.Execute();

            //Assert
            Assert.IsFalse(isValid);

        }

        [TestMethod]
        public void Example7_Under0_False() {

            //Arrange
            var l1 = GetListNodeFromArray(new int[] { 2, 8, -1 }, 0);

            var l2 = GetListNodeFromArray(new int[] { 0, 2 }, 0);

            var solution = GetSolutionInstance(l1, l2);

            //Act
            var isValid = solution.Validate();
            var result = solution.Execute();

            //Assert
            Assert.IsFalse(isValid);

        }

        private ListNode GetListNodeFromArray(int[] numbers, int pointer) {
            if (pointer >= numbers.Length)
                return null;

            return new ListNode(numbers[pointer], GetListNodeFromArray(numbers, ++pointer));
        }

        private ISolution<ListNode> GetSolutionInstance(ListNode l1, ListNode l2) {
            var input = new AddTwoNumbersLinkedListInput { L1 = l1, L2 = l2 };
            return new AddTwoNumbersLinkedListChallenge(input);
        }

    }
}
