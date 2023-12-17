using Resumade.Server.Models.BaseModels;

namespace Resumade.Server.Models;

public class IndustryEntity : Entity
{

    public IndustryEntity()
    {
        UserProfiles = new List<UserProfileEntity>();
    }
    public string Name { get; set; }

    public int Sequence { get; set; }
    
    public List<UserProfileEntity> UserProfiles { get; set; } 
}