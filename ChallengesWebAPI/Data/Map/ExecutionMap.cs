using ChallengesWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ChallengesWebAPI.Data.Map
{
    public class ExecutionMap : IEntityTypeConfiguration<Execution>
    {
        public void Configure(EntityTypeBuilder<Execution> builder) {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Challenge);
        }
    }
}
