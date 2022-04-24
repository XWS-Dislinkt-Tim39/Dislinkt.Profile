using Dislinkt.Profile.Application;
using MediatR;
using System;

namespace Dislinkt.Profile.App.Users.Commands.UpdatePrivacy
{
    public class UpdatePrivacyCommand : IRequest<bool>
    {
        public UpdatePrivacyCommand(Guid userId, bool isPrivate)
        {
            this.Request = new UpdatePrivacyData
            {
                UserId = userId,
                IsPublic = isPrivate
            };
        }
        public UpdatePrivacyData Request;
    }
}
