namespace ChallengesWebAPI.Models.Interfaces
{
    public interface IExecutionBase
    {
        string Input { get; set; }
        string Output { get; set; }
        bool IsSuccessful { get; set; }
        DateTime Time { get; set; }
    }
}
