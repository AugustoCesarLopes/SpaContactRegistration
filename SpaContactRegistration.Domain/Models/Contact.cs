using SpaContactRegistration.Common.Validation;
using System;

namespace SpaContactRegistration.Domain.Models
{
    public class Contact
    {
        #region Construtor
        protected Contact() { }

        public Contact(string name, string email, string phone)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Email = email;
            this.Telefone = phone;
        }
        #endregion

        #region Properties

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }//
        public string Password { get; private set; }

        #endregion 

        #region Methods

        public void SetPassword(string password, string confirmPassword)
        {
            AssertionConcern.AssertArgumentNotNull(password, "Errors.InvalidUserPassword");
            AssertionConcern.AssertArgumentNotNull(confirmPassword, "Errors.InvalidUserPassword");
            AssertionConcern.AssertArgumentLength(password, 6, 20, "Errors.InvalidUserPassword");
            AssertionConcern.AssertArgumentEquals(password, confirmPassword, "Errors.PasswordDoesNotMatch");

            this.Password = PasswordAssertionConcern.Encrypt(password);
        }
        public string ResetPassword()
        {
            string password = Guid.NewGuid().ToString().Substring(0, 8);
            this.Password = PasswordAssertionConcern.Encrypt(password);

            return password;
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
            PasswordAssertionConcern.AssertIsValid(this.Password);
        }

        #endregion
    }
}
