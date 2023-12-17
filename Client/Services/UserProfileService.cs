using System.Net.Http.Json;
using System.Text.Json;
using Resumade.Shared.Constants;
using Resumade.Shared.Models;

namespace Resumade.Client.Services;

public class UserProfileService
{
    
    private readonly HttpClient _client;

    public UserProfileService(IHttpClientFactory httpClientFactory)
    {
        _client = httpClientFactory.CreateClient("Resumade.ServerAPI");
    } 
    
    public async Task<Guid> GetProfileGuidByName(string name)
    {
        try
        {
            var response = await _client.GetAsync($"api/{Constants.ControllerUserProfile}/guid/{name}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var guid = JsonSerializer.Deserialize<Guid>(json);
                return guid;
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
        }
        

        throw new Exception("Unable to fetch user profile guid from API");
    }
    
    public async Task<UserProfile> GetProfileById(Guid id)
    {
        var response = await _client.GetAsync($"api/{Constants.ControllerUserProfile}/profile/{id}");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var userProfile = JsonSerializer.Deserialize<UserProfile>(json);
            return userProfile;
        }

        throw new Exception("Unable to fetch user profile from API");
    }
    
    public async Task<PagedResult<UserProfileSummary>> GetUserProfileSummaryCardsAsync(int pageNumber = 1)
    {
        var response = await _client.GetAsync($"api/{Constants.ControllerUserProfile}/profileSummaries?pageNumber={pageNumber}");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var pagedResult = JsonSerializer.Deserialize<PagedResult<UserProfileSummary>>(json);
            return pagedResult;
        }

        throw new Exception("Unable to fetch user profile summaries from API");
    }
    
    public async Task<PagedResult<UserProfileSummary>> GetUserProfileSummaryCardsByFilterIdAsync(Guid filterId, int pageNumber = 1)
    {
        var response = await _client.GetAsync($"api/{Constants.ControllerUserProfile}/profileSummaries/{filterId}?pageNumber={pageNumber}");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var pagedResult = JsonSerializer.Deserialize<PagedResult<UserProfileSummary>>(json);
            return pagedResult;
        }

        throw new Exception("Unable to fetch user profile from API");
    }
    
    public async Task<bool> SaveUserProfileAsync(UserProfile userProfile)
    {
        var response = await _client.PostAsJsonAsync($"api/{Constants.ControllerUserProfile}/profile", userProfile);

        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public async Task<HttpResponseMessage> UploadProfilePicture(Guid userProfileId, MultipartFormDataContent content)
    {
        return await _client.PostAsync($"api/UserProfile/UploadProfilePicture/{userProfileId}", content);
    }
}