using Resumade.Server.Models;
using Resumade.Shared.Models;

namespace Resumade.Server.Mappers;

public static class UserProfileMapper
{
    public static UserProfile Map(this UserProfileEntity entity)
    {
        if (entity == null)
            return new UserProfile();
        
        return new UserProfile
        {
            Id = entity.Id,
            Name = entity.Name,
            LastName = entity.LastName,
            Industry = entity.Industry.Map(),
            Phone = entity.Phone,
            Email = entity.Email,
            Location = entity.Location,
            Summary = entity.Summary,
            ImageUrl = entity.ImageUrl,
            WorkHistories = entity.WorkHistories?.Select(wh => wh.Map()).ToList(),
            Educations = entity.Educations?.Select(ed => ed.Map()).ToList(),
            Skills = entity.UserProfileSkills?.Select(us => us.Skill.Map()).ToList(),
            Hobbies = entity.UserProfileHobbies?.Select(uh => uh.Hobby.Map()).ToList()
        };
    }
    
    public static UserProfileSummary MapToSummary(this UserProfileEntity entity)
    {
        return new UserProfileSummary
        {
            Id = entity.Id,
            Name = entity.Name,
            LastName = entity.LastName,
            Industry = entity.Industry?.Name,
            Phone = entity.Phone,
            Email = entity.Email,
            Location = entity.Location,
            Summary = entity.Summary,
            ImageUrl = entity.ImageUrl
        };
    }
    
    public static UserProfileEntity MapToEntity(this UserProfile model)
    {
        return new UserProfileEntity
        {
            Id = model.Id,
            Name = model.Name,
            LastName = model.LastName,
            Industry = new IndustryEntity { Name = model.Industry.Name, Id = model.Industry.Id },
            Phone = model.Phone,
            Email = model.Email,
            Location = model.Location,
            Summary = model.Summary,
            ImageUrl = model.ImageUrl,
            WorkHistories = model.WorkHistories?.Select(wh => wh.MapToEntity()).ToList(),
            Educations = model.Educations?.Select(ed => ed.MapToEntity()).ToList(),
            UserProfileSkills = model.Skills?.Select(us => new UserProfileSkillEntity { Skill = us.MapToEntity() }).ToList(),
            UserProfileHobbies = model.Hobbies?.Select(uh => new UserProfileHobbyEntity { Hobby = uh.MapToEntity() }).ToList()
        };
    }
    
}