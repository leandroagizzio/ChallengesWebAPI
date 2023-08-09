namespace ChallengesWebAPI.Interfaces
{
    public interface IErrorDetail
    {
        string Message { get; set; }
        bool IsValid { get; set; }
    }
}
