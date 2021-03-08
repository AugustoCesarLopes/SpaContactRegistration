using Microsoft.Practices.Unity;
using SpaContactRegistration.Business.Services;
using SpaContactRegistration.Domain.Contracts.Repositories;
using SpaContactRegistration.Domain.Contracts.Services;
using SpaContactRegistration.Domain.Models;
using SpaContactRegistration.Infraestructure.Data;
using SpaContactRegistration.Infraestructure.Repositories;

namespace SpaContactRegistration.Startup
{
    public class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<AppDataContext, AppDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IContactRepository, ContactRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IContactService, ContactService>(new HierarchicalLifetimeManager());

            container.RegisterType<Contact, Contact>(new HierarchicalLifetimeManager());

        }
    }
}
