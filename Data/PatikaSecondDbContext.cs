using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstTableRelations.Data
{
    public class PatikaSecondDbContext:DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<PostEntity> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             optionsBuilder.UseSqlServer("Server=MERT_TOPCU\\SQLEXPRESS;Database=PatikaCodeFirstDb2;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostEntity>()
                        .HasOne(p=>p.User)
                        .WithMany(u=>u.Posts)
                        .HasForeignKey(p=>p.UserId);
        }
    }
}