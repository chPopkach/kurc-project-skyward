using Microsoft.EntityFrameworkCore;
using Skyward.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyward
{
    public class AppContext : DbContext
    {
        public AppContext()
        {
            Database.EnsureCreated();
        }
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }
        public DbSet<Humen> Humens { get; set; } = null!;
        public DbSet<RoleUser> RoleUsers { get; set; } = null!;
        public DbSet<Schedule> Schedules { get; set; } = null!;
        public DbSet<ScheduleHumen> ScheduleHumens { get; set; } = null!;
        public DbSet<Ticket> Tickets { get; set; } = null!;
        public DbSet<TypeTicket> TypeTickets { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseNpgsql(@"Server=localhost; User Id=postgres; Database=AppContext; Port=5432; Password=123456; SSL Mode=Prefer; Trust Server Certificate=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Humen>()
                .HasOne(m => m.Ticket)
                .WithMany(m => m.Humens)
                .HasForeignKey(m => m.TicketId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ScheduleHumen>()
                .HasOne(m => m.Schedule)
                .WithMany(m => m.ScheduleHumens)
                .HasForeignKey(m => m.ScheduleId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ScheduleHumen>()
                .HasOne(m => m.Humen)
                .WithMany(m => m.ScheduleHumens)
                .HasForeignKey(m => m.HumenId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Ticket>()
                .HasOne(m => m.TypeTicket)
                .WithMany(m => m.Tickets)
                .HasForeignKey(m => m.TypeTicketId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>()
                .HasOne(m => m.RoleUser)
                .WithMany(m => m.Users)
                .HasForeignKey(m => m.RoleUserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>()
                .HasOne(m => m.Humen)
                .WithMany(m => m.Users)
                .HasForeignKey(m => m.HumenId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
