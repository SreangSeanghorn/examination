using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.Domain.Entities;
using OnlineExam.Domain.Values;

namespace OnlineExam.Infrastructure.Persistence.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Username).IsRequired();
            builder.Property(e => e.Password).IsRequired();

            builder.OwnsOne(e => e.Email, email =>
                {
                    email.Property(e => e.Value)
                         .IsRequired()
                            .HasColumnName("Email");
            });
            builder.HasMany(e => e.Roles)
                      .WithMany(e => e.Users)
                        .UsingEntity<Dictionary<string, object>>(
                          "UserRole",
                          j => j.HasOne<Role>()
                                .WithMany()
                                .HasForeignKey("RoleId"),
                          j => j.HasOne<User>()
                                .WithMany()
                                .HasForeignKey("UserId"),
                          j =>
                          {
                              j.HasKey("UserId", "RoleId");
                          });
                
            var userId1 = Guid.NewGuid();
            var userId2 = Guid.NewGuid();
            builder.HasData(
                new User
                {
                    Id = userId1,
                    Username = "admin",
                    Password = new PasswordHasher<User>().HashPassword(null, "123")
                });

            builder.OwnsOne(e => e.Email, email =>
            {
                email.HasData(
                    new { UserId = userId1, Value = "seanghorn@gmail.com" }
                    );
            });

            
        }
    }
}