using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace helloWorlld
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void SetValues(string customer, string country, string gender, string hobbies)
        {
            materialLabel1.Text = customer;
            label4.Text = country;
            label6.Text = gender;
            label8.Text = hobbies;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
