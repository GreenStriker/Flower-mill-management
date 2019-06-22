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
    public partial class check : Form
    {

        MySqlConnection con = null;
        public check()
        {
            InitializeComponent();
            con = DatabaseConnection.getDBConnection();
       
        }




        public void start()
        {

         
        }




        private void check_Load(object sender, EventArgs e)
        {
           
           



        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bunifuTextbox1.text == "XDM3T-W3T3V-MGJWK-8BFVD-GVPKY")
            {
                MessageBox.Show(" Licence valied ");
                string query102 = "Update magik set licence='1'  where id ='1' ";




                con.Open();


                //create command and assign the query and connection from the constructor
                MySqlCommand cmd102 = new MySqlCommand(query102, con);

                //Execute command
                cmd102.ExecuteNonQuery();

                //close connection
                con.Close();


                login l = new login();
                l.Show();
                this.Visible = false;


            }



            else
            {


                MessageBox.Show("Invalid Licence");


            }
        }
    }
}
