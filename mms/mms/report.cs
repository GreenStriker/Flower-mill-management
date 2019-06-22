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
using System.Web.UI.WebControls;

namespace mms
{
    public partial class report : Form
    {
        MySqlConnection con = null;
        ReportDocument crReportDocument;

        public report()
        {
            InitializeComponent();
            con = DatabaseConnection.getDBConnection();

            bunifuDatepicker3.Value = DateTime.Now;
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      

        private void report_Load(object sender, EventArgs e)
        {




            MySqlDataReader rdr1 = null;



            con.Open();

            string stm = "SELECT  DISTINCT month ,year FROM staf_rec";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            rdr1 = cmd.ExecuteReader();


            comboBox2.Items.Clear();
            while (rdr1.Read())
            {


                comboBox2.Items.Add(rdr1.GetString("month"));
                comboBox1.Items.Add(rdr1.GetString("year"));

            }

            con.Close();


        }

        private void bunifuImageButton2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
           // main1 m = new main1();
          //  m.Show();
            this.Visible = false;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            bunifuTransition1.ShowSync(panel1);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {



            if (comboBox2.Text == "" && comboBox1.Text == "")
            {

                MessageBox.Show("Fill All The Field!!");

            }



            else
            {
                double income = 0;

                MySqlDataReader rdr28 = null;
                con.Open();

                string stm8 = "select * from staf_rec where month ='" + comboBox2.Text + "' AND year='" + comboBox1.Text + "'";
                MySqlCommand cmd8 = new MySqlCommand(stm8, con);
                rdr28 = cmd8.ExecuteReader();

                while (rdr28.Read())
                {
                    income = income + Convert.ToDouble(rdr28.GetString("salary"));


                }

                con.Close();

                // MessageBox.Show(""+income);



                this.printDialog1.Document = this.printDocument1;
                DialogResult dr = this.printDialog1.ShowDialog();

                print p = new print();

                MySqlCommand cmd;
                MySqlDataAdapter adap;



                if (dr == DialogResult.OK)
                {

                    int nCopy = this.printDocument1.PrinterSettings.Copies;

                    int sPage = this.printDocument1.PrinterSettings.FromPage;

                    int ePage = this.printDocument1.PrinterSettings.ToPage;
                    string PrinterName = this.printDocument1.PrinterSettings.PrinterName;

                    crReportDocument = new ReportDocument();

                    con.Open();
                    cmd = con.CreateCommand();
                    staffdata2 custDB = new staffdata2();
                    custDB.Clear();

                    cmd.CommandText = "select * from staf_rec where month ='" + comboBox2.Text + "' AND year='" + comboBox1.Text + "'";
                    cmd.ExecuteNonQuery();


                    adap = new MySqlDataAdapter();

                    adap.SelectCommand = cmd;

                    DataTable d1 = new DataTable();

                    adap.Fill(custDB.DataTable1);
                    adap.Fill(d1);


                    crReportDocument = new CrystalReport8();

                    crReportDocument.SetDataSource(custDB);

                    crReportDocument.SetParameterValue("total", income.ToString());




                    try
                    {


                        crReportDocument.PrintOptions.PrinterName = PrinterName;




                        p.crystalReportViewer1.ReportSource = crReportDocument;
                        p.crystalReportViewer1.Refresh();
                        p.Show();
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


        }

        private void bunifuThinButton1_Click(object sender, EventArgs e)
        {
          
        }

        private void bunifuThinButton26_Click_1(object sender, EventArgs e)
        {



            //print



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
                productiondata custDB = new productiondata();
                custDB.Clear();

                cmda.CommandText = "select * from production_history where date between '" + bunifuDatepicker1.Value.ToString("yyyy-MM-dd") + "' AND '" + bunifuDatepicker2.Value.ToString("yyyy-MM-dd") + "'";
                cmda.ExecuteNonQuery();


                adap = new MySqlDataAdapter();

                adap.SelectCommand = cmda;

                DataTable d1 = new DataTable();

                adap.Fill(custDB.DataTable1);
                adap.Fill(d1);

                con.Close();


                //
    



                crReportDocument = new CrystalReport14();

                crReportDocument.SetDataSource(custDB);








                try
                {


                    crReportDocument.PrintOptions.PrinterName = PrinterName;




                    p.crystalReportViewer1.ReportSource = crReportDocument;
                    p.crystalReportViewer1.Refresh();
                    p.Show();
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

        private void bunifuThinButton23_Click_1(object sender, EventArgs e)
        {
          
        

            panel1.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;

            bunifuTransition1.ShowSync(panel3);

        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {



            panel1.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;

            bunifuTransition1.ShowSync(panel4);





        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuDatepicker2_onValueChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuDatepicker3_onValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuDatepicker4_onValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel9_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {


    



            //purchase hiistory


            double pur1 = 0;

            MySqlDataReader rdr28 = null;
            con.Open();

            string stm8 = "select * from purchase_history where date >='" + bunifuDatepicker4.Value.ToString("yyyy-MM-dd") + "' AND date <='" + bunifuDatepicker3.Value.ToString("yyyy-MM-dd") + "'";
            MySqlCommand cmd8 = new MySqlCommand(stm8, con);
            rdr28 = cmd8.ExecuteReader();

            while (rdr28.Read())
            {
                pur1 = pur1 + Convert.ToDouble(rdr28.GetString("amount"));


            }

            con.Close();
          


  //other payment

            double pur2= 0;

            MySqlDataReader rdr281 = null;
            con.Open();

            string stm81 = "select * from other_payment where date >='" + bunifuDatepicker4.Value.ToString("yyyy-MM-dd") + "' AND date <='" + bunifuDatepicker3.Value.ToString("yyyy-MM-dd") + "'";
            MySqlCommand cmd81 = new MySqlCommand(stm81, con);
            rdr281 = cmd81.ExecuteReader();

            while (rdr281.Read())
            {
                pur2 = pur2 + Convert.ToDouble(rdr281.GetString("amount"));


            }

            con.Close();

         


    
   //purchase payment



            double pur3= 0;

            MySqlDataReader rdr2812 = null;
            con.Open();

            string stm812 = "select * from purchage_payment where date >='" + bunifuDatepicker4.Value.ToString("yyyy-MM-dd") + "' AND date <='" + bunifuDatepicker3.Value.ToString("yyyy-MM-dd") + "'";
            MySqlCommand cmd812 = new MySqlCommand(stm812, con);
            rdr2812 = cmd812.ExecuteReader();

            while (rdr2812.Read())
            {
                pur3 = pur3 + Convert.ToDouble(rdr2812.GetString("amount"));


            }

            con.Close();





            //kuchrar sale




            double in3 = 0;

            MySqlDataReader rdr284 = null;
            con.Open();

            string stm84 = "select * from   kusra_sale where date >='" + bunifuDatepicker4.Value.ToString("yyyy-MM-dd") + "' AND date <='" + bunifuDatepicker3.Value.ToString("yyyy-MM-dd") + "'";
         
            MySqlCommand cmd84 = new MySqlCommand(stm84, con);
            rdr284 = cmd84.ExecuteReader();

            while (rdr284.Read())
            {
                in3 = in3 + Convert.ToDouble(rdr284.GetString("tprice"));


            }


            con.Close();



   //collection



            double pur4 = 0;

            MySqlDataReader rdr = null;
            con.Open();

            string stm = "select * from colection where date >='" + bunifuDatepicker4.Value.ToString("yyyy-MM-dd") + "' AND date <='" + bunifuDatepicker3.Value.ToString("yyyy-MM-dd") + "'";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                pur4 = pur4 + Convert.ToDouble(rdr.GetString("amount"));


            }

            con.Close();



             //print purchase




            this.printDialog1.Document = this.printDocument1;
            DialogResult dr = this.printDialog1.ShowDialog();

            print p = new print();

            MySqlCommand cmda8;
            MySqlDataAdapter adap8;

            MySqlCommand cmda1;
            MySqlDataAdapter adap1;

            MySqlCommand cmda2;
            MySqlDataAdapter adap2;


            MySqlCommand cmda3;
            MySqlDataAdapter adap3;

            MySqlCommand cmda4;
            MySqlDataAdapter adap4;


            MySqlCommand cmda5;
            MySqlDataAdapter adap5;



            MySqlCommand cmda6;
            MySqlDataAdapter adap6;



            if (dr == DialogResult.OK)
            {

                int nCopy = this.printDocument1.PrinterSettings.Copies;

                int sPage = this.printDocument1.PrinterSettings.FromPage;

                int ePage = this.printDocument1.PrinterSettings.ToPage;
                string PrinterName = this.printDocument1.PrinterSettings.PrinterName;

                crReportDocument = new ReportDocument();



                con.Open();
                cmda8 = con.CreateCommand();
                incomeadd custDB = new incomeadd();
                custDB.Clear();



                cmda8.CommandText = "select * from purchase_history where date >='" + bunifuDatepicker4.Value.ToString("yyyy-MM-dd") + "' AND date <='" + bunifuDatepicker3.Value.ToString("yyyy-MM-dd") + "'";
                cmda8.ExecuteNonQuery();


                adap8 = new MySqlDataAdapter();

                adap8.SelectCommand = cmda8;

                DataTable d1 = new DataTable();

                adap8.Fill(custDB.DataTable3);
                adap8.Fill(d1);

                con.Close();



                  
                //
                con.Open();
                cmda1 = con.CreateCommand();



                cmda1.CommandText = "select * from other_payment where date >='" + bunifuDatepicker4.Value.ToString("yyyy-MM-dd") + "' AND date <='" + bunifuDatepicker3.Value.ToString("yyyy-MM-dd") + "'";
                cmda1.ExecuteNonQuery();


                adap1 = new MySqlDataAdapter();

                adap1.SelectCommand = cmda1;

                DataTable d2 = new DataTable();

                adap1.Fill(custDB.DataTable7);
                adap1.Fill(d2);
                con.Close();


       //



                con.Open();
                cmda2 = con.CreateCommand();



                cmda2.CommandText = "select * from purchage_payment where date >='" + bunifuDatepicker4.Value.ToString("yyyy-MM-dd") + "' AND date <='" + bunifuDatepicker3.Value.ToString("yyyy-MM-dd") + "'";
                cmda2.ExecuteNonQuery();


                adap2 = new MySqlDataAdapter();

                adap2.SelectCommand = cmda2;

                DataTable d3 = new DataTable();

                adap2.Fill(custDB.DataTable6);
                adap2.Fill(d3);
                con.Close();




           //



                con.Open();
                cmda3 = con.CreateCommand();



                cmda3.CommandText = "select * from kusra_sale where date >='" + bunifuDatepicker4.Value.ToString("yyyy-MM-dd") + "' AND date <='" + bunifuDatepicker3.Value.ToString("yyyy-MM-dd") + "'";
                cmda3.ExecuteNonQuery();


                adap3 = new MySqlDataAdapter();

                adap3.SelectCommand = cmda3;

                DataTable d4 = new DataTable();

                adap3.Fill(custDB.DataTable2);
                adap3.Fill(d4);
                con.Close();



                //






                con.Open();
                cmda4 = con.CreateCommand();



                cmda4.CommandText = "select * from colection where date >='" + bunifuDatepicker4.Value.ToString("yyyy-MM-dd") + "' AND date <='" + bunifuDatepicker3.Value.ToString("yyyy-MM-dd") + "'";
                cmda4.ExecuteNonQuery();


                adap4 = new MySqlDataAdapter();

                adap4.SelectCommand = cmda4;

                DataTable d5= new DataTable();

                adap4.Fill(custDB.DataTable1);
                adap4.Fill(d5);
                con.Close();



//

                con.Open();
                cmda5 = con.CreateCommand();



                cmda5.CommandText = "select * from ad_delivery where date >='" + bunifuDatepicker4.Value.ToString("yyyy-MM-dd") + "' AND date <='" + bunifuDatepicker3.Value.ToString("yyyy-MM-dd") + "'";
                cmda5.ExecuteNonQuery();


                adap5 = new MySqlDataAdapter();

                adap5.SelectCommand = cmda5;

                DataTable d6 = new DataTable();

                adap5.Fill(custDB.DataTable5);
                adap5.Fill(d6);
                con.Close();






                  //




                con.Open();
                cmda6 = con.CreateCommand();



                cmda6.CommandText = "select * from  sales_delivery where date >='" + bunifuDatepicker4.Value.ToString("yyyy-MM-dd") + "' AND date <='" + bunifuDatepicker3.Value.ToString("yyyy-MM-dd") + "'";
                cmda6.ExecuteNonQuery();


                adap6 = new MySqlDataAdapter();

                adap6.SelectCommand = cmda6;

                DataTable d7 = new DataTable();

                adap6.Fill(custDB.DataTable4);
                adap6.Fill(d7);
                con.Close();

               



                

                crReportDocument = new CrystalReport7();

                crReportDocument.SetDataSource(custDB);

                //purchase 
                crReportDocument.SetParameterValue("purh", pur1.ToString());
                //other
                crReportDocument.SetParameterValue("oth", pur2.ToString());
                //p payment

                crReportDocument.SetParameterValue("ppay", pur3.ToString());
                //kurcha
                crReportDocument.SetParameterValue("kuc", in3.ToString());


                //collection
                crReportDocument.SetParameterValue("col", pur4.ToString());





                try
                {


                    crReportDocument.PrintOptions.PrinterName = PrinterName;




                    p.crystalReportViewer1.ReportSource = crReportDocument;
                    p.crystalReportViewer1.Refresh();
                    p.Show();
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

        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {
            Application.OpenForms[2].Visible = true;
            while (Application.OpenForms.Count > 4) { Application.OpenForms[3].Dispose(); }
            Application.OpenForms[3].Dispose();
        }


      
    }
}
