//===================================================================================
// $$
//
// Coder: Code Milker v1.0
// 0 - EntityName
// 1 - Properties
//===================================================================================

namespace FindIt.Domain.Handlers.Digests {
    using FindIt.Data;
    using FindIt.Domain.Contracts;
    using FindIt.Domain.Models;

    public class UpdateDigest {
        private readonly IDigestRepository _digestRepository;

        public UpdateDigest(IDigestRepository digestRepository) {
            _digestRepository = digestRepository;
        }

        public void Execute(ICreateDigestCommand digestForm) {
            var digest = digestForm.ConvertToEntity();

            _digestRepository.Update(digest);
        }
    }
}
