using Moq;
using Resumade.Server.DataAccess.Interfaces;
using Resumade.Server.Services;
using Resumade.Shared.Models;
using Resumade.Server.Models;

namespace Resumade.Tests.ServiceTests;

[TestFixture]
public class UserProfileServiceTest
{
    private Mock<IResumadeDataAccess> _resumadeDataAccessMock;
    private UserProfileService _serviceUnderTest;

    [SetUp]
    public void SetUp()
    {
        _resumadeDataAccessMock = new Mock<IResumadeDataAccess>();
        _serviceUnderTest = new UserProfileService(_resumadeDataAccessMock.Object);
    }

    [Test]
    public async Task GetUserProfileByIdAsync_CallsResumadeDataAccessWithCorrectId()
    {
        var testId = Guid.NewGuid();
        _resumadeDataAccessMock.Setup(rd => rd.GetUserProfileById(It.IsAny<Guid>()))
            .ReturnsAsync(new UserProfileEntity() { Industry = new IndustryEntity() });
        await _serviceUnderTest.GetUserProfileByIdAsync(testId);

        _resumadeDataAccessMock.Verify(rd => rd.GetUserProfileById(testId), Times.Once);
    }

    [Test]
    public async Task GetUserProfileSummaryCardsAsync_CallsResumadeDataAccessWithCorrectParameters()
    {
        var pageNumber = 1;
        var pageSize = 10;

        _resumadeDataAccessMock.Setup(rd => rd.GetUserProfileSummaryCardsAsync(pageNumber, pageSize))
            .ReturnsAsync(new PagedResult<UserProfileEntity>());

        await _serviceUnderTest.GetUserProfileSummaryCardsAsync(pageNumber, pageSize);

        _resumadeDataAccessMock.Verify(rd => rd.GetUserProfileSummaryCardsAsync(pageNumber, pageSize), Times.Once);
    }

    [Test]
    public async Task GetUserProfileSummaryCardsByFilterIdAsync_CallsResumadeDataAccessWithCorrectParameters()
    {
        var filterId = Guid.NewGuid();
        var pageNumber = 1;
        var pageSize = 10;
        _resumadeDataAccessMock
            .Setup(rd => rd.GetUserProfileSummaryCardsByFilterIdAsync(filterId, pageNumber, pageSize))
            .ReturnsAsync(new PagedResult<UserProfileEntity>());
        await _serviceUnderTest.GetUserProfileSummaryCardsByFilterIdAsync(filterId, pageNumber, pageSize);
        _resumadeDataAccessMock.Verify(
            rd => rd.GetUserProfileSummaryCardsByFilterIdAsync(filterId, pageNumber, pageSize), Times.Once);
    }
    
    [Test]
    public async Task CreateUserProfileAsync_CallsResumadeDataAccessWithCorrectUserProfile()
    {
        var userProfile = new UserProfile();
        _resumadeDataAccessMock.Setup(rd => rd.SaveUserProfile(It.IsAny<UserProfile>()))
            .ReturnsAsync(new UserProfileEntity());
        await _serviceUnderTest.CreateUserProfileAsync(userProfile);
        _resumadeDataAccessMock.Verify(rd => rd.SaveUserProfile(userProfile), Times.Once);
    }
    
    [Test]
    public async Task UpdateProfilePicture_CallsResumadeDataAccessWithCorrectParameters()
    {
        var userProfileId = Guid.NewGuid();
        var filePath = "path/to/image.jpg";
        _resumadeDataAccessMock.Setup(rd => rd.UpdateProfilePicture(userProfileId, filePath))
            .ReturnsAsync(true);
        await _serviceUnderTest.UpdateProfilePicture(userProfileId, filePath);
        _resumadeDataAccessMock.Verify(rd => rd.UpdateProfilePicture(userProfileId, filePath), Times.Once);
    }
}