using ChallengesWebAPI.Challenges.Challenges.TextJustification;
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
    public class TextJustificationTest
    {
        [TestMethod]
        public void Example1_MaxWidthNotInRange_False() {
            //Arrange    
            var solution = GetInstanceWithInput(new string[] { "this", "is", "a", "test" }, 101);

            //Act
            var isValid = solution.Validate();

            //Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Example2_WordBiggerThanMaxWidth_False() {
            //Arrange    
            var solution = GetInstanceWithInput(new string[] { "this", "is", "thisWordIsBiggerThanMaxWidth", "test" }, 5);

            //Act
            var isValid = solution.Validate();

            //Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Example3_ShouldMatchReturn() {
            Examples_Returnables(
                new string[] { "This", "is", "an", "example", "of", "text", "justification." }, 
                16,
                new List<string> {"This    is    an", "example  of text", "justification.  "}
            );
        }

        [TestMethod]
        public void Example4_ShouldMatchReturn() {
            Examples_Returnables(
                new string[] { "What", "must", "be", "acknowledgment", "shall", "be" }, 
                16,
                new List<string> {"What   must   be", "acknowledgment  ", "shall be        "}
            );
        }

        [TestMethod]
        public void Example5_ShouldMatchReturn() {
            Examples_Returnables(
                new string[] { "Science", "is", "what", "we", "understand", "well", "enough", "to", 
                    "explain", "to", "a", "computer.", "Art", "is", "everything", "else", "we", "do" }, 
                20,
                new List<string> {"Science  is  what we", "understand      well", "enough to explain to",
                        "a  computer.  Art is", "everything  else  we", "do                  "}
            );
        }

        private void Examples_Returnables(string[] words, int maxWidth, IList<string> resultToValidate) {
            //Arrange    
            var solution = GetInstanceWithInput(words, maxWidth);

            //Act
            var isValid = solution.Validate();
            var result = solution.Execute();

            var stringResult = JsonConvert.SerializeObject(result);
            var stringExpected = JsonConvert.SerializeObject(resultToValidate);

            //Assert
            Assert.IsTrue(isValid);
            Assert.AreEqual(stringExpected, stringResult);
        }
        private ISolution<IList<string>> GetInstanceWithInput(string[] words, int maxWidth) {
            var input = new TextJustificationInput { words = words, maxWidth = maxWidth };
            return new TextJustificationChallenge(input);
        }
    }
}
