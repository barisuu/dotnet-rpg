using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_rpg.Models
{
    public class Character
    {
        [Key]
        [Column("Id")]
        public int charId { get; set; }
        [Column("Name")]
        public string charName { get; set; } = "Frodo";
        [Column("Hitpoints")]
        public int charHitPoints { get; set; } = 100;
        [Column("Strength")]
        public int charStrength { get; set; } = 10;
        [Column("Defense")]
        public int charDefense { get; set; } = 10;
        [Column("Intelligence")]
        public int charIntelligence { get; set; } = 10;
        [Column("Class")]
        public RpgClass charClass { get; set; } = RpgClass.Knight;
        public User User{get; set;}
        public Weapon Weapon { get; set; }
        public List<CharacterSkill> CharacterSkills {get; set;}
    }
}