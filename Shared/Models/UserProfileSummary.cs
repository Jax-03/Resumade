using System.Text.Json.Serialization;

namespace Resumade.Shared.Models;

public class UserProfileSummary
{
    [JsonPropertyName("id")] 
    public Guid Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("lastName")]
    public string LastName { get; set; }
    
    [JsonPropertyName("industry")]
    public string Industry { get; set; }
    
    [JsonPropertyName("phone")]
    public string Phone { get; set; }
    
    [JsonPropertyName("email")]
    public string Email { get; set; }
    
    [JsonPropertyName("location")]
    public string Location { get; set; }
    
    [JsonPropertyName("summary")]
    public string Summary { get; set; }
    
    [JsonPropertyName("imageUrl")]
    public string ImageUrl { get; set; }

    public string FullName => Name + " " + LastName;
}