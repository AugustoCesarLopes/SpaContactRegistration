using SpaContactRegistration.Domain.Models;
using System;
using System.Collections.Generic;

namespace SpaContactRegistration.Domain.Contracts.Services
{
    public interface IContactService : IDisposable
    {
        Contact Authenticate(string email, string password);
        Contact GetByEmail(string email);
        Contact GetById(Guid Id);
        void Register(string name, string email, string phone, string password, string confirmPassword);
        void ChangeInformation(string email, string name);
        void ChangePassword(string email, string password, string newPassword, string confirmNewPassword);
        string ResetPassword(string email);

        List<Contact> GetByRange(int skip, int take);
    }
}
