using SpaContactRegistration.Domain.Contracts.Repositories;
using SpaContactRegistration.Domain.Models;
using SpaContactRegistration.Infraestructure.Repositories;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var contact = new Contact(
                "Augustus Cesar",
                "ac_34567@gmail.com");

            contact.setTelefone("62981329876");
            contact.Validate();

            using (IContactRepository contactRep = new ContactRepository())
            {
                contactRep.Create(contact);
            }

            using (ContactRepository contactRep = new ContactRepository())
            {
                var usr = contactRep.Get("ac_34567@gmail.com");
                Console.WriteLine(usr.Email);
            }

            Console.WriteLine(contact.Name);
            Console.ReadKey();

        }
    }
}
