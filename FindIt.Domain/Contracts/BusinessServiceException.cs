namespace FindIt.Domain.Contracts {
    using System;
    [Serializable]
    public class BusinessServicesException : Exception {
        public BusinessServicesException()
            : base() {
        }

        public BusinessServicesException(string message)
            : base(message) {
        }

        public BusinessServicesException(string message, Exception innerException)
            : base(message, innerException) {
        }
    }
}
