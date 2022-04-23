using Dislinkt.Profile.Core.Repositories;
using Dislinkt.Profile.Domain.Users;
using MediatR;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dislinkt.Profile.App.RegisterUser.Commands
{
    class RegisterUserHandler : IRequestHandler<RegisterUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        public RegisterUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
       
        public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByEmailAddressAsync(request.Request.EmailAddress);

            if(existingUser != null)
            {
                return false;
            }

            await _userRepository.CreateUserAsync(new Domain.Users.User(Guid.NewGuid(), request.Request.FirstName, request.Request.LastName, request.Request.FirstName + " " + request.Request.LastName,
                request.Request.EmailAddress, request.Request.Password, request.Request.DateOfBirth, request.Request.Address, request.Request.City, request.Request.Country,
                request.Request.PhoneNumber, (Domain.Users.Gender)request.Request.Gender, 
                false, Domain.Users.VisibilityStatus.Public, Array.Empty<Education>(), 
                Array.Empty<WorkExperience>(), Array.Empty<Guid>(), Array.Empty<Guid>()));

            SendEmailViaWebApi(request.Request.EmailAddress);
            return true;
        }
        private void SendEmailViaWebApi(string receiverEmailAddress)
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
                    Body = "<h1>Hello</h1>",
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
