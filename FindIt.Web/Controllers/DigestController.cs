using System;
using System.Linq;
using System.Web.Mvc;
using FindIt.Domain.Contracts;
using FindIt.Domain.Handlers.Digests;
using FindIt.Model;
using FindIt.Web.Models;
using Microsoft.Practices.ServiceLocation;

namespace FindIt.Web.Controllers {
    public class DigestController : AuthorizedController {

        public DigestController(IUserServices userServices,
            IServiceLocator serviceLocator)
            : base(userServices, serviceLocator) {
        }



        public ActionResult List(DigestPagingFilteringModel command) {

            var model = new DigestListModel();

            if (command.PageSize <= 0)
                command.PageSize = 5;
            if (command.PageNumber <= 0)
                command.PageNumber = 1;

            var digests = Using<FindDigests>().Execute(command.PageNumber - 1, command.PageSize);
            model.PagingFilteringContext.LoadPagedList(digests);

            model.Digests = digests
               .Select(x => {
                   var dm = new DigestModel();
                   PrepareDigestModel(dm, x);
                   return dm;
               }).ToList();

            return View(model);
        }

        [NonAction]
        protected void PrepareDigestModel(DigestModel model, Digest digest) {
            model.Id = digest.Id;
            model.Title = digest.Title;
            model.Brief = digest.Brief;
            model.Author = digest.Author;
            model.CategoryId = digest.CategoryId;
            model.DatePosted = digest.DatePosted;
            model.ContributorId = digest.ContributorId;
            model.DateSelected = digest.DateSelected;
            model.Deleted = digest.Deleted;
            model.FullText = digest.FullText;
            model.Source = digest.Source;
            model.LastUpdated = digest.LastUpdated;
            model.Keywords = digest.Keywords;
            model.Press = digest.Press;
            model.PressUrl = digest.PressUrl;
        }



        public ActionResult Add() {
            return View();
        }

        [HttpPost]
        public ActionResult Add(DigestFormModel digestForm) {
            if (ModelState.IsValid) {
                Using<CreateDigest>().Execute(Guid.NewGuid(), digestForm);
            }

            return View(digestForm);
        }


        public ActionResult Edit(Guid id) {
            var digest = Using<GetDigest>()
                .Execute(id);

            var digestForm = new DigestFormModel {
                Id = digest.Id,
                Title = digest.Title,
                Brief = digest.Brief,
                Author = digest.Author,
                CategoryId = digest.CategoryId,
                DatePosted = digest.DatePosted,
                ContributorId = digest.ContributorId,
                DateSelected = digest.DateSelected,
                Deleted = digest.Deleted,
                FullText = digest.FullText,
                Source = digest.Source,
                LastUpdated = digest.LastUpdated,
                Keywords = digest.Keywords,
                Press = digest.Press,
                PressUrl = digest.PressUrl
            };
            return View(digestForm);
        }

        [HttpPost]
        public ActionResult Edit(DigestFormModel digestForm) {
            if (ModelState.IsValid) {
                Using<UpdateDigest>().Execute(digestForm);
            }



            return View(digestForm);
        }

        public ActionResult Show(Guid id) {
            var digest = Using<GetDigest>()
               .Execute(id);

            var digestForm = new DigestFormModel {
                Id = digest.Id,
                Title = digest.Title,
                Brief = digest.Brief,
                Author = digest.Author,
                CategoryId = digest.CategoryId,
                DatePosted = digest.DatePosted,
                ContributorId = digest.ContributorId,
                DateSelected = digest.DateSelected,
                Deleted = digest.Deleted,
                FullText = digest.FullText,
                Source = digest.Source,
                LastUpdated = digest.LastUpdated,
                Keywords = digest.Keywords,
                Press = digest.Press,
                PressUrl = digest.PressUrl
            };
            return View(digestForm);
        }

    }
}
