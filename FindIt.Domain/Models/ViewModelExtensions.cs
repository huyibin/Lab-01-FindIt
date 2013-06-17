using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FindIt.Domain.Contracts;
using FindIt.Model;

namespace FindIt.Domain.Models {
    public static class ViewModelExtensions {

        public static Category ConvertToEntity(this ICreateCategoryCommand categoryForm) {
            if (categoryForm == null)
                return null;

            var category = new Category {
                Id = categoryForm.Id,
                Name = categoryForm.Name,
                Notes = categoryForm.Notes,
                SortOrder = categoryForm.SortOrder,
                ParentId = categoryForm.ParentId,
            };

            return category;
        }

        public static Digest ConvertToEntity(this ICreateDigestCommand digestForm) {
            if (digestForm == null)
                return null;

            var digest = new Digest {
                Id = digestForm.Id,
                Title = digestForm.Title,
                Author = digestForm.Author,
                DatePosted = digestForm.DatePosted,
                Picture = digestForm.Picture,
                Width = digestForm.Width,
                Height = digestForm.Height,
                PictureFormat = digestForm.PictureFormat,
                Brief = digestForm.Brief,
                FullText = digestForm.FullText,
                Press = digestForm.Press,
                PressUrl = digestForm.PressUrl,
                Source = digestForm.Source,
                CategoryId = digestForm.CategoryId,
                Keywords = digestForm.Keywords,
                ContributorId = digestForm.ContributorId,
                Deleted = digestForm.Deleted,
                DateSelected = digestForm.DateSelected,
                LastUpdated = digestForm.LastUpdated,
            };

            return digest;
        }







    }
}
