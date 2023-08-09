using System;

namespace ChallengesWebAPI.Models.Interfaces
{
    public interface IChallenge : IModelId, IChallengeBase
    {
        IList<Execution>? Executions { get; set; }
    }
}
