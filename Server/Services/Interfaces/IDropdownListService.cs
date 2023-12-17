using Resumade.Shared.Models;

namespace Resumade.Server.Services.Interfaces;

public interface IDropdownListService
{
    Task<IEnumerable<Skill>> GetSkills();
    Task<IEnumerable<Hobby>> GetHobbies();
    Task<IEnumerable<Industry>> GetIndustries();
}