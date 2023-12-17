using Microsoft.EntityFrameworkCore;
using Resumade.Api;
using Resumade.Server.DataAccess.Interfaces;
using Resumade.Server.Models;

namespace Resumade.Server.DataAccess;

public class DropDownListDataAccess : IDropDownListDataAccess
{
    private readonly ResumadeContext _context;

    public DropDownListDataAccess(ResumadeContext context)
    {
        _context = context;
    }
    
    public async Task<List<SkillEntity>> GetSkills()
    {
        return await _context.Skills
            .Select(s => new SkillEntity { Id = s.Id, Name = s.Name })
            .ToListAsync();
    }

    public async Task<List<HobbyEntity>> GetHobbies()
    {
        return await _context.Hobbies
            .Select(s => new HobbyEntity { Id = s.Id, Name = s.Name })
            .ToListAsync();
    }

    public async Task<List<IndustryEntity>> GetIndustries()
    {
        return await _context.Industries
            .Select(s => new IndustryEntity { Id = s.Id, Name = s.Name })
            .ToListAsync();
    }
}