using System;
using System.Data.Entity;
using DAL.Interface.Repository;

namespace DAL.Concrete
{
    //Implementation Unit of Work pattern keeps track of all actions of the application that can change the database within one transaction.
    // When the transaction is completed, Unit of Work reveals all the changes and submit them to the database.
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; private set; }

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }
        //method saves changes to database
        public void Commit()
        {
            if (Context != null)
            {
                Context.SaveChanges();
            }
        }
        //IDisposable interface implementation
        public void Dispose()
        {
            Dispose(true);
            //prevents calling finalizer.
            GC.SuppressFinalize(this);
        }
        //custom function for disposing
        private void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (Context != null)
            {
                Context.Dispose();
            }
        }
    }
}
