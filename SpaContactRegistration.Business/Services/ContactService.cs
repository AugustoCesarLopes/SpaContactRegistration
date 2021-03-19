using SpaContactRegistration.Common.Validation;
using SpaContactRegistration.Domain.Contracts.Repositories;
using SpaContactRegistration.Domain.Contracts.Services;
using SpaContactRegistration.Domain.Models;
using System;
using System.Collections.Generic;

namespace SpaContactRegistration.Business.Services
{
    public class ContactService : IContactService
    {
        private IContactRepository _repository;
        public ContactService(IContactRepository repository)
        {
            _repository = repository;
        }

        public Contact Authenticate(string email, string password)
        {
            var contact = GetByEmail(email);

            if (contact.Password != PasswordAssertionConcern.Encrypt(password))
                throw new Exception("Errors.InvalidCredentials");

            return contact;
        }
        public void ChangeInformation(string email, string name)
        {
            var contact = GetByEmail(email);

            contact.ChangeName(name);
            contact.Validate();

            _repository.Update(contact);
        }

        
        public Contact GetByEmail(string email)
        {
            var contact = _repository.Get(email);
            if (contact == null)
                throw new Exception("Contato Não Encontrado");

            return contact;
        }

        public Contact GetById(Guid Id)
        {
            var contact = _repository.Get(Id);
            if (contact == null)
                throw new Exception("Contato Não Encontrado");

            return contact;
        }

        public void ChangePassword(string email, string password, string newPassword, string confirmNewPassword)
        {
            var contact = Authenticate(email, password);

            contact.SetPassword(newPassword, confirmNewPassword);
            contact.Validate();

            _repository.Update(contact);
        }
        public void Register(string name, string email, string phone, string password, string confirmPassword)
        {
            /*var hasContact = GetByEmail(email);//   _repository.Get(email)
            if (hasContact != null)
                throw new Exception("Usuario Duplicado!");
            */
            var contact = new Contact(name, email, phone);
            contact.SetPassword(password, confirmPassword);
            contact.Validate();

            _repository.Create(contact);
        }

        public string ResetPassword(string email)
        {
            var contact = GetByEmail(email);
            var password = contact.ResetPassword();
            contact.Validate();

            _repository.Update(contact);
            return password;
        }
        public List<Contact> GetByRange(int skip, int take)
        {
            return _repository.Get(skip, take);
        }
        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
