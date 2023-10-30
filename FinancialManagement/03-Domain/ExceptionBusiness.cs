using System;
namespace FinancialManagement.Domain
{
    public class ExceptionBusiness : Exception
    {
        public ExceptionBusiness(string message) : base(message) { }

        public ExceptionBusiness(string message, Exception innerException) : base(message, innerException) { }
    }
}

