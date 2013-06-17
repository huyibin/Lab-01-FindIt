//===================================================================================
// $$
//
// Coder: Code Milker v1.0
// 0 - upper
// 1 - lower
//===================================================================================

namespace FindIt.Domain.Handlers.Digests {
    using System;
    using FindIt.Data;
    using FindIt.Domain.Contracts;
    using FindIt.Model;

    public class GetDigest {
        private readonly IDigestRepository _digestRepository;

        public GetDigest(IDigestRepository digestRepository) {
            _digestRepository = digestRepository;
        }

        public Digest Execute(Guid digestId) {
            try {
                return _digestRepository.GetDigest(digestId);
            }
            catch (InvalidOperationException ex) {
                throw new BusinessServicesException("UnableToRetrieveReminderExceptionMessage", ex);
            }
        }
    }
}
