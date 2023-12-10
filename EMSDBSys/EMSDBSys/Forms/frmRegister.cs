using EMSDBSys.AppData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMSDBSys.Forms
{
    public partial class frmRegister : Form
    {
        EmpManagementEntities db;
        public frmRegister()
        {
            InitializeComponent();
            db = new EmpManagementEntities();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtFirstname.Text))
            {
                errorProvider1.SetError(txtFirstname, "Empty field");
                return;
            }
            if (String.IsNullOrEmpty(txtLastname.Text))
            {
                errorProvider1.SetError(txtLastname, "Empty field");
                return;
            }
            if (String.IsNullOrEmpty(txtAddress.Text))
            {
                errorProvider1.SetError(txtAddress, "Empty field");
                return;
            }          
            if (String.IsNullOrEmpty(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Empty field");
                return;
            }
            if (String.IsNullOrEmpty(txtPhone.Text))
            {
                errorProvider1.SetError(txtPhone, "Empty field");
                return;
            }
            if (String.IsNullOrEmpty(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, "Empty field");
                return;
            }
            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Empty field");
                return;
            }
            if (String.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                errorProvider1.SetError(txtConfirmPassword, "Empty field");
                return;
            }
            if (!txtPassword.Text.Equals(txtConfirmPassword.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtConfirmPassword, "Password not match");
                return;
            }
            UserAccount nUserAccount = new UserAccount();
            nUserAccount.userFName = txtFirstname.Text;
            nUserAccount.userLName = txtLastname.Text;
            nUserAccount.userAddress = txtAddress.Text;
            nUserAccount.userEmail = txtEmail.Text;
            nUserAccount.userPhone = txtPhone.Text;
            nUserAccount.userName = txtUsername.Text;
            nUserAccount.userPassword = txtPassword.Text;
            nUserAccount.roleId = 1;

            db.UserAccount.Add(nUserAccount);
            db.SaveChanges();

            txtFirstname.Clear();
            txtLastname.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            MessageBox.Show("Registed!");
            this.Close();
            new frmLogin().Show();
        }
    }
}
