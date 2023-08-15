using ChallengesWebAPI.Challenges.Challenges.AddTwoNumbersLinkedList;
using ChallengesWebAPI.Challenges.Challenges.EqualRowColumnPairs;
using ChallengesWebAPI.Challenges.Challenges.SubarrayAverages;
using ChallengesWebAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChallengesWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class ChallengeController : BaseController
    {

        public ChallengeController(
            IChallengeRepository challengeRepository,
            IExecutionRepository executionRepository,
            IRegistrationRepository registrationRepository)
            : base(challengeRepository, executionRepository, registrationRepository) {
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll() {
            return Ok(GetAllChallenges());
        }


        //[HttpGet("GetChallenge")]
        //public IActionResult GetChall([FromQuery] string challengeName) {
        //    return GetChallengeExecutions(challengeName);
        //}

        //TODO
        //httpGet GetAll(challengeName)



        /*
         
        [HttpPost("challenges")]
        public IActionResult InsertChallenge([FromQuery] string name, [FromQuery] string link) {
            var challenge = _challengeRepository.GetPerName(name);
            if (challenge == null) {
                return Ok(_challengeRepository.Create(name, link));
            }
            return Ok(challenge);
        }

        [HttpGet("challenges")]
        public IActionResult GetAllChallenges() {
            return Ok(_challengeRepository.GetAll());
        }

        [HttpGet("challenges/{challengeId}")]
        public IActionResult GetChallenge(int challengeId) {
            var challenge = _challengeRepository.GetPerId(challengeId);
            if (challenge == null)
                return NotFound();
            return Ok(challenge);
        }

        [HttpGet("challenges/executions/{challengeId}")]
        public IActionResult GetExecutionsFromChallenge(int challengeId) {
            var challenge = _challengeRepository.GetPerId(challengeId);
            if (challenge == null)
                return NotFound();
            return Ok(_executionRepository.GetExecutionsPerChallengeId(challengeId));
        }


        [HttpPost("executions")]
        public IActionResult InsertExecution(
            [FromQuery] string input, [FromQuery] string output, [FromQuery] bool isSuccessful, [FromQuery] int challengeId
            ) {
            var challenge = _challengeRepository.GetPerId(challengeId);
            if (challenge == null)
                return NotFound("Challenge not found");
            return Ok(_executionRepository.Create(input, output, isSuccessful, challenge));
        }

        [HttpGet("executions")]
        public IActionResult GetAllExecutions() {
            return Ok(_executionRepository.GetAll());
        }

        [HttpGet("executions/{executionId}")]
        public IActionResult GetExecutionPerId(int executionId) {
            var execution = _executionRepository.GetPerId(executionId);
            if (execution == null)
                return NotFound();
            return Ok(execution);
        }
        */
    }
}
