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
using CrystalDecisions.CrystalReports.Engine;

namespace mms
{
    public partial class truckhisab : Form
    {
        ReportDocument crReportDocument;
        MySqlConnection con = null;
        public truckhisab()
        {
            InitializeComponent();
            con = DatabaseConnection.getDBConnection();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Application.OpenForms[2].Visible = true;
            while (Application.OpenForms.Count > 4) { Application.OpenForms[3].Dispose(); }
            Application.OpenForms[3].Dispose();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            ani.ShowSync(panel4);
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            ani.ShowSync(panel3);
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            ani.ShowSync(panel1);
        }

        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel5_Click(object sender, EventArgs e)
        {

        }

        private void truckhisab_Load(object sender, EventArgs e)
        {
            LoadCombo();
            reload();

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
            textBox25.AutoCompleteCustomSource = mm2;
            
            con.Close();




            bunifuDatepicker1.Value = DateTime.Now;

            bunifuDatepicker2.Value = DateTime.Now;


            bunifuDatepicker3.Value = DateTime.Now;

            bunifuDatepicker4.Value = DateTime.Now;
            






        }




        private void LoadCombo()
        {

            MySqlDataReader rdr = null;



            con.Open();

            string stm = "SELECT * FROM vehicle";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            rdr = cmd.ExecuteReader();

            

            while (rdr.Read())
            {


                comboBox1.Items.Add(rdr.GetString("name"));
                comboBox2.Items.Add(rdr.GetString("name"));

            }
           
            con.Close();
        

          
        }

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {

            try
            {

                MySqlDataReader rdr2 = null;



                con.Open();

                string stm = "SELECT * FROM vehicle where name ='"+comboBox1.Text+"'";
                MySqlCommand cmd = new MySqlCommand(stm, con);
                rdr2 = cmd.ExecuteReader();



                while (rdr2.Read())
                {
                    textBox1.Text = rdr2.GetString("driver_name");

                    textBox2.Text = rdr2.GetString("driver_no");
                    textBox4.Text = rdr2.GetString("helper_name");
                    textBox3.Text = rdr2.GetString("helper_no"); 



                }

                con.Close();


            }
            catch (System.Exception r)
            {
                con.Close();
                MessageBox.Show("error"+r);
            }


        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            con.Open();

            string query1 = "Update vehicle SET driver_name= '" + textBox1.Text + "' , driver_no ='" + textBox2.Text + "' ,helper_name ='" + textBox4.Text + "',helper_no ='" + textBox3.Text + "' where name ='" + comboBox1.Text + "' ";

          
            //create command and assign the query and connection from the constructor
            MySqlCommand cmd1 = new MySqlCommand(query1, con);

            //Execute command
            cmd1.ExecuteNonQuery();

            //close connection
            con.Close();
            comboBox1.Text = null;
            comboBox1.Items.Clear();
            comboBox2.Text = null;
            comboBox2.Items.Clear();
            LoadCombo();
            textBox1.Text = null;

            textBox2.Text = null;
            textBox4.Text = null;
            textBox3.Text = null;
            MessageBox.Show("UPDATE SUCCESSFULL ");


        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            con.Open();

            string query1 = "Delete from vehicle where name ='" + comboBox1.Text + "'";


            //create command and assign the query and connection from the constructor
            MySqlCommand cmd1 = new MySqlCommand(query1, con);

            //Execute command
            cmd1.ExecuteNonQuery();

            //close connection
            con.Close();
            comboBox1.Items.Clear();
            comboBox1.Text = null;
            LoadCombo();
            textBox1.Text = null;

            textBox2.Text = null;
            textBox4.Text = null;
            textBox3.Text = null;
            MessageBox.Show("DELETE SUCCESSFULL ");



        }

