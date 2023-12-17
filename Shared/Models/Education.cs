using System.Text.Json.Serialization;

namespace Resumade.Shared.Models;

public class Education
{
    [JsonPropertyName("institution")]
    public string Institution { get; set; }
    
    [JsonPropertyName("qualification")]
    public string Qualification { get; set; }
    
    [JsonPropertyName("duration")]
    public string Duration { get; set; }
    
    
    public string InstitutionErrorMsg { get; set; }
    public string QualificationErrorMsg { get; set; }
    public string DurationErrorMsg { get; set; }
}