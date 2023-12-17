using Microsoft.EntityFrameworkCore;
using Resumade.Server.Models;

namespace Resumade.Api;

public class ResumadeContext : DbContext
{
    public ResumadeContext(DbContextOptions<ResumadeContext> options)
        : base(options)
    {
    }
    
    public DbSet<UserProfileSkillEntity> UserProfileSkills { get; set; }
    public DbSet<UserProfileHobbyEntity> UserProfileHobbies { get; set; }
    public DbSet<EducationEntity> Education { get; set; }
    public DbSet<HobbyEntity> Hobbies { get; set; }
    public DbSet<IndustryEntity> Industries { get; set; }
    public DbSet<SkillEntity> Skills { get; set; }
    public DbSet<UserProfileEntity> UserProfiles { get; set; }
    public DbSet<WorkHistoryEntity> WorkHistory { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserProfileEntity>()
            .HasOne(u => u.Industry)
            .WithMany(i => i.UserProfiles)
            .HasForeignKey(u => u.IndustryId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserProfileEntity>()
            .HasMany(up => up.WorkHistories)
            .WithOne(wh => wh.UserProfile)
            .HasForeignKey(wh => wh.UserProfileEntityId);

        modelBuilder.Entity<UserProfileEntity>()
            .HasMany(up => up.UserProfileSkills)
            .WithOne(ups => ups.UserProfile)
            .HasForeignKey(ups => ups.UserProfileId);

        modelBuilder.Entity<UserProfileEntity>()
            .HasMany(up => up.UserProfileHobbies)
            .WithOne(uph => uph.UserProfile)
            .HasForeignKey(uph => uph.UserProfileId);

        modelBuilder.Entity<SkillEntity>()
            .HasMany(s => s.UserProfileSkills)
            .WithOne(ups => ups.Skill)
            .HasForeignKey(ups => ups.SkillId);

        modelBuilder.Entity<HobbyEntity>()
            .HasMany(h => h.UserProfileHobbies)
            .WithOne(uph => uph.Hobby)
            .HasForeignKey(uph => uph.HobbyId);
        
        modelBuilder.Entity<UserProfileSkillEntity>()
            .HasKey(us => new { us.UserProfileId, us.SkillId });

        modelBuilder.Entity<UserProfileHobbyEntity>()
            .HasKey(uh => new { uh.UserProfileId, uh.HobbyId });

        // Generating some Guids for the IndustryEntity, SkillEntity, HobbyEntity
        var IndustryEntityGuid1 = Guid.NewGuid();
        var IndustryEntityGuid2 = Guid.NewGuid();
        var IndustryEntityGuid3 = Guid.NewGuid();
        var SkillsEntityGuid1 = Guid.NewGuid();
        var SkillsEntityGuid2 = Guid.NewGuid();
        var SkillsEntityGuid3 = Guid.NewGuid();
        var HobbyEntityGuid1 = Guid.NewGuid();
        var HobbyEntityGuid2 = Guid.NewGuid();
        var HobbyEntityGuid3 = Guid.NewGuid();

// Seed IndustryEntity data
        modelBuilder.Entity<IndustryEntity>().HasData(
            new IndustryEntity { Id = IndustryEntityGuid1, Name = "Administrative", Sequence = 1},
            new IndustryEntity { Id = IndustryEntityGuid2, Name = "Construction", Sequence = 2},
            new IndustryEntity { Id = IndustryEntityGuid3, Name = "Consumer Services", Sequence = 3},
            new IndustryEntity { Id = Guid.NewGuid(), Name = "Education", Sequence = 4},
            new IndustryEntity { Id = Guid.NewGuid(), Name = "Entertainment", Sequence = 5},
            new IndustryEntity { Id = Guid.NewGuid(), Name = "Farming", Sequence = 5},
            new IndustryEntity { Id = Guid.NewGuid(), Name = "Financial Services", Sequence = 6},
            new IndustryEntity { Id = Guid.NewGuid(), Name = "Health Care", Sequence = 7},
            new IndustryEntity { Id = Guid.NewGuid(), Name = "Manufacturing", Sequence = 8},
            new IndustryEntity { Id = Guid.NewGuid(), Name = "Media", Sequence = 9},
            new IndustryEntity { Id = Guid.NewGuid(), Name = "Mining", Sequence = 10},
            new IndustryEntity { Id = Guid.NewGuid(), Name = "Real Estate", Sequence = 11},
            new IndustryEntity { Id = Guid.NewGuid(), Name = "Retail", Sequence = 12},
            new IndustryEntity { Id = Guid.NewGuid(), Name = "Technology", Sequence = 13},
            new IndustryEntity { Id = Guid.NewGuid(), Name = "Logistics", Sequence = 14},
            new IndustryEntity { Id = Guid.NewGuid(), Name = "Utilities", Sequence = 15},
            new IndustryEntity { Id = Guid.NewGuid(), Name = "Whole Sale", Sequence = 16},
            new IndustryEntity { Id = Guid.NewGuid(), Name = "Other", Sequence = 999}
        );

// Seed SkillEntity data
        modelBuilder.Entity<SkillEntity>().HasData(
            new SkillEntity { Id = SkillsEntityGuid1, Name = "Communication" },
            new SkillEntity { Id = SkillsEntityGuid2, Name = "Teamwork" },
            new SkillEntity { Id = SkillsEntityGuid3, Name = "Problem Solving" }
        );

// Seed HobbyEntity data
        modelBuilder.Entity<HobbyEntity>().HasData(
            new HobbyEntity { Id = HobbyEntityGuid1, Name = "Reading" },
            new HobbyEntity { Id = HobbyEntityGuid2, Name = "Gaming" },
            new HobbyEntity { Id = HobbyEntityGuid3, Name = "Cooking" }
        );

// Generate a Guid for the UserProfileEntity
        var UserProfileEntityId1 = Guid.NewGuid();
        modelBuilder.Entity<UserProfileEntity>().HasData(
            new UserProfileEntity
            {
                Id = UserProfileEntityId1,
                Name = "John",
                LastName = "Doe",
                Phone = "123456789",
                Email = "john.doe@example.com",
                Location = "Location 1",
                Summary = "Profile Summary for John",
                ImageUrl = "/Media/ProfilePictures/ad781b18-b553-4941-ae8d-ac88c8028b59.png",
                CreatedDate = DateTime.UtcNow,
                EditedDate = DateTime.UtcNow,
                IndustryId = IndustryEntityGuid1,
                // Assuming IndustryEntityGuid1 exists in IndustryEntity table
            }
        );

// Seed UserProfileSkill
        modelBuilder.Entity<UserProfileSkillEntity>().HasData(
            new UserProfileSkillEntity { UserProfileId = UserProfileEntityId1, SkillId = SkillsEntityGuid1 },
            new UserProfileSkillEntity { UserProfileId = UserProfileEntityId1, SkillId = SkillsEntityGuid2 }
        );

// Seed UserProfileHobby
        modelBuilder.Entity<UserProfileHobbyEntity>().HasData(
            new UserProfileHobbyEntity { UserProfileId = UserProfileEntityId1, HobbyId = HobbyEntityGuid1 },
            new UserProfileHobbyEntity { UserProfileId = UserProfileEntityId1, HobbyId = HobbyEntityGuid2 }
        );

// Seed EducationEntity
        modelBuilder.Entity<EducationEntity>().HasData(
            new EducationEntity
            {
                Id = Guid.NewGuid(),
                Institution = "MIT",
                Qualification = "Computer Science",
                Duration = "4 Years",
                CreatedDate = DateTime.Now,
                EditedDate = DateTime.Now,
                UserProfileEntityId = UserProfileEntityId1
            },
            new EducationEntity
            {
                Id = Guid.NewGuid(),
                Institution = "Harvard",
                Qualification = "Engineering",
                Duration = "3 Years",
                CreatedDate = DateTime.Now,
                EditedDate = DateTime.Now,
                UserProfileEntityId = UserProfileEntityId1
            }
        );

        // Seed WorkHistoryEntity
        modelBuilder.Entity<WorkHistoryEntity>().HasData(
            new WorkHistoryEntity
            {
                Id = Guid.NewGuid(),
                Position = "Software Engineer",
                Company = "Company A",
                Duration = "2 Years",
                Description = "Worked on various projects",
                CreatedDate = DateTime.UtcNow,
                EditedDate = DateTime.UtcNow,
                UserProfileEntityId = UserProfileEntityId1
            },
            new WorkHistoryEntity
            {
                Id = Guid.NewGuid(),
                Position = "Project Manager",
                Company = "Company B",
                Duration = "4 Years",
                Description = "Managed several teams",
                CreatedDate = DateTime.UtcNow,
                EditedDate = DateTime.UtcNow,
                UserProfileEntityId = UserProfileEntityId1
            }
        );

        // Generate a Guid for the second UserProfileEntity
        var UserProfileEntityId2 = Guid.NewGuid();
        modelBuilder.Entity<UserProfileEntity>().HasData(
            new UserProfileEntity
            {
                Id = UserProfileEntityId2,
                Name = "Jane",
                LastName = "Smith",
                Phone = "987654321",
                Email = "jane.smith@example.com",
                Location = "Location 2",
                Summary = "Profile Summary for Jane",
                ImageUrl = "/Media/ProfilePictures/4da54050-12bd-49c2-afcc-ba18f9152eaa.png",
                CreatedDate = DateTime.UtcNow,
                EditedDate = DateTime.UtcNow,
                IndustryId = IndustryEntityGuid2, // Different Industry
                // Assuming IndustryEntityGuid2 exists in IndustryEntity table
            }
        );

// Seed UserProfileSkill for second user
        modelBuilder.Entity<UserProfileSkillEntity>().HasData(
            new UserProfileSkillEntity { UserProfileId = UserProfileEntityId2, SkillId = SkillsEntityGuid1 },
            new UserProfileSkillEntity
                { UserProfileId = UserProfileEntityId2, SkillId = SkillsEntityGuid3 } // Different skill
        );

// Seed UserProfileHobby for second user
        modelBuilder.Entity<UserProfileHobbyEntity>().HasData(
            new UserProfileHobbyEntity { UserProfileId = UserProfileEntityId2, HobbyId = HobbyEntityGuid2 },
            new UserProfileHobbyEntity { UserProfileId = UserProfileEntityId2, HobbyId = HobbyEntityGuid3 } // Different hobby
        );

// Seed EducationEntity for second user
        modelBuilder.Entity<EducationEntity>().HasData(
            new EducationEntity
            {
                Id = Guid.NewGuid(),
                Institution = "Stanford",
                Qualification = "Computer Engineering",
                Duration = "3 Years",
                CreatedDate = DateTime.Now,
                EditedDate = DateTime.Now,
                UserProfileEntityId = UserProfileEntityId2,
            },
            new EducationEntity
            {
                Id = Guid.NewGuid(),
                Institution = "Oxford",
                Qualification = "Mechanical Engineering",
                Duration = "2 Years",
                CreatedDate = DateTime.Now,
                EditedDate = DateTime.Now,
                UserProfileEntityId = UserProfileEntityId2,
            }
        );

// Seed WorkHistoryEntity for second user
        modelBuilder.Entity<WorkHistoryEntity>().HasData(
            new WorkHistoryEntity
            {
                Id = Guid.NewGuid(),
                Position = "Data Scientist",
                Company = "Company C",
                Duration = "3 Years",
                Description = "Worked in machine learning projects",
                CreatedDate = DateTime.UtcNow,
                EditedDate = DateTime.UtcNow,
                UserProfileEntityId = UserProfileEntityId2,
            },
            new WorkHistoryEntity
            {
                Id = Guid.NewGuid(),
                Position = "Product Manager",
                Company = "Company D",
                Duration = "5 Years",
                Description = "Developed and launched new products",
                CreatedDate = DateTime.UtcNow,
                EditedDate = DateTime.UtcNow,
                UserProfileEntityId = UserProfileEntityId2,
            }
        );
    }
}