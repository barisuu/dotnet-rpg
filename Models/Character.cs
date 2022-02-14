using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dotnet_rpg.Models
{
    public class Character
    {
        [Key]
        public int charId { get; set; }
        public string charName { get; set; } = "Frodo";
        public int charHitPoints { get; set; } = 100;
        public int charStrength { get; set; } = 10;
        public int charDefense { get; set; } = 10;
        public int charIntelligence { get; set; } = 10;
        public RpgClass charClass { get; set; } = RpgClass.Knight;
        public User User{get; set;}
        public Weapon Weapon { get; set; }
        public List<CharacterSkill> CharacterSkills {get; set;}
    }
}