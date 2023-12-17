using Resumade.Server.Models;

namespace Resumade.Server.DataAccess.Interfaces;

public interface IDropDownListDataAccess
{
    public Task<List<SkillEntity>> GetSkills();
    public Task<List<HobbyEntity>> GetHobbies();
    public Task<List<IndustryEntity>> GetIndustries();
}