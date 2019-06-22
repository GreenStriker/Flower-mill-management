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
    public partial class staf : Form
    {

        ReportDocument crReportDocument;
        MySqlConnection con = null;
        long last;
        public staf()
        {
            
            InitializeComponent();
            con = DatabaseConnection.getDBConnection();

            con.Close();
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

        private void staf_Load(object sender, EventArgs e)
        {
            con.Close();
           
          try{  MySqlDataReader rdr = null;

            con.Open();

            string stm = "SELECT name FROM staff_info";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            rdr = cmd.ExecuteReader();

            AutoCompleteStringCollection mm = new AutoCompleteStringCollection();


            while (rdr.Read())
            {

                mm.Add(rdr.GetString(0));




            }
            textBox7.AutoCompleteCustomSource = mm;
            textBox2.AutoCompleteCustomSource = mm;
            textBox3.AutoCompleteCustomSource = mm;
            con.Close();











            con.Open();
            DataTable dataTable = new DataTable();




            string sql1 = "SELECT 	id,name,salary,taken_amount,overtime_amount  FROM  staf_curent_month ; ";





            MySqlCommand cmd1 = new MySqlCommand(sql1, con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd1);

            da.Fill(dataTable);


            dataGridView2.DataSource = dataTable;

            dataGridView2.Columns[0].HeaderText = "Staf ID ";
            dataGridView2.Columns[1].HeaderText = "Staf Name ";

            dataGridView2.Columns[2].HeaderText = "Remaining Salary ";
            dataGridView2.Columns[3].HeaderText = "Advanced Taken  ";
            dataGridView2.Columns[4].HeaderText = "Overtime/taka ";


            con.Close();




















            con.Open();
            DataTable dataTable1 = new DataTable();




            string sql11 = "SELECT 	id,name,present_days FROM  staf_curent_month ; ";





            MySqlCommand cmd11 = new MySqlCommand(sql11, con);
            MySqlDataAdapter da1 = new MySqlDataAdapter(cmd11);

            da1.Fill(dataTable1);


            dataGridView1.DataSource = dataTable1;

            //dataGridView1.Columns[0].HeaderText = "Product ID ";
            //dataGridView1.Columns[1].HeaderText = "Product Name ";
            //dataGridView1.Columns[2].HeaderText = "Quantity In Stock ";
            //dataGridView1.Columns[3].HeaderText = "Unit  ";
            //dataGridView1.Columns[4].HeaderText = "Lowest Selling Price/TAKA ";


            con.Close();

          }


          catch (Exception r)
          {
              main1 m = new main1();
              m.Show();
             this.Hide();







          }




        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {

            panel1.Visible = false;
            panel5.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel6.Visible = false;

            ani2.ShowSync(panel1);









        }

        private void bunifuCustomLabel15_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            con.Close();

            try
            {
                con.Open();

                string query1 = "Update staf_curent_month SET salary =salary- '" + textBox5.Text + "' , taken_amount =taken_amount+ '" + textBox5.Text + "' where name = '" + textBox2.Text + "' ";


                //create command and assign the query and connection from the constructor
                MySqlCommand cmd1 = new MySqlCommand(query1, con);

                //Execute command
                cmd1.ExecuteNonQuery();

                //close connection
                con.Close();


                con.Open();

                string query10 = "Update totalbal SET total_debit =total_debit+ '" + textBox5.Text + "' where id='1' ";


                //create command and assign the query and connection from the constructor
                MySqlCommand cmd10 = new MySqlCommand(query10, con);

                //Execute command
                cmd10.ExecuteNonQuery();

                //close connection
                con.Close();





                MessageBox.Show("Advanced Salary Given");

                staf s = new staf();
                s.Show();
               this.Hide();

            }
            catch (Exception r)
            {
                main1 m = new main1();
                m.Show();
               this.Hide();






            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            con.Close();


            try { 

            con.Open();
            DataTable dataTable = new DataTable();




            string sql1 = "SELECT 	id,name,salary,taken_amount,overtime_amount  FROM  staf_curent_month where name= '" + textBox3.Text + "'; ";





            MySqlCommand cmd1 = new MySqlCommand(sql1, con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd1);

            da.Fill(dataTable);


            dataGridView2.DataSource = dataTable;

            dataGridView2.Columns[0].HeaderText = "Staf ID ";
            dataGridView2.Columns[1].HeaderText = "Staf Name ";

            dataGridView2.Columns[2].HeaderText = "Salary ";
            dataGridView2.Columns[3].HeaderText = "Advanced Taken  ";
            dataGridView2.Columns[4].HeaderText = "Overtime/taka ";


            con.Close();






            MySqlDataReader rdr2 = null;

            con.Open();

            string stm2 = "SELECT post,adress,mobile,curent_salary   FROM  staff_info where name= '" + textBox3.Text + "'; ";
            MySqlCommand cmd2 = new MySqlCommand(stm2, con);
            rdr2 = cmd2.ExecuteReader();

            if (rdr2.Read())
            {
                textBox9.Text = rdr2.GetString(0);
                textBox10.Text = rdr2.GetString(1);
                textBox11.Text = rdr2.GetString(2);
                textBox12.Text = rdr2.GetString(3);












            }

            else
            {




            }


            con.Close();









            }


            catch (Exception r)
            {
                main1 m = new main1();
                m.Show();
               this.Hide();







            }


        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            con.Close();

            try { 
            con.Open();

            string query1 = "Update staf_curent_month SET salary =salary+'" + textBox6.Text + "' ,	overtime_amount =	overtime_amount+ '" + textBox6.Text + "' where name = '" + textBox7.Text + "' ";


            //create command and assign the query and connection from the constructor
            MySqlCommand cmd1 = new MySqlCommand(query1, con);

            //Execute command
            cmd1.ExecuteNonQuery();

            //close connection
            con.Close();


            con.Open();

            string query10 = "Update totalbal SET total_debit =total_debit+ '" + textBox6.Text + "' where id='1' ";


            //create command and assign the query and connection from the constructor
            MySqlCommand cmd10 = new MySqlCommand(query10, con);

            //Execute command
            cmd10.ExecuteNonQuery();

            //close connection
            con.Close();





            MessageBox.Show("overtime Salary Given");



            staf s = new staf();
            s.Show();
           this.Hide();



            }


            catch (Exception r)
            {
                main1 m = new main1();
                m.Show();
               this.Hide();







            }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {




        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {




            //MessageBox.Show(rowindex.ToString());
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
           try

           { 
               
               dataGridView1.EndEdit();



            int fuck = 0;
                
                int i = 0;
                int index = dataGridView1.Rows.Count ;
            //MessageBox.Show("UPDATED"+index);
                do
                {
                   // MessageBox.Show("UPDATED" + index + "index" + i);
                    string id = dataGridView1.Rows[i].Cells[1].Value.ToString();
                   // int id = Convert.ToInt32(y);
                   // MessageBox.Show("id" + id);
                    string present = dataGridView1.Rows[i].Cells[2].Value.ToString();
                   // pre.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    double x = Convert.ToDouble(present);
                  //  con.Close();
                    con.Open();

                    string query10 = "Update staf_curent_month SET 	present_days ='" + x + "' where name='" + id + "' ";


                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd10 = new MySqlCommand(query10, con);

                    //Execute command
                    cmd10.ExecuteNonQuery();

                    //close connection
                    con.Close();
                    fuck = i;
                    i++;
                }
                while (i != index);

               




                MessageBox.Show("UPDATED");


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

            try { 

            string month = DateTime.Now.AddMonths(-1).ToString("MMMM");
            string year=DateTime.Now.ToString("yyyy");


            con.Open();
            string stm11 = "SELECT * FROM  staf_rec where month = '"+month+"' AND year='"+year+"'";
            MySqlCommand cmd11 = new MySqlCommand(stm11, con);

            MySqlDataReader rdr111 = cmd11.ExecuteReader();


            if (rdr111.Read())
            {


                MessageBox.Show("The Month Has Already Been Closed ");

                con.Close();
            }
            else 
            {
            con.Close();





            con.Open();

            string query10 = "Update staf_curent_month SET salary =(present_days/'" + textBox8.Text + "'*main_salary-taken_amount+overtime_amount )";


            //create command and assign the query and connection from the constructor
            MySqlCommand cmd10 = new MySqlCommand(query10, con);

            //Execute command
            cmd10.ExecuteNonQuery();

            //close connection
            con.Close();
          

            
            string[] a =  new string[200] ;
            string[] b = new string[1000];
            string[] c = new string[1000];
            string[] d = new string[1000];
            string[] ee = new string[1000];
            string[] f = new string[1000];
            string[] g = new string[1000]; 


            int i=0;
            double totalsal = 0;
            con.Open();
            string stm = "SELECT * FROM  staf_curent_month";
            MySqlCommand cmd = new MySqlCommand(stm, con);
          
           MySqlDataReader rdr1  = cmd.ExecuteReader();


            while (rdr1.Read())
            {

                a[i] = rdr1["id"].ToString();
                   b[i]= rdr1["present_days"].ToString();
             c[i]= rdr1["salary"].ToString(); 
             d[i]= rdr1["taken_amount"].ToString();
            ee[i]=rdr1["overtime_amount"].ToString();
             f[i]= rdr1["main_salary"].ToString();
             g[i]= rdr1["name"].ToString();

            
             i++;

             

            }

            con.Close();


          
            int q = 0;
            for (q = 0; q < i; q++)
            {
                totalsal = totalsal + Convert.ToDouble(c[i]);
                string query11 = "insert into staf_rec (month,year,staf_id,present_days,salary,taken_amount,overtime_amount,main_salary,name) values ('" + month + "','" + year + "','" + Convert.ToDouble(a[q]) + "', '" + Convert.ToDouble(b[q]) + "' ,'" + Convert.ToDouble(c[q]) + "' ,'" + Convert.ToDouble(d[q]) + "', '" + Convert.ToDouble(ee[q]) + "', '" + Convert.ToDouble(f[q]) + "','" + g[q] + "') ";

                con.Open();

                MySqlCommand cmd111 = new MySqlCommand(query11, con);


                cmd111.ExecuteNonQuery();


                 last = cmd111.LastInsertedId;

                

                con.Close();

            }


          



            con.Open();

            string query101 = "Update totalbal SET total_debit =total_debit+ '" + totalsal + "' where id='1' ";


            //create command and assign the query and connection from the constructor
            MySqlCommand cmd101 = new MySqlCommand(query101, con);

            //Execute command
            cmd101.ExecuteNonQuery();

            //close connection
            con.Close();


            con.Open();

            string query334 = "INSERT INTO other_payment (date, expence_id, pament_type, bank_name, check_no,remark,	amount  ) VALUES ('" + DateTime.Now.ToString("yyyy-MM-dd") + "', 'salary', 'cash', ' ', ' ', ' ','" + totalsal + "')";


            //create command and assign the query and connection from the constructor
            MySqlCommand cmd334 = new MySqlCommand(query334, con);

            //Execute command
            cmd334.ExecuteNonQuery();

            //close connection
            con.Close();



            con.Open();

            string query410 = "Update staf_curent_month SET salary = main_salary ,	overtime_amount = '0',	taken_amount = '0',	present_days = '0'";


            //create command and assign the query and connection from the constructor
            MySqlCommand cmd410 = new MySqlCommand(query410, con);

            //Execute command
            cmd410.ExecuteNonQuery();

            //close connection
            con.Close();





//print




            string mm="";
            string yy="";


            MySqlDataReader rdr42 = null;

            con.Open();

            string stm42 = "SELECT * FROM staf_rec where id = '" + last + "'";
            MySqlCommand cmd42 = new MySqlCommand(stm42, con);
            rdr42 = cmd42.ExecuteReader();

            if (rdr42.Read())
            {
                 mm = rdr42.GetString(1).ToString();
                 yy= rdr42.GetString(2).ToString();

                
            }

            con.Close();






                //print



            double income = 0;

            MySqlDataReader rdr28 = null;
            con.Open();

            string stm8 = "select * from staf_rec where month ='" + mm + "' AND year='"+ yy +"'";
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

            MySqlCommand cmd33;
            MySqlDataAdapter adap;



            if (dr == DialogResult.OK)
            {

                int nCopy = this.printDocument1.PrinterSettings.Copies;

                int sPage = this.printDocument1.PrinterSettings.FromPage;

                int ePage = this.printDocument1.PrinterSettings.ToPage;
                string PrinterName = this.printDocument1.PrinterSettings.PrinterName;

                crReportDocument = new ReportDocument();

                con.Open();
                cmd33 = con.CreateCommand();
                staffdata custDB = new staffdata();
                custDB.Clear();

                cmd33.CommandText = "select * from staf_rec where month ='" + mm + "' AND year='" + yy + "'";
                cmd33.ExecuteNonQuery();


                adap = new MySqlDataAdapter();

                adap.SelectCommand = cmd33;

                DataTable d1 = new DataTable();

                adap.Fill(custDB.DataTable1);
                adap.Fill(d1);


                crReportDocument = new CrystalReport2();

                crReportDocument.SetDataSource(custDB);

                crReportDocument.SetParameterValue("total", income.ToString());

                crReportDocument.SetParameterValue("days", textBox8.Text);




                try
                {


                    crReportDocument.PrintOptions.PrinterName = PrinterName;




                    p.crystalReportViewer1.ReportSource = crReportDocument;
                  //  p.crystalReportViewer1.Refresh();
                   // p.Show();
                    crReportDocument.PrintToPrinter(nCopy, false, sPage, ePage);


                 //   MessageBox.Show("Report finished printing!");
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
                con.Close();
            }
          


























            MessageBox.Show("month Close Successfull");
            
            
            }

            }


            catch (Exception r)
            {
                main1 m = new main1();
                m.Show();
               this.Hide();







            }
        }

        private void bunifuCustomTextbox7_TextChanged(object sender, EventArgs e)
        {

            if (bunifuCustomTextbox7.Text == "15289420")
            {

                ani1.HideSync(panel7);
                
             


            }





        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel5.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel6.Visible = false;

            ani2.ShowSync(panel5);
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel5.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel6.Visible = false;

            ani2.ShowSync(panel2);
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel5.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel6.Visible = false;

            ani2.ShowSync(panel3);
        }

        private void bunifuThinButton27_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel5.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel6.Visible = true;

            
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {


            try { 



            if (textBox9.Text == "" ||
                textBox10.Text == "" ||
                textBox11.Text == "" ||
                textBox12.Text == "")
            {

                MessageBox.Show("Fill all the fields!");
            }

            else
            {



                try
                {
                    con.Open();




                    string query = "UPDATE  staff_info SET  post='" + textBox9.Text + "', adress='" + textBox10.Text + "', mobile='" + textBox11.Text + "',	curent_salary='" + textBox12.Text + "'  where name = '" + textBox3.Text + "'";


                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, con);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection


                    string query1 = "UPDATE  staf_curent_month SET  main_salary='" + textBox12.Text + "'where name = '" + textBox3.Text + "'";


                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd1 = new MySqlCommand(query1, con);

                    //Execute command
                    cmd1.ExecuteNonQuery();


                    con.Close();




                    MessageBox.Show("SUCCESSFULL");
                    staf m1 = new staf();


                    m1.Show();

                   this.Hide();


                }
                catch (Exception e11)
                {

                    con.Close();
                    MessageBox.Show("Error ocure Check Server PC OR Name Already Exits Use Different name"+e11);


                }


            }



            }


            catch (Exception r)
            {
                main1 m = new main1();
                m.Show();
               this.Hide();







            }





        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }
        }
    }
