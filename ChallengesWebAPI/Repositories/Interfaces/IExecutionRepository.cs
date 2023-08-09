using ChallengesWebAPI.Models;

namespace ChallengesWebAPI.Repositories.Interfaces
{
    public interface IExecutionRepository : IBaseRepository<Execution>// where T : class, IExecution
    {
        IList<Execution> GetExecutionsPerChallengeId(int challengeId);
        Execution Create(string input, string output, bool isSuccessful, Challenge challenge);
    }
}
