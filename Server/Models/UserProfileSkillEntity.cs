namespace Resumade.Server.Models;

public class UserProfileSkillEntity
{
    public Guid UserProfileId { get; set; }
    public UserProfileEntity UserProfile { get; set; }
    public Guid SkillId { get; set; }
    public SkillEntity Skill { get; set; }
}