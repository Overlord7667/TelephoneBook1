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
    class ContactViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        List<Contact> contacts;
        Contact contact;
        PersonModel personModel;
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
        public Contact SelectedContact
        {
            get { return contact; }
            set
            {
                contact = value;
                Notify("SelectedContact");
            }
        }

        public ICommand AddButton
        {
            get
            {
                return new ButtonComand(new Action(() =>
                {
                    AddContact addContact = new AddContact();
                    addContact.ShowDialog();
                    Contacts = personModel.GetAllContacts();
                }));
            }
        }

        public ICommand DeleteButton
        {
            get
            {
                return new ButtonComand(new Action(() =>
                {
                    if(contact != null)
                    {
                        MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить контакт?",
                            "Удаление контакта " + contact.FirstName, MessageBoxButton.YesNo);
                        if (result == MessageBoxResult.Yes)
                        {
                            personModel.DeleteContact(contact);
                        }
                        Contacts = personModel.GetAllContacts();
                    }
                }));
            }
        }

        public ICommand UpdateButton
        {
            get
            {
                return new ButtonComand(new Action(() =>
                {
                    if(contact != null)
                    {
                        UpdateViewModel.Id = contact.Id;
                        UpdateContact updateContact = new UpdateContact();
                        updateContact.ShowDialog();
                        Contacts = personModel.GetAllContacts();
                    }
                }));
            }
        }

    }
}
