
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
    public partial class print : Form
    {
        MySqlConnection con = null;
        ReportDocument crReportDocument;
        public print()
        {
            InitializeComponent();
            con = DatabaseConnection.getDBConnection();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }


        public void getId(string aa, Double pt, string n)
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
                DataSet1 custDB = new DataSet1();
                custDB.Clear();

                cmda.CommandText = "select * from kusra_sale where kusra_sale.s_id=" + aa + " ";
                cmda.ExecuteNonQuery();


                adap = new MySqlDataAdapter();

                adap.SelectCommand = cmda;

                DataTable d1 = new DataTable();

                adap.Fill(custDB.DataTable1);
                adap.Fill(d1);


                crReportDocument = new CrystalReport1();

                crReportDocument.SetDataSource(custDB);

                crReportDocument.SetParameterValue("total", pt);

                crReportDocument.SetParameterValue("name",n);





                try
                {


                    crReportDocument.PrintOptions.PrinterName = PrinterName;




                    p.crystalReportViewer1.ReportSource = crReportDocument;
                   // p.crystalReportViewer1.Refresh();
                    //p.Show();
                    crReportDocument.PrintToPrinter(nCopy, false, sPage, ePage);


                    MessageBox.Show("Report finished printing!");
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
                con.Close();
            }







        }

        private void print_Load(object sender, EventArgs e)
        {

        }
    }
}
