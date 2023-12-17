using Microsoft.EntityFrameworkCore;
using Resumade.Api;
using Resumade.Server.DataAccess.Interfaces;
using Resumade.Server.Mappers;
using Resumade.Server.Models;
using Resumade.Shared.Models;

namespace Resumade.Server.DataAccess;

public class ResumadeDataAccess : IResumadeDataAccess
{
    private readonly ResumadeContext _context;

    public ResumadeDataAccess(ResumadeContext context)
    {
        _context = context;
    }
    
    public async Task<UserProfileEntity> GetUserProfileById(Guid id)
    {
        return await _context.UserProfiles
            .Include(i => i.Industry)
            .Include(i => i.UserProfileSkills)
                .ThenInclude(us => us.Skill) // Get the actual Skill entities
            .Include(i => i.UserProfileHobbies)
                .ThenInclude(uh => uh.Hobby) // Get the actual Hobby entities
            .Include(i => i.WorkHistories)
            .Include(i => i.Educations)
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<PagedResult<UserProfileEntity>> GetUserProfileSummaryCardsAsync(int pageNumber = 1, int pageSize = 10)
    {
        IQueryable<UserProfileEntity> query = _context.UserProfiles.Include(i => i.Industry);

        var total = await query.CountAsync();
        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResult<UserProfileEntity>
        {
            Items = items,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalPages = (int)Math.Ceiling((double)total / pageSize),
            TotalCount = total
        };
    }

    public async Task<PagedResult<UserProfileEntity>> GetUserProfileSummaryCardsByFilterIdAsync(Guid filterId, int pageNumber = 1, int pageSize = 10)
    {
        IQueryable<UserProfileEntity> query = _context.UserProfiles.Include(i => i.Industry)
            .Where(x=>x.IndustryId == filterId);

        var total = await query.CountAsync();
        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResult<UserProfileEntity>
        {
            Items = items,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalPages = (int)Math.Ceiling((double)total / pageSize),
            TotalCount = total
        };
    }

    public async Task<UserProfileEntity> SaveUserProfile(UserProfile userProfile)
    {
        try
        {
            var entity = new UserProfileEntity();

            var exists = await _context.UserProfiles.AnyAsync(x => x.Id == userProfile.Id);

            if (exists)
            {
                await _context.UserProfiles
                    .Include(up => up.UserProfileSkills)
                    .Include(up => up.UserProfileHobbies)
                    .SingleAsync(up => up.Id == userProfile.Id);

                // Map properties from the Model to the Entity
                entity.Name = userProfile.Name;
                entity.LastName = userProfile.LastName;
                entity.Phone = userProfile.Phone;
                entity.Email = userProfile.Email;
                entity.Location = userProfile.Location;
                entity.Summary = userProfile.Summary;
                entity.CreatedDate = entity.CreatedDate;
                entity.EditedDate = DateTime.Now;

                await Populate(userProfile, entity);
            }
            else
            {
                entity = userProfile.MapToEntity();
                await Populate(userProfile, entity);

                entity.CreatedDate = DateTime.Now;
                entity.EditedDate = DateTime.Now;
                _context.UserProfiles.Add(entity);
            }

            await _context.SaveChangesAsync();

            return entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> UpdateProfilePicture(Guid UserProfileId, string FilePath)
    {
        var userProfileEntity = await _context.UserProfiles.Where(x => x.Id == UserProfileId).FirstAsync();
        userProfileEntity.ImageUrl = FilePath;
        
        await _context.SaveChangesAsync();
        return true;
    }

    private async Task Populate(UserProfile userProfile, UserProfileEntity entity)
    {
        // Handle related entities
        var industryEntity = await _context.Industries.SingleOrDefaultAsync(i => i.Id == userProfile.Industry.Id);
        entity.Industry = industryEntity;

        entity.UserProfileHobbies.Clear();
        foreach (var hobby in userProfile.Hobbies) // where Hobbies list of ID hobby
        {
            var hobbyEntity = await _context.Hobbies.SingleOrDefaultAsync(h => h.Id == hobby.Id);
            entity.UserProfileHobbies.Add(new UserProfileHobbyEntity { Hobby = hobbyEntity }); 
        }

        entity.UserProfileSkills.Clear();
        foreach (var skill in userProfile.Skills) // where Skills list of Skill ID
        {
            var skillEntity = await _context.Skills.SingleOrDefaultAsync(s => s.Id == skill.Id);
            entity.UserProfileSkills.Add(new UserProfileSkillEntity { Skill = skillEntity });
        }
    }
}