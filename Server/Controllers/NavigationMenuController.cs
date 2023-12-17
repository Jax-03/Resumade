using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resumade.Server.Services.Interfaces;

namespace Resumade.Server.Controllers;

[Authorize]
[Route("api/[controller]")]
public class NavigationMenuController : Controller
{
    private readonly INavigationMenuService _service;

    public NavigationMenuController(INavigationMenuService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetNavigationMenuItems()
    {
        var result = await _service.GetNavigationMenuItems();
        return Ok(result);
    }
}