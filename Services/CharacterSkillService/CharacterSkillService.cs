using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rpg.Data;
using dotnet_rpg.DTOs.Character;
using dotnet_rpg.DTOs.CharacterSkill;
using dotnet_rpg.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace dotnet_rpg.Services.CharacterSkillService
{
    public class CharacterSkillService : ICharacterSkillService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        public CharacterSkillService(DataContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper){
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _context = context;

        }

        public async Task<ServiceResponse<GetCharacterDto>> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            try{
                Character character = await _context.characters.Include(c => c.Weapon).Include(c => c.CharacterSkills).ThenInclude(cs => cs.Skill).FirstOrDefaultAsync(c => c.charId == newCharacterSkill.CharacterFK && c.User.Id == int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)));
                if (character == null){
                    response.Success = false;
                    response.Message = "Character not found";
                    return response;
                }

                Skill skill = await _context.skills.FirstOrDefaultAsync(s => s.Id == newCharacterSkill.SkillFK);

                if (skill == null){
                    response.Success=false;
                    response.Message = "Skill not found";
                    return response;
                }

                CharacterSkill characterSkill = new CharacterSkill{
                    Character = character,
                    Skill = skill
                };

                await _context.characterskills.AddAsync(characterSkill);
                await _context.SaveChangesAsync();

                response.Data= _mapper.Map<GetCharacterDto>(character);
            }
            catch(Exception ex){
                response.Success=false;
                response.Message=ex.Message;
            }
            return response;
        }
    }
}