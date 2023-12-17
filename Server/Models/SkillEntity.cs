using Resumade.Server.Models.BaseModels;

namespace Resumade.Server.Models;

public class SkillEntity : Entity
{
    public SkillEntity()
    {
        UserProfileSkills = new List<UserProfileSkillEntity>();
    }
        
    public string Name { get; set; }
    public List<UserProfileSkillEntity> UserProfileSkills { get; set; }
}