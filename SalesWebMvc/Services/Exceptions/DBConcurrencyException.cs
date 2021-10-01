using System;

namespace SalesWebMvc.Services.Exceptions
{
    public class DBConcurrencyException:ApplicationException
    {
        public DBConcurrencyException (string message) : base(message)
        {

        }
    }
}
