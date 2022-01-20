using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServerUsingDapperUI
{
    public class Person
    {
        public int people_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email_address { get; set; }
        public string phone_number { get; set; }

        

        public string FullInfo
        {
            get 
            {
                return $"{ first_name} {last_name} ({email_address}) ({phone_number})";


            }
            
        }

    }
}
