using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TryAgain.DAL.Entities;


namespace TryAgain.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Project> Projects { get; }
        IRepository<Programmer> Programmers { get; }
        void Save();
    }
}
