using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CashLimit
{

    public class db_context : DbContext
    {
        public db_context() : base("DefaultConnection")
        {
        }
        public DbSet<operations> operations { get; set; }
    }


    public class database_class
    {
        private static database_class instant;
        public db_context data;
        private database_class()
        {
            data = new db_context();
        }

        public static database_class Create()
        {
            if (instant == null) instant = new database_class();
            return instant;
        }
    }
}
