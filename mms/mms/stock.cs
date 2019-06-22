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
    public partial class stock : Form
    {

      

        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        int x = 0;
        string total2 = "0";
        string total = "";
        ReportDocument crReportDocument;

        MySqlConnection con = null;
        public stock()
        {
            InitializeComponent();
            con = DatabaseConnection.getDBConnection();



            
           
        }
        public stock(int x)
        {
            InitializeComponent();
            con = DatabaseConnection.getDBConnection();
            bunifuThinButton24.Visible = false;
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

        private void stock_Load(object sender, EventArgs e)
        {
            bunifuDatepicker1.Value = DateTime.Now;





            dt1.Clear();

            dt1.Columns.Add("Customer_name");
            dt1.Columns.Add("Item_name");
            dt1.Columns.Add("Amount");
            dt1.Columns.Add("Total_Item");
            dt1.Columns.Add("Total_Delivery");
            dt1.Columns.Add("Remaining_Delivery");
           










            dt.Clear();

            dt.Columns.Add("Product_Name");
           
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Status");







            MySqlDataReader rdr = null;
            con.Close();
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







            con.Open();
            DataTable dataTable = new DataTable();




            string sql1 = "SELECT 	id,name,quantity,unit,low_price,up_price  FROM stock ; ";





            MySqlCommand cmd1 = new MySqlCommand(sql1, con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd1);

            da.Fill(dataTable);


            dataGridView2.DataSource = dataTable;

            dataGridView2.Columns[0].HeaderText = "Product ID ";
            dataGridView2.Columns[1].HeaderText = "Product Name ";
            dataGridView2.Columns[2].HeaderText = "Quantity In Stock ";
            dataGridView2.Columns[3].HeaderText = "Unit  ";
            dataGridView2.Columns[4].HeaderText = "Lowest Selling Price/TAKA ";
            dataGridView2.Columns[5].HeaderText = "Kuchra Selling Price/TAKA ";

            con.Close();



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





            MySqlCommand cmd12 = new MySqlCommand("SELECT * FROM  production_history ;", con);
            con.Open();
            DataTable dataTable12 = new DataTable();
            MySqlDataAdapter da12 = new MySqlDataAdapter(cmd12);

            da12.Fill(dataTable12);


            dataGridView3.DataSource = dataTable12;

            dataGridView3.Columns[0].HeaderText = "Production ID ";





            con.Close();


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            if(textBox3.Text=="")
            {

                con.Open();
                DataTable dataTable = new DataTable();




                string sql1 = "SELECT 	id,name,quantity,unit,low_price  FROM stock ; ";





                MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd1);

                da.Fill(dataTable);


                dataGridView2.DataSource = dataTable;

                dataGridView2.Columns[0].HeaderText = "Product ID ";
                dataGridView2.Columns[1].HeaderText = "Product Name ";
                dataGridView2.Columns[2].HeaderText = "Quantity In Stock ";
                dataGridView2.Columns[3].HeaderText = "Unit  ";
                dataGridView2.Columns[4].HeaderText = "Lowest Selling Price/TAKA ";


                con.Close();






            }
            else
            {



                con.Open();
                DataTable dataTable = new DataTable();




                string sql1 = "SELECT 	id,name,quantity,unit,low_price  FROM stock where name='"+textBox3.Text+"' ; ";





                MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd1);

                da.Fill(dataTable);


                dataGridView2.DataSource = dataTable;

                dataGridView2.Columns[0].HeaderText = "Product ID ";
                dataGridView2.Columns[1].HeaderText = "Product Name ";
                dataGridView2.Columns[2].HeaderText = "Quantity In Stock ";
                dataGridView2.Columns[3].HeaderText = "Unit  ";
                dataGridView2.Columns[4].HeaderText = "Lowest Selling Price/TAKA ";


                con.Close();




            }

















        }

        private void bunifuCustomLabel25_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            ani.ShowSync(panel1);
            


        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            ani.ShowSync(panel5);
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            ani.ShowSync(panel4);
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {


            MySqlDataReader rdr43 = null;

            con.Open();

            string stm43 = "SELECT did FROM  ids where id='1'";
            MySqlCommand cmd43 = new MySqlCommand(stm43, con);
            rdr43 = cmd43.ExecuteReader();

            if (rdr43.Read())
            {
                bunifuCustomLabel28.Text = rdr43.GetString(0).ToString();
               


            }

            con.Close();
            
  
            
            panel1.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            ani.ShowSync(panel3);


                this.ActiveControl = textBox1;

                this.textBox1.Focus();

               // e.SuppressKeyPress = true;





            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {



            MySqlDataReader rdr2 = null;

            con.Open();

            string stm2 = "SELECT id,c_add,c_mobile,main_bal FROM clients where c_name = '" + textBox1.Text + "'";
            MySqlCommand cmd2 = new MySqlCommand(stm2, con);
            rdr2 = cmd2.ExecuteReader();

            if (rdr2.Read())
            {
                bunifuCustomLabel24.Text = rdr2.GetString(0);
                bunifuCustomLabel23.Text = rdr2.GetString(1);
                bunifuCustomLabel22.Text = rdr2.GetString(2);

         
                double x = Convert.ToDouble(rdr2.GetString(3));


                bunifuCustomLabel21.Text = x.ToString("N");








            } con.Close();



























            MySqlDataReader rdr29 = null;

            con.Open();

            string stm29 = "SELECT id FROM clients where c_name = '" + textBox1.Text + "'";
            MySqlCommand cmd29 = new MySqlCommand(stm29, con);
            rdr29 = cmd29.ExecuteReader();

            while (rdr29.Read())
            {
                string ccname = rdr29.GetString(0);

                x = Convert.ToInt32(ccname);
            }

            con.Close();
















            string stm = "";




            stm = "select DISTINCT item_id from advanced_buj where c_id = '" + x +"'";








            MySqlDataReader rdr = null;

            con.Open();


            MySqlCommand cmd = new MySqlCommand(stm, con);
            rdr = cmd.ExecuteReader();
            comboBox1.Items.Clear();
            comboBox1.ResetText();
            while (rdr.Read())
            {

                comboBox1.Items.Add(rdr.GetString(0));




            }

            con.Close();

            DataTable dt = new DataTable();

            dt.Clear();
            dt.Columns.Add("Product Name ");
            dt.Columns.Add("Total  item   ");
            dt.Columns.Add("Total Delivered  item  ");
            dt.Columns.Add("Remaining  item  ");


            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                total = "0";
                total2 = "0";



                 MySqlDataReader rdr211 = null;

            con.Open();

            string stm211 = "SELECT sum(total_buj) FROM advanced_buj where c_id = '" + x + "' AND item_id='" + comboBox1.Items[i] + "'";
            MySqlCommand cmd211 = new MySqlCommand(stm211, con);
            rdr211 = cmd211.ExecuteReader();

            while (rdr211.Read())
            {

                total=rdr211.GetString(0);
            }

            con.Close();



          //  MessageBox.Show(""+total);


            try {

          
            MySqlDataReader rdr22 = null;

            con.Open();

            string stm22 = "SELECT sum(deli_item) FROM ad_delivery where c_id = '" + textBox1.Text + "' AND item_name='" + comboBox1.Items[i] + "'";
            MySqlCommand cmd22 = new MySqlCommand(stm22, con);
            rdr22 = cmd22.ExecuteReader();

            if (rdr22.Read())
            {

                total2 = rdr22.GetString(0);
            }

            con.Close();

                 }

            catch (Exception ee)
            {
                con.Close();
            }

          //  MessageBox.Show("" + total2);








            con.Open();


            dt.Rows.Add(new object[] { comboBox1.Items[i], total, total2, (Convert.ToDouble(total) - Convert.ToDouble(total2)) });
            

         


           // MySqlCommand cmd1 = new MySqlCommand(stm, con);
          //  MySqlDataAdapter da = new MySqlDataAdapter(cmd1);

            //da.Fill(dataTable);


            dataGridView1.DataSource = dt;
            //dataGridView1.DataBindingComplete();

           
            con.Close();









            }













        }

      

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            total = "0";

            total2 = "0";
           
            MySqlDataReader rdr2 = null;

            con.Open();

            string stm2 = "SELECT sum(total_buj) FROM advanced_buj where c_id = '" + x + "' AND item_id='"+ comboBox1.Text+"'";
            MySqlCommand cmd2 = new MySqlCommand(stm2, con);
            rdr2 = cmd2.ExecuteReader();

            while (rdr2.Read())
            {

                total=rdr2.GetString(0);
            }

            con.Close();



          //  MessageBox.Show(""+total);


            try {

          
            MySqlDataReader rdr22 = null;

            con.Open();

            string stm22 = "SELECT sum(deli_item) FROM ad_delivery where c_id = '" + textBox1.Text + "' AND item_name='" + comboBox1.Text + "'";
            MySqlCommand cmd22 = new MySqlCommand(stm22, con);
            rdr22 = cmd22.ExecuteReader();

            if (rdr22.Read())
            {

                total2 = rdr22.GetString(0);
            }

            con.Close();

                 }

            catch (Exception ee)
            {
                con.Close();
            }

          //  MessageBox.Show("" + total2);
















            con.Open();
            DataTable dt = new DataTable();

            dt.Clear();
            dt.Columns.Add("Product_Name ");
            dt.Columns.Add( "Total_Item   ");
            dt.Columns.Add( "Total_Delivered_item  ");
            dt.Columns.Add( "Remaining_item  ");

            dt.Rows.Add(new object[] {comboBox1.Text,total,total2,(Convert.ToDouble(total)-Convert.ToDouble(total2)) });
            

         


           // MySqlCommand cmd1 = new MySqlCommand(stm, con);
          //  MySqlDataAdapter da = new MySqlDataAdapter(cmd1);

            //da.Fill(dataTable);


            dataGridView1.DataSource = dt;
            //dataGridView1.DataBindingComplete();

           
            con.Close();

          
            MySqlDataReader rdr = null;

            con.Open();

            string stmm = "SELECT unit FROM stock where name ='"+dataGridView1.Rows[0].Cells[1].Value.ToString()+"' ";
            MySqlCommand cmd = new MySqlCommand(stmm, con);
            rdr = cmd.ExecuteReader();

            AutoCompleteStringCollection mm = new AutoCompleteStringCollection();


            if (rdr.Read())
            {

                bunifuCustomLabel8.Text = rdr.GetString(0);




            }

            con.Close();





        }

        private void button1_Click(object sender, EventArgs e)
        {






            if (dt1.Rows.Count == 0 || textBox1.Text=="")
            {

                MessageBox.Show("FILL THE Boxes And Add Customer Name ");

            }
            
            
            else{





                    try
                    {















                        //datagrid insert


                      
                        foreach (DataRow dr1 in dt1.Rows)
                        {

                    


                            con.Open();



                            string insertQuery = "INSERT INTO ad_delivery (id,date,item_name, deli_item,c_id) VALUES( '" + bunifuCustomLabel28 .Text+ "'  ,  '" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + dr1["Item_name"].ToString() + "','" + dr1["Amount"].ToString() + "','" + textBox1.Text + "')";

                            MySqlCommand command = new MySqlCommand(insertQuery, con);

                            command.ExecuteNonQuery();

                            con.Close();

                            con.Open();



                            string insertQuery1 = "INSERT INTO sales_delivery (date,item_name, deli_item,c_name) VALUES('" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + dr1["Item_name"].ToString() + "','" + dr1["Amount"].ToString() + "','" + textBox1.Text + "')";

                            MySqlCommand command1 = new MySqlCommand(insertQuery1, con);

                            command1.ExecuteNonQuery();

                            con.Close();



                            string query102 = "Update stock  SET quantity =quantity - '" + (Convert.ToDouble(dr1["Amount"].ToString())) + "' where name = '" + dr1["Item_name"].ToString() + "' ";




                            con.Open();


                            //create command and assign the query and connection from the constructor
                            MySqlCommand cmd102 = new MySqlCommand(query102, con);

                            //Execute command
                            cmd102.ExecuteNonQuery();

                            //close connection
                            con.Close();










                        }




                        textBox2.Text = ""; textBox5.Text = ""; comboBox3.Text = "";



                    }
                    catch (Exception e11)
                    {
                        con.Close();

                        MessageBox.Show("Error ocure Check Server PC" + e11);


                    }





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








              string query1024 = "Update ids  SET did =did+1 ";




                            con.Open();


                            //create command and assign the query and connection from the constructor
                            MySqlCommand cmd1024 = new MySqlCommand(query1024, con);

                            //Execute command
                            cmd1024.ExecuteNonQuery();

                            //close connection
                            con.Close();





//delivery print



                  this.printDialog1.Document = this.printDocument1;
                   // DialogResult dr3 = this.printDialog1.ShowDialog();

                    print p = new print();


                        int nCopy = this.printDocument1.PrinterSettings.Copies;

                        int sPage = this.printDocument1.PrinterSettings.FromPage;

                        int ePage = this.printDocument1.PrinterSettings.ToPage;
                        string PrinterName = this.printDocument1.PrinterSettings.PrinterName;

                        crReportDocument = new ReportDocument();

                        con.Open();
                      
                        ddata custDB = new ddata();
                        
                        


                        crReportDocument = new CrystalReport12();

                       
                        crReportDocument.Database.Tables["dt1"].SetDataSource(dt1);

             

                         crReportDocument.SetParameterValue("name",textBox1.Text);
                         crReportDocument.SetParameterValue("add", mm);

                         crReportDocument.SetParameterValue("mob", yy);

                         crReportDocument.SetParameterValue("bal", bunifuCustomLabel21.Text);

                         crReportDocument.SetParameterValue("did", bunifuCustomLabel28.Text);
                         crReportDocument.SetParameterValue("typ", "Office Copy");

     
                





                        try
                        {


                            crReportDocument.PrintOptions.PrinterName = PrinterName;




                            p.crystalReportViewer1.ReportSource = crReportDocument;
                           // p.crystalReportViewer1.Refresh();
                           // p.Show();
                            crReportDocument.PrintToPrinter(nCopy, false, sPage, ePage);


                           // MessageBox.Show("Report finished printing!");
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.ToString());
                        }
                        con.Close();





                        this.printDialog1.Document = this.printDocument1;
                        // DialogResult dr3 = this.printDialog1.ShowDialog();

                        print p1 = new print();


                        int nCopy1= this.printDocument1.PrinterSettings.Copies;

                        int sPage1 = this.printDocument1.PrinterSettings.FromPage;

                        int ePage1 = this.printDocument1.PrinterSettings.ToPage;
                        string PrinterName1 = this.printDocument1.PrinterSettings.PrinterName;

                        crReportDocument = new ReportDocument();

                        con.Open();

                        ddata custDB1 = new ddata();




                        crReportDocument = new CrystalReport12();


                        crReportDocument.Database.Tables["dt1"].SetDataSource(dt1);



                        crReportDocument.SetParameterValue("name", textBox1.Text);
                        crReportDocument.SetParameterValue("add", mm);

                        crReportDocument.SetParameterValue("mob", yy);

                        crReportDocument.SetParameterValue("bal", bunifuCustomLabel21.Text);

                        crReportDocument.SetParameterValue("did", bunifuCustomLabel28.Text);
                        crReportDocument.SetParameterValue("typ", "Customer Copy");








                        try
                        {


                            crReportDocument.PrintOptions.PrinterName = PrinterName1;




                            p.crystalReportViewer1.ReportSource = crReportDocument;
                            // p.crystalReportViewer1.Refresh();
                            // p.Show();
                            crReportDocument.PrintToPrinter(nCopy1, false, sPage1, ePage1);


                            // MessageBox.Show("Report finished printing!");
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.ToString());
                        }
                        con.Close();
                    











                   // textBox6.Text = "";
                    textBox1.Text = "";
                    //comboBox1.Text = "";



                    stock m22 = new stock();
                    m22.Show();
                   this.Hide();





        }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("ADD Products First ");
            }
            else
            {
                try
                {
                   





  //datagrid insert



                    int qty;
                    string pname;
                    string insertQuery2;
                    foreach (DataRow dr in dt.Rows)
                    {
                       
                        qty = Convert.ToInt32(dr["quantity"].ToString());
                        pname = dr["Product_Name"].ToString();


                        con.Open();

                        //MessageBox.Show(""+dr["Status"]);

                        if (dr["Status"].ToString() == "Production")
                        {

                      

                             insertQuery2 = "update stock set quantity=quantity+" + qty + " where name='" + pname.ToString() + "'";

                        
                          
                        
                        
                        }


                        else
                        {
                             insertQuery2 = "update stock set quantity=quantity-" + qty + " where name='" + pname.ToString() + "'";




                        }

                        MySqlCommand command2 = new MySqlCommand(insertQuery2, con);

                        command2.ExecuteNonQuery();
                        con.Close();


                        con.Open();
                        string insertQuery = "INSERT INTO production_history (date, item,quantity,Status) VALUES('" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + dr["Product_Name"] + "','" + dr["Quantity"] + "','" + dr["Status"] + "')";

                        MySqlCommand command = new MySqlCommand(insertQuery, con);

                        command.ExecuteNonQuery();

                        con.Close();





                    }






















                    textBox2.Text = ""; textBox5.Text = ""; comboBox3.Text = "";





                    stock m22 = new stock();
                    m22.Show();
                    this.Hide();




                }
                catch (Exception e11)
                {
                    con.Close();

                    MessageBox.Show("Error ocure Check Server PC" + e11);


                }
            }

          






        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
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

        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {
           

                //bunifuCustomDataGrid1.ColumnCount = 8;




            MySqlCommand cmd = new MySqlCommand("SELECT * FROM  production_history where date >='" + bunifuDatepicker1.Value.ToString("yyyy-MM-dd") + "';", con);
                con.Open();
                DataTable dataTable = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                da.Fill(dataTable);


                dataGridView3.DataSource = dataTable;

                dataGridView3.Columns[0].HeaderText = "Production ID ";





                con.Close();


        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
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
                stockdata custDB = new stockdata();
                custDB.Clear();

                cmda.CommandText = "select * from stock ";
                cmda.ExecuteNonQuery();


                adap = new MySqlDataAdapter();

                adap.SelectCommand = cmda;

                DataTable d1 = new DataTable();

                adap.Fill(custDB.DataTable1);
                adap.Fill(d1);


                crReportDocument = new CrystalReport13();

                crReportDocument.SetDataSource(custDB);





                try
                {


                    crReportDocument.PrintOptions.PrinterName = PrinterName;




                    p.crystalReportViewer1.ReportSource = crReportDocument;
                   // p.crystalReportViewer1.Refresh();
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

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {



            DataRow dr = dt.NewRow();


            dr["Product_Name"] = textBox2.Text;


            dr["Quantity"] = textBox5.Text;

            dr["Status"] = comboBox3.Text;
           


            dt.Rows.Add(dr);

            bunifuCustomDataGrid1.DataSource = dt;

            textBox2.Text = "";
            textBox5.Text = "";
            comboBox3.Text = "";
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="" && comboBox1.Text!="" && textBox6.Text!="")
            {


            

            double remain = 0;

            double td = 0;

            double t1=0;

            double t2=0;


            MySqlDataReader rdr2 = null;

            con.Open();

            string stm2 = "SELECT sum(total_buj) FROM advanced_buj where c_id = '" + x + "' AND item_id='" + comboBox1.Text + "'";
            MySqlCommand cmd2 = new MySqlCommand(stm2, con);
            rdr2 = cmd2.ExecuteReader();

            while (rdr2.Read())
            {

                t1 =Convert.ToDouble(rdr2.GetString(0));
            }

            con.Close();




            try
            {


                MySqlDataReader rdr22 = null;

                con.Open();

                string stm22 = "SELECT sum(deli_item) FROM ad_delivery where c_id = '" + textBox1.Text + "' AND item_name='" + comboBox1.Text + "'";
                MySqlCommand cmd22 = new MySqlCommand(stm22, con);
                rdr22 = cmd22.ExecuteReader();

                if (rdr22.Read())
                {

                    t2 = Convert.ToDouble(rdr22.GetString(0));
                }

                con.Close();

            }

            catch (Exception ee)
            {
                con.Close();
            }








            remain = t1 - (t2 + Convert.ToDouble(textBox6.Text));

            td = t2 + Convert.ToDouble(textBox6.Text);

            DataRow dr1 = dt1.NewRow();


            dr1["Customer_name"] = textBox1.Text;


            dr1["Item_name"] = comboBox1.Text;

            dr1["Amount"] = textBox6.Text;


            dr1["Total_Item"] = t1.ToString();

            dr1["Total_Delivery"] = td.ToString();
            dr1["Remaining_Delivery"] = remain.ToString();




           

















            dt1.Rows.Add(dr1);

            bunifuCustomDataGrid2.DataSource = dt1;

           // textBox1.Text = "";
            textBox6.Text = "";
            //comboBox1.Text = "";

            this.ActiveControl = comboBox1;

            this.comboBox1.Focus();

            //e.SuppressKeyPress = true;
        }

        else{

        MessageBox.Show("Fill all The Fields");
    }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dt1.Rows.Count == 0)
            {

                MessageBox.Show("Table is already clean!!");
            }

            else
            {

                dt1.Rows.RemoveAt(Convert.ToInt32(bunifuCustomDataGrid2.CurrentCell.RowIndex.ToString()));

            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {





                this.ActiveControl = comboBox1;

                this.comboBox1.Focus();

                e.SuppressKeyPress = true;





            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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
                this.ActiveControl = button3;

                this.button3.Focus();

                e.SuppressKeyPress = true;
            }
        }
        private void button3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {















                if (textBox1.Text != "" && comboBox1.Text != "" && textBox6.Text != "")
                {




                    double remain = 0;

                    double td = 0;

                    double t1 = 0;

                    double t2 = 0;


                    MySqlDataReader rdr2 = null;

                    con.Open();

                    string stm2 = "SELECT sum(total_buj) FROM advanced_buj where c_id = '" + x + "' AND item_id='" + comboBox1.Text + "'";
                    MySqlCommand cmd2 = new MySqlCommand(stm2, con);
                    rdr2 = cmd2.ExecuteReader();

                    while (rdr2.Read())
                    {

                        t1 = Convert.ToDouble(rdr2.GetString(0));
                    }

                    con.Close();




                    try
                    {


                        MySqlDataReader rdr22 = null;

                        con.Open();

                        string stm22 = "SELECT sum(deli_item) FROM ad_delivery where c_id = '" + textBox1.Text + "' AND item_name='" + comboBox1.Text + "'";
                        MySqlCommand cmd22 = new MySqlCommand(stm22, con);
                        rdr22 = cmd22.ExecuteReader();

                        if (rdr22.Read())
                        {

                            t2 = Convert.ToDouble(rdr22.GetString(0));
                        }

                        con.Close();

                    }

                    catch (Exception ee)
                    {
                        con.Close();
                    }








                    remain = t1 - (t2 + Convert.ToDouble(textBox6.Text));

                    td = t2 + Convert.ToDouble(textBox6.Text);

                    DataRow dr1 = dt1.NewRow();


                    dr1["Customer_name"] = textBox1.Text;


                    dr1["Item_name"] = comboBox1.Text;

                    dr1["Amount"] = textBox6.Text;


                    dr1["Total_Item"] = t1.ToString();

                    dr1["Total_Delivery"] = td.ToString();
                    dr1["Remaining_Delivery"] = remain.ToString();






















                    dt1.Rows.Add(dr1);

                    bunifuCustomDataGrid2.DataSource = dt1;

                    // textBox1.Text = "";
                    textBox6.Text = "";
                    //comboBox1.Text = "";


                }

                else
                {

                    MessageBox.Show("Fill all The Fields");
                }
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                this.ActiveControl = comboBox1;

                this.comboBox1.Focus();

                e.SuppressKeyPress = true;
            }
        }
    }
}
