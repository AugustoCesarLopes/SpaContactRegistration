using SpaContactRegistration.Domain.Models;
using System;
using System.Collections.Generic;

namespace SpaContactRegistration.Domain.Contracts.Repositories
{
    public interface IContactRepository :IDisposable
    {
        Contact Get(string email);
        Contact Get(Guid id);
        List<Contact> Get(int skip, int take);
        
        void Create(Contact contact);
        void Update(Contact contact);
        void Delete(Contact contact);
    }
}
