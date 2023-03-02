using EContact.econtactClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EContact
{
    public partial class Econtact : Form
    {
        public Econtact()
        {
            InitializeComponent();
        }

        Class1 c = new Class1();


        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblIDContact_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        static string myconnstr = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBoxSearch.Text;
            SqlConnection conn = new SqlConnection(myconnstr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tbl_contact WHERE FirstName LIKE '%"+keyword+"%' OR LastName LIKE '%"+keyword+"%' OR Address LIKE '%"+keyword+"%'", conn);
            DataTable dt = new DataTable(); 
            sda.Fill(dt);
            dgvContactList.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.FirstName = textFirstName.Text;
            c.LastName = textLastName.Text;
            c.ContactNo = textContactNo.Text;
            c.Address = textAddress.Text;
            c.Gender = comboBoxGender.Text;

            bool success = c.Insert(c);
            if (success == true)
            {
                MessageBox.Show("New Contact Successfully Insert");
                Clear();
            }
            else
            {
                MessageBox.Show("Failed To Insert New Contact");
            }

            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Clear()
        {
            textFirstName.Text = "";
            textLastName.Text = "";
            textAddress.Text = "";
            textContactNo.Text = "";
            comboBoxGender.Text = "";
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            c.ContactID = int.Parse(textBox1.Text);
            c.FirstName = textFirstName.Text;
            c.LastName = textLastName.Text;
            c.ContactNo= textContactNo.Text;
            c.Address = textAddress.Text;
            c.Gender = comboBoxGender.Text;

            bool success = c.Update(c);
            if(success==true)
            {
                MessageBox.Show("Contact Has Been Updated.");
                DataTable dt = c.Select();
                dgvContactList.DataSource = dt;
                Clear();
            }
            else
            {
                MessageBox.Show("Contact Has Not Been Updated. Try Again.");
            }
        }

        private void dgvContactList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            textBox1.Text = dgvContactList.Rows[rowIndex].Cells[0].Value.ToString();
            textFirstName.Text = dgvContactList.Rows[rowIndex].Cells[1].Value.ToString();
            textLastName.Text = dgvContactList.Rows[rowIndex].Cells[2].Value.ToString();
            textContactNo.Text = dgvContactList.Rows[rowIndex].Cells[3].Value.ToString();
            textAddress.Text = dgvContactList.Rows[rowIndex].Cells[4].Value.ToString();
            comboBoxGender.Text = dgvContactList.Rows[rowIndex].Cells[5].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            c.ContactID= Convert.ToInt32(textBox1.Text);
            bool success = c.Delete(c);
            if (success==true)
            {
                MessageBox.Show("Contact Has Been Successfully Deleted.");
                DataTable dt = c.Select();
                dgvContactList.DataSource = dt;
                Clear();
            }
            else
            {
                MessageBox.Show("Contact Has Not Been Deleted. Try Again.");
            }
        }
    }
}
