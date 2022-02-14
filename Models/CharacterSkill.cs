using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Models
{
    public class CharacterSkill
    {
        [ForeignKey("Character")]
        public int CharacterFK { get; set; }
        [Key]
        public Character Character { get; set; }
        [ForeignKey("Skill")]
        public int SkillFK { get; set; }
        [Key]
        public Skill Skill { get; set; }
    }
}