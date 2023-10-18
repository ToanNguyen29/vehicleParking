using FinalWindow.Database;
using FinalWindow.Model;
using FinalWindow.View.Director.List;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using Manager = FinalWindow.Model.Manager;
namespace FinalWindow.View.Director
{
    public partial class UpdateManagerForm : Form
    {
        private int id = -1;

        public int Id { get => id; set => id = value; }

        public UpdateManagerForm()
        {
            InitializeComponent();
        }
        public static byte[] converterDemo(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }
        private void button_selectManager_Click(object sender, EventArgs e)
        {
            ListManagerForm listManagerForm = new ListManagerForm();
            listManagerForm.Show();
            this.Hide();
        }

        private void UpdateManagerForm_Load(object sender, EventArgs e)
        {
            using (var context = new DatabaseContext())
            {
                comboBox_facilityID.DataSource = context.Facilities.ToList();
                comboBox_facilityID.DisplayMember = "address";
                comboBox_facilityID.ValueMember = "ID";
                comboBox_facilityID.SelectedItem = 1;
            }
            
        }

        private void button_update_Click(object sender, EventArgs e)
        {

            if(id==-1)
            {
                MessageBox.Show("Please select manager to update");
                return;
            }
            if (string.IsNullOrEmpty(textBox_cardID.Text) ||
                    //string.IsNullOrEmpty(textBox_facilityID.Text) ||
                    string.IsNullOrEmpty(textBox_firstName.Text) ||
                    string.IsNullOrEmpty(textBox_lastName.Text) ||
                    string.IsNullOrEmpty(textBox_phone.Text) ||
                    string.IsNullOrEmpty(textBox_email.Text) ||
                    string.IsNullOrEmpty(textBox_address.Text) ||
                    pictureBox_image.Image == null)
            {
                MessageBox.Show("Please enter all information");
                return;
            }

            try
            {
                using (var context = new DatabaseContext())
                {

                    try
                    {

                        var checkcardIDman = context.Users.OfType<Model.Manager>().Where(t => t.cardID == textBox_cardID.Text && t.ID != id).Count();
                        if (checkcardIDman > 0)
                        {
                            MessageBox.Show("CardID has already existed");
                            return;
                        }
                        var checkcardIDfix = context.Users.OfType<Model.FixWorker>().Where(t => t.cardID == textBox_cardID.Text).Count();
                        if (checkcardIDfix > 0)
                        {
                            MessageBox.Show("CardID has already existed");
                            return;
                        }
                        var checkcardIDkeep = context.Users.OfType<Model.KeepWorker>().Where(t => t.cardID == textBox_cardID.Text).Count();
                        if (checkcardIDkeep > 0)
                        {
                            MessageBox.Show("CardID has already existed");
                            return;
                        }
                        var checkusername = context.Users.Where(t => t.username == textBox_username.Text).Count();
                        if (checkusername > 0)
                        {
                            MessageBox.Show("UserName has already existed");
                            return;
                        }
                        Model.Manager manager = context.Users.OfType<Model.Manager>().Where(u => u.ID == id).FirstOrDefault();
                        var checkphone = context.Users.Where(t => t.phone == textBox_phone.Text);
                        if (checkphone.FirstOrDefault() != manager)
                        {
                            if (checkphone.Count() > 0)
                            {
                                MessageBox.Show("Phone number has already existed");
                                return;
                            }
                        }
                        var checkemail = context.Users.Where(t => t.email == textBox_email.Text);
                        if (checkemail.FirstOrDefault() != manager)
                        {
                            if (checkphone.Count() > 0)
                            {
                                MessageBox.Show("Email has already existed");
                                return;
                            }
                        }

                        if (manager == null)
                        {

                            MessageBox.Show("Don't exist this manager");

                        }
                        else
                        {
                            manager.cardID = textBox_cardID.Text;
                            manager.username = textBox_username.Text;
                            manager.password = textBox_password.Text;
                            manager.picture = UpdateManagerForm.converterDemo(pictureBox_image.Image);
                            manager.facilityID = (int?)comboBox_facilityID.SelectedValue;
                            manager.firstName = textBox_firstName.Text;
                            manager.lastName = textBox_lastName.Text;
                            manager.gender = comboBox_gender.SelectedItem.ToString();
                            manager.birthday = birthday_picker.Value;
                            manager.phone = textBox_phone.Text;
                            manager.email = textBox_email.Text;
                            manager.address = textBox_address.Text;
                           

                            if (checkBox_status.Checked)
                            {
                                manager.active = true;
                            }
                            else
                            {
                                manager.active = false;
                            }

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

       
    }
}
