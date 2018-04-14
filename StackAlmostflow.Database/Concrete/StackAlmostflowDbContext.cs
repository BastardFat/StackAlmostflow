using StackAlmostflow.Entity.Models;
using StackAlmostflow.Utils;
using System;
using System.Data.Entity;
using System.Reflection;

namespace StackAlmostflow.Database.Concrete
{
    public class StackAlmostflowDbContext : DbContext
    {
        public StackAlmostflowDbContext() : base ("DefaultConnection")
        {
            System.Data.Entity.Database.SetInitializer(new Initializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Configuration.LazyLoadingEnabled = true;
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(typeof(StackAlmostflowDbContext)));
        }
    }

    class Initializer : DropCreateDatabaseIfModelChanges<StackAlmostflowDbContext>
    {
        protected override void Seed(StackAlmostflowDbContext context)
        {
            context.Set<User>().Add(new User
            {
                Login = "admin",
                Password = "admin"
            });
            base.Seed(context);
        }
    }
}
