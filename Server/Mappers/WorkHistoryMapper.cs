using Resumade.Server.Models;
using Resumade.Shared.Models;

namespace Resumade.Server.Mappers;

public static class WorkHistoryMapper
{
    public static WorkHistory Map(this WorkHistoryEntity entity)
    {
        return new WorkHistory { Position = entity.Position, Company = entity.Company, Duration = entity.Duration, Description = entity.Description };
    }
    
    public static WorkHistoryEntity MapToEntity(this WorkHistory model)
    {
        return new WorkHistoryEntity 
        { 
            Position = model.Position, 
            Company = model.Company, 
            Duration = model.Duration, 
            Description = model.Description 
        };
    }
}