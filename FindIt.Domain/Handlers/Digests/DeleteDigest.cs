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

    public class DeleteDigest {
        private readonly IDigestRepository _DigestRepository;

        public DeleteDigest(IDigestRepository DigestRepository) {
            _DigestRepository = DigestRepository;
        }

        public virtual void Execute(Guid digestId) {
            var DigestToDelete = _DigestRepository.GetDigest(digestId);

            if (DigestToDelete != null) {
                _DigestRepository.Delete(digestId);
            }
            else {
                throw new BusinessServicesException("UnableToDeleteVehicleExceptionMessage");
            }
        }
    }
}
