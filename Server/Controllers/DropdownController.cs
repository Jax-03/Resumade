using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resumade.Server.Services.Interfaces;

namespace Resumade.Server.Controllers;

[Authorize]
[Route("api/[controller]")]
public class DropdownController : Controller
{
    private readonly IDropdownListService _dropdownListService;

    public DropdownController(IDropdownListService dropdownListService)
    {
        _dropdownListService = dropdownListService;
    }

    [HttpGet("hobbies")]
    public async Task<IActionResult> GetHobbies()
    {
        var values = await _dropdownListService.GetHobbies();
        return Ok(values);
    }

    [HttpGet("skills")]
    public async Task<IActionResult> GetSkills()
    {
        var values = await _dropdownListService.GetSkills();
        return Ok(values);
    }

    [HttpGet("industries")]
    public async Task<IActionResult> GetIndustries()
    {
        var values = await _dropdownListService.GetIndustries();
        return Ok(values);
    }
}