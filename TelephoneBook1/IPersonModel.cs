using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneBook1
{
    interface IPersonModel
    {
        // List<Person> GetAllPersons();
        // List<Person> GetActualPersons();
        // Person GetPerson(int id);
        // void OpenPerson(Person person, Person result);
        List<Contact> GetAllContacts();
        Person GetLogin(string login, string password);
       
    }
}
