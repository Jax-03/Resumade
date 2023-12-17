using Resumade.Server.DataAccess.Interfaces;
using Resumade.Server.Mappers;
using Resumade.Server.Services.Interfaces;
using Resumade.Shared.Models;

namespace Resumade.Server.Services;

public class UserProfileService : IUserProfileService
{
    private readonly IResumadeDataAccess _resumadeDataAccess;
    
    public UserProfileService(IResumadeDataAccess resumadeDataAccess)
    {
        _resumadeDataAccess = resumadeDataAccess;
    }
    
    public async Task<UserProfile> GetUserProfileByIdAsync(Guid id)
    {
        var result = await _resumadeDataAccess.GetUserProfileById(id);
        return result.Map();
    }

    public async Task<PagedResult<UserProfileSummary>> GetUserProfileSummaryCardsAsync(int pageNumber = 1, int pageSize = 10)
    {
        var result = await _resumadeDataAccess.GetUserProfileSummaryCardsAsync(pageNumber, pageSize);

        var userProfileSummaries = result.Items.Select(x => x.MapToSummary()).ToList();

        return new PagedResult<UserProfileSummary>
        {
            Items = userProfileSummaries,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize,
            TotalPages = result.TotalPages,
            TotalCount = result.TotalCount
        };
    }

    public async Task<PagedResult<UserProfileSummary>> GetUserProfileSummaryCardsByFilterIdAsync(Guid filterId, int pageNumber = 1, int pageSize = 10)
    {
        var result = await _resumadeDataAccess.GetUserProfileSummaryCardsByFilterIdAsync(filterId, pageNumber, pageSize);

        var userProfileSummaries = result.Items.Select(x => x.MapToSummary()).ToList();

        return new PagedResult<UserProfileSummary>
        {
            Items = userProfileSummaries,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize,
            TotalPages = result.TotalPages,
            TotalCount = result.TotalCount
        };

    }

    public async Task<UserProfile> CreateUserProfileAsync(UserProfile userProfile)
    {
        await _resumadeDataAccess.SaveUserProfile(userProfile);
        return userProfile;
    }

    public async Task<bool> UpdateProfilePicture(Guid UserProfileId, string FilePath)
    {
        return await _resumadeDataAccess.UpdateProfilePicture(UserProfileId, FilePath);
    }
}