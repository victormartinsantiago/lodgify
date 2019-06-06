namespace VacationRental.Contact.Domain.Common.Exceptions
{
    using System;

    public class NotFoundException : BaseException
    {
        public NotFoundException(string message)
            : base(message)
        {
        }

        public NotFoundException(string message, Exception exception)
            : base(message, exception)
        {
        }

        public override int StatusCode => 404;

        public override string Title => "Not Found";
    }
}
