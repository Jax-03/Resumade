using System.Text.Json;
using Resumade.Shared.Constants;
using Resumade.Shared.Models;

namespace Resumade.Client.Services;

public class NavigationMenuItemsService
{
    private readonly HttpClient _client;

    public NavigationMenuItemsService(IHttpClientFactory httpClientFactory)
    {
        _client = httpClientFactory.CreateClient("Resumade.ServerAPI");
    }

    public async Task<List<NavigationMenuItem>> GetMenuItemsAsync()
    {
        var response = await _client.GetAsync($"api/{Constants.ControllerNavigationMenu}");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var menuItems = JsonSerializer.Deserialize<List<NavigationMenuItem>>(json);
            return menuItems;
        }

        throw new Exception("Unable to fetch menuItems from API");
    }
}