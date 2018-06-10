using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashLimit
{
    public class cashlimit_class
    {
        private static cashlimit_class instant;
        database_class database;
        public IPrimeOperations PrimeOperations;

        private cashlimit_class()
        {
            database = database_class.Create();
            PrimeOperations = new prime_operation_class(database.data);
        }

        public static cashlimit_class Create()
        {
            if (instant == null) instant = new cashlimit_class();
            return instant;
        }
    }
}
