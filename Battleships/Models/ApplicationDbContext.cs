using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleships.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        
        public DbSet<Game> Games { get; set; }
        public DbSet<UserGame> UserGames { get; set; }       
        public DbSet<NavyBattlePiece> NavyBattlePieces { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserGame>()
            .HasOne(ug => ug.User)
            .WithMany(u => u.Games)
            .HasForeignKey(ug => ug.UserId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserGame>()
            .HasOne(ug => ug.Game)
            .WithMany(g => g.UserGames)
            .HasForeignKey(ug => ug.GameId)
            .OnDelete(DeleteBehavior.NoAction);



            modelBuilder.Entity<Game>()
                .HasMany(g => g.UserGames).WithOne(x => x.Game);






            modelBuilder.Entity<NavyBattlePiece>().HasIndex(x => new { x.PosX, x.PosY });
        }
    }
}
