using FinalWindow.CustomerBuilderPattern;
using FinalWindow.Database;
using FinalWindow.Model;
using FinalWindow.Tool;
using FinalWindow.View.Customer;
using FinalWindow.View.FixWorker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalWindow
{
    public partial class FixWorkerMainForm : Form
    {
        private static int fixID;
        public static int FixID { get => fixID; set => fixID = value; }

        public FixWorkerMainForm()
        {
            InitializeComponent();
        }



        private void FixWorkerMainForm_Load(object sender, EventArgs e)
        {
            loadProfile();
        }


        void loadProfile()
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    var fixer = context.Users.OfType<FixWorker>().Where(t => t.ID == fixID).FirstOrDefault();
                    if (fixer.picture != null)
                    {
                        byte[] imageData = (byte[])fixer.picture;
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            pictureBox_profile.Image = Image.FromStream(ms);
                        }
                    }

                    label_username.Text = fixer.username;
                    label_firstName.Text = fixer.firstName;
                    label_lastName.Text = fixer.lastName;
                    label_gender.Text = fixer.gender;
                    label_birthDate.Text = fixer.birthday.Value.Date.ToString("dd/MM/yyyy");
                    label_email.Text = fixer.email;
                    label_phone.Text = fixer.phone;
                    label_address.Text = fixer.address;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button_editInformation_Click(object sender, EventArgs e)
        {
            FixWorkerEditInformationForm form = new FixWorkerEditInformationForm();
            form.Show();
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            loadProfile();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {


        }

        private void tabPage_profile_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void ButtonCheckNumberPhone_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox_phoneCus.Text))
            {
                MessageBox.Show("Please enter phone number");
                return;
            }    
            if (CheckInput.IsPhoneNbr(textBox_phoneCus.Text) == false)
            {
                MessageBox.Show("Invalid phone number");
                return;
            }
            using (var context = new DatabaseContext())
           {
                var cus = context.Users.OfType<Customer>().Where(t => t.phone == textBox_phoneCus.Text).FirstOrDefault();
                if(cus != null)
                {
                    textBox_fName.Text = cus.firstName;
                    textBox_lName.Text = cus.lastName;
                    
                }    
                else
                {
                    MessageBox.Show("Customer has not been exist in system");
                    
                }    

           }    
        }


        private void ButtonCalculate_Click(object sender, EventArgs e)
        {

        }

        private void Button_add_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox_phoneCus.Text) || string.IsNullOrEmpty(textBox_fName.Text) || string.IsNullOrEmpty(textBox_lName.Text)
                || string.IsNullOrEmpty(textBox_vehicle.Text) || string.IsNullOrEmpty(TextBox_FeeReparing.Text) || string.IsNullOrEmpty(richTextBox_desBill.Text))
            {
                MessageBox.Show("Please enter all information");
                return;
            }

            using (var context = new DatabaseContext())
            {
                var cus = context.Users.OfType<Customer>().Where(t => t.phone == textBox_phoneCus.Text).FirstOrDefault();
                if(cus==null)
                {
                    IBuilder customerBuilder = new CustomerBuilder();
                    Customer customer = customerBuilder.SetFirstName(textBox_fName.Text).SetLastName(textBox_lName.Text).SetPhone(textBox_phoneCus.Text).SetActive(true).Build();
                    context.Users.Add(customer);
                }
                else
                {
                    cus.lastName = textBox_lName.Text;
                    cus.firstName = textBox_fName.Text;
                }
                try
                {
                    context.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Add or Edit customer failed");
                    return;
                }

            }

            using (var context = new DatabaseContext())
            {
                var fix = context.Users.OfType<FixWorker>().Where(t => t.ID == FixWorkerMainForm.FixID).FirstOrDefault();
                var cus = context.Users.OfType<Customer>().Where(t => t.phone == textBox_phoneCus.Text).FirstOrDefault();
                var bill = new BillFix
                {
                    fixWorkerID = FixWorkerMainForm.FixID,
                    vehicle = textBox_vehicle.Text,
                    customerID = cus.ID,
                    totalBill = float.Parse(TextBox_FeeReparing.Text),
                    facilityID = fix.facilityID,
                    dateCreate = DateTime.Now

                };
                try
                {
                    context.BillFixes.Add(bill);
                    context.SaveChanges();
                    MessageBox.Show("Create repair bill successfully");

                }
                catch
                {
                    MessageBox.Show("Create repair bill fail");

                }
                
            }



        }
    }

        

       
}
