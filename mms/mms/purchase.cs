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
    public partial class purchase : Form
    {
        MySqlConnection con = null;
        public purchase()
        {
            InitializeComponent();
            con = DatabaseConnection.getDBConnection();
        }
        public purchase(string s)
        {
            InitializeComponent();
            con = DatabaseConnection.getDBConnection();

            textBox4.Text = s;
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {

            Application.OpenForms[2].Visible = true;
            while (Application.OpenForms.Count > 4) { Application.OpenForms[3].Dispose(); }
            Application.OpenForms[3].Dispose();





        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || bunifuCustomTextbox4.Text == "" || bunifuCustomTextbox5.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Fill All the Forms ");
            }
            else
            {
                try
                {
                    int x = 0;
                    int y = 0;
                    double main = Convert.ToDouble(this.bunifuCustomTextbox4.Text) * Convert.ToDouble(this.bunifuCustomTextbox5.Text);
                    double total = Convert.ToDouble(this.bunifuCustomTextbox4.Text) * Convert.ToDouble(this.bunifuCustomTextbox5.Text);



                    MySqlDataReader rdr2 = null;

                    con.Open();

                    string stm2 = "SELECT id FROM supplier where c_name = '" + textBox4.Text + "'";
                    MySqlCommand cmd2 = new MySqlCommand(stm2, con);
                    rdr2 = cmd2.ExecuteReader();

                    while (rdr2.Read())
                    {
                        string ccname = rdr2.GetString(0);

                        x = Convert.ToInt32(ccname);
                    }

                    con.Close();


                    MySqlDataReader rdr22 = null;

                    con.Open();

                    string stm22 = "SELECT id FROM stock where name = '" + textBox3.Text + "'";
                    MySqlCommand cmd22 = new MySqlCommand(stm22, con);
                    rdr22 = cmd22.ExecuteReader();

                    while (rdr22.Read())
                    {
                        string icname = rdr22.GetString(0);
                        y = Convert.ToInt32(icname);
                    }

                    con.Close();






                    con.Open();

                    string query = "INSERT INTO purchase_history (date, c_id,item_id,amount,quantity,rate) VALUES ('" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" + x + "', '" + textBox3.Text + "','" + Convert.ToDouble(this.bunifuCustomTextbox4.Text) * Convert.ToDouble(this.bunifuCustomTextbox5.Text) + "','" + Convert.ToDouble(this.bunifuCustomTextbox5.Text) + "','" + Convert.ToDouble(this.bunifuCustomTextbox4.Text) + "')";


                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, con);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    con.Close();






                    



                    con.Open();

                    string query1 = "Update supplier SET main_bal =main_bal-'" + (Convert.ToDouble(bunifuCustomLabel20.Text)) + "' where c_name = '" + textBox4.Text + "' ";


                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd1 = new MySqlCommand(query1, con);

                    //Execute command
                    cmd1.ExecuteNonQuery();

                    //close connection
                    con.Close();








               


                    con.Open();

                    string query10 = "Update totalbal  SET total_debit =total_debit+ '" + (Convert.ToDouble(bunifuCustomLabel20.Text)) + "' where id = '1' ";


                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd10 = new MySqlCommand(query10, con);

                    //Execute command
                    cmd10.ExecuteNonQuery();

                    //close connection
                    con.Close();



                    con.Open();

                    string query102 = "Update stock  SET quantity =quantity+ '" + (Convert.ToDouble(bunifuCustomTextbox5.Text)) + "' where name = '" + textBox3.Text + "'";


                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd102 = new MySqlCommand(query102, con);

                    //Execute command
                    cmd102.ExecuteNonQuery();

                    //close connection
                    con.Close();













                    MessageBox.Show("Success !!! ");
                    //end();
                    purchase m = new purchase(textBox4.Text);
            m.Show();
           this.Hide();


                }
                catch (Exception e11)
                {
                    con.Close();

                    MessageBox.Show("Error ocure Check Server PC" + e11);

                    end();
                }
            }
        }
        public void end()
        {

            purchase m = new purchase();
            m.Show();
           this.Hide();


        }
        private void purchase_Load(object sender, EventArgs e)
        {



            this.ActiveControl = textBox4;

            this.textBox4.Focus();
            MySqlDataReader rdr2 = null;



            con.Open();

            string stm2 = "SELECT c_name FROM supplier";
            MySqlCommand cmd2 = new MySqlCommand(stm2, con);
            rdr2 = cmd2.ExecuteReader();

            AutoCompleteStringCollection mm2 = new AutoCompleteStringCollection();

            while (rdr2.Read())
            {

                mm2.Add(rdr2.GetString(0));



            }
            //textBox1.AutoCompleteCustomSource = mm2;
            textBox4.AutoCompleteCustomSource = mm2;
            con.Close();


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
            //  textBox2.AutoCompleteCustomSource = mm;
            textBox3.AutoCompleteCustomSource = mm;
            con.Close();


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            MySqlDataReader rdr2 = null;

            con.Open();

            string stm2 = "SELECT unit FROM stock where name = '" + textBox3.Text + "'";
            MySqlCommand cmd2 = new MySqlCommand(stm2, con);
            rdr2 = cmd2.ExecuteReader();

            if (rdr2.Read())
            {
                bunifuCustomLabel19.Text = rdr2.GetString(0);
                bunifuCustomLabel18.Text = rdr2.GetString(0);
            }

            con.Close();




        }

        private void bunifuCustomTextbox5_TextChanged(object sender, EventArgs e)
        {



            if (bunifuCustomTextbox4.Text != "" && bunifuCustomTextbox5.Text != "")
            {

                try
                {
                    double x = Convert.ToDouble(this.bunifuCustomTextbox4.Text) * Convert.ToDouble(this.bunifuCustomTextbox5.Text);

                    bunifuCustomLabel20.Text = x.ToString("N");
                }

                catch (Exception e12)
                {
                    con.Close();

                    MessageBox.Show("THE MAXXIMUM AMOUNT RICHED" + e12);
                    bunifuCustomLabel20.Text = "0";

                }

            }
        }

        private void bunifuCustomTextbox4_TextChanged(object sender, EventArgs e)
        {
            if (bunifuCustomTextbox4.Text != "" && bunifuCustomTextbox5.Text != "")
            {

                try
                {
                    double x = Convert.ToDouble(this.bunifuCustomTextbox4.Text) * Convert.ToDouble(this.bunifuCustomTextbox5.Text);

                    bunifuCustomLabel20.Text = x.ToString();
                }

                catch (Exception e12)
                {
                    

                    MessageBox.Show("THE MAXXIMUM AMOUNT RICHED" + e12);
                    bunifuCustomLabel20.Text = "0";

                }

            }
        }

        private void bunifuCustomTextbox5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void bunifuCustomTextbox4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {





                this.ActiveControl = textBox3;

                this.textBox3.Focus();

                e.SuppressKeyPress = true;





            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter)
            {





                this.ActiveControl = bunifuCustomTextbox5;

                this.bunifuCustomTextbox5.Focus();

                e.SuppressKeyPress = true;





            }
        }

        private void bunifuCustomTextbox5_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {





                this.ActiveControl = bunifuCustomTextbox4;

                this.bunifuCustomTextbox4.Focus();

                e.SuppressKeyPress = true;





            }
        }

        private void bunifuCustomTextbox4_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {





                this.ActiveControl = bunifuCustomTextbox6;

                this.bunifuCustomTextbox6.Focus();

                e.SuppressKeyPress = true;





            }

        }

        private void bunifuCustomTextbox6_KeyDown(object sender, KeyEventArgs e)
        {
            
                   if (e.KeyCode == Keys.Enter)
            {





                this.ActiveControl = bunifuThinButton26;

                this.bunifuThinButton26.Focus();

                e.SuppressKeyPress = true;





            }
        }
    }
}