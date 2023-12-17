using Moq;
using Resumade.Server.DataAccess.Interfaces;
using Resumade.Server.Services;
using Resumade.Server.Models;

namespace Resumade.Tests.ServiceTests;

[TestFixture]
public class DropDownListServiceTests
{
    private Mock<IDropDownListDataAccess> _dropDownListDataAccess;
    private DropdownListService _serviceUnderTest;

    [SetUp]
    public void SetUp()
    {
        _dropDownListDataAccess = new Mock<IDropDownListDataAccess>();
        _serviceUnderTest = new DropdownListService(_dropDownListDataAccess.Object);
    }
    
    [Test]
    public async Task GetSkills_ShouldReturnListOfSkills()
    {
        // Arrange
        var skills = new List<SkillEntity> { new SkillEntity { Id = Guid.NewGuid(), Name = "Skill 1" }, new SkillEntity { Id = Guid.NewGuid(), Name = "Skill 2" }, new SkillEntity { Id = Guid.NewGuid(), Name = "Skill 3" } };
        _dropDownListDataAccess.Setup(d => d.GetSkills()).ReturnsAsync(skills);
        // Act
        var result = await _serviceUnderTest.GetSkills();
        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(skills.Count, result.Count());
        Assert.IsTrue(result.All(s => skills.Any(sk => sk.Id == s.Id && sk.Name == s.Name)));
    }
    
    [Test]
    public async Task GetHobbies_ShouldReturnListOfHobbies()
    {
        // Arrange
        var hobbies = new List<HobbyEntity> { new HobbyEntity { Id = Guid.NewGuid(), Name = "Hobby 1" }, new HobbyEntity { Id = Guid.NewGuid(), Name = "Hobby 2" }, new HobbyEntity { Id = Guid.NewGuid(), Name = "Hobby 3" } };
        _dropDownListDataAccess.Setup(d => d.GetHobbies()).ReturnsAsync(hobbies);
        // Act
        var result = await _serviceUnderTest.GetHobbies();
        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(hobbies.Count, result.Count());
        Assert.IsTrue(result.All(h => hobbies.Any(hb => hb.Id == h.Id && hb.Name == h.Name)));
    }
    
    [Test]
    public async Task GetIndustries_ShouldReturnListOfIndustries()
    {
        // Arrange
        var industries = new List<IndustryEntity> { new IndustryEntity { Id = Guid.NewGuid(), Name = "Industry 1", Sequence = 1 }, new IndustryEntity { Id = Guid.NewGuid(), Name = "Industry 2", Sequence = 2 }, new IndustryEntity { Id = Guid.NewGuid(), Name = "Industry 3", Sequence = 3 } };
        _dropDownListDataAccess.Setup(d => d.GetIndustries()).ReturnsAsync(industries);
        // Act
        var result = await _serviceUnderTest.GetIndustries();
        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(industries.Count, result.Count());
        Assert.IsTrue(result.All(i => industries.Any(ind => ind.Id == i.Id && ind.Name == i.Name && ind.Sequence == i.Sequence)));
    }
}