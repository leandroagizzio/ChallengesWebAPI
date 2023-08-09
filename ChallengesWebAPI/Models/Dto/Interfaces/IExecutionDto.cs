using ChallengesWebAPI.Models.Interfaces;

namespace ChallengesWebAPI.Models.Dto.Interfaces
{
    public interface IExecutionDto : IExecutionBase
    {
       public string Input { get; set; }
       public string Output { get; set; }
       public bool IsSuccessful { get; set; }
       public DateTime Time { get; set; }
    }
}
