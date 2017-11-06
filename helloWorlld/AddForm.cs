using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Odbc;

namespace helloWorlld
{

    public partial class AddForm : Form
    {
        private string updatename;
        private string gender;
        private string check = "nothing Selected";


        public AddForm()
        {
            InitializeComponent();
            


        }

        // Add Data to the database

        private void button1_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked)  { gender = "Male";}
            else if (radioButton2.Checked) { gender = "Female"; }
            else {gender = "Not Selected";}

            if (checkBox1.Checked && checkBox2.Checked) { check = checkBox1.Text + " " + checkBox2.Text; }
            
            else if (checkBox2.Checked) { check = checkBox2.Text; }
            else if (checkBox1.Checked) { check = checkBox1.Text; }

            else { check = "Nothing is selected"; }
            string customerName = custName.Text;
            string queryString =
                      "INSERT INTO Customer (name, country,gender,hobbies) Values('" + custName.Text + "','" + cntrycombo.Text + "','" + gender + "','" + check + "')";
            OdbcCommand command = new OdbcCommand(queryString);

            OdbcConnection connection = new OdbcConnection("Server=localhost;Dsn=test;uid=root;upassword=mazmaz");

            command.Connection = connection;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
           
            checkBox1.Checked = false;
            checkBox2.Checked = false; 
            custName.Text = "";
            cntrycombo.Text = "";

            MessageBox.Show(" Record has been submited");
            //Form2 obj = new Form2();
            // obj.SetValues(custName.Text, cntrycombo.Text,gender,check);
            // obj.ShowDialog();
        }

 
        //View Data for list View
    

      private void dataGridView_CellBeginEdit(object sender,
 DataGridViewCellCancelEventArgs e)

      {
            
           
        }




    


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cntrycombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
