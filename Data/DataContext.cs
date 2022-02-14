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

        public DbSet<Skill> skills { get; set; }

        public DbSet<CharacterSkill> characterskills { get; set; }

        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<CharacterSkill>().HasKey(cs => new {cs.CharacterFK, cs.SkillFK});
           // builder.Entity<CharacterSkill>().HasOne(cs => cs.Character).WithMany(c => c.)
        }

        /*public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }*/
    }
}