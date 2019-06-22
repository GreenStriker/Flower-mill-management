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
    public partial class login : Form
    {
        
      

        MySqlConnection con = null;
        public int i = 0;

        public login()
        {
            InitializeComponent();

            con = DatabaseConnection.getDBConnection();
          
        }

        private void login_Load(object sender, EventArgs e)
        {
try{
            MySqlDataReader rdr2 = null;



            con.Open();

            string stm = "SELECT * FROM magik where id ='1'";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            rdr2 = cmd.ExecuteReader();

            string loc;
            string lie;
            string exp;
            string cure;
            

            if (rdr2.Read())
            {
                loc = rdr2.GetString("lock_soft");
                lie = rdr2.GetString("licence");
                exp = rdr2.GetString("exp_date");
                cure = rdr2.GetString("last_date");




                con.Close();


                if (lie == "1")
                {

                    
                }

                else
                {
                    if (loc == "1")
                    {


                        l33.Visible = true;
                        bunifuFlatButton1.Enabled = false;


                    }
                    else
                    {

                        l33.Visible = true;
                        l33.Text = "Your Licence Will Expire On " + exp;
                       
                        string cur = DateTime.Now.ToString("MM/dd/yyyy");
                        //MessageBox.Show(cur);
                        //MessageBox.Show(cure);


                        if (DateTime.Parse(cur) >= DateTime.Parse(exp))
                        {


                            MessageBox.Show("Your Licence Has Expir0");



                            string query102 = "Update magik set lock_soft='1'  where id ='1' ";






                            con.Open();


                            //create command and assign the query and connection from the constructor
                            MySqlCommand cmd102 = new MySqlCommand(query102, con);

                            //Execute command
                            cmd102.ExecuteNonQuery();

                            //close connection
                            con.Close();

                            l33.Visible = true;
                            l33.Text = "Your Licence Has Expired On " + exp;
                            bunifuFlatButton1.Enabled = false;




                        }







                       else if (DateTime.Parse(cur) < DateTime.Parse(cure))
                        {


                            MessageBox.Show("Honesty IS The best Policy . Pay money First");



                            string query102 = "Update magik set lock_soft='1'  where id ='1' ";






                            con.Open();


                            //create command and assign the query and connection from the constructor
                            MySqlCommand cmd102 = new MySqlCommand(query102, con);

                            //Execute command
                            cmd102.ExecuteNonQuery();

                            //close connection
                            con.Close();

                            l33.Visible = true;
                            bunifuFlatButton1.Enabled = false;



                        }
                        else
                        {

                            string query102 = "Update magik set last_date='" + DateTime.Now.ToString("yyyy/MM/dd") + "'  where id ='1' ";






                            con.Open();


                            //create command and assign the query and connection from the constructor
                            MySqlCommand cmd102 = new MySqlCommand(query102, con);

                            //Execute command
                            cmd102.ExecuteNonQuery();

                            //close connection
                            con.Close();







                        }





                    }








                }








            }
            else
            {
                con.Close();

                //string expdate = DateTime.Today.AddDays(5).ToString("yyyy/MM/dd");
                //string cur = DateTime.Now.ToString("yyyy/MM/dd");

             

                con.Open();

                string query = "INSERT INTO magik ( start_day,last_date, exp_date) VALUES( '" + DateTime.Now.ToString("yyyy/MM/dd") + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "','" + DateTime.Today.AddDays(5).ToString("yyyy/MM/dd") + "')";


                //create command and assign the query and connection from the constructor
                MySqlCommand cmd11 = new MySqlCommand(query, con);

                //Execute command
                cmd11.ExecuteNonQuery();

                //close connection
                con.Close();













            }

            

        }

        catch(Exception err)
{

    MessageBox.Show("server Error");





}




































        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;




                cmd.CommandText = "Select * from login where username = '" + textBox1.Text + "'  and password = '" + textBox2.Text + "'";



                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                i = Convert.ToInt32(dt.Rows.Count.ToString());

                if (i == 1)
                {

                    if (textBox1.Text == "stock")
                    {
                        stock m = new stock(12);
                        m.Show();


                        this.Hide();

                    }else
                    { 
                    main1 m = new main1();

                    m.Show();


                    this.Hide();

                    }
                }
                else
                {

                    MessageBox.Show("errror");

                }


                con.Close();
            }

            catch(Exception e22)
            {
                con.Close();
                MessageBox.Show("Server Not Responding ");


            }



        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
          
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void l33_Click(object sender, EventArgs e)
        {
            check m = new check();


            m.Show();

           //this.Hide();






        }
    }
}
