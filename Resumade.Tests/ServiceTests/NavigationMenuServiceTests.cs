using Moq;
using Resumade.Server.DataAccess.Interfaces;
using Resumade.Server.Services;
using Resumade.Shared.Models;
using Resumade.Server.Models;

namespace Resumade.Tests.ServiceTests;

[TestFixture]
public class NavigationMenuServiceTests
{
    private Mock<INavigationMenuDataAccess> _navigationMenuDataAccess;
    private NavigationMenuService _serviceUnderTest;

    [SetUp]
    public void SetUp()
    {
        _navigationMenuDataAccess = new Mock<INavigationMenuDataAccess>();
        _serviceUnderTest = new NavigationMenuService(_navigationMenuDataAccess.Object);
    }
    
    [Test]
    public async Task GetNavigationMenuItems_ShouldReturnMappedItems()
    {
        // Arrange
        var industryEntities = new List<IndustryEntity> { new IndustryEntity { Id = Guid.NewGuid(), Name = "Industry 1", Sequence = 1 }, new IndustryEntity { Id = Guid.NewGuid(), Name = "Industry 2", Sequence = 2 } };
        _navigationMenuDataAccess.Setup(x => x.GetNavigationMenuItems()).ReturnsAsync(industryEntities);
        // Act
        var result = await _serviceUnderTest.GetNavigationMenuItems();
        // Assert
        Assert.AreEqual(industryEntities.Count, result.Count);
        for (int i = 0; i < industryEntities.Count; i++)
        {
            Assert.AreEqual(industryEntities[i].Id, result[i].Id);
            Assert.AreEqual(industryEntities[i].Name, result[i].Name);
            Assert.AreEqual(industryEntities[i].Sequence, result[i].Sequence);
        }
    }
}
