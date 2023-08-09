namespace ChallengesWebAPI.Models.Interfaces
{
    public interface IExecution : IModelId, IExecutionBase
    {
        int ChallengeId { get; set; }
        Challenge? Challenge { get; set; }
    }
}
