using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using USM_Model;
using Microsoft.EntityFrameworkCore.Design;

namespace USM_EF_Helper
{
    public class EFDBContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Field>().ToTable("Fields")
                .HasDiscriminator<int>("SportType")
                .HasValue<TennisField>((int)SportType.Tennis)
                .HasValue<PaddleField>((int)SportType.Paddle)
                .HasValue<SoccerField>((int)SportType.Soccer);
            
        }

    }

    public class EFContextFactory : IDesignTimeDbContextFactory<EFDBContext>
    {
        public EFDBContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<EFDBContext>();
            optionBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=USMDataBase;Integrated Security=True; MultipleActiveResultSets=true");
            return new EFDBContext(optionBuilder.Options);
        }
    }


}
