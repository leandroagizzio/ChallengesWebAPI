using ChallengesWebAPI.Models.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChallengesWebAPI.Models
{
    public class Execution : IExecution
    {
        [Key()]
        public int Id { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }
        public bool IsSuccessful { get; set; }
        public DateTime Time { get; set; }
        [ForeignKey(nameof(Challenge))]
        public int ChallengeId { get; set; }
        public virtual Challenge? Challenge { get; set; }
    }
}
