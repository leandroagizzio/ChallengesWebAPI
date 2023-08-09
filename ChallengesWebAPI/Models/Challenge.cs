using ChallengesWebAPI.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ChallengesWebAPI.Models
{
    public class Challenge : IChallenge
    {
        [Key()]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public virtual IList<Execution>? Executions { get; set; }
    }
}
