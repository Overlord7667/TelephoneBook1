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
    class UpdateViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public static int Id;
        PersonModel model;
        Contact firstContact, secondContact;

        public UpdateViewModel()
        {
            model = new PersonModel();
            firstContact = model.GetContact(Id);
            secondContact = new Contact()
            {
                Id = firstContact.Id,
                FirstName = firstContact.FirstName,
                LastName = firstContact.LastName,
                Phone = firstContact.Phone,
                ImageUri = firstContact.ImageUri,
                Note = firstContact.Note,
                BDay = firstContact.BDay
            };
        }

        public Contact UpdateContact
        {
            get { return secondContact; }
            set
            {
                secondContact = value;
                Notify("UpdateContact");
            }
        }

        public ICommand UpdateContactButton
        {
            get
            {
                return new ButtonComand(new Action(() =>
                {
                    model.UpdateContact(firstContact, secondContact);
                    MessageBox.Show("Изменено!");
                }));
            }
        }

    }
}
