namespace FindIt.Domain.Models {
    using System.ComponentModel.DataAnnotations;
    using FindIt.Domain.Properties;
    using FindIt.Domain.Validators;

    public class User {
        /// <summary>
        /// Gets or sets the identifier for the user.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user's display name.
        /// </summary>
        [StringLength(15, ErrorMessageResourceName = "UserDisplayNameStringLengthValidationError", ErrorMessageResourceType = typeof(Resources))]
        [TextLineInputValidator]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "UserDisplayNameRequired", ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = "UserDisplayNameLabelText", ResourceType = typeof(Resources))]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the authorization identifier for the user.
        /// </summary>
        [Required(ErrorMessageResourceName = "UserAuthorizationIdRequired", ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = "UserAuthorizationIdLabelText", ResourceType = typeof(Resources))]
        public string AuthorizationId { get; set; }

        /// <summary>
        /// Gets or sets the country for the user.
        /// </summary>
        [StringLength(50, ErrorMessageResourceName = "UserCountryStringLengthValidationError", ErrorMessageResourceType = typeof(Resources))]
        [TextLineInputValidator]
        [Display(Name = "UserCountryLabelText", ResourceType = typeof(Resources))]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the country for the user.
        /// </summary>
        [StringLength(10, ErrorMessageResourceName = "UserPostalCodeStringLengthValidationError", ErrorMessageResourceType = typeof(Resources))]
        [TextLineInputValidator]
        [Display(Name = "UserPostalCodeLabelText", ResourceType = typeof(Resources))]
        [PostalCodeValidator]
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user has completed or dismissed their profile registration.
        /// </summary>
        public bool HasRegistered { get; set; }
    }
}
