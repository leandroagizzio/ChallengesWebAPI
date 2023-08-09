using ChallengesWebAPI.Data.Map;
using System.Collections.Generic;
using System.Reflection.Emit;
using System;
using Microsoft.EntityFrameworkCore;
using ChallengesWebAPI.Models;

namespace ChallengesWebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
        }

        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<Execution> Executions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new ExecutionMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
