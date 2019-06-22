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
    public partial class cassbook : Form
    {
        ReportDocument crReportDocument;
        string col = "0" , pay="0", opay="0", kcol = "0", kcolaa= "0", akcol= "0";

        MySqlConnection con = null;
        public cassbook()
        {
            InitializeComponent();
            bunifuDatepicker1.Value = DateTime.Now;


            con = DatabaseConnection.getDBConnection();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            Application.OpenForms[2].Visible = true;
            while (Application.OpenForms.Count > 4) { Application.OpenForms[3].Dispose(); }
            Application.OpenForms[3].Dispose();
        }

        private void cassbook_Load(object sender, EventArgs e)
        {
            try
            {
            string sql;



            con.Open();
            DataTable dataTable = new DataTable();



            sql = "SELECT 	*  FROM colection where  date ='" + DateTime.Now.ToString("yyyy/MM/dd") + "'; ";





            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dataTable);


            dataGridView1.DataSource = dataTable;

            dataGridView1.Columns[0].HeaderText = "ID ";
            dataGridView1.Columns[1].HeaderText = "Date";
            dataGridView1.Columns[2].HeaderText = "Customer Id";
            dataGridView1.Columns[3].HeaderText = "Payment Type ";
            dataGridView1.Columns[4].HeaderText = "Bank Name";
            dataGridView1.Columns[5].HeaderText = "Cheque No";
            dataGridView1.Columns[6].HeaderText = "Remark";
            dataGridView1.Columns[7].HeaderText = "Amount";

            con.Close();
           

            string sql2;



            con.Open();
            DataTable dataTable2 = new DataTable();



            sql2 = "SELECT 	purchage_payment.id,date,c_id,pament_type,bank_name,check_no,remark,amount,supplier.c_name  FROM purchage_payment INNER JOIN  supplier ON purchage_payment.c_id = supplier.id  where purchage_payment.date ='" + DateTime.Now.ToString("yyyy/MM/dd") + "'; ";





            MySqlCommand cmd2 = new MySqlCommand(sql2, con);
            MySqlDataAdapter da2 = new MySqlDataAdapter(cmd2);

            da2.Fill(dataTable2);


            dataGridView2.DataSource = dataTable2;

            dataGridView2.Columns[0].HeaderText = "ID ";
            dataGridView2.Columns[1].HeaderText = "Date";
            dataGridView2.Columns[2].HeaderText = "SupplierId";
            dataGridView2.Columns[3].HeaderText = "Payment Type ";
            dataGridView2.Columns[4].HeaderText = "Bank Name";
            dataGridView2.Columns[5].HeaderText = "Cheque No";
            dataGridView2.Columns[6].HeaderText = "Remark";
            dataGridView2.Columns[7].HeaderText = "Amount";

            dataGridView2.Columns[8].HeaderText = "Supplier Name";


            con.Close();


            //3
            string sql3;



            con.Open();
            DataTable dataTable3 = new DataTable();



            sql3 = "SELECT 	*  FROM other_payment where  date ='" + DateTime.Now.ToString("yyyy/MM/dd") + "'; ";





            MySqlCommand cmd3 = new MySqlCommand(sql3, con);
            MySqlDataAdapter da3 = new MySqlDataAdapter(cmd3);

            da3.Fill(dataTable3);


            dataGridView3.DataSource = dataTable3;

            dataGridView3.Columns[0].HeaderText = "ID ";
            dataGridView3.Columns[1].HeaderText = "Date";
            dataGridView3.Columns[2].HeaderText = "Payment Type ";
            dataGridView3.Columns[3].HeaderText = "Bank Name";
            dataGridView3.Columns[4].HeaderText = "Cheque No";
            dataGridView3.Columns[5].HeaderText = "Expense Id";
            dataGridView3.Columns[6].HeaderText = "Remark";
            dataGridView3.Columns[7].HeaderText = "Amount";


            con.Close();


            //4

            string sql4;

            con.Open();
            DataTable dataTable4 = new DataTable();



            sql4 = "SELECT 	date,s_id,name,quantity,rate,tprice,c_name,addr,mobi,pay_type,pertial_pay FROM kusra_sale where  date ='" + DateTime.Now.ToString("yyyy/MM/dd") + "'; ";





            MySqlCommand cmd4 = new MySqlCommand(sql4, con);
            MySqlDataAdapter da4 = new MySqlDataAdapter(cmd4);

            da4.Fill(dataTable4);


            dataGridView4.DataSource = dataTable4;

            dataGridView4.Columns[0].HeaderText = "Date";
            dataGridView4.Columns[1].HeaderText = "Sales ID";
            dataGridView4.Columns[2].HeaderText = " Product Name ";
            dataGridView4.Columns[3].HeaderText = "Total Quantity ";
            dataGridView4.Columns[4].HeaderText = "Sale Rate Per Product";
            dataGridView4.Columns[5].HeaderText = "Total Price";
            dataGridView4.Columns[6].HeaderText = "Customer Name ";
            dataGridView4.Columns[7].HeaderText = " Customer Address  ";
            dataGridView4.Columns[8].HeaderText = "Customer Mobile ";
            dataGridView4.Columns[9].HeaderText = "Payment Type";
            dataGridView4.Columns[10].HeaderText = "Partial Payment ";


            con.Close();


            //5

            string sql5;

            con.Open();
            DataTable dataTable5 = new DataTable();



            sql5 = "SELECT 	purchase_history.id,date,c_id,item_id,quantity,amount,rate,supplier.c_name  FROM purchase_history INNER JOIN supplier ON  purchase_history.c_id=supplier.id where  date ='" + DateTime.Now.ToString("yyyy/MM/dd") + "'; ";





            MySqlCommand cmd5 = new MySqlCommand(sql5, con);
            MySqlDataAdapter da5 = new MySqlDataAdapter(cmd5);

            da5.Fill(dataTable5);


            dataGridView5.DataSource = dataTable5;

            dataGridView5.Columns[0].HeaderText = "ID";
            dataGridView5.Columns[1].HeaderText = "Date ";
            dataGridView5.Columns[2].HeaderText = "Supplier ID ";
            dataGridView5.Columns[3].HeaderText = "Product Name  ";
            dataGridView5.Columns[4].HeaderText = "Quantity ";
            dataGridView5.Columns[5].HeaderText = "Total Amount ";
            dataGridView5.Columns[6].HeaderText = "Rate";
            dataGridView5.Columns[7].HeaderText = "Supplier Name";


            con.Close();




            //6

            string sql6;

            con.Open();
            DataTable dataTable6 = new DataTable();



            sql6 = "SELECT 	*  FROM advanced_buj where  date ='" + DateTime.Now.ToString("yyyy/MM/dd") + "'; ";





            MySqlCommand cmd6 = new MySqlCommand(sql6, con);
            MySqlDataAdapter da6 = new MySqlDataAdapter(cmd6);

            da6.Fill(dataTable6);


            dataGridView6.DataSource = dataTable6;

            dataGridView6.Columns[0].HeaderText = "ID";
            dataGridView6.Columns[1].HeaderText = "Date ";
            dataGridView6.Columns[2].HeaderText = "Customer ID ";
            dataGridView6.Columns[3].HeaderText = "Detail   ";
            dataGridView6.Columns[4].HeaderText = "Debit Amount ";
            dataGridView6.Columns[5].HeaderText = "Product Name ";
            dataGridView6.Columns[6].HeaderText = "Rate";
            dataGridView6.Columns[7].HeaderText = "Total Budget";
            dataGridView6.Columns[8].HeaderText = "Remaining Budget";


            con.Close();


            //7

            string sql7;

            con.Open();
            DataTable dataTable7 = new DataTable();



          

            sql7 = " SELECT item_name,sum(deli_item) as deli_item FROM sales_delivery  where  date ='" +  DateTime.Now.ToString("yyyy/MM/dd")  + "' group by item_name; ";





            MySqlCommand cmd7 = new MySqlCommand(sql7, con);
            MySqlDataAdapter da7 = new MySqlDataAdapter(cmd7);

            da7.Fill(dataTable7);


            dataGridView7.DataSource = dataTable7;

            dataGridView7.Columns[0].HeaderText = "Product Name";
            dataGridView7.Columns[1].HeaderText = "Total Sell Unit ";
        


            con.Close();


                //8



            

            string sql8;

            con.Open();
            DataTable dataTable8 = new DataTable();



            sql8 = "SELECT 	ad_delivery.id,date,c_name,c_add,c_mobile,item_name,deli_item,remark FROM ad_delivery  INNER JOIN  clients ON  ad_delivery.c_id =clients.c_name AND date ='" + DateTime.Now.ToString("yyyy/MM/dd") + "'; ";





            MySqlCommand cmd8 = new MySqlCommand(sql8, con);
            MySqlDataAdapter da8 = new MySqlDataAdapter(cmd8);

            da8.Fill(dataTable8);


            dataGridView8.DataSource = dataTable8;

            dataGridView8.Columns[0].HeaderText = "ID";
            
            dataGridView8.Columns[1].HeaderText = "Date";
            dataGridView8.Columns[2].HeaderText = "Customer Name";
            dataGridView8.Columns[3].HeaderText = "Address ";
            dataGridView8.Columns[4].HeaderText = "Mobile NO";
            dataGridView8.Columns[5].HeaderText = "Item Namne ";
            dataGridView8.Columns[6].HeaderText = "Total Quantity";
            dataGridView8.Columns[7].HeaderText = "Remark   ";
            
            
         


            con.Close();

//s1


            try
            {


                con.Open();
                string stm9 = "SELECT sum(amount) FROM  colection   where  date ='" + DateTime.Now.ToString("yyyy/MM/dd") + "'  ";
                MySqlCommand cmd9 = new MySqlCommand(stm9, con);

                MySqlDataReader rdr9 = cmd9.ExecuteReader();


                while (rdr9.Read())
                {

                    col = rdr9.GetString(0);




                }
                bunifuCustomLabel13.Text = col.ToString();
              
                } 

                catch(Exception ii)
            {

                bunifuCustomLabel13.Text = "0";

            }
                
                
                
                
                
                
                con.Close();

           
            //s2



try{

            con.Open();
            string stm91 = "SELECT sum(amount) FROM  purchage_payment   where  date ='" + DateTime.Now.ToString("yyyy/MM/dd") + "'  ";
            MySqlCommand cmd91 = new MySqlCommand(stm91, con);

            MySqlDataReader rdr91 = cmd91.ExecuteReader();


            if (rdr91.Read())
            {

                pay = rdr91.GetString(0);




            }
            bunifuCustomLabel15.Text = pay.ToString();
            } 

                catch(Exception ii)
            {

                bunifuCustomLabel15.Text = "0";

            }  con.Close();

            //s3




try{
            con.Open();
            string stm911 = "SELECT sum(amount) FROM  other_payment   where  date ='" + DateTime.Now.ToString("yyyy/MM/dd") + "' ";
            MySqlCommand cmd911 = new MySqlCommand(stm911, con);

            MySqlDataReader rdr911 = cmd911.ExecuteReader();


            if (rdr911.Read())
            {

                opay = rdr911.GetString(0);




            }
            bunifuCustomLabel17.Text = opay.ToString();
           } 

                catch(Exception ii)
            {

                bunifuCustomLabel17.Text = "0";

            }  con.Close();




            //s4




try { 
            con.Open();
            string stm9111 = "SELECT sum(tprice) FROM  kusra_sale  where  date ='" + DateTime.Now.ToString("yyyy/MM/dd") + "'  ";
            MySqlCommand cmd9111 = new MySqlCommand(stm9111, con);

            MySqlDataReader rdr9111 = cmd9111.ExecuteReader();


            if (rdr9111.Read())
            {

                kcol = rdr9111.GetString(0);




            }
            bunifuCustomLabel19.Text = kcol.ToString();
}

catch (Exception ii)
{

    bunifuCustomLabel19.Text = "0";

} con.Close();





               // debit_amu
try
{
    con.Open();
    string ww = "SELECT sum(debit_amu) FROM  advanced_buj where  date ='" + DateTime.Now.ToString("yyyy/MM/dd") + "'  ";
    MySqlCommand eee = new MySqlCommand(ww, con);

    MySqlDataReader rrr = eee.ExecuteReader();


    if (rrr.Read())
    {

        akcol = rrr.GetString(0);

      //  MessageBox.Show("" + rrr.GetString(0));


    }
    bunifuCustomLabel25.Text = akcol.ToString();
}

catch (Exception ii)
{

    bunifuCustomLabel25.Text = "0";

} con.Close();


try
{
    con.Open();
    string stm911111 = "SELECT sum(amount) FROM  purchase_history  where  date ='" + DateTime.Now.ToString("yyyy/MM/dd") + "'  ";
    MySqlCommand cmd911111 = new MySqlCommand(stm911111, con);

    MySqlDataReader rdr911111 = cmd911111.ExecuteReader();


    if (rdr911111.Read())
    {

        kcolaa = rdr911111.GetString(0);




    }
    bunifuCustomLabel21.Text = kcolaa.ToString();
}

catch (Exception ii)
{

    bunifuCustomLabel21.Text = "0";

} con.Close();













bunifuCustomLabel26.Text = (Convert.ToDouble(col) - (Convert.ToDouble(pay) + Convert.ToDouble(opay))).ToString("N");











            

        }


        catch(Exception ee)
    {

        MessageBox.Show(""+ee);


    }





            bunifuDatepicker1.Value = DateTime.Now;







        }

        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {
            bunifuCustomLabel26.Text = "0";
            col = "0"; pay = "0"; opay = "0"; kcol = "0"; kcolaa = "0"; akcol = "0";
            try
            {
                string sql;

                con.Close();

                con.Open();
                DataTable dataTable = new DataTable();



                sql = "SELECT 	*  FROM colection where  date ='" + bunifuDatepicker1.Value.ToString("yyyy-MM-dd") + "'; ";





                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                da.Fill(dataTable);


                dataGridView1.DataSource = dataTable;

                dataGridView1.Columns[0].HeaderText = "ID ";
                dataGridView1.Columns[1].HeaderText = "Date";
                dataGridView1.Columns[2].HeaderText = "Customer Id";
                dataGridView1.Columns[3].HeaderText = "Payment Type ";
                dataGridView1.Columns[4].HeaderText = "Bank Name";
                dataGridView1.Columns[5].HeaderText = "Cheque No";
                dataGridView1.Columns[6].HeaderText = "Remark";
                dataGridView1.Columns[7].HeaderText = "Amount";


                con.Close();
                //2

                string sql2;



                con.Open();
                DataTable dataTable2 = new DataTable();



                sql2 = "SELECT 	purchage_payment.id,date,c_id,pament_type,bank_name,check_no,remark,amount,supplier.c_name  FROM purchage_payment INNER JOIN  supplier ON purchage_payment.c_id = supplier.id  where purchage_payment.date ='" + bunifuDatepicker1.Value.ToString("yyyy/MM/dd") + "'; ";





                MySqlCommand cmd2 = new MySqlCommand(sql2, con);
                MySqlDataAdapter da2 = new MySqlDataAdapter(cmd2);

                da2.Fill(dataTable2);


                dataGridView2.DataSource = dataTable2;

                dataGridView2.Columns[0].HeaderText = "ID ";
                dataGridView2.Columns[1].HeaderText = "Date";
                dataGridView2.Columns[2].HeaderText = "SupplierId";
                dataGridView2.Columns[3].HeaderText = "Payment Type ";
                dataGridView2.Columns[4].HeaderText = "Bank Name";
                dataGridView2.Columns[5].HeaderText = "Cheque No";
                dataGridView2.Columns[6].HeaderText = "Remark";
                dataGridView2.Columns[7].HeaderText = "Amount";

                dataGridView2.Columns[8].HeaderText = "Supplier Name";


                con.Close();


                //3
                string sql3;



                con.Open();
                DataTable dataTable3 = new DataTable();



                sql3 = "SELECT 	*  FROM other_payment where  date ='" + bunifuDatepicker1.Value.ToString("yyyy-MM-dd") + "'; ";





                MySqlCommand cmd3 = new MySqlCommand(sql3, con);
                MySqlDataAdapter da3 = new MySqlDataAdapter(cmd3);

                da3.Fill(dataTable3);


                dataGridView3.DataSource = dataTable3;

                dataGridView3.Columns[0].HeaderText = "ID ";
                dataGridView3.Columns[1].HeaderText = "Date";
                dataGridView3.Columns[2].HeaderText = "Payment Type ";
                dataGridView3.Columns[3].HeaderText = "Bank Name";
                dataGridView3.Columns[4].HeaderText = "Cheque No";
                dataGridView3.Columns[5].HeaderText = "Expense Id";
                dataGridView3.Columns[6].HeaderText = "Remark";
                dataGridView3.Columns[7].HeaderText = "Amount";


                con.Close();


                //4

                string sql4;

                con.Open();
                DataTable dataTable4 = new DataTable();



                sql4 = "SELECT 	date,s_id,name,quantity,rate,tprice,c_name,addr,mobi,pay_type,pertial_pay  FROM kusra_sale where  date ='" + bunifuDatepicker1.Value.ToString("yyyy-MM-dd") + "'; ";





                MySqlCommand cmd4 = new MySqlCommand(sql4, con);
                MySqlDataAdapter da4 = new MySqlDataAdapter(cmd4);

                da4.Fill(dataTable4);


                dataGridView4.DataSource = dataTable4;

                dataGridView4.Columns[0].HeaderText = "Date";
                dataGridView4.Columns[1].HeaderText = "Sales ID";
                dataGridView4.Columns[2].HeaderText = " Product Name ";
                dataGridView4.Columns[3].HeaderText = "Total Quantity ";
                dataGridView4.Columns[4].HeaderText = "Sale Rate Per Product";
                dataGridView4.Columns[5].HeaderText = "Total Price";
                dataGridView4.Columns[6].HeaderText = "Customer Name ";
                dataGridView4.Columns[7].HeaderText = " Customer Address  ";
                dataGridView4.Columns[8].HeaderText = "Customer Mobile ";
                dataGridView4.Columns[9].HeaderText = "Payment Type";
                dataGridView4.Columns[10].HeaderText = "Partial Payment ";



                con.Close();


                //5

                string sql5;

                con.Open();
                DataTable dataTable5 = new DataTable();



                sql5 = "SELECT 	purchase_history.id,date,c_id,item_id,quantity,amount,rate,supplier.c_name  FROM purchase_history INNER JOIN supplier ON  purchase_history.c_id=supplier.id where  date ='" + DateTime.Now.ToString("yyyy/MM/dd") + "'; ";





                MySqlCommand cmd5 = new MySqlCommand(sql5, con);
                MySqlDataAdapter da5 = new MySqlDataAdapter(cmd5);

                da5.Fill(dataTable5);


                dataGridView5.DataSource = dataTable5;

                dataGridView5.Columns[0].HeaderText = "ID";
                dataGridView5.Columns[1].HeaderText = "Date ";
                dataGridView5.Columns[2].HeaderText = "Supplier ID ";
                dataGridView5.Columns[3].HeaderText = "Product Name  ";
                dataGridView5.Columns[4].HeaderText = "Quantity ";
                dataGridView5.Columns[5].HeaderText = "Total Amount ";
                dataGridView5.Columns[6].HeaderText = "Rate";
                dataGridView5.Columns[7].HeaderText = "Supplier Name";


                con.Close();




                //6

                string sql6;

                con.Open();
                DataTable dataTable6 = new DataTable();



                sql6 = "SELECT 	*  FROM advanced_buj where  date ='" + bunifuDatepicker1.Value.ToString("yyyy-MM-dd") + "'; ";





                MySqlCommand cmd6 = new MySqlCommand(sql6, con);
                MySqlDataAdapter da6 = new MySqlDataAdapter(cmd6);

                da6.Fill(dataTable6);


                dataGridView6.DataSource = dataTable6;

                dataGridView6.Columns[0].HeaderText = "ID";
                dataGridView6.Columns[1].HeaderText = "Date ";
                dataGridView6.Columns[2].HeaderText = "Customer ID ";
                dataGridView6.Columns[3].HeaderText = "Detail   ";
                dataGridView6.Columns[4].HeaderText = "Debit Amount ";
                dataGridView6.Columns[5].HeaderText = "Product Name ";
                dataGridView6.Columns[6].HeaderText = "Rate";
                dataGridView6.Columns[7].HeaderText = "Total Budget";
                dataGridView6.Columns[8].HeaderText = "Remaining Budget";


                con.Close();


                //7


                string sql7;

                con.Open();
                DataTable dataTable7 = new DataTable();



                sql7 = " SELECT item_name,sum(deli_item) as deli_item FROM sales_delivery  where  date ='" + bunifuDatepicker1.Value.ToString("yyyy/MM/dd") + "' group by item_name; ";





                MySqlCommand cmd7 = new MySqlCommand(sql7, con);
                MySqlDataAdapter da7 = new MySqlDataAdapter(cmd7);

                da7.Fill(dataTable7);


                dataGridView7.DataSource = dataTable7;

                dataGridView7.Columns[0].HeaderText = "Product Name";
                dataGridView7.Columns[1].HeaderText = "Total Sell Unit ";



                con.Close();

                //8





                string sql8;

                con.Open();
                DataTable dataTable8 = new DataTable();



                sql8 = "SELECT 	ad_delivery.id,date,c_name,c_add,c_mobile,item_name,deli_item,remark FROM ad_delivery  INNER JOIN  clients ON  ad_delivery.c_id =clients.c_name AND date ='" + bunifuDatepicker1.Value.ToString("yyyy/MM/dd") + "'; ";


               




                MySqlCommand cmd8 = new MySqlCommand(sql8, con);
                MySqlDataAdapter da8 = new MySqlDataAdapter(cmd8);

                da8.Fill(dataTable8);


                dataGridView8.DataSource = dataTable8;

                dataGridView8.Columns[0].HeaderText = "ID";

                dataGridView8.Columns[1].HeaderText = "Date";
                dataGridView8.Columns[2].HeaderText = "Customer Name";
                dataGridView8.Columns[3].HeaderText = "Address ";
                dataGridView8.Columns[4].HeaderText = "Mobile NO";
                dataGridView8.Columns[5].HeaderText = "Item Namne ";
                dataGridView8.Columns[6].HeaderText = "Total Quantity";
                dataGridView8.Columns[7].HeaderText = "Remark   ";


                con.Close();

                //s1




try{
                con.Open();
                string stm9 = "SELECT sum(amount) FROM  colection   where  date ='" + bunifuDatepicker1.Value.ToString("yyyy/MM/dd") + "' ";
                MySqlCommand cmd9 = new MySqlCommand(stm9, con);

                MySqlDataReader rdr9 = cmd9.ExecuteReader();


                while (rdr9.Read())
                {

                    col = rdr9.GetString(0);




                }
                bunifuCustomLabel13.Text = col.ToString();
                } 

                catch(Exception ii)
            {

                bunifuCustomLabel13.Text = "0";

            } con.Close();


                //s2




try{
                con.Open();
                string stm91 = "SELECT sum(amount) FROM  purchage_payment   where  date ='" + bunifuDatepicker1.Value.ToString("yyyy/MM/dd") + "'";
                MySqlCommand cmd91 = new MySqlCommand(stm91, con);

                MySqlDataReader rdr91 = cmd91.ExecuteReader();


                while (rdr91.Read())
                {

                    pay = rdr91.GetString(0);




                }
                bunifuCustomLabel15.Text = pay.ToString();
               } 

                catch(Exception ii)
            {

                bunifuCustomLabel15.Text = "0";

            }  con.Close();

                //s3




try{                con.Open();
                string stm911 = "SELECT sum(amount) FROM  other_payment   where  date ='" + bunifuDatepicker1.Value.ToString("yyyy/MM/dd") + "' ";
                MySqlCommand cmd911 = new MySqlCommand(stm911, con);

                MySqlDataReader rdr911 = cmd911.ExecuteReader();


                while (rdr911.Read())
                {

                    opay = rdr911.GetString(0);




                }
                bunifuCustomLabel17.Text = opay.ToString();
               } 

                catch(Exception ii)
            {

                bunifuCustomLabel17.Text = "0";

            }  con.Close();




                //s4





            try{    con.Open();
                string stm9111 = "SELECT sum(tprice) FROM  kusra_sale    where  date ='" + bunifuDatepicker1.Value.ToString("yyyy/MM/dd") + "'";
                MySqlCommand cmd9111 = new MySqlCommand(stm9111, con);

                MySqlDataReader rdr9111 = cmd9111.ExecuteReader();


                while (rdr9111.Read())
                {

                    kcol = rdr9111.GetString(0);




                }
                bunifuCustomLabel19.Text = kcol.ToString();
               } 

                catch(Exception ii)
            {

                bunifuCustomLabel19.Text = "0";

            }  con.Close();


            // debit_amu
            try
            {
                con.Open();
                string ww = "SELECT sum(debit_amu) FROM  advanced_buj where  date ='" + bunifuDatepicker1.Value.ToString("yyyy/MM/dd") + "'  ";
                MySqlCommand eee = new MySqlCommand(ww, con);

                MySqlDataReader rrr = eee.ExecuteReader();


                if (rrr.Read())
                {

                    akcol = rrr.GetString(0);

                  //  MessageBox.Show("" + rrr.GetString(0));


                }
                bunifuCustomLabel25.Text = akcol.ToString();
            }

            catch (Exception ii)
            {

                bunifuCustomLabel25.Text = "0";

            } con.Close();


            try
            {
                con.Open();
                string stm911111 = "SELECT sum(amount) FROM  purchase_history  where  date ='" + bunifuDatepicker1.Value.ToString("yyyy/MM/dd") + "'  ";
                MySqlCommand cmd911111 = new MySqlCommand(stm911111, con);

                MySqlDataReader rdr911111 = cmd911111.ExecuteReader();


                if (rdr911111.Read())
                {

                    kcolaa = rdr911111.GetString(0);




                }
                bunifuCustomLabel21.Text = kcolaa.ToString();
            }

            catch (Exception ii)
            {

                bunifuCustomLabel21.Text = "0";

            } con.Close();











            bunifuCustomLabel26.Text = (Convert.ToDouble(col) - (Convert.ToDouble(pay) + Convert.ToDouble(opay))).ToString("N");










            }


            catch (Exception ee)
            {




            }


        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            try{

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
                totaldata custDB = new totaldata();
                custDB.Clear();

                cmda.CommandText = " SELECT item_name,sum(deli_item) as deli_item FROM sales_delivery  where  date ='" + DateTime.Now.ToString("yyyy/MM/dd") + "' group by item_name ";


                cmda.ExecuteNonQuery();


                adap = new MySqlDataAdapter();

                adap.SelectCommand = cmda;

                DataTable d1 = new DataTable();

                adap.Fill(custDB.DataTable1);
                adap.Fill(d1);


                crReportDocument = new CrystalReport18();

                crReportDocument.SetDataSource(custDB);





                try
                {


                    crReportDocument.PrintOptions.PrinterName = PrinterName;




                    p.crystalReportViewer1.ReportSource = crReportDocument;
                    //p.crystalReportViewer1.Refresh();
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

        catch(Exception gg){MessageBox.Show(""+gg);

        con.Close();
        }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {



            this.printDialog1.Document = this.printDocument1;
            DialogResult dr = this.printDialog1.ShowDialog();

            print p = new print();

            MySqlCommand cmda;
            MySqlDataAdapter adap;
            MySqlCommand cmda1;
            MySqlDataAdapter adap1;
            MySqlCommand cmda2;
            MySqlDataAdapter adap2;


            if (dr == DialogResult.OK)
            {

                int nCopy = this.printDocument1.PrinterSettings.Copies;

                int sPage = this.printDocument1.PrinterSettings.FromPage;

                int ePage = this.printDocument1.PrinterSettings.ToPage;
                string PrinterName = this.printDocument1.PrinterSettings.PrinterName;

                crReportDocument = new ReportDocument();

                con.Open();
                cmda = con.CreateCommand();
                purchasedata custDB = new purchasedata();
                custDB.Clear();

                cmda.CommandText = "SELECT 	*  FROM purchase_history where  date ='" + bunifuDatepicker1.Value.ToString("yyyy-MM-dd") + "'; ";


                cmda.ExecuteNonQuery();


                adap = new MySqlDataAdapter();

                adap.SelectCommand = cmda;

                DataTable d1 = new DataTable();

                adap.Fill(custDB.DataTable1);
                adap.Fill(d1);


                con.Close();

                con.Open();
                cmda1 = con.CreateCommand();


                cmda1.CommandText = "SELECT *  FROM advanced_buj where  date ='" + bunifuDatepicker1.Value.ToString("yyyy-MM-dd") + "'; ";


                cmda1.ExecuteNonQuery();


                adap1 = new MySqlDataAdapter();

                adap1.SelectCommand = cmda1;

                DataTable d2 = new DataTable();

                adap1.Fill(custDB.DataTable2);
                adap1.Fill(d2);



                con.Close();

           

                //
                con.Open();

                cmda2 = con.CreateCommand();


                cmda2.CommandText ="SELECT 	c_name,date,item_name,deli_item,remark,c_add,c_mobile FROM ad_delivery  INNER JOIN  clients ON  ad_delivery.c_id =clients.c_name AND date ='" + bunifuDatepicker1.Value.ToString("yyyy/MM/dd") + "'; ";



                cmda2.ExecuteNonQuery();


                adap2 = new MySqlDataAdapter();

                adap2.SelectCommand = cmda2;

                DataTable d3 = new DataTable();

                adap2.Fill(custDB.DataTable3);
                adap2.Fill(d3);









                crReportDocument = new CrystalReport19();

                crReportDocument.SetDataSource(custDB);

                crReportDocument.SetParameterValue("his", bunifuCustomLabel21.Text);
                crReportDocument.SetParameterValue("ord", bunifuCustomLabel25.Text);





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
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {


            //0000000

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
                daybookdata custDB = new daybookdata();
                custDB.Clear();
                con.Open();
                cmda = con.CreateCommand();


                cmda.CommandText = "SELECT 	*  FROM colection where  date ='" + bunifuDatepicker1.Value.ToString("yyyy-MM-dd") + "'; ";


                cmda.ExecuteNonQuery();


                adap = new MySqlDataAdapter();

                adap.SelectCommand = cmda;

                DataTable d1 = new DataTable();

                adap.Fill(custDB.DataTable1);
                adap.Fill(d1);


                con.Close();

                con.Open();
                cmda1 = con.CreateCommand();


                cmda1.CommandText = "SELECT *  FROM purchage_payment where  date ='" + bunifuDatepicker1.Value.ToString("yyyy-MM-dd") + "' ";


                cmda1.ExecuteNonQuery();


                adap1 = new MySqlDataAdapter();

                adap1.SelectCommand = cmda1;

                DataTable d2 = new DataTable();

                adap1.Fill(custDB.DataTable2);
                adap1.Fill(d2);




                //3rd
                con.Close();

                con.Open();
                cmda2 = con.CreateCommand();


                cmda2.CommandText = "SELECT *  FROM other_payment where  date ='" + bunifuDatepicker1.Value.ToString("yyyy-MM-dd") + "'; ";


                cmda2.ExecuteNonQuery();


                adap2 = new MySqlDataAdapter();

                adap2.SelectCommand = cmda2;

                DataTable d3 = new DataTable();

                adap2.Fill(custDB.DataTable3);
                adap2.Fill(d3);


                //4th
                con.Close();

                con.Open();
                cmda3 = con.CreateCommand();


                cmda3.CommandText = "SELECT *  FROM kusra_sale where  date ='" + bunifuDatepicker1.Value.ToString("yyyy-MM-dd") + "'; ";


                cmda3.ExecuteNonQuery();


                adap3 = new MySqlDataAdapter();

                adap3.SelectCommand = cmda3;

                DataTable d4 = new DataTable();

                adap3.Fill(custDB.DataTable4);
                adap3.Fill(d4);








                crReportDocument = new CrystalReport20();

                crReportDocument.SetDataSource(custDB);


                double cash = Convert.ToDouble(bunifuCustomLabel13.Text) - (Convert.ToDouble(bunifuCustomLabel15.Text) + Convert.ToDouble(bunifuCustomLabel17.Text));

                crReportDocument.SetParameterValue("amo", bunifuCustomLabel13.Text);
                crReportDocument.SetParameterValue("2", bunifuCustomLabel15.Text);
                crReportDocument.SetParameterValue("3", bunifuCustomLabel17.Text);
                crReportDocument.SetParameterValue("4", bunifuCustomLabel19.Text);

                crReportDocument.SetParameterValue("5", cash);
               

                try
                {


                    crReportDocument.PrintOptions.PrinterName = PrinterName;




                    p.crystalReportViewer1.ReportSource = crReportDocument;
                  //  p.crystalReportViewer1.Refresh();
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

        private void bunifuCustomLabel2_MouseHover(object sender, EventArgs e)
        {




            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;
            dataGridView6.Visible = false;
            dataGridView7.Visible = false;
            dataGridView8.Visible = false;



            dataGridView1.Visible = true;











        }

        private void bunifuCustomLabel3_MouseHover(object sender, EventArgs e)
        {

            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;
            dataGridView6.Visible = false;
            dataGridView7.Visible = false;
            dataGridView8.Visible = false;



            dataGridView2.Visible = true;
        }

        private void bunifuCustomLabel4_MouseHover(object sender, EventArgs e)
        {

            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;
            dataGridView6.Visible = false;
            dataGridView7.Visible = false;

            dataGridView8.Visible = false;


            dataGridView3.Visible = true;
        }

        private void bunifuCustomLabel8_MouseHover(object sender, EventArgs e)
        {

            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;
            dataGridView6.Visible = false;
            dataGridView7.Visible = false;
            dataGridView8.Visible = false;



            dataGridView4.Visible = true;
        }

        private void bunifuCustomLabel7_MouseHover(object sender, EventArgs e)
        {

            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;
            dataGridView6.Visible = false;
            dataGridView7.Visible = false;
            dataGridView8.Visible = false;



            dataGridView6.Visible = true;
        }

        private void bunifuCustomLabel6_MouseHover(object sender, EventArgs e)
        {

            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;
            dataGridView6.Visible = false;
            dataGridView7.Visible = false;
            dataGridView8.Visible = false;



            dataGridView7.Visible = true;
        }

        private void bunifuCustomLabel5_MouseHover(object sender, EventArgs e)
        {

            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;
            dataGridView6.Visible = false;
            dataGridView7.Visible = false;
            dataGridView8.Visible = false;



            dataGridView5.Visible = true;
        }

        private void bunifuCustomLabel28_MouseHover(object sender, EventArgs e)
        {


            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            dataGridView5.Visible = false;
            dataGridView6.Visible = false;
            dataGridView7.Visible = false;

            dataGridView8.Visible = false;


            dataGridView8.Visible = true;
            


        }

        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {

        }
    }
}
