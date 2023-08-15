using ChallengesWebAPI.Challenges.Challenges.AddTwoNumbersLinkedList;
using ChallengesWebAPI.Challenges.Challenges.EqualRowColumnPairs;
using ChallengesWebAPI.Challenges.Challenges.SubarrayAverages;
using ChallengesWebAPI.Challenges.Challenges.TextJustification;
using ChallengesWebAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChallengesWebAPI.Controllers.PartialChallenges
{
    public partial class ChallengeController : BaseController
    {
        public ChallengeController(
            IChallengeRepository challengeRepository,
            IExecutionRepository executionRepository,
            IRegistrationRepository registrationRepository)
            : base(challengeRepository, executionRepository, registrationRepository) {
        }

        [HttpPost("EqualRowColumnPairs")]
        public IActionResult EqualRowColumnPairs([FromBody] EqualRowColumnPairsInput input) {
            return base.ProcessChallenge<int>(new EqualRowColumnPairsChallenge(input), input);
        }

        [HttpGet("EqualRowColumnPairs")]
        public IActionResult GetEqualRowColumnPairs() {
            return GetChallengeExecutions(new EqualRowColumnPairsChallenge());
        }

        [HttpPost("AddTwoNumbersLinkedList")]
        public IActionResult AddTwoNumbersLinkedList([FromBody] AddTwoNumbersLinkedListInput input) {
            return ProcessChallenge<ListNode>(new AddTwoNumbersLinkedListChallenge(input), input);
        }

        [HttpGet("AddTwoNumbersLinkedList")]
        public IActionResult GetAddTwoNumbersLinkedList() {
            return GetChallengeExecutions(new AddTwoNumbersLinkedListChallenge());
        }

        [HttpPost("SubarrayAverages")]
        public IActionResult SubarrayAverages([FromBody] SubarrayAveragesInput input) {
            return ProcessChallenge<int[]>(new SubarrayAveragesChallenge(input), input);
        }

        [HttpGet("SubarrayAverages")]
        public IActionResult GetSubarrayAverages() {
            return GetChallengeExecutions(new SubarrayAveragesChallenge());
        }
        
        [HttpPost("TextJustification")]
        public IActionResult TextJustification([FromBody] TextJustificationInput input) {
            return ProcessChallenge<IList<string>>(new TextJustificationChallenge(input), input);
        }

        [HttpGet("TextJustification")]
        public IActionResult GetTextJustification() {
            return GetChallengeExecutions(new TextJustificationChallenge());
        }

    }
}
