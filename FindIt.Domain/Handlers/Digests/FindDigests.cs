

namespace FindIt.Domain.Handlers.Digests {
    using System.Collections.Generic;
    using FindIt.Data;
    using FindIt.Model;
    using FindIt.Infrastructure;

    public class FindDigests {
        private readonly IDigestRepository _digestRepository;

        public FindDigests(IDigestRepository digestRepository) {
            _digestRepository = digestRepository;
        }

        public IPagedList<Digest> Execute(int pageIndex, int pageSize) {
            return _digestRepository.GetAll(pageIndex, pageSize);
        }

    }
}
