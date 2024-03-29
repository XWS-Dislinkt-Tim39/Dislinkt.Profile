﻿using Dislinkt.Profile.Core.Repositories;
using Dislinkt.Profile.Domain.Users;
using MediatR;
using System;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Profile.App.RegisterUser.Commands
{
    class RegisterUserHandler : IRequestHandler<RegisterUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        public RegisterUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
       
        public async Task<User> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByEmailAddressAndUsernameAsync(request.Request.EmailAddress, request.Request.Username);

            if(existingUser != null)
            {
                return null;
            }

            await _userRepository.CreateUserAsync(new Domain.Users.User(Guid.NewGuid(), request.Request.FirstName, request.Request.LastName, request.Request.Username, request.Request.Biography,
                request.Request.EmailAddress, BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(request.Request.Password))), request.Request.DateOfBirth, request.Request.Address, request.Request.City, request.Request.Country,
                request.Request.PhoneNumber, (Domain.Users.Gender)request.Request.Gender, 
                true, Domain.Users.VisibilityStatus.Public, Array.Empty<Education>(), 
                Array.Empty<WorkExperience>(), Array.Empty<Guid>(), Array.Empty<Guid>(), MapSeniorityData(request.Request.Seniority),Role.User));
           
            var newUser = await _userRepository.GetByEmailAddressAndUsernameAsync(request.Request.EmailAddress, request.Request.Username);

            if (newUser== null)
            {
                return null;
            }
            var id = newUser.Id.ToString();

            //SendEmailViaWebApi(request.Request.EmailAddress,id);
            return newUser;
        }
        private Seniority MapSeniorityData(SeniorityData seniorityData)
        {
            if (seniorityData == SeniorityData.Junior) return Seniority.Junior;
            if (seniorityData == SeniorityData.Medior) return Seniority.Medior;
            if (seniorityData == SeniorityData.Senior) return Seniority.Senior;

            return Seniority.Junior;
        }
        private void SendEmailViaWebApi(string receiverEmailAddress,string id)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("dislinkt@gmail.com", "SifrazaDI99!"),
                    EnableSsl = true,
                };
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("dislinkt@gmail.com"),
                    Subject = "Approve your account on Dislinkt",
                    Body = String.Format("<h3>Hello</h3> <br/> <p>Click on the link to approve your account!</p></br>http://localhost:4200/registration-confirm/{0}", id),
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(receiverEmailAddress);
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
