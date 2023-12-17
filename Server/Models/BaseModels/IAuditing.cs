namespace Resumade.Server.Models.BaseModels;

public interface IAuditing
{
    public DateTime CreatedDate { get; set; }
    
    public DateTime EditedDate { get; set; }
}