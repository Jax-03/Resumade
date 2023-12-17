using Resumade.Server.Models.BaseModels;

namespace Resumade.Server.Models;

public class WorkHistoryEntity : Entity, IAuditing
{
    public string Position { get; set; }
    
    public string Company { get; set; }
    
    public string Duration { get; set; }
    
    public string Description { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public DateTime EditedDate { get; set; }
    
    public Guid UserProfileEntityId { get; set; }
    public UserProfileEntity UserProfile { get; set; }
}