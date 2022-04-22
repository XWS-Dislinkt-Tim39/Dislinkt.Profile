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
        public UserEntity ToUserEntity(User user)
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
                Status = user.Status
            };
        }
        public User ToUser()
            => new User(this.Id, this.FirstName, this.LastName, this.Username, this.EmailAddress, this.Password, this.DateOfBirth, this.Address, this.City, this.Country, this.PhoneNumber, this.Gender, this.IsApproved, this.Status);
        public static UserEntity ToUserEntityWithEducation(User user)
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
                Educations = user.Educations.Select(p => EducationEntity.ToEducationEntity(p)).ToArray()
            };
        }
        public  User ToUserWithEducation()
            => new User(this.Id, this.FirstName, this.LastName, this.Username, this.EmailAddress, this.Password, this.DateOfBirth, this.Address, this.City, this.Country, this.PhoneNumber, this.Gender, this.IsApproved, this.Status, this.Educations.Select(p => p.ToEducation()).ToArray());


    }
}
