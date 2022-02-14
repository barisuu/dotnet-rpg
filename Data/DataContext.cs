using dotnet_rpg.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_rpg.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){

        }

        public DbSet<Character> characters {get; set;}

        public DbSet<User> users {get; set;}
        
        public DbSet<Weapon> weapons {get; set;}

        /*protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }*/
    }
}