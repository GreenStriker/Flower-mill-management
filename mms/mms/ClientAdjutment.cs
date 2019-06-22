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
    public partial class ClientAdjutment : Form
    {
        MySqlConnection con = null;
        public ClientAdjutment()
        {
            InitializeComponent();
            con = DatabaseConnection.getDBConnection();
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

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel5.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            bunifuTransition1.ShowSync(panel1);
        }

        private void ClientAdjutment_Load(object sender, EventArgs e)
        {


            //MySqlDataReader rdr2 = null;


            //con.Close();


            //con.Open();

            //string stm = "SELECT * FROM totalbal where id ='1'";
            //MySqlCommand cmd = new MySqlCommand(stm, con);
            //rdr2 = cmd.ExecuteReader();


            //double xxd = 0;

            //if (rdr2.Read())
            //{
            //    bunifuCustomLabel39.Text = rdr2.GetString("total_debit");
            //    bunifuCustomLabel33.Text = rdr2.GetString("total_credit");



            //}
            //xxd = Convert.ToDouble(bunifuCustomLabel33.Text) - Convert.ToDouble(bunifuCustomLabel39.Text);
            //// MessageBox.Show(""+xxd);
            //double cdd = Convert.ToDouble(bunifuCustomLabel32.Text); ;
            //bunifuCustomLabel36.Text = xxd.ToString();
            //con.Close();

            //try
            //{
            //    if ((Convert.ToInt32((xxd) / cdd) / 20) > 100 || (Convert.ToInt32((xxd) / cdd) / 20) < 0)
            //    { bunifuCircleProgressbar2.Value = 30; }
            //    else
            //    {
            //        bunifuCircleProgressbar2.Value = Convert.ToInt32((xxd) / cdd) / 20;
            //    }
            //}
            //catch (Exception EW)
            //{

            //    bunifuCircleProgressbar2.Value = 0;

            //}


            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            MySqlDataReader rdr288 = null;



            con.Open();

            string stm200 = "SELECT c_name FROM clients";
            MySqlCommand cmd200 = new MySqlCommand(stm200, con);
            rdr288 = cmd200.ExecuteReader();

            AutoCompleteStringCollection mm2 = new AutoCompleteStringCollection();

            while (rdr288.Read())
            {

                mm2.Add(rdr288.GetString(0));



            }
            textBox3.AutoCompleteCustomSource = mm2;
           // textBox5.AutoCompleteCustomSource = mm2;
            con.Close();









            MySqlDataReader rdr22 = null;


            con.Open();

            string stm22 = "SELECT c_name FROM supplier";
            MySqlCommand cmd22 = new MySqlCommand(stm22, con);
            rdr22 = cmd22.ExecuteReader();

            AutoCompleteStringCollection mm22 = new AutoCompleteStringCollection();

            while (rdr22.Read())
            {

                mm22.Add(rdr22.GetString(0));



            }
            textBox4.AutoCompleteCustomSource = mm22;
            textBox6.AutoCompleteCustomSource = mm22;

            con.Close();




        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            MySqlDataReader rdr2 = null;

            con.Open();

            string stm2 = "SELECT id,c_add,c_mobile,main_bal FROM clients where c_name = '" + textBox3.Text + "'";
            MySqlCommand cmd2 = new MySqlCommand(stm2, con);
            rdr2 = cmd2.ExecuteReader();

            if (rdr2.Read())
            {
                bunifuCustomLabel23.Text = rdr2.GetString(0);
                bunifuCustomLabel22.Text = rdr2.GetString(1);
                bunifuCustomLabel21.Text = rdr2.GetString(2);

                if (Convert.ToDouble(rdr2.GetString(3)) < 0)
                {
                    bunifuCustomLabel20.ForeColor = System.Drawing.Color.Red;
                }
                else
                {

                    bunifuCustomLabel20.ForeColor = System.Drawing.Color.White;

                }
                double x = Convert.ToDouble(rdr2.GetString(3));


                bunifuCustomLabel20.Text = x.ToString("N");








            } con.Close();


        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==""|| textBox3.Text=="")
            {

                MessageBox.Show("fill the boxes");
            }
            else
            {



                con.Open();

                string query1 = "Update clients SET main_bal=main_bal+'" + textBox1.Text + "'  where c_name ='" + textBox3.Text + "' ";


                //create command and assign the query and connection from the constructor
                MySqlCommand cmd1 = new MySqlCommand(query1, con);

                //Execute command
                cmd1.ExecuteNonQuery();

                //close connection
                con.Close();

                con.Open();

                string query91 = "Update  totalbal SET 	total_credit=	total_credit+'" + textBox1.Text + "'  where id ='1' ";


                //create command and assign the query and connection from the constructor
                MySqlCommand cmd91 = new MySqlCommand(query91, con);

                //Execute command
                cmd91.ExecuteNonQuery();

                //close connection
                con.Close();





                MessageBox.Show("Update Successfull");
                textBox3.Text = null;
                textBox1.Text = null;
                bunifuCustomLabel23.Text = null;
                bunifuCustomLabel22.Text = null;
                bunifuCustomLabel21.Text = null;


                bunifuCustomLabel20.Text = null;

            }





        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 45 || e.KeyChar == 44 || e.KeyChar == 46)
            {


                e.Handled = false;

            }
            else
            {
                MessageBox.Show("Please Enter only Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Handled = true;

            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            MySqlDataReader rdr2 = null;

            con.Open();

            string stm2 = "SELECT id,c_add,c_mobile,main_bal FROM supplier where c_name = '" + textBox4.Text + "'";
            MySqlCommand cmd2 = new MySqlCommand(stm2, con);
            rdr2 = cmd2.ExecuteReader();

            if (rdr2.Read())
            {
                bunifuCustomLabel12.Text = rdr2.GetString(0);
                bunifuCustomLabel10.Text = rdr2.GetString(1);
                bunifuCustomLabel9.Text = rdr2.GetString(2);

                if (Convert.ToDouble(rdr2.GetString(3)) < 0)
                {
                    bunifuCustomLabel8.ForeColor = System.Drawing.Color.Red;
                }
                else
                {

                    bunifuCustomLabel8.ForeColor = System.Drawing.Color.White;

                }
                double x = Convert.ToDouble(rdr2.GetString(3));


                bunifuCustomLabel8.Text = x.ToString("N");








            } con.Close();

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox4.Text == "")
            {

                MessageBox.Show("fill the boxes");
            }
            else
            {



                con.Open();

                string query1 = "Update supplier SET main_bal=main_bal+'" + textBox2.Text + "'  where c_name ='" + textBox4.Text + "' ";


                //create command and assign the query and connection from the constructor
                MySqlCommand cmd1 = new MySqlCommand(query1, con);

                //Execute command
                cmd1.ExecuteNonQuery();

                //close connection
                con.Close();

                con.Open();

                string query91 = "Update  totalbal SET 	total_credit=	total_credit+'" + textBox2.Text + "'  where id ='1' ";


                //create command and assign the query and connection from the constructor
                MySqlCommand cmd91 = new MySqlCommand(query91, con);

                //Execute command
                cmd91.ExecuteNonQuery();

                //close connection
                con.Close();





                MessageBox.Show("Update Successfull");
                textBox2.Text = null;
                textBox4.Text = null;
                bunifuCustomLabel12.Text = null;
                bunifuCustomLabel10.Text = null;
                bunifuCustomLabel9.Text = null;
                bunifuCustomLabel8.Text = null;

            }




        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 45 || e.KeyChar == 44 || e.KeyChar == 46)
            {


                e.Handled = false;

            }
            else
            {
                MessageBox.Show("Please Enter only Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Handled = true;

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {


            try
            {
                con.Close();

                MySqlDataReader rdr2 = null;

                con.Open();
                int x = 0;
                string stm2 = "SELECT id FROM supplier where c_name='" + textBox6.Text + "'";
                MySqlCommand cmd2 = new MySqlCommand(stm2, con);
                rdr2 = cmd2.ExecuteReader();

                if (rdr2.Read())
                {
                    string ccname = rdr2.GetString(0);

                    x = Convert.ToInt32(ccname);
                }

                con.Close();

 if(x!=0)
 {

                MySqlDataReader rdr3 = null;



                con.Open();

                string stm3 = "SELECT * FROM purchage_payment where c_id='" + x + "';";
                MySqlCommand cmd3 = new MySqlCommand(stm3, con);
                rdr3 = cmd3.ExecuteReader();


                comboBox2.Items.Clear();
                while (rdr3.Read())
                {


                    //  comboBox1.Items.Add(rdr.GetString("name"));
                    comboBox2.Items.Add(rdr3.GetString("id"));

                }

                con.Close();


                MySqlCommand cmd = new MySqlCommand("SELECT * FROM purchage_payment where c_id='" + x + "';", con);
                con.Open();
                DataTable dataTable = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                da.Fill(dataTable);


                dataGridView2.DataSource = dataTable;

                dataGridView2.Columns[0].HeaderText = "Payment ID ";





                con.Close();

 }
            }
            catch (Exception e1)
            {
                con.Close();
                MessageBox.Show("" + e1);
            }

        }

        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "") {


                
                DialogResult dialogResult = MessageBox.Show("Sure You Want To Delete ", "Some Title", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    con.Open();

    string query19 = "Delete from purchage_payment where id ='" + comboBox2.Text + "'";


    //create command and assign the query and connection from the constructor
    MySqlCommand cmd19 = new MySqlCommand(query19, con);

    //Execute command
    cmd19.ExecuteNonQuery();

    //close connection
    con.Close();


    textBox6.Text = null;
    comboBox2.Items.Clear();
    comboBox2.Text = "";
    dataGridView2.DataSource = null;
}
else if (dialogResult == DialogResult.No)
{
    //do something else
}

            
            }
            else
            {



                MessageBox.Show("PLZ FILL ALL THE BOXES") ;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {


            try
            {
                con.Close();

              

                    MySqlDataReader rdr3 = null;



                    con.Open();

                    string stm3 = "SELECT * FROM colection where c_id='" + textBox5.Text + "';";
                    MySqlCommand cmd3 = new MySqlCommand(stm3, con);
                    rdr3 = cmd3.ExecuteReader();


                    comboBox1.Items.Clear();
                    while (rdr3.Read())
                    {


                        //  comboBox1.Items.Add(rdr.GetString("name"));
                        comboBox1.Items.Add(rdr3.GetString("id"));

                    }

                    con.Close();


                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM colection where c_id='" + textBox5.Text + "';", con);
                    con.Open();
                    DataTable dataTable = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    da.Fill(dataTable);


                    dataGridView1.DataSource = dataTable;

                    dataGridView1.Columns[0].HeaderText = "Colection ID ";





                    con.Close();

                
            }
            catch (Exception e1)
            {
                con.Close();
                MessageBox.Show("" + e1);
            }

        }

        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {




                DialogResult dialogResult = MessageBox.Show("Sure You Want To Delete ", "Some Title", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    con.Open();

                    string query19 = "Delete from colection where id ='" + comboBox1.Text + "'";


                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd19 = new MySqlCommand(query19, con);

                    //Execute command
                    cmd19.ExecuteNonQuery();

                    //close connection
                    con.Close();


                    textBox5.Text = null;
                    comboBox1.Items.Clear();
                    comboBox1.Text = "";
                    dataGridView1.DataSource = null;
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }











            }
            else
            {



                MessageBox.Show("PLZ FILL ALL THE BOXES");
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel5.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            bunifuTransition1.ShowSync(panel3);
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {

            MySqlDataReader rdr2 = null;



            con.Open();

            string stm2 = "SELECT c_id FROM colection";
            MySqlCommand cmd2 = new MySqlCommand(stm2, con);
            rdr2 = cmd2.ExecuteReader();

            AutoCompleteStringCollection mm2 = new AutoCompleteStringCollection();

            while (rdr2.Read())
            {

                mm2.Add(rdr2.GetString(0));



            }
           // textBox3.AutoCompleteCustomSource = mm2;
            textBox5.AutoCompleteCustomSource = mm2;
            con.Close();
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            panel3.Visible = false;
            panel5.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            bunifuTransition1.ShowSync(panel5);
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel5.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            bunifuTransition1.ShowSync(panel2);
        }

        private void bunifuCustomTextbox1_TextChanged(object sender, EventArgs e)
        {

            if (bunifuCustomTextbox1.Text == "15289431")
            {

                bunifuTransition1.HideSync(panel6);
                //bunifuThinButton21.Visible=true;
                //    bunifuThinButton23.Visible=true;
                //    bunifuThinButton25.Visible=true;
                //    bunifuThinButton26.Visible = true;
                    bunifuTransition1.ShowSync(bunifuThinButton21);
                    bunifuTransition1.ShowSync(bunifuThinButton23);
                    bunifuTransition1.ShowSync(bunifuThinButton26);
                    bunifuTransition1.ShowSync(bunifuThinButton25);
            
            
            
            }
        }
    }
}
