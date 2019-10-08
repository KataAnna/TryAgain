using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TryAgain.DAL.Entities;
using TryAgain.DAL.Interfaces;

namespace TryAgain.DAL.Repositories
{
    public class ProgrammerRepository : IRepository<Programmer>
    {
        private readonly ProjectContext db;

        public ProgrammerRepository(ProjectContext context)
        {
            this.db = context;
        }

        public IEnumerable<Programmer> GetAll()
        {
            return db.Programmers;
        }

        public Programmer Get(int id)
        {
            return db.Programmers.Find(id);
        }
        [HttpPost]
        [ActionName("Create")]
        public void CreateAction(Programmer people)
        {
            db.Programmers.Add(people);
        }
        [HttpPost]
        [ActionName("Update")]
        public void UpdateAction(Programmer people)
        {
            db.Entry(people).State = EntityState.Modified;
        }
        [HttpPost]
        [ActionName("Find")]
        public IEnumerable<Programmer> FindAction(Func<Programmer, Boolean> predicate)
        {
            return db.Programmers.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Programmer people = db.Programmers.Find(id);
            if (people != null)
                db.Programmers.Remove(people);
        }

        IEnumerable<Programmer> IRepository<Programmer>.GetAll()
        {
            throw new NotImplementedException();
        }

        Programmer IRepository<Programmer>.Get(int id)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public IEnumerable<Programmer> Find(Func<Programmer, bool> predicate)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public void Create(Programmer item)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public void Update(Programmer item)
        {
            throw new NotImplementedException();
        }
    }
}
