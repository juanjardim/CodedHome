﻿using CodedHome.Model;
using System.Data.Entity.ModelConfiguration;

namespace CodeHome.Data.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            this.Property(p => p.Id).HasColumnOrder(0);

            this.Property(p => p.Username)
                .IsRequired().HasMaxLength(200);

            this.Property(p => p.FirstName)
                .IsOptional().HasMaxLength(100);

            this.Property(p => p.LastName)
                .IsOptional().HasMaxLength(100);
        }
    }
}
