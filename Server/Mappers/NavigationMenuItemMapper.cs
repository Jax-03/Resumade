using Resumade.Server.Models;
using Resumade.Shared.Models;

namespace Resumade.Server.Mappers;

public static class NavigationMenuItemMapper
{
    public static Industry MapMenuItems(this IndustryEntity entity)
    {
        return new Industry { Id = entity.Id, Name = entity.Name, Sequence = entity.Sequence };
    }
}