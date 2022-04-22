using System;

namespace Dislinkt.Profile.Domain.Users
{
    public class User
    {
        public User(Guid id, string firstName, string lastName, string emailAddress, string password,
            string address, string city, string country, string  phoneNumber, Gender gender, bool isApproved, VisibilityStatus visibilityStatus)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            Password = password;
            Address = address;
            City = city;
            Country = country;
            PhoneNumber = phoneNumber;
            Gender = gender;
            IsApproved = isApproved;
            Status = visibilityStatus;
        }
        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get;  }
        public string EmailAddress { get; }
        public string Password { get; }
        public string Address { get; }
        public string City { get; }
        public string Country { get; }
        public string PhoneNumber { get; }
        public Gender Gender { get; }
        public bool IsApproved { get; }
        public VisibilityStatus Status { get; }
    }
}
