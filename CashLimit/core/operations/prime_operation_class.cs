using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CashLimit
{

    public interface IPrimeOperations
    {
        void addRecord(operations op);
        void RemoveRecord(operations op);
        Task<List<operations>> getAllRecords();
    }

    public class prime_operation_class : IPrimeOperations
    {
        db_context context;

        public prime_operation_class(db_context context)
        {
            this.context = context;
        }

        public async void addRecord(operations op)
        {
            context.operations.Add(op);
           await context.SaveChangesAsync();
        }

        public async Task<List<operations>> getAllRecords()
        {
          return await context.operations.ToListAsync();
        }

        public async void RemoveRecord(operations op)
        {
            context.operations.Remove(op);
            await context.SaveChangesAsync();
        }
    }
}
