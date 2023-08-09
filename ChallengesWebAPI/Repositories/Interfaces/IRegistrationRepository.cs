using ChallengesWebAPI.Interfaces;

namespace ChallengesWebAPI.Repositories.Interfaces
{
    public interface IRegistrationRepository
    {
        int RegisterChallenge(IRegisterChallenge registerChallenge);
        bool RegisterExecution(string input, string output, bool isSuccessful, int challengeId);
    }
}
