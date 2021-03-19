using SpaContactRegistration.Domain.Contracts.Repositories;
using SpaContactRegistration.Domain.Models;
using SpaContactRegistration.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaContactRegistration.Infraestructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private AppDataContext _context = new AppDataContext();
        /*
        private AppDataContext _context;

        public ContactRepository(AppDataContext context)
        {
            this._context = context;
        }
        */

        public Contact Get(string email)
        {
            return _context.Contacts.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }

        public Contact Get(Guid id)
        {
            return _context.Contacts.Where(x => x.Id == id).FirstOrDefault();
        }
        public void Create(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        public void Update(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        public void Delete(Contact contact)
        {
            _context.Entry<Contact>(contact).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public List<Contact> Get(int skip, int take)
        {
            return _context.Contacts.OrderBy(x => x.Name).Skip(skip).Take(take).ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
