using dotnet_rpg.Models;

namespace dotnet_rpg.DTOs.Character
{
    public class AddCharacterDto
    {
        public string charName { get; set; } = "Frodo";
        public int charHitPoints { get; set; } = 100;
        public int charStrength { get; set; } = 10;
        public int charDefense { get; set; } = 10;
        public int charIntelligence { get; set; } = 10;
        public RpgClass charClass { get; set; } = RpgClass.Knight;
    }
}