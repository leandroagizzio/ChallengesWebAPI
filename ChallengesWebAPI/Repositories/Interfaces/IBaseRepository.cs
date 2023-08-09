using ChallengesWebAPI.Models.Interfaces;

namespace ChallengesWebAPI.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class, IModelId
    {
        T? GetPerId(int id);
        IList<T> GetAll();
        T Create(T t);
    }
}
