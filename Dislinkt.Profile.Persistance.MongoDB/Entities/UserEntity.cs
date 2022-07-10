using Dislinkt.Profile.Domain.Users;
using Dislinkt.Profile.Persistance.MongoDB.Attributes;
using System;
using System.Linq;

namespace Dislinkt.Profile.Persistance.MongoDB.Entities
{
    [CollectionName("Users")]
    public class UserEntity : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Biography { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public bool IsApproved { get; set; }
        public VisibilityStatus Status { get; set; }
        public EducationEntity[] Educations { get; set; } 
        public WorkExperienceEntity[] WorkExperiences { get; set; }
        public Guid[] Skills { get; set; }
        public Guid[] Interests { get; set; }

        public Seniority Seniority { get; set; }

        public Role Role { get; set; }

        public static UserEntity ToUserEntity(User user)
        {
            return new UserEntity
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                EmailAddress = user.EmailAddress,
                Password = user.Password,
                DateOfBirth = user.DateOfBirth,
                Address = user.Address,
                City = user.City,
                Country = user.Country,
                PhoneNumber = user.PhoneNumber,
                Gender = user.Gender,
                IsApproved = user.IsApproved,
                Status = user.Status,
                Educations = EducationEntity.ToEducationEntities(user.Educations),
                WorkExperiences = WorkExperienceEntity.ToWorkExperienceEntities(user.WorkExperiences),
                Skills = user.Skills,
                Interests = user.Interests,
                Seniority=user.Seniority,
                Role=user.Role
            };
        }
        public User ToUser()
            => new User(this.Id, this.FirstName, this.LastName, this.Username, this.Biography,this.EmailAddress, this.Password,
                this.DateOfBirth, this.Address, this.City, this.Country, this.PhoneNumber, this.Gender, this.IsApproved,
                this.Status, this.Educations == null ? Array.Empty<Education>() : this.Educations.Select(p => p.ToEducation()).ToArray(),
                this.WorkExperiences == null ? Array.Empty<WorkExperience>() : this.WorkExperiences.Select(p => p.ToWorkExperience()).ToArray(),
                this.Skills ?? Array.Empty<Guid>(), this.Interests ?? Array.Empty<Guid>(),this.Seniority,this.Role);

    }
}
