using FinalWindow.Database;
using FinalWindow.Tool;
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

namespace FinalWindow.View.FixWorker
{
    public partial class FixWorkerEditInformationForm : Form
    {
        public FixWorkerEditInformationForm()
        {
            InitializeComponent();
        }
        string[] checkUser = { "fuck", "Nigger", "Twat", "Ass" };
        public string temp = null;
        public static byte[] converterDemo(System.Drawing.Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }
        private void button_edit_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    if (//string.IsNullOrEmpty(textBox_facilityID.Text) ||
                    string.IsNullOrEmpty(textBox_firstName.Text) ||
                    string.IsNullOrEmpty(textBox_lastName.Text) ||
                    string.IsNullOrEmpty(textBox_phone.Text) ||
                    string.IsNullOrEmpty(textBox_email.Text) ||
                    string.IsNullOrEmpty(textBox_address.Text) ||
                    (comboBox_gender.SelectedItem == null))
                    {
                        MessageBox.Show("Please enter all information");
                        return;
                    }

                    if (CheckInput.checkAlphabeticCharacters(textBox_firstName.Text) == false)
                    {

                        MessageBox.Show("Your first name has invalid characters");
                        return;
                    }
                    else
                    {
                        for (int i = 0; i < checkUser.Length; i++)
                        {
                            if (String.Compare(textBox_firstName.Text, checkUser[i], true) == 0)
                            {
                                MessageBox.Show("First name is a sensetive word");
                                textBox_firstName.Text = "";
                                return;
                            }

                        }
                    }
                    if (CheckInput.checkAlphabeticCharacters(textBox_lastName.Text) == false)
                    {

                        MessageBox.Show("Your last name has invalid characters");
                        return;
                    }
                    else
                    {
                        for (int i = 0; i < checkUser.Length; i++)
                        {
                            if (String.Compare(textBox_lastName.Text, checkUser[i], true) == 0)
                            {
                                MessageBox.Show("Last name is a sensetive word");
                                textBox_lastName.Text = "";
                                return;
                            }

                        }
                    }

                    if (CheckInput.checkEmailIsValid(textBox_email.Text) == false)
                    {
                        MessageBox.Show("Email is invalid");
                        return;
                    }

                    if (CheckInput.IsPhoneNbr(textBox_phone.Text) == false)
                    {
                        MessageBox.Show("Phone number is invalid");
                        return;
                    }

                    //if (CheckInput.CheckYear(birthday_picker.Text) == false)
                    //{
                    //    MessageBox.Show("Student is invalid age");
                    //    return;
                    //}

                    if (pictureBox_image == null)
                    {
                        MessageBox.Show("Please choose picture");
                        return;
                    }

                    try
                    {

                        Model.FixWorker fix = context.Users.OfType<Model.FixWorker>().Where(u => u.ID == FixWorkerMainForm.FixID).FirstOrDefault();

                        if (fix == null)
                        {

                            MessageBox.Show("Don't exist this manager");

                        }
                        else
                        {
                            fix.firstName = textBox_firstName.Text;
                            fix.lastName = textBox_lastName.Text;
                            fix.gender = comboBox_gender.SelectedItem.ToString();
                            fix.email = textBox_email.Text;
                            fix.phone = textBox_phone.Text;
                            fix.address = textBox_address.Text;
                            fix.birthday = birthday_picker.Value;
                            if (pictureBox_image != null) { fix.picture = converterDemo(pictureBox_image.Image); }



                            context.SaveChanges();
                            MessageBox.Show("Update successfully !!!");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Cannot update !!");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Update fail");
            }
        }

        private void FixWorkerEditInformationForm_Load(object sender, EventArgs e)
        {
            loadProfile();
        }
        void loadProfile()
        {
            using (var context = new DatabaseContext())
            {
                var fix = context.Users.OfType<Model.FixWorker>().Where(t => t.ID == FixWorkerMainForm.FixID).FirstOrDefault();
                if (fix == null) { return; }
                if (fix.picture != null)
                {
                    byte[] imageData = (byte[])fix.picture;
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        pictureBox_image.Image = System.Drawing.Image.FromStream(ms);
                    }
                }
                label_username.Text = fix.username;
            }
        }

        private void pictureBox_image_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.Filter = "Select Image (*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
                if ((opf.ShowDialog() == DialogResult.OK))
                {
                    pictureBox_image.Image = System.Drawing.Image.FromFile(opf.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
