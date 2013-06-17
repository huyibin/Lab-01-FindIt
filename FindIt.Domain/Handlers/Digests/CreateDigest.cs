//===================================================================================
// $$
//
// Coder: Code Milker v1.0
// 0 - EntityName
// 1 - Properties
//===================================================================================


namespace FindIt.Domain.Handlers.Digests {
    using System;
    using FindIt.Data;
    using FindIt.Domain.Contracts;
    using FindIt.Domain.Models;

    public class CreateDigest {
        private readonly IDigestRepository _digestRepository;

        public CreateDigest(IDigestRepository digestRepository) {
            _digestRepository = digestRepository;
        }

        public void Execute(Guid userId, ICreateDigestCommand digestForm) {
            if (digestForm == null)
                throw new ArgumentNullException("digestForm");

            try {
                var digest = digestForm.ConvertToEntity();
                _digestRepository.Create(digest);
            }
            catch (InvalidOperationException ex) {
                throw new BusinessServicesException("UnableToCreateVehicleExceptionMessage", ex);
            }
        }
    }
}
