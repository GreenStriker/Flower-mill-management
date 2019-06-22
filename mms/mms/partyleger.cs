using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using CrystalDecisions.CrystalReports.Engine;
namespace mms
{
    public partial class partyleger : Form
    {
        MySqlConnection con = null;
        int x;
        string cadd;
        string cmob;
        ReportDocument crReportDocument;
        public partyleger()
        {
            InitializeComponent();
            con = DatabaseConnection.getDBConnection();
        }

        private void partyleger_Load(object sender, EventArgs e)
        {
            bunifuDatepicker5.Value = DateTime.Now;
            bunifuDatepicker2.Value = DateTime.Now;
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







        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;

            MySqlDataReader rdr2 = null;

            con.Open();

            string stm2 = "SELECT id,c_add,c_mobile,main_bal FROM clients where c_name = '" + textBox4.Text + "'";
            MySqlCommand cmd2 = new MySqlCommand(stm2, con);
            rdr2 = cmd2.ExecuteReader();

            if (rdr2.Read())
            {
                bunifuCustomLabel6.Text = rdr2.GetString(0);
                bunifuCustomLabel7.Text = rdr2.GetString(1);
                bunifuCustomLabel8.Text = rdr2.GetString(2);

                if (Convert.ToDouble(rdr2.GetString(3)) < 0)
                {
                    bunifuCustomLabel11.ForeColor = System.Drawing.Color.Red;
                }
                else
                {

                    bunifuCustomLabel11.ForeColor = System.Drawing.Color.Green;

                }
                double x = Convert.ToDouble(rdr2.GetString(3));


                bunifuCustomLabel11.Text = x.ToString("N");








            } con.Close();






            MySqlDataReader rdr = null;



            con.Open();

            string stm = "SELECT id FROM advanced_buj where c_id= '" + bunifuCustomLabel6.Text + "' ";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            rdr = cmd.ExecuteReader();


          comboBox1.Items.Clear();
            while (rdr.Read())
            {


                //  comboBox1.Items.Add(rdr.GetString("name"));
                comboBox1.Items.Add(rdr.GetString("id"));

            }

            con.Close();









            MySqlDataReader rdr3 = null;



            con.Open();

            string stm3 = "SELECT id FROM ad_delivery where c_id= '" + textBox4.Text + "' ";
            MySqlCommand cmd3 = new MySqlCommand(stm3, con);
            rdr3 = cmd3.ExecuteReader();


            comboBox3.Items.Clear();
            while (rdr3.Read())
            {


                //  comboBox1.Items.Add(rdr.GetString("name"));
                comboBox3.Items.Add(rdr3.GetString("id"));

            }

            con.Close();



















        }

