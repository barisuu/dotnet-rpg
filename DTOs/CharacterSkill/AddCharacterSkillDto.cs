using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.DTOs.CharacterSkill
{
    public class AddCharacterSkillDto
    {
        public int CharacterFK { get; set; }
        public int SkillFK { get; set; }
    }
}