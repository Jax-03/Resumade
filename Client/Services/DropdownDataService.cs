using System.Text.Json;
using Resumade.Shared.Constants;
using Resumade.Shared.Models;

namespace Resumade.Client.Services;

public class DropdownDataService
{
    
    private readonly HttpClient _client;

    public DropdownDataService(IHttpClientFactory httpClientFactory)
    {
        _client = httpClientFactory.CreateClient("Resumade.ServerAPI");
    } 
    
    public async Task<List<Skill>> GetSkillsAsync()
    {
        var response = await _client.GetAsync($"api/{Constants.ControllerDropDown}/skills");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var skills = JsonSerializer.Deserialize<List<Skill>>(json);
            return skills;
        }

        throw new Exception("Unable to fetch skills from API");
    }

    public async Task<List<Hobby>> GetHobbiesAsync()
    {
        var response = await _client.GetAsync($"api/{Constants.ControllerDropDown}/hobbies");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var hobbies = JsonSerializer.Deserialize<List<Hobby>>(json);
            return hobbies;
        }

        throw new Exception("Unable to fetch hobbies from API");
    }

    public async Task<List<Industry>> GetIndustryAsync()
    {
        var response = await _client.GetAsync($"api/{Constants.ControllerDropDown}/industries");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var industries = JsonSerializer.Deserialize<List<Industry>>(json);
            return industries;
        }

        throw new Exception("Unable to fetch industries from API");
    }
}