using Resumade.Server.Models;
using Resumade.Shared.Models;

namespace Resumade.Server.DataAccess.Interfaces;

public interface IResumadeDataAccess
{
    Task<UserProfileEntity> GetUserProfileById(Guid id);
    Task<PagedResult<UserProfileEntity>> GetUserProfileSummaryCardsAsync(int pageNumber = 1, int pageSize = 10);

    Task<PagedResult<UserProfileEntity>> GetUserProfileSummaryCardsByFilterIdAsync(Guid filterId, int pageNumber = 1, int pageSize = 10);
    Task<UserProfileEntity> SaveUserProfile(UserProfile userProfileEntity);
    Task<bool> UpdateProfilePicture(Guid UserProfileId, string FilePath);
}