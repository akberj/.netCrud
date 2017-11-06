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

    public partial class Form1 : Form
    {
        private string updatename;
        private string gender;
        private string check = "nothing Selected";


        public Form1()
        {
            InitializeComponent();
            display();


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
            display();
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
        private void display()
        {
            string queryString =
                      "Select * From Customer";
            OdbcCommand command = new OdbcCommand(queryString);

            OdbcConnection connection = new OdbcConnection("Server=localhost;Dsn=test;uid=root;upassword=mazmaz");

            command.Connection = connection;
            connection.Open();
            command.ExecuteNonQuery();
            DataTable dt = new DataTable();
            dataGridView.DataSource = dt;
            OdbcDataAdapter da = new OdbcDataAdapter(command);
            da.Fill(dt);
            connection.Close();
        }


        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           
            
            custName.Text = dataGridView.SelectedRows[0].Cells[1].Value.ToString();
            cntrycombo.Text = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
            String gender = dataGridView.SelectedRows[0].Cells[3].Value.ToString();
            String check = dataGridView.SelectedRows[0].Cells[4].Value.ToString();
            if (gender == "Female") { radioButton2.Checked = true; } else if ( gender == "Male") { radioButton1.Checked = true; }
            if (check.IndexOf("reading") >= 0) { checkBox1.Checked = true; }else { checkBox1.Checked = false; }
            if (check.IndexOf("Painting") >=0) { checkBox2.Checked = true; } else { checkBox2.Checked = false; }

        } 
      private void dataGridView_CellBeginEdit(object sender,
 DataGridViewCellCancelEventArgs e)

      {
            
           
        }




        private void dataGridView_CellEndEdit(object sender,
        DataGridViewCellEventArgs e)
        {
           
          

            String data = dataGridView.SelectedRows[0].Cells[1].Value.ToString();
            String id = dataGridView.SelectedRows[0].Cells[0].Value.ToString();

            //private Keys Key;


            if (data != "" ) 
            {

               
                MessageBox.Show(data + updatename + data);
                string country = dataGridView.SelectedRows[0].Cells[1].Value.ToString();
                string queryString =
                             "UPDATE Customer SET name = '" + data + "' WHERE ID ='" + id + "'";
                OdbcCommand command = new OdbcCommand(queryString);

                OdbcConnection connection = new OdbcConnection("Server=localhost;Dsn=test;uid=root;upassword=mazmaz");

                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("changes succesful");
                display();


            } 
            else
            {

                MessageBox.Show("nothing changes ");
                
                return;
            
            }
           
            // MessageBox.Show("hello" + dataGridView.SelectedRows[0].Cells[0].Value.ToString());

        }




        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cntrycombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
