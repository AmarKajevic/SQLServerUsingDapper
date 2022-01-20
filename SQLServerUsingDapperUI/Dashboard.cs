using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLServerUsingDapperUI
{
    

    public partial class Dashboard : Form
    {
        List<Person> people = new List<Person>();
        public Dashboard()
        {
            InitializeComponent();

            UpdateBinding();
        }
        private void UpdateBinding()
        {
            PeopleFoundlistBox.DataSource = people;
            PeopleFoundlistBox.DisplayMember = "FullInfo";
        }

        private void Searchbutton_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();


            people = db.GetPeople(LastNameText.Text);

            UpdateBinding();
        }

        private void InsertRecordbutton_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();

            db.InsertPerson(FirstNameinsText.Text, LastNameInsText.Text, EmailInsText.Text, PhoneInsText.Text);
           
            FirstNameinsText.Text = "";
            LastNameInsText.Text = "";
            EmailInsText.Text = "";
            PhoneInsText.Text = "";
        }
    }
}
