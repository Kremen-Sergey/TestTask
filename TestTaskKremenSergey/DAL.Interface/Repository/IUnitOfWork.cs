using System;
using System.Data.Entity;

namespace DAL.Interface.Repository
{
    //Interface for unit of work pattern
    //for greater flexibility in the application we shoud write wrapper on DbContext to be able change data base to other data source but in this example it,s enough
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }
        void Commit();
    }
}