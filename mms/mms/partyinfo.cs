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
    public partial class partyinfo : Form
    {

        string ctotalbal = "0";
        string stotalbal = "0";

        MySqlConnection con = null;
        ReportDocument crReportDocument;
        public partyinfo()
        {
            InitializeComponent();
            con = DatabaseConnection.getDBConnection();
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
                textBox1.Text = rdr2.GetString(1);
                textBox2.Text = rdr2.GetString(2);

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








            }


            else
            {


              

            }
            
            
            con.Close();
        }

        private void partyinfo_Load(object sender, EventArgs e)
        {
            MySqlDataReader rdr2 = null;



            con.Open();

            string stm2 = "SELECT c_name FROM clients";
            MySqlCommand cmd2 = new MySqlCommand(stm2, con);
            rdr2 = cmd2.ExecuteReader();

            AutoCompleteStringCollection mm2 = new AutoCompleteStringCollection();

            while (rdr2.Read())
            {

                mm2.Add(rdr2.GetString(0));



            }
            textBox3.AutoCompleteCustomSource = mm2;
            textBox4.AutoCompleteCustomSource = mm2;
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
            textBox6.AutoCompleteCustomSource = mm22;

            con.Close();





            string sql;



            con.Open();
            DataTable dataTable = new DataTable();



            sql = "SELECT 	*  FROM clients ; ";





            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dataTable);


            dataGridView1.DataSource = dataTable;

            dataGridView1.Columns[0].HeaderText = "Customer ID ";
            dataGridView1.Columns[1].HeaderText = "Customer Name ";
            dataGridView1.Columns[2].HeaderText = "Customer Address ";
            dataGridView1.Columns[3].HeaderText = "Customer Mobile  ";
            dataGridView1.Columns[4].HeaderText = "Customer Balance";


            con.Close();
            //2

            string sql2;



            con.Open();
            DataTable dataTable2 = new DataTable();



            sql2 = "SELECT 	*  FROM supplier ; ";





            MySqlCommand cmd222 = new MySqlCommand(sql2, con);
            MySqlDataAdapter da2 = new MySqlDataAdapter(cmd222);

            da2.Fill(dataTable2);


            dataGridView2.DataSource = dataTable2;

            dataGridView2.Columns[0].HeaderText = "Supplier ID ";
            dataGridView2.Columns[1].HeaderText = "Supplier Name ";
            dataGridView2.Columns[2].HeaderText = "Supplier Address ";
            dataGridView2.Columns[3].HeaderText = "Supplier Mobile  ";
            dataGridView2.Columns[4].HeaderText = "Supplier Balance";

            con.Close();
















        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            MySqlDataReader rdr2 = null;

            con.Open();

            string stm2 = "SELECT id,c_add,c_mobile,main_bal FROM supplier where c_name = '" + textBox6.Text + "'";
            MySqlCommand cmd2 = new MySqlCommand(stm2, con);
            rdr2 = cmd2.ExecuteReader();

            if (rdr2.Read())
            {
                bunifuCustomLabel8.Text = rdr2.GetString(0);
                textBox5.Text = rdr2.GetString(1);
                textBox4.Text = rdr2.GetString(2);

                if (Convert.ToDouble(rdr2.GetString(3)) < 0)
                {
                    bunifuCustomLabel7.ForeColor = System.Drawing.Color.Red;
                }
                else
                {

                    bunifuCustomLabel7.ForeColor = System.Drawing.Color.Green;

                }
                double x = Convert.ToDouble(rdr2.GetString(3));


                bunifuCustomLabel7.Text = x.ToString("N");








            }

            else
            {


           
            }
            
            
            con.Close();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel1.Visible = false;
            panel5.Visible = false;
            ani.ShowSync(panel5);
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuThinButton22_Click_1(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel1.Visible = false;
            panel5.Visible = false;
            ani.ShowSync(panel1);
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {

            if (bunifuCustomLabel23.Text != "") { 
            con.Open();

            string query1 = "Update clients SET c_add = '" + textBox1.Text + "', c_mobile = '" + textBox2.Text + "'  , c_name = '" + textBox3.Text + "' where id = '" + bunifuCustomLabel23.Text + "' ";


            //create command and assign the query and connection from the constructor
            MySqlCommand cmd1 = new MySqlCommand(query1, con);

            //Execute command
            cmd1.ExecuteNonQuery();

            //close connection
            con.Close();

            textBox1.Text = "";

            textBox2.Text = "";
            textBox3.Text = "";
            MessageBox.Show("SUCCESSFULL");

            partyinfo m = new partyinfo();
            m.Show();
            this.Hide();

            }

            else
            {

                MessageBox.Show("Enter valid supplier");


            }

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (bunifuCustomLabel8.Text != "")
            {
                con.Open();

                string query1 = "Update supplier SET c_add = '" + textBox5.Text + "', c_mobile = '" + textBox4.Text + "' , c_name = '" + textBox6.Text + "'   where id = '" + bunifuCustomLabel8.Text + "' ";


                //create command and assign the query and connection from the constructor
                MySqlCommand cmd1 = new MySqlCommand(query1, con);

                //Execute command
                cmd1.ExecuteNonQuery();

                //close connection
                con.Close();

                textBox5.Text = "";

                textBox4.Text = "";
                textBox6.Text = "";
                MessageBox.Show("SUCCESSFULL");



                partyinfo m = new partyinfo();
               m.Show();
                this.Hide();


            }

            else
            {


                MessageBox.Show("Enter a Valid Supplier Name");

            }

        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                string ww = "SELECT sum(main_bal) FROM   clients where  main_bal>0  ";
                MySqlCommand eee = new MySqlCommand(ww, con);

                MySqlDataReader rrr = eee.ExecuteReader();


                if (rrr.Read())
                {

                    ctotalbal = rrr.GetString(0);

                    //  MessageBox.Show("" + rrr.GetString(0));


                }
               // bunifuCustomLabel25.Text = akcol.ToString();
            }

            catch (Exception ii)
            {

               ctotalbal  = "0";

            } con.Close();


            try
            {
                con.Open();
                string stm911111 = "SELECT sum(main_bal) FROM   supplier where  main_bal<0  ";
                MySqlCommand cmd911111 = new MySqlCommand(stm911111, con);

                MySqlDataReader rdr911111 = cmd911111.ExecuteReader();


                if (rdr911111.Read())
                {

                    stotalbal = rdr911111.GetString(0);




                }
               // bunifuCustomLabel21.Text = kcolaa.ToString();
            }

            catch (Exception ii)
            {

                stotalbal = "0";

            } con.Close();



            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            panel3.Visible = false;
            panel1.Visible = false;
            panel5.Visible = false;
            ani.ShowSync(panel3);
        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
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
                clientdata custDB = new clientdata();
                custDB.Clear();

                cmda.CommandText = "select * from  clients where main_bal>0";
                cmda.ExecuteNonQuery();


                adap = new MySqlDataAdapter();

                adap.SelectCommand = cmda;

                DataTable d1 = new DataTable();

                adap.Fill(custDB.DataTable1);
                adap.Fill(d1);


                crReportDocument = new CrystalReport10();

                crReportDocument.SetDataSource(custDB);
                crReportDocument.SetParameterValue("tt", ctotalbal);



               





                try
                {


                    crReportDocument.PrintOptions.PrinterName = PrinterName;




                    p.crystalReportViewer1.ReportSource = crReportDocument;
                    //p.crystalReportViewer1.Refresh();
                  //  p.Show();
                    crReportDocument.PrintToPrinter(nCopy, false, sPage, ePage);


                    //MessageBox.Show("Report finished printing!");
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
                con.Close();
            }











        }

        private void bunifuThinButton28_Click(object sender, EventArgs e)
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
                supplierdata custDB = new supplierdata();
                custDB.Clear();

                cmda.CommandText = "select * from  supplier where main_bal<0 ";
                cmda.ExecuteNonQuery();


                adap = new MySqlDataAdapter();

                adap.SelectCommand = cmda;

                DataTable d1 = new DataTable();

                adap.Fill(custDB.DataTable1);
                adap.Fill(d1);


                crReportDocument = new CrystalReport11();

                crReportDocument.SetDataSource(custDB);


                crReportDocument.SetParameterValue("tt", stotalbal);




                try
                {


                    crReportDocument.PrintOptions.PrinterName = PrinterName;




                    p.crystalReportViewer1.ReportSource = crReportDocument;
                    //p.crystalReportViewer1.Refresh();
                    //p.Show();
                    crReportDocument.PrintToPrinter(nCopy, false, sPage, ePage);


                   // MessageBox.Show("Report finished printing!");
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
