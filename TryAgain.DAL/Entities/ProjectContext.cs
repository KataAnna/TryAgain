using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TryAgain.DAL.Entities
{
    public class ProjectContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Programmer> Programmers { get; set; }

        static ProjectContext()
        {
            Database.SetInitializer<ProjectContext>(new StoreDbInitializer());
        }
        public ProjectContext(string connectionString)
        : base(connectionString)
        {
        }
    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<ProjectContext>
    {
        protected void Seed(ProjectContext db)
        {
            db.Programmers.Add(new Programmer { FirstName = "Nokia Lumia 630", LastName = "Nokia", Email = "220" });
            db.Programmers.Add(new Programmer { FirstName = "iPhone 6", LastName = "Apple", Email = "320" });
            db.Programmers.Add(new Programmer { FirstName = "LG G4", LastName = "lG", Email = "260" });
            db.Programmers.Add(new Programmer { FirstName = "Samsung Galaxy S 6", LastName = "Samsung", Email = "300" });
            db.SaveChanges();
        }
    }
}
