using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneBook1
{
    class ContactViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        List<Contact> contacts;
        Contact contact;
        IPersonModel personModel;
        public ContactViewModel()
        {
            personModel = new PersonModel();
            contact = new Contact();
            if(personModel.GetAllContacts() != null)
            {
                contacts = new List<Contact>(personModel.GetAllContacts());
            }
            else
            {
                contacts = new List<Contact>();
            }
        }

        public List<Contact> Contacts
        {
            get { return contacts; }
            set
            {
                contacts = value;
                Notify("Contacts");
            }
        }
    }
}
