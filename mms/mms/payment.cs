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
using MySql.Data;


namespace mms
{

    //bunifuDropdown2

    public partial class payment : Form
    {
        double new_amount = 0;
        MySqlConnection con = null;
        public payment()
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

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            p1.Visible = false;
            other.Visible = false;
            ani1.ShowSync(p1);


            this.ActiveControl = textBox2;

            this.textBox2.Focus();



        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            p1.Visible = false;
            other.Visible = false;
            ani1.ShowSync(other);


            this.ActiveControl = textBox1;

            this.textBox1.Focus();

            //e.SuppressKeyPress = true;


        }

        private void payment_Load(object sender, EventArgs e)
        {


            //MySqlCommand cmd = con.CreateCommand();
            //cmd.CommandType = CommandType.Text;




            //cmd.CommandText = "Select * from login ";

            //con.Open();

            //cmd.ExecuteNonQuery();
            //DataTable dt = new DataTable();
            //MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            //da.Fill(dt);










            MySqlDataReader rdr = null;



            con.Open();

            string stm = "SELECT name FROM expence";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            rdr = cmd.ExecuteReader();

            AutoCompleteStringCollection mm = new AutoCompleteStringCollection();

            while (rdr.Read())
            {

                mm.Add(rdr.GetString(0));



            }
            textBox1.AutoCompleteCustomSource = mm;
            con.Close();





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
            textBox2.AutoCompleteCustomSource = mm2;
            con.Close();







        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

            if (textBox2.Text == "" || bunifuCustomTextbox3.Text == "" || bunifuDropdown2.Text == "")
            {

                MessageBox.Show("FILL AMOUNT AND SUPPLIER NAME AND PAYMENT TYPE");

            }

            else
            {







                int x = 0;




                try
                {


                    MySqlDataReader rdr2 = null;

                    con.Open();

                    string stm2 = "SELECT id FROM supplier where c_name = '" + textBox2.Text + "'";
                    MySqlCommand cmd2 = new MySqlCommand(stm2, con);
                    rdr2 = cmd2.ExecuteReader();

                    while (rdr2.Read())
                    {
                        string ccname = rdr2.GetString(0);

                        x = Convert.ToInt32(ccname);
                    }

                    con.Close();





                    con.Open();

                    string query = "INSERT INTO purchage_payment (date, c_id, pament_type, bank_name, check_no,remark,	amount  ) VALUES ('" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" + x + "', '" + bunifuDropdown2.Text + "', '" + tproname.Text + "', '" + bunifuCustomTextbox1.Text + "', '" + bunifuCustomTextbox2.Text + "','" + bunifuCustomTextbox3.Text + "')";


                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, con);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    con.Close();
                    //MessageBox.Show("COLLECTION STORED ");






                    new_amount = new_amount + Convert.ToDouble(bunifuCustomTextbox3.Text);




                    con.Open();

                    string query1 = "Update supplier SET main_bal = '" + new_amount + "' where c_name = '" + textBox2.Text + "' ";


                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd1 = new MySqlCommand(query1, con);

                    //Execute command
                    cmd1.ExecuteNonQuery();

                    //close connection
                    con.Close();


                    new_amount = 0;


                   // MessageBox.Show("Payment STORED ");

                    payment NewForm = new payment();
                    NewForm.Show();
                    this.Hide();

                }

                catch (Exception e22)
                {
                    con.Close();
                    MessageBox.Show(" " + e22);

                }
            }










        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            MySqlDataReader rdr2 = null;

            con.Open();

            string stm2 = "SELECT main_bal,c_mobile,c_add FROM supplier where c_name = '" + textBox2.Text + "'";
            MySqlCommand cmd2 = new MySqlCommand(stm2, con);
            rdr2 = cmd2.ExecuteReader();

