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
        public DbSet<MembersChallenges> MembersChallenges { get; set; }

        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Field>().ToTable("Fields")
                .HasDiscriminator<int>("SportType")
                .HasValue<TennisField>((int)SportType.Tennis)
                .HasValue<PaddleField>((int)SportType.Paddle)
                .HasValue<SoccerField>((int)SportType.Soccer);

            modelBuilder.Entity<MembersChallenges>()
                .HasKey(mc => new { mc.MemberId, mc.ChallengeId });

            modelBuilder.Entity<MembersChallenges>()
                .HasOne(mc => mc.Member)
                .WithMany(m => m.MembersChallenges)
                .HasForeignKey(mc => mc.MemberId);
                

            modelBuilder.Entity<MembersChallenges>()
                .HasOne(mc => mc.Challenge)
                .WithMany(c => c.MembersChallenges)
                .HasForeignKey(mc => mc.ChallengeId);
                
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Field)
                .WithMany(f => f.Reservations)
                .IsRequired();

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Member) //Reservations ha un Member
                .WithMany(m => m.Reservations) //e un Member ha molte Reservations
                .IsRequired();//OnDelete(DeleteBehavior.Restrict);


            //modelBuilder.Entity<Reservation>()
            //    .HasOne(r => r.Challenge) //ha una relazione uno a unocon challenge
            //    .WithOne(c => c.Reservation) //e challenge ha una relazione uno a uno con Reservations
            //    .HasForeignKey<Reservation>(r => r.ChallengeId);

            modelBuilder.Entity<Challenge>()
                .HasOne(c => c.Reservation)
                .WithOne(r => r.Challenge)
                .HasForeignKey<Challenge>(c => c.ReservationId)
                .IsRequired().OnDelete(DeleteBehavior.ClientSetNull);

        }

    }

    public class EFContextFactory : IDesignTimeDbContextFactory<EFDBContext>
    {
        public EFDBContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<EFDBContext>();
            optionBuilder.UseSqlServer(@"Data Source=LAPTOP-2N0J4TUT;Initial Catalog=USMDataBase;Integrated Security=True; MultipleActiveResultSets=true");
            return new EFDBContext(optionBuilder.Options);
        }
    }


}
