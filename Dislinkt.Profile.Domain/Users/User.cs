using System;

namespace Dislinkt.Profile.Domain.Users
{
    public class User
    {
        public User(Guid id, string firstName, string lastName, string username, string biography,string emailAddress, string password, DateTime dateOfBirth, 
            string address, string city, string country, string  phoneNumber, Gender gender, bool isApproved, VisibilityStatus visibilityStatus, 
            Education[] educations, WorkExperience[] workExperiences, Guid[] skills, Guid[] interests, Seniority seniority)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            EmailAddress = emailAddress;
            Password = password;
            Biography = biography;
            DateOfBirth = dateOfBirth;
            Address = address;
            City = city;
            Country = country;
            PhoneNumber = phoneNumber;
            Gender = gender;
            IsApproved = isApproved;
            Status = visibilityStatus;
            Educations = educations;
            WorkExperiences = workExperiences;
            Skills = skills;
            Interests = interests;
            Seniority = seniority;
        }
        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get;  }
        public string Username { get; }
        public string EmailAddress { get; }
        public string Biography { get; }
        public string Password { get; }
        public string Address { get; }
        public DateTime DateOfBirth { get; }
        public string City { get; }
        public string Country { get; }
        public string PhoneNumber { get; }
        public Gender Gender { get; }
        public bool IsApproved { get; }
        public VisibilityStatus Status { get; }
        public Education[] Educations { get; }
        public WorkExperience[] WorkExperiences { get; }
        public Guid[] Skills { get; }
        public Guid[] Interests { get; }
        public Seniority Seniority { get; }
    }
}
