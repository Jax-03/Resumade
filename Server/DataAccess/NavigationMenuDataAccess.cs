using Microsoft.EntityFrameworkCore;
using Resumade.Api;
using Resumade.Server.DataAccess.Interfaces;
using Resumade.Server.Models;

namespace Resumade.Server.DataAccess;


public class NavigationMenuDataAccess : INavigationMenuDataAccess
{
    private readonly ResumadeContext _context;

    public NavigationMenuDataAccess(ResumadeContext context)
    {
        _context = context;
    }
    
    public async Task<List<IndustryEntity>> GetNavigationMenuItems()
    {
        return await _context.Industries.ToListAsync();
    }
}