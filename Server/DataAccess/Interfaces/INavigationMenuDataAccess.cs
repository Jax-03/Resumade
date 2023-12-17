using Resumade.Server.Models;

namespace Resumade.Server.DataAccess.Interfaces;

public interface INavigationMenuDataAccess
{
    Task<List<IndustryEntity>> GetNavigationMenuItems();
}