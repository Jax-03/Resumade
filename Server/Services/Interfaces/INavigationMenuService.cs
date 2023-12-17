using Resumade.Shared.Models;

namespace Resumade.Server.Services.Interfaces;

public interface INavigationMenuService
{
    Task<List<Industry>> GetNavigationMenuItems();
}