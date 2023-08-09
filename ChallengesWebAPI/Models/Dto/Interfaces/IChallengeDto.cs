using ChallengesWebAPI.Models.Interfaces;

namespace ChallengesWebAPI.Models.Dto.Interfaces
{
    public interface IChallengeDto : IChallengeBase
    {
        IList<IExecutionDto> Executions { get; set; }
    }
}
