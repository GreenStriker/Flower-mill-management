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
    public partial class sales : Form
    {
        MySqlConnection con = null;

        DataTable dt = new DataTable();
        ReportDocument crReportDocument;
        public sales()
        {
            InitializeComponent();
            con = DatabaseConnection.getDBConnection();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            main1 m = new main1();
            m.Show();
           this.Hide();
        }
        public void end()
        {

            main1 m = new main1();
            m.Show();
           this.Hide();


        }
        private void sales_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox1;

            this.textBox1.Focus();
                








            con.Close();






            dt.Clear();

            dt.Columns.Add("Product_Name");

            dt.Columns.Add("Quantity");
            dt.Columns.Add("Unit_price");
            dt.Columns.Add("Price");
            dt.Columns.Add("remark");















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
            textBox4.AutoCompleteCustomSource = mm2;
            con.Close();


            MySqlDataReader rdr = null;

            con.Open();

            string stm = "SELECT name FROM stock";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            rdr = cmd.ExecuteReader();

            AutoCompleteStringCollection mm = new AutoCompleteStringCollection();


            while (rdr.Read())
            {

                mm.Add(rdr.GetString(0));




            }
            textBox2.AutoCompleteCustomSource = mm;
            textBox3.AutoCompleteCustomSource = mm;
            con.Close();





        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel11_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomTextbox1_TextChanged(object sender, EventArgs e)
        {

            if (bunifuCustomTextbox3.Text != "" && bunifuCustomTextbox1.Text != "")
            {

                try
                {
                    double x = Convert.ToDouble(this.bunifuCustomTextbox3.Text) * Convert.ToDouble(this.bunifuCustomTextbox1.Text);

                    bunifuCustomLabel11.Text = x.ToString();
                }

                catch (Exception e12)
                {


                    MessageBox.Show("THE MAXXIMUM AMOUNT RICHED" + e12);
                    bunifuCustomLabel11.Text = "0";

                }

            }




        }

        private void bunifuCustomTextbox3_TextChanged(object sender, EventArgs e)
        {

            if (bunifuCustomTextbox3.Text != "" && bunifuCustomTextbox1.Text != "")
            {

                try
                {
                    double x = Convert.ToDouble(this.bunifuCustomTextbox3.Text) * Convert.ToDouble(this.bunifuCustomTextbox1.Text);

                    bunifuCustomLabel11.Text = x.ToString();
                }

                catch (Exception e12)
                {


                    MessageBox.Show("THE MAXXIMUM AMOUNT REACHED" + e12);
                    bunifuCustomLabel11.Text = "0";

                }

            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {


            MySqlDataReader rdr2 = null;

            con.Open();

            string stm2 = "SELECT unit FROM stock where name = '" + textBox2.Text + "'";
            MySqlCommand cmd2 = new MySqlCommand(stm2, con);
            rdr2 = cmd2.ExecuteReader();

            while (rdr2.Read())
            {
                bunifuCustomLabel9.Text = rdr2.GetString(0);
                bunifuCustomLabel8.Text = rdr2.GetString(0);
            }

            con.Close();



        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Fill All the Forms ");
            }
            else
            {
                try
                {

                    int x = 0;
                
                    double cba=0;

                    double main = 0;

                    double totalo=0;
                


                    MySqlDataReader rdr2 = null;

                    con.Open();

                    string stm2 = "SELECT id,main_bal FROM clients where c_name = '" + textBox1.Text + "'";
                    MySqlCommand cmd2 = new MySqlCommand(stm2, con);
                    rdr2 = cmd2.ExecuteReader();

                    while (rdr2.Read())
                    {
                        string ccname = rdr2.GetString(0);

                        cba = Convert.ToDouble(rdr2.GetString(1));
                        x = Convert.ToInt32(ccname);
                    }

                    con.Close();


                   
                    try
                    {



                        //datagrid insert



                        foreach (DataRow dr in dt.Rows)
                        {




                            con.Open();




                            string insertQuery = "INSERT INTO advanced_buj (date, c_id, detail, debit_amu, item_id,total_buj,curent_buj,rate) VALUES('" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" + x + "','" + dr["remark"].ToString() + "','" + dr["Price"].ToString() + "', '" + dr["Product_Name"].ToString() + "','" + dr["Quantity"].ToString() + "','" + dr["Quantity"].ToString() + "','" + dr["Unit_price"].ToString() + "')";

                            MySqlCommand command = new MySqlCommand(insertQuery, con);

                            command.ExecuteNonQuery();

                            con.Close();



                        //    string query102 = "Update stock  SET quantity =quantity - '" + (Convert.ToDouble(dr1["Amount"].ToString())) + "' where name = '" + dr1["Item_name"].ToString() + "' ";





                        }




                    }
                    catch (Exception e11)
                    {
                        con.Close();

                        MessageBox.Show("" + e11);
                       


                        sales s = new sales();
                        s.Show();
                       this.Hide();


                    }

                    foreach (DataRow dr in dt.Rows)
                    {

                        totalo = totalo + Convert.ToDouble(dr["Price"].ToString());


                    }



                    con.Open();

                    string query1 = "Update clients SET main_bal =main_bal+  '" + totalo + "' where c_name = '" + textBox1.Text + "' ";


                    MySqlCommand cmd1 = new MySqlCommand(query1, con);

                    //Execute command
                    cmd1.ExecuteNonQuery();

                    //close connection
                    con.Close();





                    con.Open();

                    string query10 = "Update totalbal SET total_credit =total_credit+ '" + totalo + "' where id = '1' ";


                   
                    MySqlCommand cmd10 = new MySqlCommand(query10, con);

                    //Execute command
                    cmd10.ExecuteNonQuery();

                    //close connection
                    con.Close();





                    //add and mob

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






                    main = cba + totalo;





                    MessageBox.Show("Order Taken !!! ");

                    sales s22 = new sales();
                    
                    s22.Show();

                   this.Hide();


                









                   // print

                    this.printDialog1.Document = this.printDocument1;
                    DialogResult dr3 = this.printDialog1.ShowDialog();

                    print p = new print();

                   
                  



                    if (dr3 == DialogResult.OK)
                    {

                        int nCopy = this.printDocument1.PrinterSettings.Copies;

                        int sPage = this.printDocument1.PrinterSettings.FromPage;

                        int ePage = this.printDocument1.PrinterSettings.ToPage;
                        string PrinterName = this.printDocument1.PrinterSettings.PrinterName;

                        crReportDocument = new ReportDocument();

                        con.Open();
                      
                        adddata custDB = new adddata();
                        
                        


                        crReportDocument = new CrystalReport4();

                        crReportDocument.Database.Tables["dt"].SetDataSource(dt);



             

                         crReportDocument.SetParameterValue("name", textBox1.Text);

                         crReportDocument.SetParameterValue("total", totalo);

                         crReportDocument.SetParameterValue("add", mm);

                         crReportDocument.SetParameterValue("mob", yy);

                        crReportDocument.SetParameterValue("prem", cba);

                       crReportDocument.SetParameterValue("new", main);






                        try
                        {


                            crReportDocument.PrintOptions.PrinterName = PrinterName;




                            p.crystalReportViewer1.ReportSource = crReportDocument;
                            //p.crystalReportViewer1.Refresh();
                          //  p.Show();
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
                catch (Exception e11)
                {


                    MessageBox.Show("Error ocure Check Server PC" + e11);

                    con.Close();


                    sales s = new sales();
                    s.Show();
                   this.Hide();
                }



                con.Close();
                sales s1 = new sales();
                s1.Show();
               this.Hide();
            }
        }







        private void bunifuCustomTextbox5_TextChanged(object sender, EventArgs e)
        {



            if (bunifuCustomTextbox4.Text != "" && bunifuCustomTextbox5.Text != "")
            {

                try
                {
                    double x = Convert.ToDouble(this.bunifuCustomTextbox4.Text) * Convert.ToDouble(this.bunifuCustomTextbox5.Text);

                    bunifuCustomLabel20.Text = x.ToString("N");
                }

                catch (Exception e12)
                {


                    MessageBox.Show("THE MAXXIMUM AMOUNT RICHED" + e12);
                    bunifuCustomLabel20.Text = "0";

                }

            }






        }

        private void bunifuCustomTextbox4_TextChanged(object sender, EventArgs e)
        {
            if (bunifuCustomTextbox4.Text != "" && bunifuCustomTextbox5.Text != "")
            {

                try
                {
                    double x = Convert.ToDouble(this.bunifuCustomTextbox4.Text) * Convert.ToDouble(this.bunifuCustomTextbox5.Text);

                    bunifuCustomLabel20.Text = x.ToString();
                }

                catch (Exception e12)
                {


                    MessageBox.Show("THE MAXXIMUM AMOUNT RICHED" + e12);
                    bunifuCustomLabel20.Text = "0";

                }

            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {








            MySqlDataReader rdr2 = null;

            con.Open();

            string stm2 = "SELECT unit FROM stock where name = '" + textBox3.Text + "'";
            MySqlCommand cmd2 = new MySqlCommand(stm2, con);
            rdr2 = cmd2.ExecuteReader();

            if (rdr2.Read())
            {
                bunifuCustomLabel19.Text = rdr2.GetString(0);
                bunifuCustomLabel18.Text = rdr2.GetString(0);
            }

            con.Close();












        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {

            if (textBox4.Text == "" || bunifuCustomTextbox4.Text == "" || bunifuCustomTextbox5.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Fill All the Forms ");
            }
            else
            {
                try
                {
                    int x = 0;
                    int y = 0;
                    double main = Convert.ToDouble(this.bunifuCustomTextbox4.Text) * Convert.ToDouble(this.bunifuCustomTextbox5.Text);
                    double total = Convert.ToDouble(this.bunifuCustomTextbox4.Text) * Convert.ToDouble(this.bunifuCustomTextbox5.Text);



                    MySqlDataReader rdr2 = null;

                    con.Open();

                    string stm2 = "SELECT id FROM clients where c_name = '" + textBox4.Text + "'";
                    MySqlCommand cmd2 = new MySqlCommand(stm2, con);
                    rdr2 = cmd2.ExecuteReader();

                    while (rdr2.Read())
                    {
                        string ccname = rdr2.GetString(0);

                        x = Convert.ToInt32(ccname);
                    }

                    con.Close();


                    MySqlDataReader rdr22 = null;

                    con.Open();

                    string stm22 = "SELECT id FROM stock where name = '" + textBox3.Text + "'";
                    MySqlCommand cmd22 = new MySqlCommand(stm22, con);
                    rdr22 = cmd22.ExecuteReader();

                    while (rdr22.Read())
                    {
                        string icname = rdr22.GetString(0);
                        y = Convert.ToInt32(icname);
                    }

                    con.Close();






                    con.Open();

                    string query = "INSERT INTO sales_buj (date, c_id, detail, debit_amu, item_id,total_buj,curent_buj,rate) VALUES ('" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" + x + "', '" + bunifuCustomTextbox6.Text + "','" + Convert.ToDouble(this.bunifuCustomTextbox4.Text) * Convert.ToDouble(this.bunifuCustomTextbox5.Text) + "', '" + textBox3.Text + "','" + bunifuCustomTextbox5.Text + "','" + bunifuCustomTextbox5.Text + "','" + bunifuCustomTextbox4.Text + "') ";


                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, con);

                    //Execute command




                    cmd.ExecuteNonQuery();
                    long last = cmd.LastInsertedId;

                    //close connection
                    con.Close();


                    //MessageBox.Show("" + imageId);



                    MySqlDataReader rdr42 = null;

                    con.Open();

                    string stm42 = "SELECT main_bal FROM clients where c_name = '" + textBox4.Text + "'";
                    MySqlCommand cmd42 = new MySqlCommand(stm42, con);
                    rdr42 = cmd42.ExecuteReader();

                    while (rdr42.Read())
                    {
                        string ccname = rdr42.GetString(0);

                        main = main + Convert.ToDouble(ccname);
                    }

                    con.Close();




                    con.Open();

                    string query1 = "Update clients SET main_bal = '" + main + "' where c_name = '" + textBox4.Text + "' ";


                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd1 = new MySqlCommand(query1, con);

                    //Execute command
                    cmd1.ExecuteNonQuery();

                    //close connection
                    con.Close();








                    MySqlDataReader rdr042 = null;

                    con.Open();

                    string stm042 = "SELECT total_credit FROM  totalbal where id = '1'";
                    MySqlCommand cmd042 = new MySqlCommand(stm042, con);
                    rdr042 = cmd042.ExecuteReader();

                    while (rdr042.Read())
                    {
                        string ccname = rdr042.GetString(0);

                        total = total + Convert.ToDouble(ccname);
                    }

                    con.Close();



                    con.Open();

                    string query10 = "Update totalbal  SET total_credit = '" + total + "' where id = '1' ";


                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd10 = new MySqlCommand(query10, con);

                    //Execute command
                    cmd10.ExecuteNonQuery();

                    //close connection
                    con.Close();

                    MessageBox.Show("Sold !!! ");
                    end();









                    string mm = "";
                    string yy = "";


                    MySqlDataReader rdr43 = null;

                    con.Open();

                    string stm43 = "SELECT * FROM clients where c_name='" + textBox4.Text + "'";
                    MySqlCommand cmd43 = new MySqlCommand(stm43, con);
                    rdr43 = cmd43.ExecuteReader();

                    if (rdr43.Read())
                    {
                        mm = rdr43.GetString(2).ToString();
                        yy = rdr43.GetString(3).ToString();


                    }

                    con.Close();














                    //print report


                    double income = 0;

                    MySqlDataReader rdr28 = null;
                    con.Open();

                    string stm8 = "select * from sales_buj where id=" + last + " ";
                    MySqlCommand cmd8 = new MySqlCommand(stm8, con);
                    rdr28 = cmd8.ExecuteReader();

                    while (rdr28.Read())
                    {
                        income = income + Convert.ToDouble(rdr28.GetString("debit_amu"));


                    }

                    con.Close();




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
                        resell custDB = new resell();
                        custDB.Clear();

                        cmda.CommandText = "select * from sales_buj where id=" + last + " ";
                        cmda.ExecuteNonQuery();


                        adap = new MySqlDataAdapter();

                        adap.SelectCommand = cmda;

                        DataTable d1 = new DataTable();

                        adap.Fill(custDB.DataTable1);
                        adap.Fill(d1);


                        crReportDocument = new CrystalReport3();

                        crReportDocument.SetDataSource(custDB);

                        crReportDocument.SetParameterValue("name", textBox4.Text);
                        crReportDocument.SetParameterValue("qut", bunifuCustomTextbox5.Text);

                        crReportDocument.SetParameterValue("income", income);

                        crReportDocument.SetParameterValue("add", mm);

                        crReportDocument.SetParameterValue("mob", yy);



                        try
                        {


                            crReportDocument.PrintOptions.PrinterName = PrinterName;




                            p.crystalReportViewer1.ReportSource = crReportDocument;
                           // p.crystalReportViewer1.Refresh();
                           // p.Show();
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
                catch (Exception e11)
                {


                    MessageBox.Show("Error ocure Check Server PC" + e11);


                }
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            preg.Visible = false;
            ani1.ShowSync(panel1);

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            preg.Visible = false;
            panel1.Visible = false;

            ani1.ShowSync(preg);
        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCustomTextbox5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            Application.OpenForms[2].Visible = true;
            while (Application.OpenForms.Count > 4) { Application.OpenForms[3].Dispose(); }
            Application.OpenForms[3].Dispose();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
if( textBox1.Text==""||textBox2.Text==""||bunifuCustomTextbox1.Text==""|| bunifuCustomTextbox3.Text=="" )
{


    MessageBox.Show("Fill all the boxes");


}



            else{

            DataRow dr = dt.NewRow();


            dr["Product_Name"] = textBox2.Text;


            dr["Quantity"] = bunifuCustomTextbox1.Text;
            dr["Unit_price"] = bunifuCustomTextbox3.Text;

            dr["Price"] = bunifuCustomLabel11.Text;

            dr["remark"] = bunifuCustomTextbox2.Text;


            dt.Rows.Add(dr);

            bunifuCustomDataGrid2.DataSource = dt;




            textBox2.Text = "";


            bunifuCustomTextbox1.Text = "";
            bunifuCustomTextbox3.Text="";
            bunifuCustomLabel11.Text="";

            bunifuCustomTextbox2.Text="";

                }


         this.ActiveControl = textBox2;

               this.textBox2.Focus();



           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0)
            {

                MessageBox.Show("Table is already clean!!");
            }

            else
            {

                dt.Rows.RemoveAt(Convert.ToInt32(bunifuCustomDataGrid2.CurrentCell.RowIndex.ToString()));
               
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {





                this.ActiveControl = textBox2;

                this.textBox2.Focus();

                e.SuppressKeyPress = true;


            }

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
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

        private void bunifuCustomTextbox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {





                this.ActiveControl = bunifuCustomTextbox2;

                this.bunifuCustomTextbox2.Focus();

                e.SuppressKeyPress = true;


            }
        }

        private void bunifuCustomTextbox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {





                this.ActiveControl = button3;

                this.button3.Focus();

                e.SuppressKeyPress = true;


            }
        }

        private void button3_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {





                this.ActiveControl = textBox2;

                this.textBox2.Focus();

                e.SuppressKeyPress = true;


            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MySqlDataReader rdr2 = null;

            con.Open();

            string stm2 = "SELECT c_mobile,c_add FROM  clients where c_name = '" + textBox1.Text + "'";
            MySqlCommand cmd2 = new MySqlCommand(stm2, con);
            rdr2 = cmd2.ExecuteReader();

            if (rdr2.Read())
            {

               
               // double x = Convert.ToDouble(rdr2.GetString(0));

               // new_amount = x;
               // bunifuCustomLabel9.Text = x.ToString("N");
                //bunifuCustomLabel18.Text = rdr2.GetString(0);

                bunifuCustomLabel29.Text = rdr2.GetString(0);
                bunifuCustomTextbox8.Text = rdr2.GetString(1);




            }
            else
            {


               // bunifuCustomLabel9.Text = "";
                bunifuCustomLabel22.Text = "";
                bunifuCustomTextbox8.Text = "";


            }

            con.Close();

        }
    }
}
