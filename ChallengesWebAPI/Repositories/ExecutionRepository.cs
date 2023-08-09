using ChallengesWebAPI.Data;
using ChallengesWebAPI.Models;
using ChallengesWebAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ChallengesWebAPI.Repositories
{
    public class ExecutionRepository : BaseRepository<Execution>, IExecutionRepository
    {
        private readonly DbSet<Execution> _dbSet;

        public ExecutionRepository(AppDbContext appDbContext) : base(appDbContext, appDbContext.Executions) {
            _dbSet = appDbContext.Executions;
        }

        public Execution Create(string input, string output, bool isSuccessful, Challenge challenge) {
            var executionCreated = new Execution() {
                Input = input, Output = output, IsSuccessful = isSuccessful,
                Challenge = challenge, Time = DateTime.Now
            };
            return Create(executionCreated);
        }

        public IList<Execution> GetExecutionsPerChallengeId(int challengeId) {
            return _dbSet.Where(e => e.ChallengeId == challengeId).ToList();
        }
    }
}
