namespace ChallengesWebAPI.Interfaces
{
    public interface ISolution<T> : IValidator, IExecutor<T>, IGetInputOutputToString, IRegisterChallenge
    {
    }
}
