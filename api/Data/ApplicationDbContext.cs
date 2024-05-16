using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions)
         : base(dbContextOptions)
        {

        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Stay> Stays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define your model configuration here
            modelBuilder.Entity<Pet>()
                .HasOne(p => p.Owner)
                .WithMany(o => o.Pets)
                .HasForeignKey(p => p.OwnerId)
                .OnDelete(DeleteBehavior.Restrict); // Or Cascade depending on your requirements

            modelBuilder.Entity<Stay>()
                .HasOne(s => s.Pet)
                .WithMany(p => p.Stays)
                .HasForeignKey(s => s.PetId)
                .OnDelete(DeleteBehavior.Cascade); // Or another appropriate behavior

            modelBuilder.Entity<Stay>()
                .HasOne(s => s.Room)
                .WithMany(r => r.Stays)
                .HasForeignKey(s => s.RoomId)
                .OnDelete(DeleteBehavior.Cascade); // Or another appropriate behavior

            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, Name = "Pink", Price = 3.4m, Quality = 5, Capacity = 3 },
                new Room { Id = 2, Name = "Green",Price = 2.4m, Quality = 4, Capacity = 2 },
                new Room { Id = 3, Name = "Orange",Price = 2.0m, Quality = 3, Capacity = 4 },
                new Room { Id = 4, Name = "Blue",Price = 5.4m, Quality = 5, Capacity = 3 }
            );
        }
    }
}