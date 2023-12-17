using EMSDBSys.Model;
using EMSDBSys.Repositories;
using EMSDBSys.Utils;
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
    public partial class FrmAdmin : Form
    {
        UserRepository userRepo;
        public FrmAdmin()
        {
            InitializeComponent();
            userRepo = new UserRepository();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            String strOutputMsg = "";
            if (String.IsNullOrEmpty(txtLastName.Text))
            {
                errorProvider1.SetError(txtLastName, "Empty field");
                return;
            }
            if (String.IsNullOrEmpty(txtFirstName.Text))
            {
                errorProvider1.SetError(txtFirstName, "Empty field");
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
            if (String.IsNullOrEmpty(txtPass.Text))
            {
                errorProvider1.SetError(txtPass, "Empty field");
                return;
            }
            if (String.IsNullOrEmpty(txtConfirmPass.Text))
            {
                errorProvider1.SetError(txtConfirmPass, "Empty field");
                return;
            }
            if (!txtPass.Text.Equals(txtConfirmPass.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtConfirmPass, "Password not match");
                return;
            }

            int createdBy = UserLogged.GetInstance().UserAccount.userId;
            ErrorCode retValue = userRepo.InsertUserUsingStoredProf(txtFirstName.Text, txtLastName.Text, txtAddress.Text, txtEmail.Text, txtPhone.Text, txtUsername.Text, txtPass.Text, cbRole.SelectedIndex + 1, createdBy, ref strOutputMsg);
            if (retValue != ErrorCode.Success)
            {

                MessageBox.Show(strOutputMsg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadUsers();

                txtLastName.Clear();
                txtFirstName.Clear();
                txtAddress.Clear();
                txtEmail.Clear();
                txtPhone.Clear();
                txtUsername.Clear();
                cbRole.Text = "Roles";
                txtPass.Clear();
                txtConfirmPass.Clear();
                MessageBox.Show("Registed!");
            }
            else
            {
                MessageBox.Show(strOutputMsg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            loadUsers();
        }
        public void loadUsers()
        {
            dgvUsers.DataSource = userRepo.AllUserTable();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
