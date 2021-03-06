﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vita.Api.Domain.Aggregates.Goals;

namespace Vita.Api.Persistance.Sql.Aggregates.Goals
{
    public class GoalStatusConfiguration : IEntityTypeConfiguration<GoalStatus>
    {
        public void Configure(EntityTypeBuilder<GoalStatus> builder)
        {
            builder.ToTable("GoalStatus");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                   .ValueGeneratedNever()
                   .IsRequired();

            builder.Property(o => o.Name)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.HasData(GoalStatus.GetAllValues());
        }
    }
}
