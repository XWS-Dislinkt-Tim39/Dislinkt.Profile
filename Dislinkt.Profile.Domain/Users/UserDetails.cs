using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dislinkt.Profile.Domain.Users
{
    public class UserDetails
    {
        public UserDetails(User user,string token)
        {
            User = user;
            Token = token;

        }
        public User User { get; }
        public string Token { get; }
      
    }
}
