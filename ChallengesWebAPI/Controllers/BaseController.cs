using ChallengesWebAPI.Helper;
using ChallengesWebAPI.Interfaces;
using ChallengesWebAPI.Models.Dto.Interfaces;
using ChallengesWebAPI.Models.Interfaces;
using ChallengesWebAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChallengesWebAPI.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly IChallengeRepository _challengeRepository;
        private readonly IExecutionRepository _executionRepository;
        private readonly IRegistrationRepository _registrationRepository;

        public BaseController(
            IChallengeRepository challengeRepository,
            IExecutionRepository executionRepository,
            IRegistrationRepository registrationRepository) {
            _challengeRepository = challengeRepository;
            _executionRepository = executionRepository;
            _registrationRepository = registrationRepository;
        }

        protected IActionResult ProcessChallenge<T>(ISolution<T> solution, object input) {
            var isExecuted = false;

            var challengeId = _registrationRepository.RegisterChallenge(solution);

            try {

                if (input == null || !ModelState.IsValid) {
                    return BadRequest(ModelState);
                }

                if (!solution.Validate()) {
                    foreach (var error in solution.GetErrors()) {
                        ModelState.AddModelError(string.Empty, error);
                    }
                    return BadRequest(ModelState);
                }

                var ret = solution.Execute();
                isExecuted = true;
                return Ok(ret);

            } finally {
                _registrationRepository.RegisterExecution(
                    input: input == null ? "null" : solution.GetInputToString(),
                    output: isExecuted ? solution.GetOutputToString() : GetModelStateErrorMessages(),
                    isSuccessful: isExecuted,
                    challengeId: challengeId
                );
            }
        }

        private string GetModelStateErrorMessages() {
            var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);
            return string.Join(",", errors);
        }

        //private void SimulateDatabaseEntry(string challengeName, string input, string output, string link) {
        //    Console.WriteLine($"\nchallenge:({challengeName}) input:({input}), output:({output}), link:({link})");
        //}

        private IChallengeDto GetChallengeDto(IChallenge challenge) {
            return HelperFactory.GetChallengeDto().CopyToMe(challenge);
        }

        private IExecutionDto GetExecutionDto(IExecution execution) {
            return HelperFactory.GetExecutionDto().CopyToMe(execution);
        }

        protected IList<IChallengeBase> GetAllChallenges() {
            return _challengeRepository.GetAll()
                .Select(c => GetChallengeDto(c))
                .Cast<IChallengeBase>() // so it wont have the list
                .OrderBy(c => c.Name)
                .ToList();
        }

        protected IActionResult GetChallengeExecutions(IGetChallengeName challengeName) {
            var challenge = _challengeRepository.GetPerName(challengeName.ChallengeName);
            if (challenge == null)
                return NotFound();

            var challengeDto = GetChallengeDto(challenge);

            var executions = _executionRepository.GetExecutionsPerChallengeId(challenge.Id);

            if (executions != null)
                challengeDto.Executions = executions.Select(e => GetExecutionDto(e)).OrderByDescending(e => e.Time).ToList();

            return Ok(challengeDto);
        }
        //protected IActionResult GetChallengeExecutions(string challengeName) {
        //    var challenge = _challengeRepository.GetPerName(challengeName);
        //    if (challenge == null)
        //        return NotFound();

        //    var challengeDto = GetChallengeDto(challenge);

        //    var executions = _executionRepository.GetExecutionsPerChallengeId(challenge.Id);

        //    if (executions == null)
        //        return Ok(challengeDto);

        //    //.Cast<ExecutionDto>()
        //    //var abc = executions.Select(e => GetExecutionDto(e)).OrderByDescending(e => e.Time).ToList();

        //    challengeDto.Executions = executions.Select(e => GetExecutionDto(e)).OrderByDescending(e => e.Time).ToList();

        //    //challengeDto.Executions = new List<IExecutionDto>();

        //    //_ = executions.Select(e => challengeDto.Executions.Add(GetExecutionDto(e)));

        //    //abc.ForEach(e => challengeDto.Executions.Add(e));

        //    //challengeDto.Executions.Add(GetExecutionDto(executions[0]));

        //    return Ok(challengeDto);
        //}

    }
}
