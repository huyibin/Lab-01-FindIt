//===================================================================================
// Digest's Contract
//
// Coder: Code Milker v1.0
// 0 - EntityName
// 1 - Properties
//===================================================================================

namespace FindIt.Domain.Contracts {
    using System;

    public interface ICreateDigestCommand {
        Guid Id { get; set; }

        string Title { get; set; }

        string Author { get; set; }

        DateTime DatePosted { get; set; }

        byte[] Picture { get; set; }

        int? Width { get; set; }

        int? Height { get; set; }

        string PictureFormat { get; set; }

        string Brief { get; set; }

        string FullText { get; set; }

        string Press { get; set; }

        string PressUrl { get; set; }

        string Source { get; set; }

        Guid CategoryId { get; set; }

        string Keywords { get; set; }

        Guid ContributorId { get; set; }

        bool Deleted { get; set; }

        DateTime DateSelected { get; set; }

        DateTime LastUpdated { get; set; }


    }
}
