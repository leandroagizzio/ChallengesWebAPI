using ChallengesWebAPI.Models.Interfaces;
using ChallengesWebAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ChallengesWebAPI.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IModelId
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(DbContext dbContext, DbSet<T> dbSet) {
            _dbContext = dbContext;
            _dbSet = dbSet;
        }

        public T Create(T t) {
            _dbContext.Add(t);
            _dbContext.SaveChanges();
            return t;
        }

        public IList<T> GetAll() {
            return _dbSet.ToList();
        }

        public T? GetPerId(int id) {
            return _dbSet.Where(t => t.Id == id).FirstOrDefault();
        }
    }
}
