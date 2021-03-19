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
            Console.WriteLine("Hello World!");
            var contact = new Contact(
                "Augusto",
                "ac90_34567@gmail.com",
                "99999999");


            contact.SetPassword("babado", "babado");
            contact.Validate();

            using (IContactRepository cntRep = new ContactRepository())
            {
                cntRep.Create(contact);
            }

            using (IContactRepository cntRep = new ContactRepository())
            {
                var contR = cntRep.Get("ac90_34567@gmail.com");
                Console.WriteLine(contR.Email);
            }

            Console.WriteLine(contact.Name);
            Console.WriteLine(contact.Password);

            var password = contact.ResetPassword();
            Console.WriteLine(password);
            Console.WriteLine(contact.Password);

            Console.ReadKey();
        }
    }
}
