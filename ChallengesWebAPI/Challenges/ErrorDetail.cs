using ChallengesWebAPI.Interfaces;

namespace ChallengesWebAPI.Challenges
{
    public class ErrorDetail : IErrorDetail
    {
        public string Message { get; set; }
        public bool IsValid { get; set; }
    }
}
