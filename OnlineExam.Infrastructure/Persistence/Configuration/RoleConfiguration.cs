using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.Domain.Entities;

namespace OnlineExam.Infrastructure.Persistence.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).IsRequired();
            
            builder.HasData(
                new Role
                {
                    Id = Guid.NewGuid(),
                    Name = "Admin",
                    Description = "Admin Role"
                },
                new Role
                {
                    Id = Guid.NewGuid(),
                    Name = "User",
                    Description = "User Role"
                }
                ,
                new Role
                {
                    Id = Guid.NewGuid(),
                    Name = "Teacher",
                    Description = "Teacher Role"
                },
                new Role
                {
                    Id = Guid.NewGuid(),
                    Name = "Student",
                    Description = "Student Role"
                },
                new Role
                {
                    Id = Guid.NewGuid(),
                    Name = "Default",
                    Description = "Default Role"
                }

            );
        }
    }
}