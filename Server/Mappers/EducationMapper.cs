using Resumade.Server.Models;
using Resumade.Shared.Models;

namespace Resumade.Server.Mappers;

public static class EducationMapper
{
    public static Education Map(this EducationEntity entity)
    {
        return new Education { Institution = entity.Institution, Qualification = entity.Qualification, Duration = entity.Duration };
    }
    
    public static EducationEntity MapToEntity(this Education model)
    {
        return new EducationEntity 
        { 
            Institution = model.Institution, 
            Qualification = model.Qualification, 
            Duration = model.Duration 
        };
    }
}