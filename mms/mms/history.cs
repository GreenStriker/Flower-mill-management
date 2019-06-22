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
using CrystalDecisions.CrystalReports.Engine;

namespace mms
{
    public partial class history : Form
    {

        ReportDocument crReportDocument;
        MySqlConnection con = null;
        public history()
        {
            InitializeComponent();
            con = DatabaseConnection.getDBConnection();
        }

        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {




            MySqlCommand cmd = new MySqlCommand("SELECT s_id,name,quantity,rate,tprice,c_name,addr,mobi,pay_type,pertial_pay FROM  kusra_sale where date >='" + bunifuDatepicker1.Value.ToString("yyyy-MM-dd") + "';", con);
            con.Open();
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dataTable);


            dataGridView3.DataSource = dataTable;


            dataGridView3.Columns[0].HeaderText = "Sales Id ";
            dataGridView3.Columns[1].HeaderText = "Product Name";
            dataGridView3.Columns[2].HeaderText = "Quantity";
            dataGridView3.Columns[3].HeaderText = "Unit Price";
            dataGridView3.Columns[4].HeaderText = "Total Price";
            dataGridView3.Columns[5].HeaderText = "Customer Name ";
            dataGridView3.Columns[6].HeaderText = "Address";
            dataGridView3.Columns[7].HeaderText = "Mobile";
            dataGridView3.Columns[8].HeaderText = "Pay_Type";
            dataGridView3.Columns[9].HeaderText = "Partial_Pay";




            con.Close();






        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            Application.OpenForms[2].Visible = true;
            while (Application.OpenForms.Count > 4) { Application.OpenForms[3].Dispose(); }
            Application.OpenForms[3].Dispose();
        }

        private void bunifuCustomLabel30_Click(object sender, EventArgs e)
        {

        }

        private void history_Load(object sender, EventArgs e)
        {

            



            MySqlCommand cmd = new MySqlCommand("SELECT s_id,name,quantity,rate,tprice,c_name,addr,mobi,pay_type,pertial_pay FROM  kusra_sale where date >='" + DateTime.Now.ToString("yyyy/MM/dd") + "';", con);
            con.Open();
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dataTable);


            dataGridView3.DataSource = dataTable;


            dataGridView3.Columns[0].HeaderText = "Sales Id ";
            dataGridView3.Columns[1].HeaderText = "Product Name";
            dataGridView3.Columns[2].HeaderText = "Quantity";
            dataGridView3.Columns[3].HeaderText = "Unit Price";
            dataGridView3.Columns[4].HeaderText = "Total Price";
            dataGridView3.Columns[5].HeaderText = "Customer Name ";
            dataGridView3.Columns[6].HeaderText = "Address";
            dataGridView3.Columns[7].HeaderText = "Mobile";
            dataGridView3.Columns[8].HeaderText = "Pay_Type";
            dataGridView3.Columns[9].HeaderText = "Partial_Pay";




            con.Close();

            bunifuDatepicker1.Value = DateTime.Now;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="")
            {





                DialogResult dialogResult = MessageBox.Show("Sure You Want To Delete ", "Some Title", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                 //   rdr2.GetString(1);


                    string[,] aa = new string[6, 2];

                 int    coun = 0;

                    MySqlDataReader rdr2 = null;
                    string dateee="";

                    con.Open();

                    string stm2 = "SELECT name,quantity,date from kusra_sale where s_id ='" + textBox1.Text + "'";
                    MySqlCommand cmd2 = new MySqlCommand(stm2, con);
                    rdr2 = cmd2.ExecuteReader();

                    while (rdr2.Read())
                    {


                        aa[coun, 0] = rdr2.GetString(0);

                         aa[coun, 1] = rdr2.GetString(1);

                         bunifuDatepicker2.Value = Convert.ToDateTime(rdr2.GetString(2));
                         coun++;
                    }

               //     MessageBox.Show(dateee);


                    con.Close();


int i=0;


while(i<coun)
{






                    con.Open();



                    string insertQuery1 = "INSERT INTO sales_delivery (date,item_name, deli_item,c_name) VALUES('" + bunifuDatepicker2.Value.Date.ToString("yyyy/MM/dd") + "','" + aa[i, 0] + "','-" + aa[i, 1] + "','Invoice Delete')";

                    MySqlCommand command1 = new MySqlCommand(insertQuery1, con);

                    command1.ExecuteNonQuery();

                    con.Close();


                    i++;
                    
                   } 
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    con.Open();

                    string query19 = "Delete from kusra_sale where s_id ='" + textBox1.Text + "'";


                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd19 = new MySqlCommand(query19, con);

                    //Execute command
                    cmd19.ExecuteNonQuery();

                    //close connection
                    con.Close();

                    history h = new history();

                    h.Show();

                    this.Hide();





                    
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }


            }
            else
            {



                MessageBox.Show("PLZ Invoice ID");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {


            string n = "";
            string tY = "";
            if (textBox2.Text != "")
            {

                string xxx = "0";
                
            try
            {


                con.Open();
                string stm9 = "SELECT sum(tprice),c_name,pay_type FROM  kusra_sale   where  s_id ='" + textBox2.Text + "'  ";
                MySqlCommand cmd9 = new MySqlCommand(stm9, con);

                MySqlDataReader rdr9 = cmd9.ExecuteReader();


                while (rdr9.Read())
                {

                    xxx = rdr9.GetString(0);

                    n = rdr9.GetString(1);
                    tY = rdr9.GetString(2);

                }
                
              
                } 

                catch(Exception ii)
            {

                xxx = "0";

            }
                
                
                
                
                
                
                con.Close();




                this.printDialog1.Document = this.printDocument1;
                //  DialogResult dr4 = this.printDialog1.ShowDialog();

                print p = new print();

                MySqlCommand cmda;
                MySqlDataAdapter adap;


                string PrinterName = this.printDocument1.PrinterSettings.PrinterName;

                crReportDocument = new ReportDocument();

                con.Open();
                cmda = con.CreateCommand();
                DataSet1 custDB = new DataSet1();
                custDB.Clear();

                cmda.CommandText = "select * from kusra_sale where kusra_sale.s_id=" + textBox2.Text + " ";
                cmda.ExecuteNonQuery();


                adap = new MySqlDataAdapter();

                adap.SelectCommand = cmda;

                DataTable d1 = new DataTable();

                adap.Fill(custDB.DataTable1);
                adap.Fill(d1);


                crReportDocument = new CrystalReport001();

                crReportDocument.SetDataSource(custDB);

                crReportDocument.SetParameterValue("total",xxx );
                crReportDocument.SetParameterValue("name", n);
                crReportDocument.SetParameterValue("tY", tY);
   
                

                try
                {


                    crReportDocument.PrintOptions.PrinterName = PrinterName;




                    p.crystalReportViewer1.ReportSource = crReportDocument;
                    // p.crystalReportViewer1.Refresh();
                    // p.Show();

                    crReportDocument.PrintToPrinter(1, false, 1, 1);

                    //   MessageBox.Show("Report finished printing!");
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                    con.Close();
                }
                con.Close();














            }

            else
            {



                MessageBox.Show("Fill te Box to Print");


            }



        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
