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
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        }
        IPersonModel personModel;
        Person _person;

        public ViewModel()
        {
            personModel = new PersonModel();
            _person = new Person();
        }

        public string Login
        {
            get { return _person.Header; }
            set
            {
                _person.Header = value;
                Notify("Login");
            }
        }
        
        public string Password
        {
            get { return _person.Text; }
            set
            {
                _person.Text = value;
                Notify("Password");
            }
        }

        public ICommand OpenPersonClick
        {
            get
            {
                return new ButtonComand(new Action(() =>
                {
                    Person person = personModel.GetLogin(Login, Password);
                    if (person.Header == Login && person.Text == Password)
                    {
                        ViewPersonWindows viewPersonWindows = new ViewPersonWindows();
                        viewPersonWindows.ShowDialog();
                    }
                    else
                        MessageBox.Show("Неверный логин или пароль");
                }));
            }
        }
    }
}
