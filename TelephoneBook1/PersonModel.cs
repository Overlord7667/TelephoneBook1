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
        public void AddContact(Contact contact)
        {
            string query = $"INSERT INTO contacts (first_name, last_name, number_phone, images, note, birthd_date) " +
                $"VALUES ('{contact.FirstName}', '{contact.LastName}', '{contact.Phone}', '{contact.ImageUri}', '{contact.Note}', '{contact.BDay:yyyy-MM-dd}')";
            ExecuteCommand(query);
        }
        public void DeleteContact(Contact contact)
        {
            string query = $"DELETE FROM contacts WHERE id=" + contact.Id.ToString();
            ExecuteCommand(query);
        }
        public Contact GetContact(int id)
        {
            string query = $"SELECT * FROM contacts WHERE id= {id}";
            Contact contact = new Contact();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, _connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if(table.Rows.Count > 0)
            {
                contact.Id = (int)table.Rows[0].ItemArray[0];
                contact.FirstName = table.Rows[0].ItemArray[1].ToString();
                contact.LastName = table.Rows[0].ItemArray[2].ToString();
                contact.Phone = table.Rows[0].ItemArray[3].ToString();
                contact.ImageUri = table.Rows[0].ItemArray[4].ToString();
                contact.Note = table.Rows[0].ItemArray[5].ToString();
                contact.BDay = DateTime.Parse(table.Rows[0].ItemArray[6].ToString());
            }
            return contact;
        }
        public void UpdateContact(Contact first, Contact result)
        {
            string query = $"UPDATE contacts SET first_name='{result.FirstName}', last_name='{result.LastName}', number_phone='{result.Phone}', images='{result.ImageUri}', " +
                $"note='{result.Note}', birthd_date='{result.BDay:yyyy-MM-dd}' WHERE id={first.Id}";
            ExecuteCommand(query);
        }
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
