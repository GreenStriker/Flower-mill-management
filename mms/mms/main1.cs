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
    public partial class main1 : Form
    {

        MySqlConnection con = null;




        public main1()
        {
            InitializeComponent();
            con = DatabaseConnection.getDBConnection();

            con.Close();
        }






        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            colection m = new colection();
            m.Show();
            this.Hide();
        }

        private void bunifuFlatButton10_Click(object sender, EventArgs e)
        {
            purchase m = new purchase();
            m.Show();
             this.Hide();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            stock m22 = new stock();
            m22.Show();

            // this.Hide();
               this.Hide();
        }

        private void menuButton1_Click(object sender, EventArgs e)
        {



            if (panel1.Width == 236)
            {

                panel1.Visible = false;
                panel1.Width = 45;

                pic.Visible = false;
                ani1.ShowSync(panel1);
                ani2.ShowSync(pictureBox2);


            }
            else
            {
                pictureBox2.Visible = false;
                panel1.Visible = false;
                panel1.Width = 236;
                ani1.ShowSync(panel1);

                ani1.ShowSync(pic);
            }







        }

        private void main1_Load(object sender, EventArgs e)
        {
            if (Application.OpenForms[2].Visible == false) { Application.OpenForms[2].Show(); }
            // int main1count = 0;


            for (int i = Application.OpenForms.Count - 1; i > 2; i--)
            {

                // MessageBox.Show("" + Application.OpenForms.Count);



                //if (Application.OpenForms[i].Name != "main1" || main1count != 0)
                //{
                Application.OpenForms[i].Dispose();
                //    main1count++;
                //}

                //if (Application.OpenForms[i].Name == "main1")
                //{


                //    //main1count++;
                //}
            }

           







           // MessageBox.Show("" + Application.OpenForms.Count);


        }

        private void bunifuCustomLabel5_MouseHover(object sender, EventArgs e)
        {


            if (newaddp.Visible == false)
            {

                ani1.ShowSync(newaddp);





            }
            else
            {




                ani2.HideSync(newaddp);
            }





        }



        // sizeof =1210, 490
        //  L= 166, 137

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

            ani3.HideSync(addstafp);




        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            ani3.HideSync(addprodup);
        }

        private void bunifuFlatButton12_Click(object sender, EventArgs e)
        {
            panel1.Width = 45;
            ani3.ShowSync(addstafp);
            newaddp.Visible = false;

        }

        private void bunifuFlatButton11_Click(object sender, EventArgs e)
        {
            panel1.Width = 45;
            ani3.ShowSync(addprodup);
            newaddp.Visible = false;
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            ani3.HideSync(addclip);



        }

        private void bunifuFlatButton13_Click(object sender, EventArgs e)
        {
            panel1.Width = 45;
            ani3.ShowSync(addclip);
            newaddp.Visible = false;
        }

        private void bunifuCustomTextbox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bprosub_Click(object sender, EventArgs e)
        {

            if (
               tproname.Text == "" ||
                    tproup.Text == "" ||
                    tprolow.Text == "" ||
                    tprounit.Text == "")
            {

                MessageBox.Show("Fill all the fields!");
            }

            else
            {


                try
                {
                    con.Open();

                    string query = "INSERT INTO stock (name, up_price, low_price, quantity, unit) VALUES('" + tproname.Text + "', '" + tproup.Text + "','" + tprolow.Text + "','0','" + tprounit.Text + "')";


                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, con);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    con.Close();
                    MessageBox.Show("SUCCESSFULL");
                    tproname.Text = null;
                    tproup.Text = null;
                    tprolow.Text = null;
                    tprounit.Text = null;

                }
                catch (Exception e11)
                {

                    con.Close();
                    MessageBox.Show("Error ocure Check Server PC OR Name Already Exits Use Different name");


                }

            }
        }
        private void bunifuFlatButton14_Click(object sender, EventArgs e)
        {

            if (
               bcliname.Text == "" ||
                        bclieaddress.Text == "" ||
                        bclimobi.Text == "" || bunifuCustomTextbox6.Text == "" || (checksup.Checked == false && checkcus.Checked == false))
            {

                MessageBox.Show("Fill all the fields!");
            }

            else
            {




                if (checksup.Checked == true)
                {
                    try
                    {
                        con.Open();

                        string query = "INSERT INTO supplier (c_name,c_add, c_mobile, main_bal) VALUES('" + bcliname.Text + "', '" + bclieaddress.Text + "','" + bclimobi.Text + "','" + bunifuCustomTextbox6.Text + "' )";


                        //create command and assign the query and connection from the constructor
                        MySqlCommand cmd = new MySqlCommand(query, con);

                        //Execute command
                        cmd.ExecuteNonQuery();

                        //close connection
                        con.Close();
                        MessageBox.Show("SUCCESSFULL");
                        bcliname.Text = null;
                        bclieaddress.Text = null;
                        bclimobi.Text = null;


                    }
                    catch (Exception e11)
                    {
                        con.Close();

                        MessageBox.Show("Error ocure Check Server PC OR Name Already Exits Use Different name");


                    }
                }
                else
                {






                    try
                    {
                        con.Open();

                        string query = "INSERT INTO clients (c_name,c_add, c_mobile	, main_bal) VALUES('" + bcliname.Text + "', '" + bclieaddress.Text + "','" + bclimobi.Text + "','" + bunifuCustomTextbox6.Text + "' )";


                        //create command and assign the query and connection from the constructor
                        MySqlCommand cmd = new MySqlCommand(query, con);

                        //Execute command
                        cmd.ExecuteNonQuery();

                        //close connection
                        con.Close();
                        MessageBox.Show("SUCCESSFULL");
                        bcliname.Text = null;
                        bclieaddress.Text = null;
                        bclimobi.Text = null;


                    }
                    catch (Exception e11)
                    {
                        con.Close();

                        MessageBox.Show("Error ocure Check Server PC or name already exits");


                    }
                }
            }
        }

        private void bstafsub_Click(object sender, EventArgs e)
        {



            if (bstafname.Text == "" ||
                bstafpost.Text == "" ||
                bstafaddre.Text == "" ||
                bstafmobi.Text == "" ||
                bstafsalary.Text == "")
            {

                MessageBox.Show("Fill all the fields!");
            }

            else
            {



                try
                {
                    con.Open();

                    string query = "INSERT INTO staff_info (name, join_date, post, adress, mobile,	joining_salary,	curent_salary) VALUES('" + bstafname.Text + "', '" + datestafjoin.Value.ToString("yyyy-MM-dd") + "','" + bstafpost.Text + "','" + bstafaddre.Text + "', '" + bstafmobi.Text + "','" + bstafsalary.Text + "','" + bstafsalary.Text + "')";


                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, con);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection


                    string query1 = "INSERT INTO staf_curent_month (name, present_days	, taken_amount	,	overtime_amount,	salary,main_salary) VALUES('" + bstafname.Text + "', '0', '0', '0','" + bstafsalary.Text + "','" + bstafsalary.Text + "')";


                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd1 = new MySqlCommand(query1, con);

                    //Execute command
                    cmd1.ExecuteNonQuery();


                    con.Close();




                    MessageBox.Show("SUCCESSFULL");
                    bstafname.Text = null;
                    bstafpost.Text = null;
                    bstafaddre.Text = null;
                    bstafmobi.Text = null;
                    bstafsalary.Text = null;


                }
                catch (Exception e11)
                {

                    con.Close();
                    MessageBox.Show("Error ocure Check Server PC OR Name Already Exits Use Different name");


                }
            }
        }

        private void checksup_Click(object sender, EventArgs e)
        {
            checkcus.Checked = false;
        }

        private void checkcus_OnChange(object sender, EventArgs e)
        {
            checksup.Checked = false;
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {

            payment m = new payment();
            m.Show();
               this.Hide();


        }

        private void bunifuCustomLabel28_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            ani3.HideSync(exp);
        }

        private void bunifuFlatButton16_Click(object sender, EventArgs e)
        {
            if (ten.Text == "")
            {

                MessageBox.Show("EXPENCE NAME");

            }

            else
            {
                try
                {
                    con.Open();

                    string query = "INSERT INTO expence (name) VALUES('" + ten.Text + "')";


                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, con);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    con.Close();



                    MessageBox.Show("SUCCESSFULL");
                    ten.Text = null;



                }
                catch (Exception e11)
                {
                    con.Close();

                    MessageBox.Show("Error ocure Check Server PC OR Name Already Exits Use Different name");

                }
            }
        }

        private void bunifuFlatButton15_Click(object sender, EventArgs e)
        {
            panel1.Width = 45;
            ani3.ShowSync(exp);
            newaddp.Visible = false;
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            adjustment m = new adjustment();
            m.Show();
            this.Hide();
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            sales m = new sales();
            m.Show();
            this.Hide();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

            partyleger m = new partyleger();
            m.Show();
            this.Hide();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton17_Click(object sender, EventArgs e)
        {
            kuchra m = new kuchra();
            m.Show();
            this.Hide();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            staf m = new staf();
            m.Show();
             this.Hide();
        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            ClientAdjutment m = new ClientAdjutment();
            m.Show();
            this.Hide();
        }

        private void bunifuFlatButton19_Click(object sender, EventArgs e)
        {
            productinfo m = new productinfo();
            m.Show();
             this.Hide();
        }

        private void bunifuFlatButton18_Click(object sender, EventArgs e)
        {
            partyinfo m = new partyinfo();
            m.Show();
            this.Hide();
        }

        private void exp_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addprodup_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tproup_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton21_Click(object sender, EventArgs e)
        {
            //write here

            panel1.Width = 45;
            ani3.ShowSync(panel3);
            newaddp.Visible = false;
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            //fcvcvcv
            ani3.HideSync(panel3);
        }

        private void bunifuFlatButton22_Click(object sender, EventArgs e)
        {


            if (bunifuCustomTextbox4.Text == "")
            {

                MessageBox.Show("Give NAME");

            }

            else
            {
                try
                {
                    con.Open();

                    string query = "INSERT INTO vehicle (name,driver_name,driver_no,helper_name,helper_no) VALUES('" + bunifuCustomTextbox4.Text + "','" + bunifuCustomTextbox3.Text + "','" + bunifuCustomTextbox1.Text + "','" + bunifuCustomTextbox2.Text + "','" + bunifuCustomTextbox5.Text + "')";


                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, con);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    con.Close();



                    MessageBox.Show("SUCCESSFULL");
                    bunifuCustomTextbox1.Text = null;
                    bunifuCustomTextbox2.Text = null;
                    bunifuCustomTextbox3.Text = null;
                    bunifuCustomTextbox4.Text = null;
                    bunifuCustomTextbox5.Text = null;


                }
                catch (Exception e11)
                {

                    con.Close();
                    MessageBox.Show("Error ocure Check Server PC OR Name Already Exits Use Different name");


                }









            }






        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            truckhisab m = new truckhisab();
            m.Show();
            this.Hide();
        }

        private void tproup_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tprolow_KeyPress(object sender, KeyPressEventArgs e)
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

        private void bstafsalary_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void tproup_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void tprolow_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void tprolow_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void bstafsalary_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void bunifuCustomTextbox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void bclimobi_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void bstafmobi_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void bstafmobi_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void bclimobi_KeyPress_1(object sender, KeyPressEventArgs e)
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



        private void bunifuFlatButton20_Click(object sender, EventArgs e)
        {
            report r = new report();

            r.Show();

               this.Hide();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            cassbook c = new cassbook();


            c.Show();


            this.Hide();
        }

        private void bunifuImageButton3_Click_1(object sender, EventArgs e)
        {
            ex e11 = new ex();

            e11.Show();

            this.Hide();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            partyleger e11 = new partyleger();

            e11.Show();

            this.Hide();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {

            login e11 = new login();

            e11.Show();

               this.Hide();

        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
           report  e11 = new report();

            e11.Show();

            this.Hide();
        }

        private void addclip_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {


            this.WindowState = FormWindowState.Minimized;
        }

        private void addstafp_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            cassbook c = new cassbook();

            c.Show();

            this.Hide();
        }

        private void bunifuImageButton3_Click_2(object sender, EventArgs e)
        {
            ex eww = new ex();

            eww.Show();


            this.Hide();
        }

        private void bunifuImageButton4_Click_1(object sender, EventArgs e)
        {
            partyleger py = new partyleger();

            py.Show();

            this.Hide();
        }

        private void bunifuImageButton6_Click_1(object sender, EventArgs e)
        {
            stock s = new stock();


            s.Show();


            this.Hide();
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            report r = new report();


            r.Show();



            this.Hide();
        }



    }









}
