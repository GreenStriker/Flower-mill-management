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

    //bunifuDropdown2
    public partial class colection : Form
    {
        ReportDocument crReportDocument;
        double new_amount = 0;

        MySqlConnection con = null;
        public colection()
        {
            InitializeComponent();
            con = DatabaseConnection.getDBConnection();
        }

        private void bunifuCustomLabel8_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Application.OpenForms[2].Visible = true;
            while (Application.OpenForms.Count > 4) { Application.OpenForms[3].Dispose(); }
            Application.OpenForms[3].Dispose();
        }

        private void colection_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox1;

            this.textBox1.Focus();

            //e.SuppressKeyPress = true;

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
            textBox1.AutoCompleteCustomSource = mm2;
            con.Close();
        

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || bunifuCustomTextbox3.Text == "" || bunifuDropdown2.Text == "")
            {

              
                MessageBox.Show("FILL AMOUNT AND CUSTOMER NAME AND Payment Type");

            }

            else
            {


                int x = 0;




                try
                {


                    MySqlDataReader rdr2 = null;

                    con.Open();

                    string stm2 = "SELECT id FROM clients where c_name = '" + textBox1.Text + "'";
                    MySqlCommand cmd2 = new MySqlCommand(stm2, con);
                    rdr2 = cmd2.ExecuteReader();

                    while (rdr2.Read())
                    {
                        string ccname = rdr2.GetString(0);

                        x = Convert.ToInt32(ccname);
                    }

                    con.Close();






                    con.Open();

                    string query = "INSERT INTO colection (date, c_id, pament_type, bank_name, check_no,remark,	amount,address,mobi ) VALUES ('" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" + textBox1.Text + "', '" + bunifuDropdown2.Text + "', '" + tproname.Text + "', '" + bunifuCustomTextbox1.Text + "', '" + bunifuCustomTextbox2.Text + "','" + bunifuCustomTextbox3.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";


                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, con);

                    //Execute command
                    cmd.ExecuteNonQuery();
                    long last = cmd.LastInsertedId;

                    //close connection
                    con.Close();
                    //MessageBox.Show("COLLECTION STORED ");








                    new_amount = new_amount - Convert.ToDouble(bunifuCustomTextbox3.Text);




                    con.Open();

                    string query1 = "Update clients SET main_bal = '" + new_amount + "' where c_name = '" + textBox1.Text + "' ";


                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd1 = new MySqlCommand(query1, con);

                    //Execute command
                    cmd1.ExecuteNonQuery();

                    //close connection
                    con.Close();




                    string mm = "";
                    string yy = "";

                    MySqlDataReader rdr43 = null;

                    con.Open();

                    string stm43 = "SELECT * FROM clients where c_name='" + textBox1.Text + "'";
                    MySqlCommand cmd43 = new MySqlCommand(stm43, con);
                    rdr43 = cmd43.ExecuteReader();

                    if (rdr43.Read())
                    {
                        mm = rdr43.GetString(2).ToString();
                        yy = rdr43.GetString(3).ToString();


                    }

                    con.Close();



                    MessageBox.Show("COLLECTION STORED ");

                   


                    //print


                  //  bunifuCustomLabel9
                 //   bunifuCustomTextbox3

                    double rem = Convert.ToDouble(bunifuCustomLabel9.Text)-Convert.ToDouble( bunifuCustomTextbox3.Text);

                    double car = Convert.ToDouble(bunifuCustomTextbox3.Text);

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
                        collectiondata custDB = new collectiondata();
                        custDB.Clear();

                        cmda.CommandText = "select * from colection where id=" + last + " ";
                        cmda.ExecuteNonQuery();


                        adap = new MySqlDataAdapter();

                        adap.SelectCommand = cmda;

                        DataTable d1 = new DataTable();

                        adap.Fill(custDB.DataTable1);
                        adap.Fill(d1);


                        crReportDocument = new CrystalReport9();

                        crReportDocument.SetDataSource(custDB);

                        crReportDocument.SetParameterValue("name", textBox1.Text);
                        crReportDocument.SetParameterValue("add", mm);

                        crReportDocument.SetParameterValue("mob", yy);

                        crReportDocument.SetParameterValue("pre", bunifuCustomLabel9.Text);
                        crReportDocument.SetParameterValue("cure", car.ToString("N"));
                        crReportDocument.SetParameterValue("rem", rem.ToString("N"));




                        try
                        {


                            crReportDocument.PrintOptions.PrinterName = PrinterName;




                            p.crystalReportViewer1.ReportSource = crReportDocument;
                          //  p.crystalReportViewer1.Refresh();
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



                    colection NewForm = new colection();

                    
                    NewForm.Show();

                    this.Hide();






                }

                catch (Exception e22)
                {
                    con.Close();
                    MessageBox.Show(" " + e22);

                }



            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            con.Close();
            MySqlDataReader rdr2 = null;

            con.Open();

            string stm2 = "SELECT main_bal,c_add,c_mobile FROM clients where c_name = '" + textBox1.Text + "'";
            MySqlCommand cmd2 = new MySqlCommand(stm2, con);
            rdr2 = cmd2.ExecuteReader();

            if (rdr2.Read())
            {

                if (Convert.ToDouble(rdr2.GetString(0)) < 0)
                {
                    bunifuCustomLabel9.ForeColor = System.Drawing.Color.Red;
                }
                else
                {

                    bunifuCustomLabel9.ForeColor = System.Drawing.Color.Green;

                }
               

                double x = Convert.ToDouble(rdr2.GetString(0));

                new_amount = x;
                bunifuCustomLabel9.Text =x.ToString("N");

                textBox2.Text = rdr2.GetString(1);

                textBox3.Text = rdr2.GetString(2);


                //bunifuCustomLabel18.Text = rdr2.GetString(0);
            }

            con.Close();




        }

        private void bunifuCustomTextbox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void bunifuDropdown2_onItemSelected(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomTextbox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {





                this.ActiveControl = bunifuDropdown2;

                this.bunifuDropdown2.Focus();

                e.SuppressKeyPress = true;





            }
        }

        

        private void bunifuDropdown2_KeyDown(object sender, KeyEventArgs e)
        {
                 if (e.KeyCode == Keys.Enter)
            {





                this.ActiveControl = tproname;

                this.tproname.Focus();

                e.SuppressKeyPress = true;





            }
        }

        private void tproname_KeyDown(object sender, KeyEventArgs e)
        {
            

                      if (e.KeyCode == Keys.Enter)
            {





                this.ActiveControl = bunifuCustomTextbox1;

                this.bunifuCustomTextbox1.Focus();

                e.SuppressKeyPress = true;





            }
        }

        private void bunifuCustomTextbox1_KeyDown(object sender, KeyEventArgs e)
        {
            

                    if (e.KeyCode == Keys.Enter)
            {





                this.ActiveControl = bunifuCustomTextbox3;

                this.bunifuCustomTextbox3.Focus();

                e.SuppressKeyPress = true;





            }
        }
    }
}
