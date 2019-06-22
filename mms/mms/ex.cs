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
    public partial class ex : Form
    { MySqlConnection con = null;
    int x = 0;
         ReportDocument crReportDocument;
        public ex()
        {
            InitializeComponent();
            con = DatabaseConnection.getDBConnection();
        }

        private void ex_Load(object sender, EventArgs e)
        {

            bunifuDatepicker1.Value = DateTime.Now;
            
            
            
            
            
            string sql;



                con.Open();
                DataTable dataTable = new DataTable();




                sql = "SELECT expence_id,sum(amount) as amount FROM other_payment   where date >='" + bunifuDatepicker2.Value.ToString("yyyy-MM-dd") + "' group by expence_id;";



                

                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                da.Fill(dataTable);


                dataGridView3.DataSource = dataTable;

                dataGridView3.Columns[0].HeaderText = "Expence name ";
                dataGridView3.Columns[1].HeaderText = "Total Amount  ";
               


                con.Close();

            


        }

        private void bunifuDatepicker2_onValueChanged(object sender, EventArgs e)
        {
            string sql;

            x = 1;

            con.Open();
            DataTable dataTable = new DataTable();




            sql = "SELECT expence_id,sum(amount) as amount FROM other_payment   where date >='" + bunifuDatepicker2.Value.ToString("yyyy-MM-dd") + "' AND date <='" + bunifuDatepicker1.Value.ToString("yyyy-MM-dd") + "' group by expence_id;";





            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dataTable);


            dataGridView3.DataSource = dataTable;

            dataGridView3.Columns[0].HeaderText = "Expence name ";
            dataGridView3.Columns[1].HeaderText = "Total Amount  ";



            con.Close();


        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Application.OpenForms[2].Visible = true;
            while (Application.OpenForms.Count > 4) { Application.OpenForms[3].Dispose(); }
            Application.OpenForms[3].Dispose();
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
                expensedata custDB = new expensedata();
                custDB.Clear();
                if (x == 0) { cmda.CommandText = "SELECT expence_id,sum(amount) as amount FROM other_payment   where date >='" + bunifuDatepicker2.Value.ToString("yyyy-MM-dd") + "' AND date <='" + bunifuDatepicker1.Value.ToString("yyyy-MM-dd") + "' group by expence_id;"; }

                else
                {
                    cmda.CommandText = "SELECT expence_id,sum(amount) as amount FROM other_payment   where date >='" + bunifuDatepicker2.Value.ToString("yyyy-MM-dd") + "' AND date <='" + bunifuDatepicker1.Value.ToString("yyyy-MM-dd") + "' group by expence_id;";

                } cmda.ExecuteNonQuery();


                adap = new MySqlDataAdapter();

                adap.SelectCommand = cmda;

                DataTable d1 = new DataTable();

                adap.Fill(custDB.DataTable1);
                adap.Fill(d1);


                crReportDocument = new CrystalReport17();

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

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {
            string sql;

            x = 1;

            con.Open();
            DataTable dataTable = new DataTable();




            sql = "SELECT expence_id,sum(amount) as amount FROM other_payment   where date >='" + bunifuDatepicker2.Value.ToString("yyyy-MM-dd") + "' AND date <='" + bunifuDatepicker1.Value.ToString("yyyy-MM-dd") + "' group by expence_id;";





            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dataTable);


            dataGridView3.DataSource = dataTable;

            dataGridView3.Columns[0].HeaderText = "Expence name ";
            dataGridView3.Columns[1].HeaderText = "Total Amount  ";



            con.Close();

        }







        }
    }

