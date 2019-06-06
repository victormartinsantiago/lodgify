namespace VacationRental.Contact.Domain.Common.Exceptions
{
    using System;

    public abstract class BaseException : Exception
    {
        protected BaseException(string message)
            : base(message)
        {
        }

        protected BaseException(string message, Exception exception)
            : base(message, exception)
        {
        }

        public abstract string Title { get; }

        public abstract int StatusCode { get; }
    }
}
