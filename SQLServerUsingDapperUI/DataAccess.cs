using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace SQLServerUsingDapperUI
{
    public class DataAccess
    {
        public List<Person> GetPeople(string lastname)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("PeopleDB")))
            {
                var output = connection.Query<Person>($"select * from People where last_name = '{lastname}'").ToList();
                
                return output;
            }
        }

        public void InsertPerson(string FirstName, string LastName, string EmailAddress, string PhoneNumber)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("PeopleDB")))
            {
                //Person newPerson = new Person { first_name = FirstName, last_name = LastName, email_address = EmailAddress, phone_number = PhoneNumber };
                var count = connection.Query<Person>($"select people_id from People").Count();
                List <Person> people= new List<Person>();
                people.Add(new Person { first_name = FirstName, last_name = LastName, email_address = EmailAddress, phone_number = PhoneNumber });
                connection.Execute("insert into people(people_id, first_name, last_name, email_address, phone_number) " + 
                                   $"values({count + 1}, '{FirstName}', '{LastName}', '{EmailAddress}', '{PhoneNumber}')");
            }
        }
    }
}
