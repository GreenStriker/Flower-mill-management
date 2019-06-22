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
    public partial class productinfo : Form
    {

        MySqlConnection con = null;
        public productinfo()
        {
            InitializeComponent();
            con = DatabaseConnection.getDBConnection();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            Application.OpenForms[2].Visible = true;
            while (Application.OpenForms.Count > 4) { Application.OpenForms[3].Dispose(); }
            Application.OpenForms[3].Dispose();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            MySqlDataReader rdr2 = null;

            con.Open();

            string stm2 = "SELECT id,low_price,unit,up_price FROM stock where name = '" + textBox6.Text + "'";
            MySqlCommand cmd2 = new MySqlCommand(stm2, con);
            rdr2 = cmd2.ExecuteReader();

            if (rdr2.Read())
            {
                bunifuCustomLabel8.Text = rdr2.GetString(0);
                textBox5.Text = rdr2.GetString(1);
                textBox4.Text = rdr2.GetString(2);
                textBox1.Text = rdr2.GetString(3);
                


                








            }

            else
            {


               

            }
                
                
                con.Close();
        }

        private void productinfo_Load(object sender, EventArgs e)
        {
            MySqlDataReader rdr22 = null;


            con.Open();

            string stm22 = "SELECT name FROM stock";
            MySqlCommand cmd22 = new MySqlCommand(stm22, con);
            rdr22 = cmd22.ExecuteReader();

            AutoCompleteStringCollection mm22 = new AutoCompleteStringCollection();

            while (rdr22.Read())
            {

                mm22.Add(rdr22.GetString(0));



            }
            textBox6.AutoCompleteCustomSource = mm22;

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            
            if(bunifuCustomLabel8.Text!=""){
            
            con.Open();

            string query1 = "Update stock SET up_price = '" + textBox1.Text + "', low_price = '" + textBox5.Text + "' , unit = '" + textBox4.Text + "'   , name = '" + textBox6.Text + "'  where id = '" + bunifuCustomLabel8.Text + "' "; 


            //create command and assign the query and connection from the constructor
            MySqlCommand cmd1 = new MySqlCommand(query1, con);

            //Execute command
            cmd1.ExecuteNonQuery();

            //close connection
            con.Close();

            textBox5.Text = "";

            textBox4.Text = "";
            textBox6.Text = "";
            textBox1.Text = "";
            MessageBox.Show("SUCCESSFULL");


            main1 m = new main1();
            m.Show();
           this.Hide();



            }else{

                 MessageBox.Show("enter valid product");


            }


            



        }
    }
}
