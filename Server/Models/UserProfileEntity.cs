using Resumade.Server.Models.BaseModels;

namespace Resumade.Server.Models;

public class UserProfileEntity : Entity, IAuditing 
{
    public UserProfileEntity()
    {
        WorkHistories = new List<WorkHistoryEntity>();
        Educations = new List<EducationEntity>();
        UserProfileSkills = new List<UserProfileSkillEntity>();
        UserProfileHobbies = new List<UserProfileHobbyEntity>();
    }
        
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Location { get; set; }
    public string Summary { get; set; }
    
    public string ImageUrl { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime EditedDate { get; set; }
    public List<WorkHistoryEntity> WorkHistories { get; set; }
    public List<EducationEntity> Educations { get; set; }
    public List<UserProfileSkillEntity> UserProfileSkills { get; set; }
    public List<UserProfileHobbyEntity> UserProfileHobbies { get; set; }
    public Guid IndustryId { get; set; }
    public IndustryEntity Industry { get; set; }
}