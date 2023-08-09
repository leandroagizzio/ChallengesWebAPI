namespace ChallengesWebAPI.Interfaces
{
    public interface IValidator : IGetTheErrors
    {
        bool Validate();
    }
}
