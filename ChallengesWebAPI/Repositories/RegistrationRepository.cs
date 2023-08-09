using ChallengesWebAPI.Interfaces;
using ChallengesWebAPI.Repositories.Interfaces;

namespace ChallengesWebAPI.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly IChallengeRepository _challengeRepository;
        private readonly IExecutionRepository _executionRepository;

        public RegistrationRepository(IChallengeRepository challengeRepository, IExecutionRepository executionRepository) {
            _challengeRepository = challengeRepository;
            _executionRepository = executionRepository;
        }
        public int RegisterChallenge(IRegisterChallenge registerChallenge) {
            var challenge = _challengeRepository.GetPerName(registerChallenge.ChallengeName);
            if (challenge == null) {
                return _challengeRepository.Create(registerChallenge.ChallengeName, registerChallenge.Link).Id;
            }
            return challenge.Id;
        }

        public bool RegisterExecution(string input, string output, bool isSuccessful, int challengeId) {
            var challenge = _challengeRepository.GetPerId(challengeId);
            if (challenge == null)
                return false;
            _executionRepository.Create(input, output, isSuccessful, challenge);
            return true;
        }
    }
}
