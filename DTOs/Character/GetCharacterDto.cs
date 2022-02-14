using System.Collections.Generic;
using dotnet_rpg.DTOs.CharacterSkill;
using dotnet_rpg.DTOs.Weapon;
using dotnet_rpg.Models;

namespace dotnet_rpg.DTOs.Character
{
    public class GetCharacterDto
    {
        public int charId { get; set; }
        public string charName { get; set; } = "Frodo";
        public int charHitPoints { get; set; } = 100;
        public int charStrength { get; set; } = 10;
        public int charDefense { get; set; } = 10;
        public int charIntelligence { get; set; } = 10;
        public RpgClass charClass { get; set; } = RpgClass.Knight;
        public GetWeaponDto Weapon { get; set; }
        public List<GetSkillDto> Skills { get; set; }
    }
}