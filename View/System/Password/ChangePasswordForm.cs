using FinalWindow.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalWindow
{
    public partial class ChangePasswordForm : Form
    {
        private string username;

        public string Username { get => username; set => username = value; }

        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Password.Text) || string.IsNullOrEmpty(textBox_confirmPassword.Text))
            {
                MessageBox.Show("Please enter full information");
                return;
            }
            if (textBox_Password.Text.Length < 8)
            {
                textBox_Password.Text = "";
                textBox_confirmPassword.Text = "";
                MessageBox.Show("Password must be at least 8 characters");
                return;
            }

            if (String.Compare(textBox_Password.Text, textBox_confirmPassword.Text, false) != 0)
            {
                textBox_Password.Text = "";
                textBox_confirmPassword.Text = "";
                MessageBox.Show("Don't verify retype password");
                return;

            }


            var context = new DatabaseContext();
            
            var user = context.Users.Where(t => t.username == username).FirstOrDefault();
            user.password = textBox_Password.Text;
            try
            {
                context.SaveChanges();
                MessageBox.Show("Reset password successfully");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Reset password failed");
            }

            
        }
    }
}
