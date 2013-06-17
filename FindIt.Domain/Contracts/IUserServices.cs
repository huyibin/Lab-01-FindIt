namespace FindIt.Domain.Contracts {
    using FindIt.Domain.Models;

    public interface IUserServices {
        User GetOrCreateUser(string claimedId);
        User GetUserByClaimedIdentifier(string claimedIdentifier);
        void UpdateUser(User updatedUser);
    }
}
