using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Resumade.Server.Models;
using Resumade.Server.Services.Interfaces;
using Resumade.Shared.Constants;
using Resumade.Shared.Models;

namespace Resumade.Server.Controllers;

[Authorize]
[Route("api/[controller]")]
public class UserProfileController : Controller
{
    private readonly IUserProfileService _userProfileService;
    private readonly UserManager<ApplicationUser> _userManager;

    public UserProfileController(IUserProfileService userProfileService, UserManager<ApplicationUser> userManager)
    {
        _userProfileService = userProfileService;
        _userManager = userManager;
    }

    [HttpGet("guid/{name}")]
    public async Task<ActionResult<Guid>> GetUserGuid([FromRoute] string name)
    {
        var user = await _userManager.FindByNameAsync(name);
        if (user == null) return NotFound();
        var userGuid = new Guid(user.Id);
        return Ok(userGuid);
    }

    [HttpGet("profile/{id}")]
    public async Task<IActionResult> GetProfile([FromRoute] Guid id)
    {
        var result = await _userProfileService.GetUserProfileByIdAsync(id);
        return Ok(result);
    }

    [HttpGet("profileSummaries")]
    public async Task<IActionResult> GetAllSummaryCards([FromQuery] int pageNumber = 1)
    {
        var result = await _userProfileService.GetUserProfileSummaryCardsAsync(pageNumber, Constants.PageSize);
        return Ok(result);
    }

    [HttpGet("profileSummaries/{filterId}")]
    public async Task<IActionResult> GetAllSummaryCardsByFilterId([FromRoute] Guid filterId,
        [FromQuery] int pageNumber = 1)
    {
        var result =
            await _userProfileService.GetUserProfileSummaryCardsByFilterIdAsync(filterId, pageNumber,
                Constants.PageSize);

        return Ok(result);
    }

    [HttpPost("profile")]
    public async Task<IActionResult> CreateProfile([FromBody] UserProfile userProfile)
    {
        var createdUserProfile = await _userProfileService.CreateUserProfileAsync(userProfile);
        if (createdUserProfile != null)
        {
            return Ok(createdUserProfile);
        }
        else
        {
            return BadRequest("Failed to create user profile");
        }
    }
    
    [HttpPost("UploadProfilePicture/{userProfileId}")]
    public async Task<IActionResult> UploadProfilePicture([FromRoute] Guid userProfileId, [FromForm] IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file provided.");
        }

        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        var filePath = Path.Combine("Media", "ProfilePictures", fileName);

        // Replace backslashes with forward slashes for web compatibility
        var webFilePath = filePath.Replace("\\", "/");

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        // Save webFilePath to the user's profile in your database
        await _userProfileService.UpdateProfilePicture(userProfileId, webFilePath);

        return Ok(webFilePath);
    }
}