using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Problem> Problems { get; set; }

        public DbSet<Submission> Submissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-AMLLGJ5; Database=Suls; Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Submissions)
                .WithOne(s => s.User);

            modelBuilder.Entity<Problem>()
                .HasMany(p => p.Submissions)
                .WithOne(p => p.Problem);
                
        }
    }
}
