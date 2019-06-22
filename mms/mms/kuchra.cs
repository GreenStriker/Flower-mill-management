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
    public partial class kuchra : Form
    {

        MySqlConnection con = null;
        ReportDocument crReportDocument;


        double total = 0;
        double pt = 0;
        double ss = 0;
        double paidc = 0;
        string new_bal = "0";
        string statuspay = "DUE";
        DataTable dt = new DataTable();
        public kuchra()
        {
            InitializeComponent();
            con = DatabaseConnection.getDBConnection();

            con.Close();
        }

       


        public void clear()
        {

            textBox3.Text = "";

            textBox4.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";

           

        }

        public void clear2()
        {

            textBox3.Text = "";

            textBox4.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";
            textBox1.Text = "";
            textBox6.Text = "";
            bunifuCustomLabel11.Text = "";
            textBox11.Text = "0";
            textBox8.Text = "none";
            textBox9.Text = "none";
            textBox10.Text = "0";
            comboBox1.Text = "";
            bunifuCustomLabel2.Text = "0";

            if (dt.Rows.Count == 0)
            {

               // MessageBox.Show("Table is already clean!!");
                
            }

            else
            {
                try
                {

                    total = 0;
                    bunifuCustomLabel2.Text = total.ToString();

                    dt.Rows.Clear();



                }
                catch (Exception d)
                {
                    MessageBox.Show("Erro" + d);
                    this.Close();
                    con.Close();

                }
            }
            con.Close();
            double x = 1;
            double tracker = 0;

            MySqlDataReader rdr112 = null;

            con.Open();

            string stm112 = "SELECT id FROM kusra_sale ORDER BY id DESC";
            MySqlCommand cmd112 = new MySqlCommand(stm112, con);
            rdr112 = cmd112.ExecuteReader();

            if (rdr112.Read())
            {

                tracker = Convert.ToDouble(rdr112.GetString(0));





            }
            con.Close();





            MySqlDataReader rdr1122 = null;

            con.Open();

            string stm1122 = "SELECT s_id FROM kusra_sale where id='" + tracker + "'";
            MySqlCommand cmd1122 = new MySqlCommand(stm1122, con);
            rdr1122 = cmd1122.ExecuteReader();

            if (rdr1122.Read())
            {

                x += Convert.ToDouble(rdr1122.GetString(0));





            } con.Close();















            textBox1.Text = x.ToString();
            textBox2.Text = DateTime.Now.ToString("dd/MM/yyyy");

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

        private void button5_Click_1(object sender, EventArgs e)
        {

            if (dt.Rows.Count == 0 || textBox6.Text == "" || comboBox1.Text=="")
            {

                MessageBox.Show("add item first And Client Name And payment Type");
            }
            else
            {
                try 
                {
                int qty;
                string pname;

                



                if(comboBox1.Text=="Cash")
                {

                    foreach (DataRow dr in dt.Rows)
                    {

                        con.Open();
                        string insertQuery = "INSERT INTO kusra_sale(s_id,name,tprice,quantity,date,c_name,rate,addr,mobi,pay_type,pertial_pay) VALUES('" + textBox1.Text + "','" + dr["product"].ToString() + "','" + dr["total"].ToString() + "','" + dr["quantity"].ToString() + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "','" + textBox6.Text + "','" + dr["price"].ToString() + "','" + textBox8.Text + "','" + textBox9.Text + "','" + comboBox1.Text + "','" + textBox10.Text + "')";

                        MySqlCommand command = new MySqlCommand(insertQuery, con);

                        command.ExecuteNonQuery();


                        qty = Convert.ToInt32(dr["quantity"].ToString());
                        pname = dr["product"].ToString();

                        string insertQuery2 = "update stock set quantity=quantity-" + qty + " where name='" + pname.ToString() + "'";

                        MySqlCommand command2 = new MySqlCommand(insertQuery2, con);

                        command2.ExecuteNonQuery();




                        con.Close();


                        con.Open();



                        string insertQuery1 = "INSERT INTO sales_delivery (date,item_name, deli_item,c_name) VALUES('" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + dr["product"].ToString() + "','" + dr["quantity"].ToString() + "','" + textBox6.Text + "')";

                        MySqlCommand command1 = new MySqlCommand(insertQuery1, con);

                        command1.ExecuteNonQuery();

                        con.Close();

                    }


                    foreach (DataRow dr1 in dt.Rows)
                    {

                        pt = pt + Convert.ToDouble(dr1["total"].ToString());


                    }









                    con.Open();

                    string query = "INSERT INTO colection (date, c_id, pament_type,	amount,address,mobi ) VALUES ('" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" + textBox6.Text + "', 'Cash','" + bunifuCustomLabel2.Text + "','" + textBox8.Text + "','" + textBox9.Text + "')";


                    
                    MySqlCommand cmd = new MySqlCommand(query, con);

                
                    cmd.ExecuteNonQuery();
                   

                   
                    con.Close();







                    con.Open();

                    string query10 = "Update totalbal SET total_credit =total_credit+ '" + bunifuCustomLabel2.Text + "' where id='1' ";


                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd10 = new MySqlCommand(query10, con);

                    //Execute command
                    cmd10.ExecuteNonQuery();

                    //close connection
                    con.Close();

                    statuspay = "Paid";

                    if (bunifuCustomLabel11.Text == "Not A Ledger Customer")
                    { }
                    else
                    {
                        new_bal = bunifuCustomLabel11.Text;
                    }


                    //conver
                    paidc = Convert.ToDouble(bunifuCustomLabel2.Text);

                    PRI();


                }
                else if (comboBox1.Text=="Partial")
                {
                    if (bunifuCustomLabel11.Text == "Not A Ledger Customer")
                    {

                        MessageBox.Show("Open His Leadger For Due of Pertial Payment");


                    }

                    else
                    {



                        foreach (DataRow dr in dt.Rows)
                        {

                            con.Open();
                            string insertQuery = "INSERT INTO kusra_sale(s_id,name,tprice,quantity,date,c_name,rate,addr,mobi,pay_type,pertial_pay) VALUES('" + textBox1.Text + "','" + dr["product"].ToString() + "','" + dr["total"].ToString() + "','" + dr["quantity"].ToString() + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "','" + textBox6.Text + "','" + dr["price"].ToString() + "','" + textBox8.Text + "','" + textBox9.Text + "','" + comboBox1.Text + "','" + textBox10.Text + "')";

                            MySqlCommand command = new MySqlCommand(insertQuery, con);

                            command.ExecuteNonQuery();


                            qty = Convert.ToInt32(dr["quantity"].ToString());
                            pname = dr["product"].ToString();

                            string insertQuery2 = "update stock set quantity=quantity-" + qty + " where name='" + pname.ToString() + "'";

                            MySqlCommand command2 = new MySqlCommand(insertQuery2, con);

                            command2.ExecuteNonQuery();




                            con.Close();




                            con.Open();



                            string insertQuery1 = "INSERT INTO sales_delivery (date,item_name, deli_item,c_name) VALUES('" + DateTime.Now.ToString("yyyy-MM-dd") + "','"+ dr["product"].ToString()+ "','" + dr["quantity"].ToString() + "','" + textBox6.Text+ "')";

                            MySqlCommand command1 = new MySqlCommand(insertQuery1, con);

                            command1.ExecuteNonQuery();

                            con.Close();

                        }


                        foreach (DataRow dr1 in dt.Rows)
                        {

                            pt = pt + Convert.ToDouble(dr1["total"].ToString());


                        }

                        con.Open();

                        string query = "INSERT INTO colection (date, c_id, pament_type,	amount,address,mobi ) VALUES ('" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" + textBox6.Text + "', 'Cash','" + textBox10.Text + "','" + textBox8.Text + "','" + textBox9.Text + "')";



                        MySqlCommand cmd = new MySqlCommand(query, con);


                        cmd.ExecuteNonQuery();



                        con.Close();







                        con.Open();

                        string query10 = "Update totalbal SET total_credit =total_credit+ '" + textBox10.Text + "' where id='1' ";


                        //create command and assign the query and connection from the constructor
                        MySqlCommand cmd10 = new MySqlCommand(query10, con);

                        //Execute command
                        cmd10.ExecuteNonQuery();

                        //close connection
                        con.Close();

                        ss = Convert.ToDouble(bunifuCustomLabel2.Text) - Convert.ToDouble(textBox10.Text);



                        con.Open();

                        string query1012 = "Update clients SET main_bal =main_bal+ '" +ss +"' where c_name='" + textBox6 .Text+ "' ";


                        //create command and assign the query and connection from the constructor
                        MySqlCommand cmd1012 = new MySqlCommand(query1012, con);

                        //Execute command
                        cmd1012.ExecuteNonQuery();

                        //close connection
                        con.Close();






                       // MessageBox.Show("clear");
                        //





                        new_bal = (Convert.ToDouble(bunifuCustomLabel11.Text) + ss).ToString();


                        paidc = Convert.ToDouble(textBox10.Text);

                        PRI();




                    }


















                }

                else
                {

                    if (bunifuCustomLabel11.Text == "Not A Ledger Customer")
                    {

                        MessageBox.Show("Open His Leadger For Due of Pertial Payment");


                    }

                    else
                    {

                        foreach (DataRow dr in dt.Rows)
                        {

                            con.Open();
                            string insertQuery = "INSERT INTO kusra_sale(s_id,name,tprice,quantity,date,c_name,rate,addr,mobi,pay_type,pertial_pay) VALUES('" + textBox1.Text + "','" + dr["product"].ToString() + "','" + dr["total"].ToString() + "','" + dr["quantity"].ToString() + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "','" + textBox6.Text + "','" + dr["price"].ToString() + "','" + textBox8.Text + "','" + textBox9.Text + "','" + comboBox1.Text + "','" + textBox10.Text + "')";

                            MySqlCommand command = new MySqlCommand(insertQuery, con);

                            command.ExecuteNonQuery();


                            qty = Convert.ToInt32(dr["quantity"].ToString());
                            pname = dr["product"].ToString();

                            string insertQuery2 = "update stock set quantity=quantity-" + qty + " where name='" + pname.ToString() + "'";

                            MySqlCommand command2 = new MySqlCommand(insertQuery2, con);

                            command2.ExecuteNonQuery();




                            con.Close();








                            con.Open();



                            string insertQuery1 = "INSERT INTO sales_delivery (date,item_name, deli_item,c_name) VALUES('" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + dr["product"].ToString() + "','" + dr["quantity"].ToString() + "','" + textBox6.Text + "')";

                            MySqlCommand command1 = new MySqlCommand(insertQuery1, con);

                            command1.ExecuteNonQuery();

                            con.Close();

                        }


                        foreach (DataRow dr1 in dt.Rows)
                        {

                            pt = pt + Convert.ToDouble(dr1["total"].ToString());


                        }









                    ss = Convert.ToDouble(bunifuCustomLabel2.Text);


                    con.Open();

                    string query1012 = "Update clients SET main_bal =main_bal+ '" + ss + "' where c_name='" + textBox6.Text + "' ";


                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd1012 = new MySqlCommand(query1012, con);

                    //Execute command
                    cmd1012.ExecuteNonQuery();

                    //close connection
                    con.Close();







                    new_bal = (Convert.ToDouble(bunifuCustomLabel11.Text) + ss).ToString();


                    PRI();

                }

                }


















             

                
//print invoice











               







              


                }

                    catch(Exception E )
                {
                    con.Close();
                        //kuchra K = new kuchra();
                        //K.Show();
                        //this.Hide();

                    MessageBox.Show("last ---- " + E);

                    }




            }
        }










        public void PRI()
        {



            string name = textBox6.Text;





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

            cmda.CommandText = "select * from kusra_sale where kusra_sale.s_id=" + textBox1.Text + " ";
            cmda.ExecuteNonQuery();


            adap = new MySqlDataAdapter();

            adap.SelectCommand = cmda;

            DataTable d1 = new DataTable();

            adap.Fill(custDB.DataTable1);
            adap.Fill(d1);


            crReportDocument = new CrystalReport1();

            crReportDocument.SetDataSource(custDB);

            crReportDocument.SetParameterValue("total", bunifuCustomLabel2.Text);

            crReportDocument.SetParameterValue("name", textBox6.Text);


            crReportDocument.SetParameterValue("paid", paidc);

            crReportDocument.SetParameterValue("due", ss);

            crReportDocument.SetParameterValue("pre", bunifuCustomLabel11.Text);

            crReportDocument.SetParameterValue("new", new_bal);

            crReportDocument.SetParameterValue("sta", statuspay);

            crReportDocument.SetParameterValue("dis", textBox11.Text);

            crReportDocument.SetParameterValue("predis", pt);

            crReportDocument.SetParameterValue("cpy", "Office Copy");




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













            this.printDialog1.Document = this.printDocument1;
            //  DialogResult dr4 = this.printDialog1.ShowDialog();

            print p1 = new print();

            MySqlCommand cmda1;
            MySqlDataAdapter adap1;


            string PrinterName1 = this.printDocument1.PrinterSettings.PrinterName;

            crReportDocument = new ReportDocument();

            con.Open();
            cmda1 = con.CreateCommand();
            DataSet1 custDB1 = new DataSet1();
            custDB.Clear();

            cmda1.CommandText = "select * from kusra_sale where kusra_sale.s_id=" + textBox1.Text + " ";
            cmda1.ExecuteNonQuery();


            adap1 = new MySqlDataAdapter();

            adap1.SelectCommand = cmda1;

            DataTable d11 = new DataTable();

            adap1.Fill(custDB.DataTable1);
            adap1.Fill(d1);


            crReportDocument = new CrystalReport1();

            crReportDocument.SetDataSource(custDB);

            crReportDocument.SetParameterValue("total", bunifuCustomLabel2.Text);

            crReportDocument.SetParameterValue("name", textBox6.Text);


            crReportDocument.SetParameterValue("paid", paidc);

            crReportDocument.SetParameterValue("due", ss);

            crReportDocument.SetParameterValue("pre", bunifuCustomLabel11.Text);

            crReportDocument.SetParameterValue("new", new_bal);

            crReportDocument.SetParameterValue("sta", statuspay);

            crReportDocument.SetParameterValue("dis", textBox11.Text);

            crReportDocument.SetParameterValue("predis", pt);
            crReportDocument.SetParameterValue("cpy", "Customer Copy");




            try
            {


                crReportDocument.PrintOptions.PrinterName = PrinterName;




                p1.crystalReportViewer1.ReportSource = crReportDocument;
               // p1.crystalReportViewer1.Refresh();
                //p1.Show();

                crReportDocument.PrintToPrinter(1, false, 1, 1);

                //   MessageBox.Show("Report finished printing!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                con.Close();
            }
            con.Close();






            clear2();


            //kuchra K = new kuchra();
            //K.Show();
            //this.Hide();




        }

















        private void button4_Click_1(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0)
            {

                MessageBox.Show("add item first");
            }

            else
            {
                int qty;
                string pname;

                foreach (DataRow dr in dt.Rows)
                {

                    con.Open();
                    string insertQuery = "INSERT INTO  kusra_sale(s_id,name,tprice,quantity,date) VALUES('" + textBox1.Text + "','" + dr["product"].ToString() + "','" + dr["total"].ToString() + "','" + dr["quantity"].ToString() + "','" + textBox2.Text + "')";

                    MySqlCommand command = new MySqlCommand(insertQuery, con);

                    command.ExecuteNonQuery();


                    qty = Convert.ToInt32(dr["quantity"].ToString());
                    pname = dr["product"].ToString();

                    string insertQuery2 = "update stock set quantity=quantity-" + qty + " where name='" + pname.ToString() + "'";

                    MySqlCommand command2 = new MySqlCommand(insertQuery2, con);

                    command2.ExecuteNonQuery();

                   


                    con.Close();
              

                }


                con.Open();

                string query10 = "Update totalbal SET total_credit =total_credit+ '" + bunifuCustomLabel2.Text + "' where id='1' ";


                //create command and assign the query and connection from the constructor
                MySqlCommand cmd10 = new MySqlCommand(query10, con);

                //Execute command
                cmd10.ExecuteNonQuery();

                //close connection
                con.Close();



                MessageBox.Show("SOLD");
                clear2();

                dt.Clear();

                textBox1.Text = DateTime.Now.ToString("yyMMddHHmmss");


                

            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0)
            {

                MessageBox.Show("Table is already clean!!");
                bunifuCustomLabel2.Text = "0";
            }

            else
            {
                try
                {

                    total = 0;
                    bunifuCustomLabel2.Text = total.ToString();

                    dt.Rows.RemoveAt(Convert.ToInt32(bunifuCustomDataGrid1.CurrentCell.RowIndex.ToString()));


                    foreach (DataRow dr1 in dt.Rows)
                    {

                        total = total + Convert.ToDouble(dr1["total"].ToString());
                        bunifuCustomLabel2.Text = total.ToString();

                    }


                }
                catch (Exception d)
                {
                    MessageBox.Show("Erro" + d);
                    this.Close();
                    con.Close();

                }
            }
        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void kuchra_Load(object sender, EventArgs e)
        {



            this.ActiveControl = comboBox1;

            this.comboBox1.Focus();

            con.Close();
            double x=1;
            double tracker=0;

            MySqlDataReader rdr112 = null;

            con.Open();

            string stm112 = "SELECT id FROM kusra_sale ORDER BY id DESC";
            MySqlCommand cmd112 = new MySqlCommand(stm112, con);
            rdr112 = cmd112.ExecuteReader();

            if (rdr112.Read())
            {

                tracker= Convert.ToDouble(rdr112.GetString(0));
               




            } 
            con.Close();





            MySqlDataReader rdr1122 = null;

            con.Open();

            string stm1122 = "SELECT s_id FROM kusra_sale where id='"+tracker+"'";
            MySqlCommand cmd1122 = new MySqlCommand(stm1122, con);
            rdr1122 = cmd1122.ExecuteReader();

            if (rdr1122.Read())
            {

                x += Convert.ToDouble(rdr1122.GetString(0));





            } con.Close();
            
            
            
            





            
         




            textBox1.Text = x.ToString();
            textBox2.Text = DateTime.Now.ToString("dd/MM/yyyy");

            dt.Clear();

            dt.Columns.Add("product");
            dt.Columns.Add("price");
            dt.Columns.Add("quantity");
            dt.Columns.Add("total");




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
            // textBox2.AutoCompleteCustomSource = mm;
            textBox3.AutoCompleteCustomSource = mm;
            con.Close();





        }

        private void textBox6_KeyDown_1(object sender, KeyEventArgs e)
        {


           
        }

        private void textBox6_KeyPress_1(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBox6_KeyUp_1(object sender, KeyEventArgs e)
        {
          
        }

       

        private void textBox4_Enter_1(object sender, EventArgs e)
        {
            //string query = "SELECT * from stock WHERE name ='" + textBox3.Text + "'";
            //MySqlCommand cmd = new MySqlCommand(query, con);





            //MySqlDataReader reader;

            //try
            //{
            //    con.Open();


            //    reader = cmd.ExecuteReader();

            //    while (reader.Read())
            //    {

            //        string price = reader.GetString("up_price");

            //        textBox4.Text = price;

            //    }
            //    con.Close();



            //}
            //catch (Exception ex)
            //{

            //    con.Close();
            //    MessageBox.Show("Erro" + ex);

            //}

        }

        private void textBox5_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 44 || e.KeyChar == 45 || e.KeyChar == 46 || e.KeyChar == (char)13)
            {


                e.Handled = false;

            }
            else
            {
                MessageBox.Show("Please Enter only Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Handled = true;

            }
        }

        private void textBox5_Leave_1(object sender, EventArgs e)
        {


            try
            {


                textBox7.Text = Convert.ToString(Convert.ToDouble(textBox5.Text) * Convert.ToDouble(textBox4.Text));

            }
            catch (Exception w)
            {

               // MessageBox.Show("Plz fill the field");



            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {




            if (textBox3.Text==""||textBox4.Text==""||textBox5.Text=="")
            {
               

                MessageBox.Show("Fill All te BOXES");

            }
            
            
            else
            {
            
            
            int stock = 0;


            string query = "SELECT  * from stock WHERE name ='" + textBox3.Text + "'";
            MySqlCommand cmd = new MySqlCommand(query, con);





            MySqlDataReader reader;

            try
            {
                con.Open();


                reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    stock = Convert.ToInt32(reader.GetString("quantity"));



                }
                con.Close();

                //if (Convert.ToInt32(textBox5.Text) > stock)
                //{


                //    MessageBox.Show("Sorry u !! Desired product is not availabe");
                //}


                //else
                //{


                    DataRow dr = dt.NewRow();


                    dr["product"] = textBox3.Text;


                    dr["price"] = textBox4.Text;

                    dr["quantity"] = textBox5.Text;
                    dr["total"] = textBox7.Text;


                    dt.Rows.Add(dr);

                    bunifuCustomDataGrid1.DataSource = dt;

                    total = total + Convert.ToDouble(dr["total"].ToString());

                    bunifuCustomLabel2.Text = total.ToString();

               // }



            }
            catch (Exception q)
            {
                MessageBox.Show("Erro" + q);
                this.Close();
                con.Close();
            }

            clear();



        }


            this.ActiveControl = textBox3;

            this.textBox3.Focus();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {


                textBox7.Text = Convert.ToString(Convert.ToDouble(textBox5.Text) * Convert.ToDouble(textBox4.Text));

            }
            catch (Exception w)
            {

               // MessageBox.Show("Plz fill the field");

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {


                textBox7.Text = Convert.ToString(Convert.ToDouble(textBox5.Text) * Convert.ToDouble(textBox4.Text));

            }
            catch (Exception w)
            {

              //  MessageBox.Show("Plz fill the field");

            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text=="Cash")
            {

                int flag = 0;


                MySqlDataReader rdr2 = null;

                con.Open();

                string stm2 = "SELECT id,c_add,c_mobile,main_bal FROM clients where c_name = '" + textBox6.Text + "'";
                MySqlCommand cmd2 = new MySqlCommand(stm2, con);
                rdr2 = cmd2.ExecuteReader();

                if (rdr2.Read())
                {

                    textBox8.Text = rdr2.GetString(1);
                    textBox9.Text = rdr2.GetString(2);


                    double x = Convert.ToDouble(rdr2.GetString(3));


                    bunifuCustomLabel11.Text = x.ToString("N");



                    flag = 1;




                }
                else
                {


                    textBox8.Text = "none";
                    textBox9.Text = "none";
                }
                
                
                con.Close();
            
            
            
            
            
            
            
            
            if( flag==0 )
            {





                MySqlDataReader rdr112 = null;

                con.Open();

                string stm112 = "SELECT id,addr,mobi FROM kusra_sale where c_name = '" + textBox6.Text + "' ORDER BY id DESC";
                MySqlCommand cmd112 = new MySqlCommand(stm112, con);
                rdr112 = cmd112.ExecuteReader();

                if (rdr112.Read())
                {

                    textBox8.Text = rdr112.GetString(1);
                    textBox9.Text = rdr112.GetString(2);


                   


                    bunifuCustomLabel11.Text = "Not A Ledger Customer";



                    //flag = 1;




                }

                else
                {



                    textBox8.Text = "none";
                    textBox9.Text = "none";





                    bunifuCustomLabel11.Text = "Not A Ledger Customer";




                }
                
                
                
                con.Close();













            }
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            }


            else
            {


                 MySqlDataReader rdr2 = null;

            con.Open();

            string stm2 = "SELECT id,c_add,c_mobile,main_bal FROM clients where c_name = '" + textBox6.Text + "'";
            MySqlCommand cmd2 = new MySqlCommand(stm2, con);
            rdr2 = cmd2.ExecuteReader();

            if (rdr2.Read())
            {
                
                textBox8.Text = rdr2.GetString(1);
                textBox9.Text = rdr2.GetString(2);


                double x = Convert.ToDouble(rdr2.GetString(3));


                bunifuCustomLabel11.Text = x.ToString("N");








            }
            else
            {



                textBox8.Text = "none";
                textBox9.Text = "none";





                bunifuCustomLabel11.Text = "Not A Ledger Customer";




            } con.Close();















            }

























        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Partial")
            {



                textBox10.Enabled = true;

               

            }

            else
            {

                textBox10.Text = "0";

                textBox10.Enabled = false;


            }

            if (comboBox1.Text == "Cash")
            {


                MySqlDataReader rdr2 = null;



                con.Open();

                string stm2 = "SELECT DISTINCT c_name FROM kusra_sale";
                MySqlCommand cmd2 = new MySqlCommand(stm2, con);
                rdr2 = cmd2.ExecuteReader();

                AutoCompleteStringCollection mm2 = new AutoCompleteStringCollection();

                while (rdr2.Read())
                {

                    mm2.Add(rdr2.GetString(0));



                }
                //textBox6.AutoCompleteCustomSource = mm2;
                
                con.Close();

                MySqlDataReader rdr211 = null;



                con.Open();

                string stm211 = "SELECT  c_name FROM  clients";
                MySqlCommand cmd211 = new MySqlCommand(stm211, con);
                rdr211 = cmd211.ExecuteReader();

               // AutoCompleteStringCollection mm1 = new AutoCompleteStringCollection();

                while (rdr211.Read())
                {

                    mm2.Add(rdr211.GetString(0));



                }
                textBox6.AutoCompleteCustomSource = mm2 ;

                con.Close();



                



            }
            else
            {


                MySqlDataReader rdr2 = null;



                con.Open();

                string stm2 = "SELECT  c_name FROM  clients";
                MySqlCommand cmd2 = new MySqlCommand(stm2, con);
                rdr2 = cmd2.ExecuteReader();

                AutoCompleteStringCollection mm2 = new AutoCompleteStringCollection();

                while (rdr2.Read())
                {

                    mm2.Add(rdr2.GetString(0));



                }
                textBox6.AutoCompleteCustomSource = mm2;

                con.Close();









            }

           

















        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 44 || e.KeyChar == 45 || e.KeyChar == 46 || e.KeyChar == (char)13)
            {


                e.Handled = false;

            }
            else
            {
                MessageBox.Show("Please Enter only Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Handled = true;

            }

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            history h = new history();

            

            h.Show();


            this.Hide();

        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 45 || e.KeyChar == 44 || e.KeyChar == 46)
            {


                e.Handled = false;

            }
            else
            {
                MessageBox.Show("Please Enter only Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Handled = true;

            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

            double ii = 0;
            
            
            
            foreach (DataRow dr1 in dt.Rows)
            {

                ii = ii + Convert.ToDouble(dr1["total"].ToString());


            }

            bunifuCustomLabel2.Text = ii.ToString();

            if (textBox11.Text != "")
            {
                double hh = Convert.ToDouble(bunifuCustomLabel2.Text) - Convert.ToDouble(textBox11.Text);



                bunifuCustomLabel2.Text = (hh).ToString();


            }
            




        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            if(textBox11.Text=="")
            {


                textBox11.Text = "0";

            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode==Keys.Enter)
            {





                   this.ActiveControl = textBox6;

                    this.textBox6.Focus();

                    e.SuppressKeyPress = true;





            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter)
            {





                this.ActiveControl = textBox8;

                this.textBox8.Focus();
                e.SuppressKeyPress = true;






            }

        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {





                this.ActiveControl = textBox9;

                this.textBox9.Focus();

                e.SuppressKeyPress = true;





            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {





                this.ActiveControl = textBox3;

                this.textBox3.Focus();
                e.SuppressKeyPress = true;






            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {





                this.ActiveControl = textBox5;

                this.textBox5.Focus();
                e.SuppressKeyPress = true;






            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {





                this.ActiveControl = textBox4;

                this.textBox4.Focus();


                e.SuppressKeyPress = true;




            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {





                this.ActiveControl = button1;

                this.button1.Focus();

                e.SuppressKeyPress = true;





            }
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
               

                if (textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
                {
                    this.ActiveControl = textBox3;

                    this.textBox3.Focus();
                    e.SuppressKeyPress = true;
                    

                }


                else
                {
                    this.ActiveControl = textBox3;

                    this.textBox3.Focus();
                    e.SuppressKeyPress = true;
                    int stock = 0;


                    string query = "SELECT  * from stock WHERE name ='" + textBox3.Text + "'";
                    MySqlCommand cmd = new MySqlCommand(query, con);





                    MySqlDataReader reader;

                    try
                    {
                        con.Open();


                        reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {

                            stock = Convert.ToInt32(reader.GetString("quantity"));



                        }
                        con.Close();

                        //if (Convert.ToInt32(textBox5.Text) > stock)
                        //{


                        //    MessageBox.Show("Sorry u !! Desired product is not availabe");
                        //}


                        //else
                        //{


                        DataRow dr = dt.NewRow();


                        dr["product"] = textBox3.Text;


                        dr["price"] = textBox4.Text;

                        dr["quantity"] = textBox5.Text;
                        dr["total"] = textBox7.Text;


                        dt.Rows.Add(dr);

                        bunifuCustomDataGrid1.DataSource = dt;

                        total = total + Convert.ToDouble(dr["total"].ToString());

                        bunifuCustomLabel2.Text = total.ToString();

                        // }



                    }
                    catch (Exception q)
                    {
                        MessageBox.Show("Erro" + q);
                        this.Close();
                        con.Close();
                    }

                    clear();
                   





                        






                    


                }






                


            }



        }

        private void button1_Enter(object sender, EventArgs e)
        {
            //this.ActiveControl = textBox3;

           /// this.textBox3.Focus();
        }

        private void button1_Enter_1(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (dt.Rows.Count == 0 || textBox6.Text == "" || comboBox1.Text == "")
            {

                MessageBox.Show("add item first And Client Name And payment Type");
            }
            else
            {
                try
                {
                    int qty;
                    string pname;





                    if (comboBox1.Text == "Cash")
                    {

                        foreach (DataRow dr in dt.Rows)
                        {

                            con.Open();
                            string insertQuery = "INSERT INTO kusra_sale(s_id,name,tprice,quantity,date,c_name,rate,addr,mobi,pay_type,pertial_pay) VALUES('" + textBox1.Text + "','" + dr["product"].ToString() + "','" + dr["total"].ToString() + "','" + dr["quantity"].ToString() + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "','" + textBox6.Text + "','" + dr["price"].ToString() + "','" + textBox8.Text + "','" + textBox9.Text + "','" + comboBox1.Text + "','" + textBox10.Text + "')";

                            MySqlCommand command = new MySqlCommand(insertQuery, con);

                            command.ExecuteNonQuery();


                            qty = Convert.ToInt32(dr["quantity"].ToString());
                            pname = dr["product"].ToString();

                            string insertQuery2 = "update stock set quantity=quantity-" + qty + " where name='" + pname.ToString() + "'";

                            MySqlCommand command2 = new MySqlCommand(insertQuery2, con);

                            command2.ExecuteNonQuery();




                            con.Close();


                            con.Open();



                            string insertQuery1 = "INSERT INTO sales_delivery (date,item_name, deli_item,c_name) VALUES('" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + dr["product"].ToString() + "','" + dr["quantity"].ToString() + "','" + textBox6.Text + "')";

                            MySqlCommand command1 = new MySqlCommand(insertQuery1, con);

                            command1.ExecuteNonQuery();

                            con.Close();

                        }


                        foreach (DataRow dr1 in dt.Rows)
                        {

                            pt = pt + Convert.ToDouble(dr1["total"].ToString());


                        }









                        con.Open();

                        string query = "INSERT INTO colection (date, c_id, pament_type,	amount,address,mobi ) VALUES ('" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" + textBox6.Text + "', 'Cash','" + bunifuCustomLabel2.Text + "','" + textBox8.Text + "','" + textBox9.Text + "')";



                        MySqlCommand cmd = new MySqlCommand(query, con);


                        cmd.ExecuteNonQuery();



                        con.Close();







                        con.Open();

                        string query10 = "Update totalbal SET total_credit =total_credit+ '" + bunifuCustomLabel2.Text + "' where id='1' ";


                        //create command and assign the query and connection from the constructor
                        MySqlCommand cmd10 = new MySqlCommand(query10, con);

                        //Execute command
                        cmd10.ExecuteNonQuery();

                        //close connection
                        con.Close();

                        statuspay = "Paid";

                        if (bunifuCustomLabel11.Text == "Not A Ledger Customer")
                        { }
                        else
                        {
                            new_bal = bunifuCustomLabel11.Text;
                        }


                        //conver
                        paidc = Convert.ToDouble(bunifuCustomLabel2.Text);

                        //PRI();
                        clear2();

                    }
                    else if (comboBox1.Text == "Partial")
                    {
                        if (bunifuCustomLabel11.Text == "Not A Ledger Customer")
                        {

                            MessageBox.Show("Open His Leadger For Due of Pertial Payment");


                        }

                        else
                        {



                            foreach (DataRow dr in dt.Rows)
                            {

                                con.Open();
                                string insertQuery = "INSERT INTO kusra_sale(s_id,name,tprice,quantity,date,c_name,rate,addr,mobi,pay_type,pertial_pay) VALUES('" + textBox1.Text + "','" + dr["product"].ToString() + "','" + dr["total"].ToString() + "','" + dr["quantity"].ToString() + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "','" + textBox6.Text + "','" + dr["price"].ToString() + "','" + textBox8.Text + "','" + textBox9.Text + "','" + comboBox1.Text + "','" + textBox10.Text + "')";

                                MySqlCommand command = new MySqlCommand(insertQuery, con);

                                command.ExecuteNonQuery();


                                qty = Convert.ToInt32(dr["quantity"].ToString());
                                pname = dr["product"].ToString();

                                string insertQuery2 = "update stock set quantity=quantity-" + qty + " where name='" + pname.ToString() + "'";

                                MySqlCommand command2 = new MySqlCommand(insertQuery2, con);

                                command2.ExecuteNonQuery();




                                con.Close();




                                con.Open();



                                string insertQuery1 = "INSERT INTO sales_delivery (date,item_name, deli_item,c_name) VALUES('" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + dr["product"].ToString() + "','" + dr["quantity"].ToString() + "','" + textBox6.Text + "')";

                                MySqlCommand command1 = new MySqlCommand(insertQuery1, con);

                                command1.ExecuteNonQuery();

                                con.Close();

                            }


                            foreach (DataRow dr1 in dt.Rows)
                            {

                                pt = pt + Convert.ToDouble(dr1["total"].ToString());


                            }

                            con.Open();

                            string query = "INSERT INTO colection (date, c_id, pament_type,	amount,address,mobi ) VALUES ('" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" + textBox6.Text + "', 'Cash','" + textBox10.Text + "','" + textBox8.Text + "','" + textBox9.Text + "')";



                            MySqlCommand cmd = new MySqlCommand(query, con);


                            cmd.ExecuteNonQuery();



                            con.Close();







                            con.Open();

                            string query10 = "Update totalbal SET total_credit =total_credit+ '" + textBox10.Text + "' where id='1' ";


                            //create command and assign the query and connection from the constructor
                            MySqlCommand cmd10 = new MySqlCommand(query10, con);

                            //Execute command
                            cmd10.ExecuteNonQuery();

                            //close connection
                            con.Close();

                            ss = Convert.ToDouble(bunifuCustomLabel2.Text) - Convert.ToDouble(textBox10.Text);



                            con.Open();

                            string query1012 = "Update clients SET main_bal =main_bal+ '" + ss + "' where c_name='" + textBox6.Text + "' ";


                            //create command and assign the query and connection from the constructor
                            MySqlCommand cmd1012 = new MySqlCommand(query1012, con);

                            //Execute command
                            cmd1012.ExecuteNonQuery();

                            //close connection
                            con.Close();






                            // MessageBox.Show("clear");
                            //





                            new_bal = (Convert.ToDouble(bunifuCustomLabel11.Text) + ss).ToString();


                            paidc = Convert.ToDouble(textBox10.Text);

                           // PRI();

                            clear2();


                        }


















                    }

                    else
                    {

                        if (bunifuCustomLabel11.Text == "Not A Ledger Customer")
                        {

                            MessageBox.Show("Open His Leadger For Due of Pertial Payment");


                        }

                        else
                        {

                            foreach (DataRow dr in dt.Rows)
                            {

                                con.Open();
                                string insertQuery = "INSERT INTO kusra_sale(s_id,name,tprice,quantity,date,c_name,rate,addr,mobi,pay_type,pertial_pay) VALUES('" + textBox1.Text + "','" + dr["product"].ToString() + "','" + dr["total"].ToString() + "','" + dr["quantity"].ToString() + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "','" + textBox6.Text + "','" + dr["price"].ToString() + "','" + textBox8.Text + "','" + textBox9.Text + "','" + comboBox1.Text + "','" + textBox10.Text + "')";

                                MySqlCommand command = new MySqlCommand(insertQuery, con);

                                command.ExecuteNonQuery();


                                qty = Convert.ToInt32(dr["quantity"].ToString());
                                pname = dr["product"].ToString();

                                string insertQuery2 = "update stock set quantity=quantity-" + qty + " where name='" + pname.ToString() + "'";

                                MySqlCommand command2 = new MySqlCommand(insertQuery2, con);

                                command2.ExecuteNonQuery();




                                con.Close();








                                con.Open();



                                string insertQuery1 = "INSERT INTO sales_delivery (date,item_name, deli_item,c_name) VALUES('" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + dr["product"].ToString() + "','" + dr["quantity"].ToString() + "','" + textBox6.Text + "')";

                                MySqlCommand command1 = new MySqlCommand(insertQuery1, con);

                                command1.ExecuteNonQuery();

                                con.Close();

                            }


                            foreach (DataRow dr1 in dt.Rows)
                            {

                                pt = pt + Convert.ToDouble(dr1["total"].ToString());


                            }









                            ss = Convert.ToDouble(bunifuCustomLabel2.Text);


                            con.Open();

                            string query1012 = "Update clients SET main_bal =main_bal+ '" + ss + "' where c_name='" + textBox6.Text + "' ";


                            //create command and assign the query and connection from the constructor
                            MySqlCommand cmd1012 = new MySqlCommand(query1012, con);

                            //Execute command
                            cmd1012.ExecuteNonQuery();

                            //close connection
                            con.Close();


                            new_bal = (Convert.ToDouble(bunifuCustomLabel11.Text) + ss).ToString();
                            clear2();

                   

                        }

                    }



                }

                catch (Exception E)
                {
                    con.Close();
                    //kuchra K = new kuchra();
                    //K.Show();
                    //this.Hide();

                    MessageBox.Show("last ---- " + E);

                }




            }



        }
        
    }
}
