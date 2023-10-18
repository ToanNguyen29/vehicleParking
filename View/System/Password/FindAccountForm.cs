using FinalWindow.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalWindow
{
    public partial class FindAccountForm : Form
    {
        private string randomCode;

        public FindAccountForm()
        {
            InitializeComponent();
        }

        private void FindAccountForm_Load(object sender, EventArgs e)
        {
            if (textBox_Username.Text == "")
            {
                textBox_Username.PlaceholderText = "Type your Username";
                textBox_Username.PlaceholderForeColor = System.Drawing.Color.Black;
            }
            if (textbox_OTP.Text == "")
            {
                textbox_OTP.PlaceholderText = "Type your OTP code";
                textbox_OTP.PlaceholderForeColor = System.Drawing.Color.Black;
            }

        }

        private void button_verify_Click(object sender, EventArgs e)
        {
            if(textbox_OTP.Text==randomCode)
            {
                ChangePasswordForm changePasswordForm = new ChangePasswordForm();
                changePasswordForm.Username = textBox_Username.Text;
                changePasswordForm.Show();
            }
            else
            {
                MessageBox.Show("Wrong code");
            }
            
        }

        private void button_Find_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox_Username.Text))
            {
                MessageBox.Show("Please enter your username");
            }
            else
            {
                var context = new DatabaseContext();
                
                var user = context.Users.Where(t => t.username == textBox_Username.Text).FirstOrDefault();
                textBox_email.Text = user.email;
            }
        }

        private void button_sendCode_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            randomCode = (rand.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            string to = textBox_email.Text;
            string from = "20110012@student.hcmute.edu.vn";
            string pass = "toan2002@it";
            string messageBody = "Your reset code is " + randomCode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Password reseting code";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try
            {
                smtp.Send(message);
                MessageBox.Show("Code send successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
