using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace mms
{
    public partial class adjustment : Form
    {

        MySqlConnection con = null;

        string aa="";
        public adjustment()
        {
            InitializeComponent();

            con = DatabaseConnection.getDBConnection();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Application.OpenForms[2].Visible = true;
            while (Application.OpenForms.Count > 4) { Application.OpenForms[3].Dispose(); }
            Application.OpenForms[3].Dispose();
        }

        private void bunifuCustomLabel22_Click(object sender, EventArgs e)
        {

        }

        private void checkadd_OnChange(object sender, EventArgs e)
        {
            checkre.Checked = false;
             aa = "add";
        }

        private void checkre_OnChange(object sender, EventArgs e)
        {
            checkadd.Checked = false;
            aa = "reduct";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



       
        private void adjustment_Load(object sender, EventArgs e)
        {





            MySqlDataReader rdr = null;

            con.Open();

            string stm = "SELECT name FROM stock";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            rdr = cmd.ExecuteReader();

            AutoCompleteStringCollection mm = new AutoCompleteStringCollection();


            while (rdr.Read())
            {

                mm.Add(rdr.GetString(0));




            }
            textBox1.AutoCompleteCustomSource = mm;
            
            con.Close();










        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
    





        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            if (bunifuCustomTextbox7.Text == "" || textBox1.Text == ""  || (checkadd.Checked == false && checkre.Checked == false))
            {


                MessageBox.Show("Fill The Values");
            
            
            }


else{
                con.Open();

                string query = "INSERT INTO  adjusment_history (item_id,add_remove,quantity,date,remarks) VALUES ('" + textBox1.Text + "','" + aa + "','" + Convert.ToDouble(bunifuCustomTextbox7.Text) + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "','" + bunifuCustomTextbox1.Text + "')";
            MySqlCommand cmd = new MySqlCommand(query, con);


            cmd.ExecuteNonQuery();


            con.Close();
            // MessageBox.Show("COLLECTION STORED ");


            string query91 = "";
            con.Open();

            if (checkadd.Checked == true)
            {
                query91 = "Update  stock SET 	quantity=quantity+'" + Convert.ToDouble(bunifuCustomTextbox7.Text) + "'  where name ='" + textBox1.Text + "' ";
                      }
            else { query91 = "Update  stock SET 	quantity=quantity-'" + Convert.ToDouble(bunifuCustomTextbox7.Text) + "'  where name ='" + textBox1.Text + "'"; }

          

            //create command and assign the query and connection from the constructor
            MySqlCommand cmd91 = new MySqlCommand(query91, con);

            //Execute command
            cmd91.ExecuteNonQuery();

            //close connection
            con.Close();
            MessageBox.Show("Saved Successful!! ");

            textBox1.Text = "";
            bunifuCustomTextbox7.Text="";
            bunifuCustomTextbox1.Text = "";

            checkadd.Checked = false;
            checkre.Checked = false;

        }

        }

        private void bunifuCustomTextbox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomTextbox7_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 44 || e.KeyChar == 45 || e.KeyChar == 46)
            {


                e.Handled = false;

            }
            else
            {
                MessageBox.Show("Please Enter only Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Handled = true;

            }
        }
    }
}
