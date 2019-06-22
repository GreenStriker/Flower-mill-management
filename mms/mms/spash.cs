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

namespace mms
{
    public partial class spash : Form
    {

        MySqlConnection con = null;
        public spash()
        {
            InitializeComponent();
            con = DatabaseConnection.getDBConnection();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {




            timer1.Start();
            bunifuProgressBar1.Value += 10;
            if (bunifuProgressBar1.Value == 100)
            {
                timer1.Stop();
                login l1 = new login();

                l1.Show();
                this.Visible = false;
               //this.Hide();


            }



        }

        private void bunifuProgressBar1_progressChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
