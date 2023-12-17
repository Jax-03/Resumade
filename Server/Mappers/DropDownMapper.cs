using Resumade.Server.Models;
using Resumade.Shared.Models;

namespace Resumade.Server.Mappers;

public static class DropDownMapper
{
    public static Skill Map(this SkillEntity entity)
    {
        if (entity == null)
            return new Skill();

        return new Skill { Id = entity.Id, Name = entity.Name };
    }

    public static Hobby Map(this HobbyEntity entity)
    {
        return new Hobby { Id = entity.Id, Name = entity.Name };
    }

    public static Industry Map(this IndustryEntity entity)
    {
        return new Industry { Id = entity.Id, Name = entity.Name, Sequence = entity.Sequence};
    }
    
    public static SkillEntity MapToEntity(this Skill model)
    {
        return new SkillEntity 
        { 
            Id = model.Id, 
            Name = model.Name 
        };
    }

    public static HobbyEntity MapToEntity(this Hobby model)
    {
        return new HobbyEntity 
        { 
            Id = model.Id, 
            Name = model.Name 
        };
    }
}