using Dislinkt.Profile.Domain.Users;
using Dislinkt.Profile.Persistance.MongoDB.Attributes;

namespace Dislinkt.Profile.Persistance.MongoDB.Entities
{
    [CollectionName("Users")]
    public class UserEntity : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public bool IsApproved { get; set; }
        public VisibilityStatus Status { get; set; }
        public UserEntity ToUserEntity(User user)
        {
            return new UserEntity
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                Password = user.Password,
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
            => new User(this.Id, this.FirstName, this.LastName, this.EmailAddress, this.Password, this.Address, this.City, this.Country, this.PhoneNumber, this.Gender, this.IsApproved, this.Status);
    }
}
