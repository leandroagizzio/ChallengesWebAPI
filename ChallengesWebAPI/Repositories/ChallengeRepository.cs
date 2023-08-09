using ChallengesWebAPI.Data;
using ChallengesWebAPI.Models;
using ChallengesWebAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ChallengesWebAPI.Repositories
{
    //public class ChallengeRepository : BaseRepository<Challenge>, IChallengeRepository<Challenge>
    public class ChallengeRepository : BaseRepository<Challenge>, IChallengeRepository
    {
        private readonly DbSet<Challenge> _dbSet;

        public ChallengeRepository(AppDbContext appDbContext) : base(appDbContext, appDbContext.Challenges) {
            _dbSet = appDbContext.Challenges;
        }

        public Challenge Create(string name, string link) {
            var challengeCreated = new Challenge() { Name = name, Link = link };
            return Create(challengeCreated);
        }

        public Challenge? GetPerName(string name) {
            return _dbSet.Where(c => c.Name == name).FirstOrDefault();
        }
    }
}
