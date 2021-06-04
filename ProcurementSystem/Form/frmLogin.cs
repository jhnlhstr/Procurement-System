using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProcurementSystem.Class.DBMethods;
using ProcurementSystem.Class.Information;

namespace ProcurementSystem
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void icnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user_rights = string.Empty;

            if (txtUsername.Text == string.Empty || txtPassword.Text == string.Empty)
            {
                MessageBox.Show("Kindly input all fields for your credentials", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DBMethods.GetUserLogin(txtUsername.Text, txtPassword.Text, ref user_rights))
            {
                InformationDetails.Username = txtUsername.Text;
                InformationDetails.Credentials = user_rights;

                frmMain frmMain = new frmMain();
                this.Hide();
                frmMain.ShowDialog();
                this.Close();

            }
            else
            {
                MessageBox.Show("User not registered!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }



    }
}
