using Resumade.Server.DataAccess.Interfaces;
using Resumade.Server.Mappers;
using Resumade.Server.Services.Interfaces;
using Resumade.Shared.Models;

namespace Resumade.Server.Services;

public class NavigationMenuService : INavigationMenuService
{
    private readonly INavigationMenuDataAccess _navigationMenuDataAccess;

    public NavigationMenuService(INavigationMenuDataAccess navigationMenuDataAccess)
    {
        _navigationMenuDataAccess = navigationMenuDataAccess;
    }
    
    public async Task<List<Industry>> GetNavigationMenuItems()
    {
        var result = await _navigationMenuDataAccess.GetNavigationMenuItems();
        return result.Select(x => x.MapMenuItems()).ToList();
    }
}