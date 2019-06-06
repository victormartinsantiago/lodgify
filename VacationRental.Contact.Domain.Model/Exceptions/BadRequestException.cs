namespace VacationRental.Contact.Domain.Common.Exceptions
{
    using System;

    public class BadRequestException : BaseException
    {
        public BadRequestException(string message)
            : base(message)
        {
        }

        public BadRequestException(string message, Exception exception)
            : base(message, exception)
        {
        }

        public override int StatusCode => 400;

        public override string Title => "Bad Request";
    }
}
