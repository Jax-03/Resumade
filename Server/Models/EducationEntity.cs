using Resumade.Server.Models.BaseModels;

namespace Resumade.Server.Models;

public class EducationEntity : Entity, IAuditing
{
    public string Institution { get; set; }
    
    public string Qualification { get; set; }
    
    public string Duration { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public DateTime EditedDate { get; set; }
    
    public Guid UserProfileEntityId { get; set; }
    public UserProfileEntity UserProfile { get; set; }
}