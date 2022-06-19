using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TelephoneBook1
{
    class AddViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        PersonModel model;
        Contact contact;

        public AddViewModel()
        {
            model = new PersonModel();
            contact = new Contact();
        }

        public Contact Contact
        {
            get { return contact; }
            set
            {
                contact = value;
                Notify("Contact");
            }
        }

        public ICommand AddContactButton
        {
            get
            {
                return new ButtonComand(new Action(() =>
                {
                    if (model.GetAllContacts().Count >= 1)
                    {
                        contact.Id = model.GetAllContacts()[model.GetAllContacts().Count - 1].Id;
                    }
                    else
                        contact.Id = 0;
                    contact.Id += 1;
                    model.AddContact(contact);
                    MessageBox.Show("Контакт добавлен!");
                }));
            }
        }
        
    }
}
