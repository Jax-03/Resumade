using System.Text.Json.Serialization;

namespace Resumade.Shared.Models;

public class NavigationMenuItem
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("order")]

    public int Order { get; set; }
}