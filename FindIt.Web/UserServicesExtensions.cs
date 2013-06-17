namespace FindIt.Web {
    using FindIt.Domain.Contracts;
    using FindIt.Domain.Models;
    using FindIt.Web.Models;

    public static class UserServicesExtensions {
        public static User GetUserFromIdentity(this IUserServices services, AppIdentity identity) {
            var user = services.GetUserByClaimedIdentifier(identity.Name);
            return user;
        }
    }
}