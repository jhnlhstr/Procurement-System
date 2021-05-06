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

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void icnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == string.Empty || txtUsername.Text == string.Empty)
            {
                MessageBox.Show("Please input all details needed!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DBMethods.GetUserLogin(txtUsername.Text, txtPassword.Text))
            {
                InformationDetails.Username = txtUsername.Text;
                Main frmMain = new Main();
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
