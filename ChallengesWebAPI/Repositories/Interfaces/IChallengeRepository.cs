using ChallengesWebAPI.Models;

namespace ChallengesWebAPI.Repositories.Interfaces
{
    //public interface IChallengeRepository<T> : IBaseRepository<T> where T : class, IChallenge
    public interface IChallengeRepository : IBaseRepository<Challenge>
    {
        //T? GetPerName(string name);
        //T Create(string name, string link);
        Challenge? GetPerName(string name);
        Challenge Create(string name, string link);
    }
}
