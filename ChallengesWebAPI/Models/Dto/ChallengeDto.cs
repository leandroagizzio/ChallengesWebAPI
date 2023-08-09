using ChallengesWebAPI.Models.Dto.Interfaces;

namespace ChallengesWebAPI.Models.Dto
{
    public class ChallengeDto : IChallengeDto
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public IList<IExecutionDto> Executions { get; set; } 
    }
}
