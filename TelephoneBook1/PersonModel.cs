using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;

namespace TelephoneBook1
{
    class PersonModel : IPersonModel
    {
        MySqlConnection _connection;
        List<Contact> _contacts;
        

        public PersonModel()
        {
            _connection = new MySqlConnection(
                "Server=localhost;database=test_data;Uid=mysql");
            _contacts = new List<Contact>();
        }
        void ExecuteCommand(string query)
        {
            MySqlCommand command = new MySqlCommand(query, _connection);
            _connection.Open();
            command.ExecuteNonQuery();
            _connection.Close();
        }
        //public void AddPerson(Person person)
        //{
        //    string query = "INSERT INTO notes (header,text,imageuri,deadline)" +
        //        $"VALUES('{person.Header}','{person.Text}','{person.ImageUri}'," +
        //        $"'{person.DeadLine.ToString("yyyy-MM-dd")}')";
        //}
        //public Person GetPerson(int id)
        //{
        //    string query = $"SELECT * FROM notes WHERE id = {id}";
        //    Person note = new Person();
        //    MySqlDataAdapter adapter = new MySqlDataAdapter(query, _connection);
        //    DataTable table = new DataTable();
        //    adapter.Fill(table);
        //    if (table.Rows.Count > 0)
        //    {
        //        note.Id = (int)table.Rows[0].ItemArray[0];
        //        note.Header = table.Rows[0].ItemArray[1].ToString();
        //        note.Text = table.Rows[0].ItemArray[2].ToString();
        //        note.ImageUri = table.Rows[0].ItemArray[3].ToString();
        //        note.DeadLine = DateTime.Parse(table.Rows[0].ItemArray[4].ToString());
        //    }
        //    return note;
        //}

        //public void OpenPerson(Person person, Person result)
        //{
        //    string connStr = "Server=Localhost;Database=test_data;Uid=mysql;";
        //    MySqlConnection mySqlConnection = new MySqlConnection(connStr);
        //    mySqlConnection.Open();
        //    string query = $"Select * from users where login = '{person.Header}'" +
        //        $" and password='{person.Text}'";
        //    MySqlDataAdapter adapter = new MySqlDataAdapter(query, mySqlConnection);
        //    DataTable table = new DataTable();
        //    adapter.Fill(table);
        //    if (table.Rows.Count > 0)
        //    {
        //        ViewPersonWindows form = new ViewPersonWindows();
        //        form.ShowDialog();
        //        MessageBox.Show(table.Rows[0].ItemArray[0].ToString());
        //    }

        //    else
        //        MessageBox.Show("Нет такого пользователя");
        //    mySqlConnection.Close();
        //}

        //public List<Person> GetAllPersons()
        //{
        //    _persons = new List<Person>();
        //    MySqlDataAdapter adapter = new MySqlDataAdapter(
        //        "SELECT * FROM notes", _connection);
        //    DataTable table = new DataTable();
        //    adapter.Fill(table);
        //    for (int i = 0; i < table.Rows.Count; i++)
        //    {
        //        _persons.Add(new Person()
        //        {
        //            Id = (int)table.Rows[i].ItemArray[0],
        //            Header = table.Rows[i].ItemArray[1].ToString(),
        //            Text = table.Rows[i].ItemArray[2].ToString(),
        //            ImageUri = table.Rows[i].ItemArray[3].ToString(),
        //            DeadLine = DateTime.Parse
        //            (table.Rows[i].ItemArray[4].ToString())
        //        });
        //    }
        //    return _persons;
        //}

        //public List<Person> GetActualPersons()
        //{
        //    _persons = new List<Person>();
        //    MySqlDataAdapter adapter = new MySqlDataAdapter(
        //        "SELECT * FROM WHERE Deadline <= CURRENT_DATE()", _connection);
        //    DataTable table = new DataTable();
        //    adapter.Fill(table);
        //    for (int i = 0; i < table.Rows.Count; i++)
        //    {
        //        _persons.Add(new Person()
        //        {
        //            Id = (int)table.Rows[i].ItemArray[0],
        //            Header = table.Rows[i].ItemArray[1].ToString(),
        //            Text = table.Rows[i].ItemArray[2].ToString(),
        //            ImageUri = table.Rows[i].ItemArray[3].ToString(),
        //            DeadLine = DateTime.Parse
        //            (table.Rows[i].ItemArray[4].ToString())
        //        });
        //    }
        //    return _persons;
        //}

        //public Person GetNote(int id)
        //{
        //    string query = $"SELECT * FROM notes WHERE id = {id}";
        //    Person note = new Person();
        //    MySqlDataAdapter adapter = new MySqlDataAdapter(query, _connection);
        //    DataTable table = new DataTable();
        //    adapter.Fill(table);
        //    if (table.Rows.Count > 0)
        //    {
        //        note.Id = (int)table.Rows[0].ItemArray[0];
        //        note.Header = table.Rows[0].ItemArray[1].ToString();
        //        note.Text = table.Rows[0].ItemArray[2].ToString();
        //        note.ImageUri = table.Rows[0].ItemArray[3].ToString();
        //        note.DeadLine = DateTime.Parse(table.Rows[0].ItemArray[4].ToString());
        //    }
        //    return note;
        //}

        public Person GetLogin(string login, string password)
        {
            Person _person = new Person();
            string connectString = "Server=Localhost;Database=test_data;Uid=mysql";
            MySqlConnection _connection = new MySqlConnection(connectString);
            _connection.Open();
            string query = $"SELECT* FROM users WHERE login = '{login}' AND password = '{password}'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, _connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                _person.Id = (int)table.Rows[0].ItemArray[0];
                _person.Header = table.Rows[0].ItemArray[1].ToString();
                _person.Text = table.Rows[0].ItemArray[2].ToString();
                _person.DeadLine = DateTime.Parse(table.Rows[0].ItemArray[3].ToString());
            }
            _connection.Close();
            return _person;
        }

        public List<Contact> GetAllContacts()
        {
            _contacts = new List<Contact>();
            string connectString = "Server=Localhost;Database=test_data;Uid=mysql";
            MySqlConnection _connection = new MySqlConnection(connectString);
            _connection.Open();
            string query = $"SELECT* FROM contacts";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, _connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                _contacts.Add(new Contact()
                {
                    Id = (int)table.Rows[i].ItemArray[0],
                    FirstName = table.Rows[i].ItemArray[1].ToString(),
                    LastName = table.Rows[i].ItemArray[2].ToString(),
                    Phone = table.Rows[i].ItemArray[3].ToString(),
                    ImageUri = table.Rows[i].ItemArray[4].ToString(),
                    Note = table.Rows[i].ItemArray[5].ToString(),
                    BDay = DateTime.Parse(table.Rows[i].ItemArray[6].ToString())
                });
            }
            _connection.Close();
            return _contacts;
        }
    }
}