        private void bunifuThinButton26_Click(object sender, System.EventArgs e)
        {


            if (comboBox2.Text!="")
            { string dn = "";
            string dm = "";
            string hn = "";
            string hm = "";

            MySqlDataReader rdr28 = null;
            con.Open();

            string stm8 = "SELECT * FROM vehicle where name='" + comboBox2.Text + "'";
            MySqlCommand cmd8 = new MySqlCommand(stm8, con);
            rdr28 = cmd8.ExecuteReader();



            if (rdr28.Read())
            {
               // MessageBox.Show("" + dn);
                dn = rdr28.GetString("driver_name");
                dm = rdr28.GetString("driver_no");
                hn = rdr28.GetString("helper_name");
                hm = rdr28.GetString("helper_no");



            }

            con.Close();


            



            con.Open();

            string query = "INSERT INTO trip (vechile_no,dept_date,arival_date,root_1,root_2,rent,rent_2,dept_reading,arival_reading,total_km,total_rent,expenditure,driverpayoffice,driverpayparty,driverpayakkas,driverplayable,driver_name,helper_name,driver_no,helper_no) VALUES ('" + comboBox2.Text + "','" + bunifuDatepicker1.Value.ToString("yyyy-MM-dd") + "','" + bunifuDatepicker2.Value.ToString("yyyy-MM-dd") + "','" + textBox7.Text + bunifuCustomLabel16.Text + textBox5.Text + "','" + textBox8.Text + bunifuCustomLabel16.Text + textBox9.Text + "','" + textBox6.Text + "','" + textBox10.Text + "','" + textBox12.Text + "','" + textBox13.Text + "','" + (Convert.ToDouble(textBox13.Text) - Convert.ToDouble(textBox12.Text)).ToString() + "','" + (Convert.ToDouble(textBox6.Text) + Convert.ToDouble(textBox10.Text)) + "','" + textBox11.Text + "','" + textBox14.Text + "','" + textBox16.Text + "','" + textBox15.Text + "','" + (Convert.ToDouble(textBox11.Text) - (Convert.ToDouble(textBox14.Text) + Convert.ToDouble(textBox15.Text) + Convert.ToDouble(textBox16.Text))) + "','" + dn + "','" + hn + "','" + dm + "','" + hn + "')";


            MySqlCommand cmd = new MySqlCommand(query, con);

            
            cmd.ExecuteNonQuery();


            con.Close();
            MessageBox.Show("Trip Started ");


            comboBox2.Text="";
               textBox7.Text ="";
              
             textBox5.Text ="";
           textBox8.Text="";
              
              textBox9.Text="";
            textBox6.Text="";
            textBox10.Text="";
             textBox12.Text ="";
           textBox13.Text="";
            textBox13.Text="";
                textBox12.Text="";
               textBox6.Text="";
              textBox10.Text="";
            textBox11.Text="";
            textBox14.Text="";
             textBox16.Text="";
             textBox15.Text = "";
            
        }


        else{



        MessageBox.Show("First Select a vehicle");


    }
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {


            try
            {

                MySqlDataReader rdr2 = null;



                con.Open();

                string stm = "SELECT * FROM trip where id ='" + textBox29.Text + "'";
                MySqlCommand cmd = new MySqlCommand(stm, con);
                rdr2 = cmd.ExecuteReader();



                if (rdr2.Read())
                {

                    bunifuCustomLabel47.Text = rdr2.GetString("vechile_no");


                    bunifuCustomLabel69.Text = rdr2.GetString("dept_date");


                    textBox20.Text = rdr2.GetString("dept_reading");
                    textBox19.Text = rdr2.GetString("arival_reading");
                    bunifuCustomLabel41.Text = rdr2.GetString("root_1");
                    bunifuCustomLabel42.Text = rdr2.GetString("root_2");

                    textBox24.Text = rdr2.GetString("rent");
                    textBox23.Text = rdr2.GetString("rent_2");


                    bunifuCustomLabel89.Text = rdr2.GetString("expenditure");

                    textBox21.Text = rdr2.GetString("driverpayoffice");
                    textBox18.Text = rdr2.GetString("driverpayakkas");

                    textBox17.Text = rdr2.GetString("driverpayparty");
                    textBox30.Text = rdr2.GetString("cashpaytodri");

                    bunifuCustomLabel64.Text = rdr2.GetString("driverplayable").ToString();


                    bunifuCustomLabel56.Text = rdr2.GetString("driver_name");


                    bunifuCustomLabel58.Text = rdr2.GetString("driver_no");


                    bunifuCustomLabel71.Text = rdr2.GetString("helper_name");

                    bunifuCustomLabel70.Text = rdr2.GetString("helper_no");

                    textBox27.Text = rdr2.GetString("e1_n");
                    textBox33.Text = rdr2.GetString("e2_n");
                    textBox35.Text = rdr2.GetString("e3_n");
                    textBox37.Text = rdr2.GetString("e4_n");
                    textBox39.Text = rdr2.GetString("e5_n");
                    textBox41.Text = rdr2.GetString("e6_n");


                    textBox26.Text = rdr2.GetString("e1_v");
                    textBox28.Text = rdr2.GetString("e2_v");
                    textBox34.Text = rdr2.GetString("e3_v");
                    textBox36.Text = rdr2.GetString("e4_v");
                    textBox38.Text = rdr2.GetString("e5_v");
                    textBox40.Text = rdr2.GetString("e6_v");






                    if(rdr2.GetString("status")=="complete")
                    {

                        bunifuThinButton28.Visible = false;
                        bunifuThinButton27.Visible = false;

                    }
                    else
                    {
                        bunifuThinButton28.Visible = true;
                        bunifuThinButton27.Visible = true;

                    }


                    comboBox3.Text = rdr2.GetString("dcashtype");

                    textBox25.Text = rdr2.GetString("station");
                    textBox31.Text = rdr2.GetString("liter");
                    textBox32.Text = rdr2.GetString("rate");

                    bunifuCustomLabel61.Text = rdr2.GetString("amount");





                }
                else
                {


                    bunifuCustomLabel47.Text = "";


                    bunifuCustomLabel69.Text = "";


                    textBox20.Text = "";
                    textBox19.Text = "";
                    bunifuCustomLabel41.Text = "";
                    bunifuCustomLabel42.Text = "";

                    textBox24.Text = "";
                    textBox23.Text = "";


                    bunifuCustomLabel89.Text = "";

                    textBox21.Text = "";
                    textBox18.Text = "";

                    textBox17.Text = "";
                    textBox30.Text = "";

                    bunifuCustomLabel64.Text = "";


                    bunifuCustomLabel56.Text = "";

                    bunifuCustomLabel58.Text = "";


                    bunifuCustomLabel71.Text = "";

                    bunifuCustomLabel70.Text = "";

                    comboBox3.Text = "";

                    textBox25.Text = "";
                    textBox31.Text = "";
                    textBox32.Text = "";

                    bunifuCustomLabel61.Text = "";





                }

                con.Close();


            }
            catch (System.Exception r)
            {
                con.Close();
                MessageBox.Show("error" + r);
            }
        }

        private void bunifuCustomLabel60_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {



            string amu = (Convert.ToDouble(textBox31.Text) * Convert.ToDouble(textBox31.Text)).ToString();

            con.Open();



            double ccc = Convert.ToDouble(textBox26.Text)+Convert.ToDouble(textBox28.Text)+Convert.ToDouble(textBox34.Text)+Convert.ToDouble(textBox36.Text)+Convert.ToDouble(textBox38.Text)+Convert.ToDouble(textBox40.Text);



            string query1 = "Update trip SET vechile_no='" + bunifuCustomLabel47.Text + "' , dept_date='" + bunifuCustomLabel69.Text + "' , arival_date='" + bunifuDatepicker3.Value.ToString("yyyy-MM-dd") + "',dept_reading='" + textBox20.Text + "' ,arival_reading='" + textBox19.Text + "',	total_km='" + (Convert.ToDouble(textBox19.Text) - Convert.ToDouble(textBox20.Text)) + "',root_1='" + bunifuCustomLabel41.Text + "' ,root_2='" + bunifuCustomLabel42.Text + "' ,total_rent='" + (Convert.ToDouble(textBox23.Text) + Convert.ToDouble(textBox24.Text)) + "',rent='" + textBox24.Text + "',rent_2='" + textBox23.Text + "',expenditure='" + ccc.ToString() + "',driverpayoffice='" + textBox21.Text + "',driverpayakkas='" + textBox18.Text + "',driverpayparty='" + textBox17.Text + "',cashpaytodri='" + textBox30.Text + "',driverplayable='" + (ccc - (Convert.ToDouble(textBox21.Text) + Convert.ToDouble(textBox18.Text) + Convert.ToDouble(textBox17.Text) + Convert.ToDouble(textBox30.Text))) + "',driver_name='" + bunifuCustomLabel56.Text + "',driver_no='" + bunifuCustomLabel58.Text + "',helper_name='" + bunifuCustomLabel71.Text + "',helper_no='" + bunifuCustomLabel70.Text + "',dcashtype='" + comboBox3.Text + "',station='" + textBox25.Text + "',liter='" + textBox31.Text + "',rate='" + textBox32.Text + "',amount='" + amu + "', e1_n='" + textBox27.Text + "', e2_n='" + textBox33.Text + "', e3_n='" + textBox35.Text + "', e4_n='" + textBox37.Text + "', e5_n='" + textBox39.Text + "', e6_n='" + textBox41.Text + "' , e1_v='" + textBox26.Text + "', e2_v='" + textBox28.Text + "', e3_v='" + textBox34.Text + "', e4_v='" + textBox36.Text + "', e5_v='" + textBox38.Text + "', e6_v='" + textBox40.Text + "'   where id ='" + textBox29.Text + "' ";


            //create command and assign the query and connection from the constructor
            MySqlCommand cmd1 = new MySqlCommand(query1, con);

            //Execute command
            cmd1.ExecuteNonQuery();
             
            //close connection
            con.Close();


            MessageBox.Show("Updated");
            comboBox2.Text = "";
            bunifuCustomLabel47.Text = "";


            bunifuCustomLabel69.Text = "";


            textBox20.Text = "";
            textBox19.Text = "";
            bunifuCustomLabel41.Text = "";
            bunifuCustomLabel42.Text = "";

            textBox24.Text = "";
            textBox23.Text = "";


            bunifuCustomLabel89.Text = "";

            textBox21.Text = "";
            textBox18.Text = "";

            textBox17.Text = "";
            textBox30.Text = "";

            bunifuCustomLabel64.Text = "";


            bunifuCustomLabel56.Text = "";

            bunifuCustomLabel58.Text = "";


            bunifuCustomLabel71.Text = "";

            bunifuCustomLabel70.Text = "";

            comboBox3.Text = "";

            textBox25.Text = "";
            textBox31.Text = "";
            textBox32.Text = "";

            bunifuCustomLabel61.Text = "";

            textBox27.Text = "";
            textBox33.Text = "";
            textBox35.Text = "";
            textBox37.Text = "";
            textBox39.Text = "";
            textBox41.Text = "";


            textBox26.Text = "";
            textBox28.Text = "";
            textBox34.Text = "";
            textBox36.Text = "";
            textBox38.Text = "";
            textBox40.Text = "";


        }

        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {
             DialogResult dialogResult = MessageBox.Show("Sure You Want To Finish The Trip !! ", "Some Title", MessageBoxButtons.YesNo);
             if (dialogResult == DialogResult.Yes)
             {
                 string amu = (Convert.ToDouble(textBox31.Text) * Convert.ToDouble(textBox31.Text)).ToString();

                 con.Open();
                 double ccc = Convert.ToDouble(textBox26.Text) + Convert.ToDouble(textBox28.Text) + Convert.ToDouble(textBox34.Text) + Convert.ToDouble(textBox36.Text) + Convert.ToDouble(textBox38.Text) + Convert.ToDouble(textBox40.Text);

                 string query1 = "Update trip SET vechile_no='" + bunifuCustomLabel47.Text + "',status='complete' , dept_date='" + bunifuCustomLabel69.Text + "' , arival_date='" + bunifuDatepicker3.Value.ToString("yyyy-MM-dd") + "',dept_reading='" + textBox20.Text + "' ,arival_reading='" + textBox19.Text + "',	total_km='" + (Convert.ToDouble(textBox19.Text) - Convert.ToDouble(textBox20.Text)) + "',root_1='" + bunifuCustomLabel41.Text + "' ,root_2='" + bunifuCustomLabel42.Text + "' ,total_rent='" + (Convert.ToDouble(textBox23.Text) + Convert.ToDouble(textBox24.Text)) + "',rent='" + textBox24.Text + "',rent_2='" + textBox23.Text + "',expenditure='" + ccc + "',driverpayoffice='" + textBox21.Text + "',driverpayakkas='" + textBox18.Text + "',driverpayparty='" + textBox17.Text + "',cashpaytodri='" + textBox30.Text + "',driverplayable='" + (ccc - (Convert.ToDouble(textBox21.Text) + Convert.ToDouble(textBox18.Text) + Convert.ToDouble(textBox17.Text) + Convert.ToDouble(textBox30.Text))) + "',driver_name='" + bunifuCustomLabel56.Text + "',driver_no='" + bunifuCustomLabel58.Text + "',helper_name='" + bunifuCustomLabel71.Text + "',helper_no='" + bunifuCustomLabel70.Text + "',dcashtype='" + comboBox3.Text + "',station='" + textBox25.Text + "',liter='" + textBox31.Text + "',rate='" + textBox32.Text + "',amount='" + amu + "', e1_n='" + textBox27.Text + "', e2_n='" + textBox33.Text + "', e3_n='" + textBox35.Text + "', e4_n='" + textBox37.Text + "', e5_n='" + textBox39.Text + "', e6_n='" + textBox41.Text + "' , e1_v='" + textBox26.Text + "', e2_v='" + textBox28.Text + "', e3_v='" + textBox34.Text + "', e4_v='" + textBox36.Text + "', e5_v='" + textBox38.Text + "', e6_v='" + textBox40.Text + "'   where id ='" + textBox29.Text + "' ";


                 //create command and assign the query and connection from the constructor
                 MySqlCommand cmd1 = new MySqlCommand(query1, con);

                 //Execute command
                 cmd1.ExecuteNonQuery();

                 //close connection
                 con.Close();


                 MessageBox.Show("Updated");
                 comboBox2.Text = "";
                 bunifuCustomLabel47.Text = "";


                 bunifuCustomLabel69.Text = "";


                 textBox20.Text = "";
                 textBox19.Text = "";
                 bunifuCustomLabel41.Text = "";
                 bunifuCustomLabel42.Text = "";

                 textBox24.Text = "";
                 textBox23.Text = "";


                 bunifuCustomLabel89.Text = "";

                 textBox21.Text = "";
                 textBox18.Text = "";

                 textBox17.Text = "";
                 textBox30.Text = "";

                 bunifuCustomLabel64.Text = "";


                 bunifuCustomLabel56.Text = "";

                 bunifuCustomLabel58.Text = "";


                 bunifuCustomLabel71.Text = "";

                 bunifuCustomLabel70.Text = "";

                 comboBox3.Text = "";

                 textBox25.Text = "";
                 textBox31.Text = "";
                 textBox32.Text = "";

                 bunifuCustomLabel61.Text = "";


                 MySqlDataReader rdr2 = null;



                 con.Open();

                 string stm = "SELECT * FROM trip where id ='" + textBox29.Text + "'";
                 MySqlCommand cmd = new MySqlCommand(stm, con);
                 rdr2 = cmd.ExecuteReader();

                 string trent = "";
                 string expence = "";
                 string oil = "";
                 string sup = "";


                 if (rdr2.Read())
                 {


                     trent = rdr2.GetString("total_rent");


                     expence = rdr2.GetString("expenditure");

                     oil = rdr2.GetString("amount");
                     sup = rdr2.GetString("station");




                 }
                 double cal = Convert.ToDouble(trent) - (Convert.ToDouble(expence) + Convert.ToDouble(oil));
                 MessageBox.Show("" + cal);
                 con.Close();
                 if (comboBox3.Text == "Due")
                 {
                     con.Open();

                     string query13 = "Update supplier SET main_bal=main_bal+'" + oil + "'  where c_name ='" + sup + "' ";


                     //create command and assign the query and connection from the constructor
                     MySqlCommand cmd13 = new MySqlCommand(query13, con);

                     //Execute command
                     cmd13.ExecuteNonQuery();

                     //close connection
                     con.Close();

                     con.Open();

                     string query91 = "Update  totalbal SET 	total_credit=	total_credit+'" + cal + "'  where id ='1' ";


                     //create command and assign the query and connection from the constructor
                     MySqlCommand cmd91 = new MySqlCommand(query91, con);

                     //Execute command
                     cmd91.ExecuteNonQuery();

                     //close connection
                     con.Close();




                 }
                 else
                 {

                     con.Open();

                     string query91 = "Update  totalbal SET 	total_credit=	total_credit+'" + cal + "'  where id ='1' ";


                     //create command and assign the query and connection from the constructor
                     MySqlCommand cmd91 = new MySqlCommand(query91, con);

                     //Execute command
                     cmd91.ExecuteNonQuery();

                     //close connection
                     con.Close();



                 }




             }













        }

        private void bunifuThinButton210_Click(object sender, EventArgs e)
        {

            reload();

            
        }



       private void reload ()
        {



            MySqlCommand cmd = new MySqlCommand("SELECT * FROM trip where  dept_date >='" + bunifuDatepicker4.Value.ToString("yyyy-MM-dd") + "';", con);
            con.Open();
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dataTable);


            dataGridView2.DataSource = dataTable;

            dataGridView2.Columns[0].HeaderText = "Trip ID ";





            con.Close();



        }

