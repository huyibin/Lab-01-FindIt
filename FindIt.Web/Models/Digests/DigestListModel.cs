using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindIt.Web.Models {
    public class DigestListModel {
        public DigestListModel() {
            PagingFilteringContext = new DigestPagingFilteringModel();
            Digests = new List<DigestModel>();
        }

        public DigestPagingFilteringModel PagingFilteringContext { get; set; }
        public IList<DigestModel> Digests { get; set; }
    }
}