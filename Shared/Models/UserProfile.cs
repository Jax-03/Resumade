using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Resumade.Shared.Models;

public class UserProfile
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(50, ErrorMessage = "Name length can't exceed 50 characters.")]
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Last Name is required.")]
    [StringLength(50, ErrorMessage = "Last Name length can't exceed 50 characters.")]
    [JsonPropertyName("lastName")]
    public string LastName { get; set; }
    
    [Required(ErrorMessage = "Industry is required.")]
    [JsonPropertyName("industry")]
    public Industry Industry { get; set; }
    
    [Required(ErrorMessage = "Phone number is required.")]
    [Phone(ErrorMessage = "Invalid phone number.")]
    [JsonPropertyName("phone")]
    public string Phone { get; set; }
    
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    [JsonPropertyName("email")]
    public string Email { get; set; }
    
    [StringLength(100, ErrorMessage = "Location length can't exceed 100 characters.")]
    [JsonPropertyName("location")]
    public string Location { get; set; }
    
    [StringLength(500, ErrorMessage = "Summary length can't exceed 500 characters.")]
    [JsonPropertyName("summary")]
    public string Summary { get; set; }
    
    [JsonPropertyName("imageUrl")]
    public string ImageUrl { get; set; } = string.Empty;
    
    
    [JsonPropertyName("workHistories")]
    public List<WorkHistory> WorkHistories { get; set; } = new();
    
    [JsonPropertyName("educations")]
    public List<Education> Educations { get; set; } = new();
    
    [JsonPropertyName("skills")]
    public List<Skill> Skills { get; set; } = new();
    
    [JsonPropertyName("hobbies")]
    public List<Hobby> Hobbies { get; set; } = new();
    
    public string FullName => Name + " " + LastName;
}