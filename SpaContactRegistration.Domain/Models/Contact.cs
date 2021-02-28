using SpaContactRegistration.Common.Validation;
using System;

namespace SpaContactRegistration.Domain.Models
{
    public class Contact
    {
        #region Construtor
        protected Contact() { }

        public Contact(string name, string email)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Email = email;
        }
        #endregion

        #region Properties

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }

        #endregion 

        #region Methods

        public void setTelefone(string telefone)
        {
            this.Telefone = telefone;
        }
       
        public void ChangeName(string name)
        {
            this.Name = name;
        }

        public void ChangeTelefone(string telefone)
        {
            this.Telefone = telefone;
        }
        /// <summary>
        /// Validar o Contato
        /// </summary>
        public void Validate()
        {
            AssertionConcern.AssertArgumentLength(this.Name, 3, 60, "Errors.InvalidContactName");
            AssertionConcern.AssertArgumentNotNull(this.Name, "");
            AssertionConcern.AssertArgumentLength(this.Telefone, 8, 12, "Errors.InvalidContactTelefone");
            AssertionConcern.AssertArgumentNotNull(this.Telefone, "");
            EmailAssertionConcern.AssertIsValid(this.Email);
        }

        #endregion
    }
}
