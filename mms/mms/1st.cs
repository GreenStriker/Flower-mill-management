using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace mms
{
    class _1st
    {

        
        MySqlConnection con = null;
        public _1st()
        {
           
            con = DatabaseConnection.getDBConnection();


            MySqlDataReader rdr2 = null;



            con.Open();

            string stm = "SELECT * FROM magik where id ='1'";
            MySqlCommand cmd = new MySqlCommand(stm, con);
            rdr2 = cmd.ExecuteReader();

            string loc;
            string lie;

            if (rdr2.Read())
            {
                loc = rdr2.GetString("lock_soft");
                lie = rdr2.GetString("licence");




                con.Close();


                if (lie == "1")
                {

                  //  MessageBox.Show("licence active");


                    spash m = new spash();

                    m.Show();


                  //  this.Visible = false;






                }

                else
                {
                    if (loc == "1")
                    {

                      //  MessageBox.Show("Active the product Frist ");
                        //licence form

                        check m = new check();

                        m.Show();


                    }
                    else
                    {







                    }








                }








            }
            else
            {
                con.Close();










            }





















        }













    }
}
