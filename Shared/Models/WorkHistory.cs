using System.Text.Json.Serialization;

namespace Resumade.Shared.Models;

public class WorkHistory
{
    [JsonPropertyName("position")]
    public string Position { get; set; }
    
    [JsonPropertyName("company")]
    public string Company { get; set; }
    
    [JsonPropertyName("duration")]
    public string Duration { get; set; }
    
    [JsonPropertyName("description")]
    public string Description { get; set; }
    
    public string CompanyErrorMsg { get; set; }
    public string PositionErrorMsg { get; set; }
    public string DurationErrorMsg { get; set; }
    public string DescriptionErrorMsg { get; set; }
    
    [JsonIgnore]
    public string ValidationErrorMsg { get; set; }
    
    public bool HasValidationError => !string.IsNullOrEmpty(ValidationErrorMsg);
}