       private void bunifuThinButton25_Click(object sender, EventArgs e)
       {
           panel1.Visible = false;
           panel3.Visible = false;
           panel4.Visible = false;
           panel5.Visible = false;
           ani.ShowSync(panel5);
       }

       private void panel2_Paint(object sender, PaintEventArgs e)
       {

       }

       private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
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

       private void textBox21_KeyPress(object sender, KeyPressEventArgs e)
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

       private void bunifuCustomLabel47_Click(object sender, EventArgs e)
       {

       }

       private void textBox32_Leave(object sender, EventArgs e)
       {
           if(textBox31.Text!="0")
           {
               bunifuCustomLabel61.Text= (Convert.ToDouble(textBox31.Text)* Convert.ToDouble(textBox32.Text)).ToString();






           }
       }

       private void bunifuThinButton212_Click(object sender, EventArgs e)
       {



       }

       private void bunifuImageButton3_Click(object sender, EventArgs e)
       {


           this.printDialog1.Document = this.printDocument1;
           DialogResult dr = this.printDialog1.ShowDialog();

           print p = new print();

           MySqlCommand cmda;
           MySqlDataAdapter adap;



           if (dr == DialogResult.OK)
           {

               int nCopy = this.printDocument1.PrinterSettings.Copies;

               int sPage = this.printDocument1.PrinterSettings.FromPage;

               int ePage = this.printDocument1.PrinterSettings.ToPage;
               string PrinterName = this.printDocument1.PrinterSettings.PrinterName;

               crReportDocument = new ReportDocument();

               con.Open();
               cmda = con.CreateCommand();
               tripdata custDB = new tripdata();
               custDB.Clear();

               cmda.CommandText = "select * from trip where id=" + Convert.ToInt32(textBox29.Text) + " ";
               cmda.ExecuteNonQuery();


               adap = new MySqlDataAdapter();

               adap.SelectCommand = cmda;

               DataTable d1 = new DataTable();

               adap.Fill(custDB.DataTable1);
               adap.Fill(d1);


               crReportDocument = new CrystalReport21();

               crReportDocument.SetDataSource(custDB);






               try
               {


                   crReportDocument.PrintOptions.PrinterName = PrinterName;




                   p.crystalReportViewer1.ReportSource = crReportDocument;
                   //p.crystalReportViewer1.Refresh();
                  // p.Show();
                   crReportDocument.PrintToPrinter(nCopy, false, sPage, ePage);


                 //  MessageBox.Show("Report finished printing!");
               }
               catch (Exception err)
               {
                   MessageBox.Show(err.ToString());
               }
               con.Close();
           }

       }

       



    }
}
