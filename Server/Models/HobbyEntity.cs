using Resumade.Server.Models.BaseModels;

namespace Resumade.Server.Models;

public class HobbyEntity : Entity
{
    public HobbyEntity()
    {
        UserProfileHobbies = new List<UserProfileHobbyEntity>();
    }

    public string Name { get; set; }

    public List<UserProfileHobbyEntity> UserProfileHobbies { get; set; }
}