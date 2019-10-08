using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TryAgain.DAL.Interfaces;
using TryAgain.DAL.Entities;
using TryAgain.DAL.Repositories;

namespace TryAgain.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly ProjectContext db;
        private ProgrammerRepository programmerRepository;
        private ProjectRepository projectRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new ProjectContext(connectionString);
        }
        public IRepository<Programmer> Programmers_data
        {
            get
            {
                if (programmerRepository == null)
                    programmerRepository = new ProgrammerRepository(db);
                return programmerRepository;
            }
        }

        public IRepository<Project> Projects_data
        {
            get
            {
                if (projectRepository == null)
                    projectRepository = new ProjectRepository(db);
                return projectRepository;
            }
        }

        public IRepository<Project> Projects => throw new NotImplementedException();

        public IRepository<Programmer> Programmers => throw new NotImplementedException();

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