            if (rdr2.Read())
            {

                if (Convert.ToDouble(rdr2.GetString(0)) < 0)
                {
                    bunifuCustomLabel9.ForeColor = System.Drawing.Color.Red;
                }
                else
                {

                    bunifuCustomLabel9.ForeColor = System.Drawing.Color.Green;

                }
                double x = Convert.ToDouble(rdr2.GetString(0));

                new_amount = x;
                bunifuCustomLabel9.Text = x.ToString("N");
                //bunifuCustomLabel18.Text = rdr2.GetString(0);

                bunifuCustomLabel22.Text = rdr2.GetString(1);
                bunifuCustomTextbox8.Text = rdr2.GetString(2);




            }
            else
            {


                bunifuCustomLabel9.Text = "";
                bunifuCustomLabel22.Text = "";
                bunifuCustomTextbox8.Text = "";


            }

            con.Close();











        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {


            if (textBox1.Text == "" || bunifuCustomTextbox4.Text == "" || bunifuDropdown5.Text == "")
            {

                MessageBox.Show("FILL AMOUNT AND SUPPLIER NAME AND PAYMENT TYPE");

            }

            else
            {

                int x = 0;




                try
                {


                    MySqlDataReader rdr2 = null;

                    con.Open();

                    string stm2 = "SELECT id FROM  expence where name = '" + textBox1.Text + "'";
                    MySqlCommand cmd2 = new MySqlCommand(stm2, con);
                    rdr2 = cmd2.ExecuteReader();

                    while (rdr2.Read())
                    {
                        string ccname = rdr2.GetString(0);

                        x = Convert.ToInt32(ccname);
                    }

                    con.Close();







                    con.Open();

                    string query = "INSERT INTO other_payment (date, expence_id, pament_type, bank_name, check_no,remark,	amount  ) VALUES ('" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" + textBox1.Text + "', '" + bunifuDropdown5.Text + "', '" + bunifuCustomTextbox7.Text + "', '" + bunifuCustomTextbox6.Text + "', '" + bunifuCustomTextbox5.Text + "','" + bunifuCustomTextbox4.Text + "')";


                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, con);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    con.Close();
                    //MessageBox.Show("COLLECTION STORED ");




                    string query102 = "Update totalbal set total_debit=total_debit+'" + bunifuCustomTextbox4.Text + "'  where id ='1' ";






                    con.Open();


                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd102 = new MySqlCommand(query102, con);

                    //Execute command
                    cmd102.ExecuteNonQuery();

                    //close connection
                    con.Close();





                   // MessageBox.Show("Payment Saved ");

                    payment NewForm = new payment();
                    NewForm.Show();
                    this.Hide();

                }

                catch (Exception e22)
                {
                    con.Close();
                    MessageBox.Show(" " + e22);

                }




            }
















        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomTextbox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8)
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
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8)
            {


                e.Handled = false;

            }
            else
            {
                MessageBox.Show("Please Enter only Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Handled = true;

            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter)
            {





                this.ActiveControl = bunifuDropdown5;

                this.bunifuDropdown5.Focus();

                e.SuppressKeyPress = true;





            }

        }

        private void bunifuDropdown5_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter)
            {





                this.ActiveControl = bunifuCustomTextbox7;

                this.bunifuCustomTextbox7.Focus();

                e.SuppressKeyPress = true;





            }
        }

        private void bunifuCustomTextbox7_KeyDown(object sender, KeyEventArgs e)
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





                this.ActiveControl = bunifuCustomTextbox4;

                this.bunifuCustomTextbox4.Focus();

                e.SuppressKeyPress = true;





            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {





                this.ActiveControl = bunifuDropdown2;

                this.bunifuDropdown2.Focus();

                e.SuppressKeyPress = true;





            }
        }

        private void bunifuDropdown2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {





                this.ActiveControl = bunifuCustomTextbox1;

                this.bunifuCustomTextbox1.Focus();

                e.SuppressKeyPress = true;





            }
        }

        private void bunifuCustomTextbox1_KeyDown(object sender, KeyEventArgs e)
        {




            if (e.KeyCode == Keys.Enter)
            {





                this.ActiveControl = tproname;

                this.tproname.Focus();

                e.SuppressKeyPress = true;





            }
        }

        private void tproname_KeyDown(object sender, KeyEventArgs e)
        {



            if (e.KeyCode == Keys.Enter)
            {





                this.ActiveControl = bunifuCustomTextbox3;

                this.bunifuCustomTextbox3.Focus();

                e.SuppressKeyPress = true;





            }
        }











    }
}
