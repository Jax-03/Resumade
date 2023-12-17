using Resumade.Server.DataAccess.Interfaces;
using Resumade.Server.Mappers;
using Resumade.Server.Services.Interfaces;
using Resumade.Shared.Models;

namespace Resumade.Server.Services;

public class DropdownListService : IDropdownListService
{
    private readonly IDropDownListDataAccess _dropDownListDataAccess;

    public DropdownListService(IDropDownListDataAccess dropDownListDataAccess )
    {
        _dropDownListDataAccess = dropDownListDataAccess;
    }
    
    public async Task<IEnumerable<Skill>> GetSkills()
    {
        var result = await _dropDownListDataAccess.GetSkills();
        return result.Select(s => s.Map()).ToList();
    }

    public async Task<IEnumerable<Hobby>> GetHobbies()
    {
        var result = await _dropDownListDataAccess.GetHobbies();
        return result.Select(s => s.Map()).ToList();
    }

    public async Task<IEnumerable<Industry>> GetIndustries()
    {
        var result = await _dropDownListDataAccess.GetIndustries();
        return result.Select(s => s.Map()).ToList();
    }
}