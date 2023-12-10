using EMSDBSys.Forms;
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

namespace EMSDBSys
{
    public partial class frmLogin : Form
    {
        UserRepository userRepo;
        public frmLogin()
        {
            InitializeComponent();
            userRepo = new UserRepository();
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            new frmRegister().Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUsername.Text))
            {
                errorProviderCustom.SetError(txtUsername, "Empty Field!");
                return;
            }
            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                errorProviderCustom.SetError(txtPassword, "Empty Field!");
                return;
            }

            var userLogged = userRepo.GetUserByUsername(txtUsername.Text);

            if (userLogged != null)
            {
                if (userLogged.userPassword.Equals(txtPassword.Text))
                {
                    UserLogged.GetInstance().UserAccount = userLogged;

                    switch ((Roles)userLogged.roleId)
                    {
                        case Roles.User:
                            new FrmUser().Show();
                            this.Hide();
                            break;
                        case Roles.Staff:
                            new FrmStaff().Show();
                            this.Hide();
                            break;
                        case Roles.Admin:
                            new FrmAdmin().Show();
                            this.Hide();
                            break;
                        default:
                            MessageBox.Show("User has no role!");
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Password");
                }
            }
            else
            {
                MessageBox.Show("Username not found");
            }
        }
    }
}

