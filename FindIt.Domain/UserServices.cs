using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FindIt.Domain.Contracts;
using FindIt.Domain.Models;

namespace FindIt.Domain {
    public class UserServices : IUserServices {
        public User GetOrCreateUser(string claimedId) {
            return null;
        }
        public User GetUserByClaimedIdentifier(string claimedIdentifier) {
            return null;
        }
        public void UpdateUser(User updatedUser) {
        }
    }
}
