using SpaContactRegistration.Domain.Models;
using SpaContactRegistration.Infraestructure.Data.Map;
using System.Data.Entity;

namespace SpaContactRegistration.Infraestructure.Data
{
    public class AppDataContext: DbContext
    {
        public AppDataContext() : base("AppConnectionString")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ContactMap());
        }
    }
}
