using ChallengesWebAPI.Models.Dto.Interfaces;

namespace ChallengesWebAPI.Models.Dto
{
    public class ExecutionDto : IExecutionDto
    {
        public string Input { get; set; }
        public string Output { get; set; }
        public bool IsSuccessful { get; set; }
        public DateTime Time { get; set; }
    }
}
