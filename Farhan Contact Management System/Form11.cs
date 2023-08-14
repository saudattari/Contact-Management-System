using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Farhan_Contact_Management_System
{
    public partial class Form11 : Form
    {
        string address = "Data Source=DESKTOP-BTIF83O\\SQLEXPRESS;Initial Catalog=Contact;Integrated Security=True";
        public Form11()
        {
            InitializeComponent();
            show_data();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            show_data();
        }
        private void show_data()
        {
            SqlConnection con = new SqlConnection(address);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT *FROM Contact_details", con);
            da.Fill(dt);
            guna2DataGridView1.DataSource = dt;
            con.Close();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            name.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString ();
            mail.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            addres.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            mobile.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox1.Text = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            show_data();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            if (name.Text == "" || mobile.Text == "")
            {
                MessageBox.Show("Your Name or Mobile no field is empty");
            }
            else
            {
                if (mail.Text == "")
                {
                    mail.Text = "Email Not Present";
                }
                else if (addres.Text == "")
                {
                    addres.Text = "Address Not Present";
                }
                try
                {
                    SqlConnection con = new SqlConnection(address);
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO Contact_details(Contact_Name, Contact_Email, Contact_Address, Cotact_No) VALUES ('" + name.Text + "', '" + mail.Text + "', '" + addres.Text + "', '" + mobile.Text + "')";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Contact Details Added Successfully");
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                show_data();
            }
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            if (name.Text == "" || mobile.Text == "")
            {
                MessageBox.Show("Your Name or Mobile no field is empty");
            }
            else
            {
                if (mail.Text == "")
                {
                    mail.Text = "Email Not Present";
                }
                else if (addres.Text == "")
                {
                    addres.Text = "Address Not Present";
                }
                try
                {
                    SqlConnection con = new SqlConnection(address);
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "UPDATE Contact_details SET Contact_Name='" + name.Text + "', Contact_Email='" + mail.Text + "', Contact_Address='" + addres.Text + "', Cotact_No='" + mobile.Text + "' WHERE Contact_Id='" + Convert.ToInt32(textBox1.Text) + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Contact Details Updated Successfully");
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                show_data();
            }

        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(address);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM Contact_details WHERE Contact_Id='" + Convert.ToInt32(textBox1.Text) + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Contact Details Deleted Successfully");
            con.Close();
        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(address);
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT *FROM Contact_details WHERE Contact_Name = '"+name.Text+"' OR Cotact_No='"+mobile.Text+"' OR Contact_Email='"+mail.Text+"'",con);
            da.Fill(dt);
            guna2DataGridView1.DataSource = dt;
            con.Close();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            show_data();

        }
    }
}
