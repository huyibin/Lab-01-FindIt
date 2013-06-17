//===================================================================================
// Digest's Form Model
//
// Coder: Code Milker v1.0
// 0 - EntityName
// 1 - Properties
//===================================================================================

namespace FindIt.Web.Models {
    using System;
    using System.ComponentModel.DataAnnotations;
    using FindIt.Domain.Contracts;

    public class DigestFormModel : ICreateDigestCommand {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime DatePosted { get; set; }

        public byte[] Picture { get; set; }

        public int? Width { get; set; }

        public int? Height { get; set; }

        public string PictureFormat { get; set; }

        public string Brief { get; set; }

        public string FullText { get; set; }

        public string Press { get; set; }

        public string PressUrl { get; set; }

        public string Source { get; set; }

        public Guid CategoryId { get; set; }

        public string Keywords { get; set; }

        public Guid ContributorId { get; set; }

        public bool Deleted { get; set; }

        public DateTime DateSelected { get; set; }

        public DateTime LastUpdated { get; set; }


    }
}
