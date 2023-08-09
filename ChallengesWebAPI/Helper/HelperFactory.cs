using ChallengesWebAPI.Challenges;
using ChallengesWebAPI.Interfaces;
using ChallengesWebAPI.Models.Dto;
using ChallengesWebAPI.Models.Dto.Interfaces;

namespace ChallengesWebAPI.Helper
{
    public static class HelperFactory
    {
        public static IList<string> GetStringListInstance() => new List<string>();
        public static IList<IErrorDetail> GetErrorDetailListInstance() => new List<IErrorDetail>();
        public static IErrorDetail GetErrorDetailInstance() => new ErrorDetail();

        public static IChallengeDto GetChallengeDto() => new ChallengeDto();
        public static IExecutionDto GetExecutionDto() => new ExecutionDto();
    }
}