        private void bunifuCustomLabel12_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {

            try
            {
                if (bunifuCustomLabel6.Text == "") { }


                else
                {

                    //bunifuCustomDataGrid1.ColumnCount = 8;




                    string sql;



                    con.Open();
                    DataTable dataTable = new DataTable();



                    sql = "SELECT 	id,date,detail,item_id,rate,total_buj,debit_amu  FROM advanced_buj where c_id= '" + bunifuCustomLabel6.Text + "'  AND date >='" + bunifuDatepicker1.Value.ToString("yyyy-MM-dd") + "' AND date <='" + bunifuDatepicker5.Value.ToString("yyyy-MM-dd") + "'; ";





                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    da.Fill(dataTable);


                    dataGridView1.DataSource = dataTable;

                    dataGridView1.Columns[0].HeaderText = "Order ID ";
                    dataGridView1.Columns[3].HeaderText = "Product Name ";
                    dataGridView1.Columns[4].HeaderText = " Rate per unit ";
                    dataGridView1.Columns[5].HeaderText = "Total Bujet/unit  ";
                    dataGridView1.Columns[6].HeaderText = "Debit Amount /taka ";


                    con.Close();

                }





            }


            catch (Exception r)
            {

                main1 m = new main1();
                m.Show();


                this.Hide();







            }

        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            try
            {
                if (bunifuCustomLabel6.Text == "")
                {

                    MessageBox.Show("Select Customer Frist");

                }

                else
                {

                    //bunifuCustomDataGrid1.ColumnCount = 8;








                    MySqlCommand cmd = new MySqlCommand("SELECT id,date,c_id,item_name,deli_item,remark FROM ad_delivery  where c_id = '" + textBox4.Text + "' AND date >='" + bunifuDatepicker1.Value.ToString("yyyy-MM-dd") + "' AND date <='" + bunifuDatepicker5.Value.ToString("yyyy-MM-dd") + "' ;", con);
                    con.Open();
                    DataTable dataTable = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    da.Fill(dataTable);


                    dataGridView1.DataSource = dataTable;

                    dataGridView1.Columns[0].HeaderText = "Delivery ID ";

                    dataGridView1.Columns[1].HeaderText = "Date";
                    dataGridView1.Columns[2].HeaderText = "Customer Name";
                    dataGridView1.Columns[3].HeaderText = "Prdoduct Name ";
                    dataGridView1.Columns[4].HeaderText = "Total Product Delivery";
                    dataGridView1.Columns[5].HeaderText = "Remark";



                    con.Close();

                }


            }


            catch (Exception r)
            {
                main1 m = new main1();
                m.Show();
                this.Hide();







            }







        }

        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {
            try
            {
                if (bunifuCustomLabel6.Text == "") { }


                else
                {

                    //bunifuCustomDataGrid1.ColumnCount = 8;








                    MySqlCommand cmd = new MySqlCommand("SELECT id,date,address,mobi,pament_type,bank_name,check_no,amount,remark FROM colection where c_id= '" + textBox4.Text + "'AND date >='" + bunifuDatepicker1.Value.ToString("yyyy-MM-dd") + "' AND date <='" + bunifuDatepicker5.Value.ToString("yyyy-MM-dd") + "';", con);
                    con.Open();
                    DataTable dataTable = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    da.Fill(dataTable);


                    dataGridView1.DataSource = dataTable;

                    dataGridView1.Columns[0].HeaderText = "Colection ID ";
                    dataGridView1.Columns[1].HeaderText = "Date";
                    dataGridView1.Columns[2].HeaderText = "Address ";
                    dataGridView1.Columns[3].HeaderText = "Mobile NO";
                    dataGridView1.Columns[4].HeaderText = "Payment Type";
                    dataGridView1.Columns[5].HeaderText = "Bank Name ";
                    dataGridView1.Columns[6].HeaderText = "Cheque NO ";
                    dataGridView1.Columns[7].HeaderText = "Collection Amount ";
                    dataGridView1.Columns[8].HeaderText = "Remark";





                    con.Close();

                }


            }


            catch (Exception r)
            {
                main1 m = new main1();
                 m.Show();
                this.Hide();







            }



        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            Application.OpenForms[2].Visible = true;
            while (Application.OpenForms.Count > 4) { Application.OpenForms[3].Dispose(); }
            Application.OpenForms[3].Dispose();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {




            dataGridView2.DataSource = null;

            MySqlDataReader rdr2 = null;

            con.Open();

            string stm2 = "SELECT id,c_add,c_mobile,main_bal FROM clients where c_name = '" + textBox3.Text + "'";
            MySqlCommand cmd2 = new MySqlCommand(stm2, con);
            rdr2 = cmd2.ExecuteReader();

            if (rdr2.Read())
            {
                bunifuCustomLabel23.Text = rdr2.GetString(0);
                bunifuCustomLabel22.Text = rdr2.GetString(1);
                bunifuCustomLabel21.Text = rdr2.GetString(2);

                if (Convert.ToDouble(rdr2.GetString(3)) < 0)
                {
                    bunifuCustomLabel20.ForeColor = System.Drawing.Color.Red;
                }
                else
                {

                    bunifuCustomLabel20.ForeColor = System.Drawing.Color.Green;

                }
                double x = Convert.ToDouble(rdr2.GetString(3));


                bunifuCustomLabel20.Text = x.ToString("N");








            } con.Close();
















            MySqlDataReader rdr = null;



            con.Open();

            string stm = "SELECT id FROM sales_buj where c_id= '" + bunifuCustomLabel23.Text + "' ";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            rdr = cmd.ExecuteReader();


            comboBox2.Items.Clear();
            while (rdr.Read())
            {


                //  comboBox1.Items.Add(rdr.GetString("name"));
                comboBox2.Items.Add(rdr.GetString("id"));

            }

            con.Close();










        }

        private void bunifuThinButton210_Click(object sender, EventArgs e)
        {

            if (bunifuCustomLabel23.Text == "") { }


            else
            {

                //bunifuCustomDataGrid1.ColumnCount = 8;




                string sql;



                con.Open();
                DataTable dataTable = new DataTable();




                sql = "SELECT 	id,date,detail,item_id,	debit_amu,total_buj,curent_buj  FROM sales_buj where c_id= '" + bunifuCustomLabel23.Text + "'AND date >='" + bunifuDatepicker3.Value.ToString("yyyy-MM-dd") + "'; ";





                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                da.Fill(dataTable);


                dataGridView2.DataSource = dataTable;

                dataGridView2.Columns[0].HeaderText = "Bujet ID ";
                dataGridView2.Columns[3].HeaderText = "Product Name ";
                dataGridView2.Columns[4].HeaderText = "Debit Amount ";
                dataGridView2.Columns[5].HeaderText = "Total Bujet  ";
                dataGridView2.Columns[6].HeaderText = "Curent Bujet ";


                con.Close();

            }

















        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
            {

                MessageBox.Show("Fill ALL Fields");

            }


            else
            {

                //bunifuCustomDataGrid1.ColumnCount = 8;








                MySqlCommand cmd = new MySqlCommand("SELECT * FROM sales_delivery where buj_id = '" + Convert.ToInt32(comboBox2.Text) + "';", con);
                con.Open();
                DataTable dataTable = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                da.Fill(dataTable);


                dataGridView2.DataSource = dataTable;

                dataGridView2.Columns[0].HeaderText = "Delivery ID ";





                con.Close();

            }

        }

        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {
            if (bunifuCustomLabel23.Text == "") { }


            else
            {

                //bunifuCustomDataGrid1.ColumnCount = 8;




                MySqlCommand cmd = new MySqlCommand("SELECT * FROM colection where c_id= '" + bunifuCustomLabel23.Text + "'AND date >='" + bunifuDatepicker3.Value.ToString("yyyy-MM-dd") + "';", con);
                con.Open();
                DataTable dataTable = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                da.Fill(dataTable);


                dataGridView2.DataSource = dataTable;

                dataGridView2.Columns[0].HeaderText = "Colection ID ";





                con.Close();

            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {




            dataGridView3.DataSource = null;

            MySqlDataReader rdr2 = null;

            con.Open();

            string stm2 = "SELECT id,c_add,c_mobile,main_bal FROM supplier where c_name = '" + textBox6.Text + "'";
            MySqlCommand cmd2 = new MySqlCommand(stm2, con);
            rdr2 = cmd2.ExecuteReader();

            if (rdr2.Read())
            {
                bunifuCustomLabel37.Text = rdr2.GetString(0);
                bunifuCustomLabel36.Text = rdr2.GetString(1);
                bunifuCustomLabel35.Text = rdr2.GetString(2);

                if (Convert.ToDouble(rdr2.GetString(3)) < 0)
                {
                    bunifuCustomLabel34.ForeColor = System.Drawing.Color.Red;
                }
                else
                {

                    bunifuCustomLabel34.ForeColor = System.Drawing.Color.Green;

                }
                double x = Convert.ToDouble(rdr2.GetString(3));


                bunifuCustomLabel34.Text = x.ToString("N");








            } con.Close();






































        }

        private void bunifuThinButton211_Click(object sender, EventArgs e)
        {
            try
            {
                if (bunifuCustomLabel37.Text == "")
                {

                }


                else
                {

                    //bunifuCustomDataGrid1.ColumnCount = 8;




                    string sql;



                    con.Open();
                    DataTable dataTable = new DataTable();




                    sql = "SELECT id,date,item_id,quantity,rate,amount FROM purchase_history where c_id= '" + bunifuCustomLabel37.Text + "'  AND date >='" + bunifuDatepicker2.Value.ToString("yyyy-MM-dd") + "'; ";





                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    da.Fill(dataTable);


                    dataGridView3.DataSource = dataTable;

                    dataGridView3.Columns[0].HeaderText = "Purchase ID ";
                    dataGridView3.Columns[1].HeaderText = "Date ";
                    dataGridView3.Columns[2].HeaderText = "Product Name ";
                    dataGridView3.Columns[3].HeaderText = "Total Quantity  ";
                    dataGridView3.Columns[4].HeaderText = "Price Per Unit ";
                    dataGridView3.Columns[5].HeaderText = "Total Price  ";


                    con.Close();

                }







            }


            catch (Exception r)
            {
                 main1 m = new main1();
                 m.Show();
                this.Hide();







            }







        }

        private void bunifuThinButton212_Click(object sender, EventArgs e)
        {
            try
            {
                if (bunifuCustomLabel37.Text == "") { }


                else
                {

                    //bunifuCustomDataGrid1.ColumnCount = 8;




                    MySqlCommand cmd = new MySqlCommand("SELECT id,date,pament_type,bank_name,check_no,amount,remark FROM purchage_payment where c_id= '" + bunifuCustomLabel37.Text + "'AND date >='" + bunifuDatepicker2.Value.ToString("yyyy-MM-dd") + "';", con);
                    con.Open();
                    DataTable dataTable = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    da.Fill(dataTable);


                    dataGridView3.DataSource = dataTable;

                    dataGridView3.Columns[0].HeaderText = "Payment ID ";
                    dataGridView3.Columns[1].HeaderText = "Date ";
                    dataGridView3.Columns[2].HeaderText = "Payment Type ";
                    dataGridView3.Columns[3].HeaderText = "Bank Name ";
                    dataGridView3.Columns[4].HeaderText = "Cheque NO ";
                    dataGridView3.Columns[5].HeaderText = "Total payment ";
                    dataGridView3.Columns[6].HeaderText = "Remark ";





                    con.Close();

                }

            }


            catch (Exception r)
            {
                main1 m = new main1();
                 m.Show();
                this.Hide();







            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {

            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            ani.ShowSync(panel1);
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            ani.ShowSync(panel2);
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            ani.ShowSync(panel3);
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

            if (textBox3.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("Please Fill the boxes Frist");
            }
            else
            {
                panel2.Visible = false;
                panel7.Visible = true;
            }
        }

        private void bunifuCustomTextbox7_TextChanged(object sender, EventArgs e)
        {

            if (bunifuCustomTextbox7.Text == "15289611")
            {

                double cus = 0;


                MySqlDataReader rdr111 = null;

                con.Open();

                string stm = "SELECT debit_amu FROM sales_buj where id= '" + comboBox2.Text + "' ";
                MySqlCommand cmd = new MySqlCommand(stm, con);
                rdr111 = cmd.ExecuteReader();



                if (rdr111.Read())
                {



                    cus = Convert.ToDouble(rdr111.GetString("debit_amu").ToString());

                    // MessageBox.Show("" + cus);

                }

                con.Close();





                con.Open();

                string query1 = "Update clients SET main_bal=main_bal-'" + cus + "'  where c_name ='" + textBox3.Text + "' ";


                //create command and assign the query and connection from the constructor
                MySqlCommand cmd1 = new MySqlCommand(query1, con);

                //Execute command
                cmd1.ExecuteNonQuery();

                //close connection
                con.Close();

                con.Open();

                string query91 = "Update  totalbal SET 	total_credit=	total_credit-'" + cus + "'  where id ='1' ";


                //create command and assign the query and connection from the constructor
                MySqlCommand cmd91 = new MySqlCommand(query91, con);

                //Execute command
                cmd91.ExecuteNonQuery();

                //close connection
                con.Close();







                con.Open();

                string query19 = "Delete from sales_buj where id ='" + comboBox2.Text + "'";


                //create command and assign the query and connection from the constructor
                MySqlCommand cmd19 = new MySqlCommand(query19, con);

                //Execute command
                cmd19.ExecuteNonQuery();

                //close connection
                con.Close();

                MessageBox.Show("dELETE SUCCESSFULL ");
                ani.HideSync(panel7);















            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {


            if (textBox4.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Please Fill the boxes Frist");
            }
            else
            {
                panel1.Visible = false;
                panel5.Visible = true;
            }
        }

        private void bunifuCustomTextbox1_TextChanged(object sender, EventArgs e)
        {


            if (bunifuCustomTextbox1.Text == "15289611")
            {

                double cus = 0;


                MySqlDataReader rdr111 = null;

                con.Open();

                string stm = "SELECT debit_amu FROM advanced_buj where id= '" + comboBox1.Text + "' ";
                MySqlCommand cmd = new MySqlCommand(stm, con);
                rdr111 = cmd.ExecuteReader();



                if (rdr111.Read())
                {



                    cus = Convert.ToDouble(rdr111.GetString("debit_amu").ToString());

                    // MessageBox.Show("" + cus);

                }

                con.Close();





                con.Open();

                string query1 = "Update clients SET main_bal=main_bal-'" + cus + "'  where c_name ='" + textBox4.Text + "' ";


                //create command and assign the query and connection from the constructor
                MySqlCommand cmd1 = new MySqlCommand(query1, con);

                //Execute command
                cmd1.ExecuteNonQuery();

                //close connection
                con.Close();

                con.Open();

                string query91 = "Update  totalbal SET 	total_credit=	total_credit-'" + cus + "'  where id ='1' ";


                //create command and assign the query and connection from the constructor
                MySqlCommand cmd91 = new MySqlCommand(query91, con);

                //Execute command
                cmd91.ExecuteNonQuery();

                //close connection
                con.Close();







                con.Open();

                string query19 = "Delete from advanced_buj where id ='" + comboBox1.Text + "'";


                //create command and assign the query and connection from the constructor
                MySqlCommand cmd19 = new MySqlCommand(query19, con);

                //Execute command
                cmd19.ExecuteNonQuery();

                //close connection
                con.Close();

                MessageBox.Show("DELETE SUCCESSFULL ");
                ani.HideSync(panel5);


                main1 m = new main1();

                m.Show();












            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {


            if (textBox4.Text == "") { MessageBox.Show("Plz Select a Client!!"); }

            else
            {




                MySqlDataReader rdr2 = null;

                con.Open();

                string stm2 = "SELECT id,c_add,c_mobile FROM clients where c_name = '" + textBox4.Text + "'";
                MySqlCommand cmd2 = new MySqlCommand(stm2, con);
                rdr2 = cmd2.ExecuteReader();

                while (rdr2.Read())
                {
                    string ccname = rdr2.GetString(0);

                    x = Convert.ToInt32(ccname);

                    cadd = rdr2.GetString(1);
                    cmob = rdr2.GetString(2);

                }

                con.Close();




                //bunifuCustomLabel11





                this.printDialog1.Document = this.printDocument1;
                DialogResult dr = this.printDialog1.ShowDialog();

                print p = new print();

                MySqlCommand cmda;
                MySqlDataAdapter adap;

                MySqlCommand cmda1;
                MySqlDataAdapter adap1;
                MySqlCommand cmda2;
                MySqlDataAdapter adap2;
                MySqlCommand cmda3;
                MySqlDataAdapter adap3;

                if (dr == DialogResult.OK)
                {

                    int nCopy = this.printDocument1.PrinterSettings.Copies;

                    int sPage = this.printDocument1.PrinterSettings.FromPage;

                    int ePage = this.printDocument1.PrinterSettings.ToPage;
                    string PrinterName = this.printDocument1.PrinterSettings.PrinterName;

                    crReportDocument = new ReportDocument();

                    con.Open();




                    cmda = con.CreateCommand();
                    clientstate custDB = new clientstate();
                    custDB.Clear();

                    cmda.CommandText = "select * from advanced_buj where c_id='" + x + "' AND date >='" + bunifuDatepicker1.Value.ToString("yyyy-MM-dd") + "' AND date <='" + bunifuDatepicker5.Value.ToString("yyyy-MM-dd") + "'";
                    cmda.ExecuteNonQuery();


                    adap = new MySqlDataAdapter();

                    adap.SelectCommand = cmda;

                    DataTable d1 = new DataTable();

                    adap.Fill(custDB.DataTable1);
                    adap.Fill(d1);


                    con.Close();

                    con.Open();

                    cmda1 = con.CreateCommand();


                    cmda1.CommandText = "select * from ad_delivery where c_id='" + textBox4.Text + "' AND date >='" + bunifuDatepicker1.Value.ToString("yyyy-MM-dd") + "' AND date <='" + bunifuDatepicker5.Value.ToString("yyyy-MM-dd") + "'";
                    cmda1.ExecuteNonQuery();


                    adap1 = new MySqlDataAdapter();

                    adap1.SelectCommand = cmda1;

                    DataTable d2 = new DataTable();

                    adap1.Fill(custDB.DataTable2);
                    adap1.Fill(d2);


                    con.Close();




                    con.Open();

                    cmda2 = con.CreateCommand();


                    cmda2.CommandText = "select * from colection where c_id='" + x + "' AND date >='" + bunifuDatepicker1.Value.ToString("yyyy-MM-dd") + "' AND date <='" + bunifuDatepicker5.Value.ToString("yyyy-MM-dd") + "'";
                    cmda2.ExecuteNonQuery();


                    adap2 = new MySqlDataAdapter();

                    adap2.SelectCommand = cmda2;

                    DataTable d3 = new DataTable();

                    adap2.Fill(custDB.DataTable3);
                    adap2.Fill(d3);

                    con.Close();





                    con.Open();

                    cmda3 = con.CreateCommand();


                    cmda3.CommandText = "select * from kusra_sale where c_name='" + textBox4.Text + "' AND date >='" + bunifuDatepicker1.Value.ToString("yyyy-MM-dd") + "' AND date <='" + bunifuDatepicker5.Value.ToString("yyyy-MM-dd") + "'";
                    cmda3.ExecuteNonQuery();


                    adap3 = new MySqlDataAdapter();

                    adap3.SelectCommand = cmda3;

                    DataTable d4 = new DataTable();

                    adap3.Fill(custDB.DataTable4);
                    adap3.Fill(d4);














                    crReportDocument = new CrystalReport15();

                    crReportDocument.SetDataSource(custDB);



                    crReportDocument.SetParameterValue("name", textBox4.Text);
                    crReportDocument.SetParameterValue("add", cadd);
                    crReportDocument.SetParameterValue("mob", cmob);
                    crReportDocument.SetParameterValue("bal", bunifuCustomLabel11.Text);

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
                        con.Close();
                    }
                    con.Close();
                }
















            }
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {



            if (textBox6.Text == "") { MessageBox.Show("Plz Select a Client!!"); }

            else
            {






                this.printDialog1.Document = this.printDocument1;
                DialogResult dr = this.printDialog1.ShowDialog();

                print p = new print();

                MySqlCommand cmda;
                MySqlDataAdapter adap;

                MySqlCommand cmda1;
                MySqlDataAdapter adap1;


                if (dr == DialogResult.OK)
                {

                    int nCopy = this.printDocument1.PrinterSettings.Copies;

                    int sPage = this.printDocument1.PrinterSettings.FromPage;

                    int ePage = this.printDocument1.PrinterSettings.ToPage;
                    string PrinterName = this.printDocument1.PrinterSettings.PrinterName;

                    crReportDocument = new ReportDocument();

                    con.Open();




                    cmda = con.CreateCommand();
                    supplierstate custDB = new supplierstate();
                    custDB.Clear();

                    cmda.CommandText = "select * from purchage_payment where c_id='" + bunifuCustomLabel37.Text + "' AND date >='" + bunifuDatepicker2.Value.ToString("yyyy-MM-dd") + "'";
                    cmda.ExecuteNonQuery();


                    adap = new MySqlDataAdapter();

                    adap.SelectCommand = cmda;

                    DataTable d1 = new DataTable();

                    adap.Fill(custDB.DataTable1);
                    adap.Fill(d1);


                    con.Close();

                    con.Open();

                    cmda1 = con.CreateCommand();


                    cmda1.CommandText = "select * from purchase_history where c_id='" + bunifuCustomLabel37.Text + "' AND date >='" + bunifuDatepicker2.Value.ToString("yyyy-MM-dd") + "'";
                    cmda1.ExecuteNonQuery();


                    adap1 = new MySqlDataAdapter();

                    adap1.SelectCommand = cmda1;

                    DataTable d2 = new DataTable();

                    adap1.Fill(custDB.DataTable2);
                    adap1.Fill(d2);



                    crReportDocument = new CrystalReport16();

                    crReportDocument.SetDataSource(custDB);



                    crReportDocument.SetParameterValue("name", textBox6.Text);
                    crReportDocument.SetParameterValue("add", bunifuCustomLabel36.Text);
                    crReportDocument.SetParameterValue("mob", bunifuCustomLabel35.Text);
                    crReportDocument.SetParameterValue("bal", bunifuCustomLabel34.Text);

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
                        con.Close();
                    }
                    con.Close();
                }






            }






















        }

        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton213_Click(object sender, EventArgs e)
        {
            try
            {
                if (bunifuCustomLabel6.Text == "") { }


                else
                {

                    //bunifuCustomDataGrid1.ColumnCount = 8;




                    string sql;



                    con.Open();
                    DataTable dataTable = new DataTable();



                    sql = "SELECT 	date,s_id,name,quantity,rate,tprice,c_name,addr,mobi,pay_type,pertial_pay  FROM kusra_sale where c_name= '" + textBox4.Text + "'  AND date >='" + bunifuDatepicker1.Value.ToString("yyyy-MM-dd") + "' AND date <='" + bunifuDatepicker5.Value.ToString("yyyy-MM-dd") + "'; ";





                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    da.Fill(dataTable);


                    dataGridView1.DataSource = dataTable;

                    dataGridView1.Columns[0].HeaderText = "Date";
                    dataGridView1.Columns[1].HeaderText = "Sales ID";
                    dataGridView1.Columns[2].HeaderText = " Product Name ";
                    dataGridView1.Columns[3].HeaderText = "Total Quantity ";
                    dataGridView1.Columns[4].HeaderText = "Sale Rate Per Product";
                    dataGridView1.Columns[5].HeaderText = "Total Price";
                    dataGridView1.Columns[6].HeaderText = "Customer Name ";
                    dataGridView1.Columns[7].HeaderText = " Customer Address  ";
                    dataGridView1.Columns[8].HeaderText = "Customer Mobile ";
                    dataGridView1.Columns[9].HeaderText = "Payment Type";

                    dataGridView1.Columns[10].HeaderText = "Partial Payment ";




                    con.Close();

                }





            }


            catch (Exception r)
            {
                 main1 m = new main1();
                 m.Show();
                this.Hide();







            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {


            if (textBox4.Text == "" || comboBox3.Text == "")
            {
                MessageBox.Show("Please Fill the boxes Frist");
            }
            else
            {
                panel1.Visible = false;
                panel6.Visible = true;
            }
        }

        private void bunifuCustomTextbox2_TextChanged(object sender, EventArgs e)
        {
            if (bunifuCustomTextbox2.Text == "15289611")
            {

                string cus ="";
                string ddate = "";
                string ditem = "";
                 


                MySqlDataReader rdr111 = null;

                con.Open();

                string stm = "SELECT date,item_name,deli_item FROM ad_delivery where id= '" + comboBox3.Text + "' ";
                MySqlCommand cmd = new MySqlCommand(stm, con);
                rdr111 = cmd.ExecuteReader();



                if (rdr111.Read())
                {


                    bunifuDatepicker4.Value = DateTime.Parse(rdr111.GetString("date").ToString());
                    ditem = rdr111.GetString("item_name").ToString();
                     cus = rdr111.GetString("deli_item").ToString();

                    // MessageBox.Show("" + ddate);

                }

                con.Close();





                con.Open();

                string query12 = "Delete from sales_delivery where c_name ='" + textBox4.Text + "'   AND  item_name ='" + ditem + "'  AND  deli_item ='" + cus + "'  ";


                //create command and assign the query and connection from the constructor
                MySqlCommand cmd12 = new MySqlCommand(query12, con);

                //Execute command
                cmd12.ExecuteNonQuery();

                //close connection
                con.Close();

                







                con.Open();

                string query19 = "Delete from ad_delivery where id ='" + comboBox3.Text + "'";


                //create command and assign the query and connection from the constructor
                MySqlCommand cmd19 = new MySqlCommand(query19, con);

                //Execute command
                cmd19.ExecuteNonQuery();

                //close connection
                con.Close();

                MessageBox.Show("DELETE SUCCESSFULL ");
                ani.HideSync(panel6);



                main1 m = new main1();

                m.Show();















            }
        }
    }
}
//12, 134

//1341, 592