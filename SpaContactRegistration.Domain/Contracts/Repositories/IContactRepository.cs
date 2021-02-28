﻿using SpaContactRegistration.Domain.Models;
using System;

namespace SpaContactRegistration.Domain.Contracts.Repositories
{
    public interface IContactRepository :IDisposable
    {
        Contact Get(string email);
        Contact Get(Guid id);
        
        void Create(Contact contact);
        void Update(Contact contact);
        void Delete(Contact contact);
    }
}
