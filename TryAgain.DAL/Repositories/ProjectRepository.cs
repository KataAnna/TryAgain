using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using TryAgain.DAL.Entities;
using TryAgain.DAL.Interfaces;

namespace TryAgain.DAL.Repositories
{
    public class ProjectRepository : IRepository<Project>
    {
        private readonly ProjectContext db;

        public ProjectRepository(ProjectContext context)
        {
            this.db = context;
        }

        public IEnumerable<Project> GetAll()
        {
            return db.Projects.Include(o => o.Programmer);
        }

        public Project Get(int id)
        {
            return db.Projects.Find(id);
        }
        [HttpPost]
        [ActionName("Create")]
        public void CreateAction(Project projects)
        {
            db.Projects.Add(projects);
        }
        [HttpPost]
        [ActionName("Update")]
        public void UpdateAction(Project projects)
        {
            db.Entry(projects).State = EntityState.Modified;
        }
        [HttpPost]
        [ActionName("Find")]
        public IEnumerable<Project> FindAction(Func<Project, Boolean> predicate)
        {
            return db.Projects.Include(o => o.Programmer).Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Project projects = db.Projects.Find(id);
            if (projects != null)
                db.Projects.Remove(projects);
        }

        IEnumerable<Project> IRepository<Project>.GetAll()
        {
            throw new NotImplementedException();
        }

        Project IRepository<Project>.Get(int id)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public IEnumerable<Project> Find(Func<Project, bool> predicate)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public void Create(Project item)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public void Update(Project item)
        {
            throw new NotImplementedException();
        }
    }
}
