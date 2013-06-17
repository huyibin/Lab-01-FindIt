//===================================================================================
// $$
//
// Coder: Code Milker v1.0
// 0 - EntityName
// 1 - Properties
//===================================================================================


namespace FindIt.Model {
    using System;

    public class Contributor {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public int Password { get; set; }

        public int PasswordSalt { get; set; }

        public string ScreenName { get; set; }

        public string RealName { get; set; }


    }
}
