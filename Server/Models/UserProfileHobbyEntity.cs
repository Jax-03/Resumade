using System.ComponentModel.DataAnnotations.Schema;

namespace Resumade.Server.Models;

[Table("UserProfileHobby")]
public class UserProfileHobbyEntity
{
    public Guid UserProfileId { get; set; }
    public UserProfileEntity UserProfile { get; set; }
    public Guid HobbyId { get; set; }
    public HobbyEntity Hobby { get; set; }
}