using Resumade.Shared.Models;

namespace Resumade.Server.Services.Interfaces;

public interface IUserProfileService
{
    Task<UserProfile> GetUserProfileByIdAsync(Guid id);
    Task<PagedResult<UserProfileSummary>> GetUserProfileSummaryCardsAsync(int pageNumber = 1, int pageSize = 10);

    Task<PagedResult<UserProfileSummary>> GetUserProfileSummaryCardsByFilterIdAsync(Guid filterId, int pageNumber = 1,
        int pageSize = 10);
    Task<UserProfile> CreateUserProfileAsync(UserProfile userProfile);
    Task<bool> UpdateProfilePicture(Guid UserProfileId, string FilePath);
}