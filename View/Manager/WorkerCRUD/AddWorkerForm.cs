using FinalWindow.Database;
using FinalWindow.Model;
using FinalWindow.Tool;
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
using System.Windows.Media.Animation;

namespace FinalWindow.View.Manager.WorkerCRUD
{
    public partial class AddWorkerForm : Form
    {

        string[] checkUser = { "fuck", "Nigger", "Twat", "Ass" };
        public AddWorkerForm()
        {
            InitializeComponent();
        }
        public static byte[] converterDemo(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }

        private void AddWorkerForm_Load(object sender, EventArgs e)
        {
            using (var context = new DatabaseContext())
            {
                
            }
        }

        //void loadKeepDataGridView()
        //{
        //    try
        //    {
        //        DatabaseContext context1 = DatabaseContext.Instance;
        //        var manager = context1.Users.OfType<Model.Manager>().Where(t => t.ID == ManagerMainForm.ManID).FirstOrDefault();
        //        using (var context = DatabaseContext.Instance)
        //        {
        //            var keeperData = context.Users.OfType<Model.KeepWorker>().Where(t => t.facilityID == manager.facilityID)
        //                .Select(u => new
        //                {
        //                    CardID = u.cardID,
        //                    FisrtName = u.firstName,
        //                    LastName = u.lastName,
        //                    Gender = u.gender,
        //                    Phone = u.phone,
        //                    FacilityID = u.facilityID

        //                })
        //                .ToList();


        //            ManagerMainForm managerMainForm = new ManagerMainForm();
        //            managerMainForm.dataGridView_listKeepWorker.DataSource = keeperData;
        //        }
        //    }
        //    catch (Exception ex)
        //    { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        //}
        //void loadFixDataGridView()
        //{
        //    try
        //    {
        //        DatabaseContext context1 = DatabaseContext.Instance;
        //        var manager = context1.Users.OfType<Model.Manager>().Where(t => t.ID == ManagerMainForm.ManID).FirstOrDefault();
        //        using (var context = DatabaseContext.Instance)
        //        {
        //            var fixerData = context.Users.OfType<Model.FixWorker>().Where(t => t.facilityID == manager.facilityID)
        //                // .Where(u => u.cardID)
        //                .Select(u => new
        //                {
        //                    CardID = u.cardID,
        //                    FisrtName = u.firstName,
        //                    LastName = u.lastName,
        //                    Gender = u.gender,
        //                    Phone = u.phone,
        //                    FacilityID = u.facilityID

        //                })
        //                .ToList();


        //            ManagerMainForm managerMainForm = new ManagerMainForm();
        //            managerMainForm.dataGridView_listFixWorker.DataSource = fixerData;
        //        }
        //    }
        //    catch (Exception ex)
        //    { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        //}

        private void pictureBox_image_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.Filter = "Select Image (*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
                if ((opf.ShowDialog() == DialogResult.OK)) 
                {
                    pictureBox_image.Image = Image.FromFile(opf.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            try
            {

                using (var context = new DatabaseContext())
                {
                    if (string.IsNullOrEmpty(textBox_cardID.Text) ||
                    //string.IsNullOrEmpty(textBox_facilityID.Text) ||
                    string.IsNullOrEmpty(textBox_firstName.Text) ||
                    string.IsNullOrEmpty(textBox_lastName.Text) ||
                    string.IsNullOrEmpty(textBox_phone.Text) ||
                    string.IsNullOrEmpty(textBox_email.Text) ||
                    string.IsNullOrEmpty(textBox_address.Text) ||
                    (comboBox_gender.SelectedItem == null) ||
                    pictureBox_image.Image == null
                    /*(comboBox_facilityID.SelectedItem == null)*/)
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

                    var checkcardIDman = context.Users.OfType<Model.Manager>().Where(t => t.cardID == textBox_cardID.Text).Count();
                    var checkcardIDfix = context.Users.OfType<Model.FixWorker>().Where(t => t.cardID == textBox_cardID.Text).Count();
                    var checkcardIDkeep = context.Users.OfType<Model.KeepWorker>().Where(t => t.cardID == textBox_cardID.Text).Count();
                    var checkusername = context.Users.Where(t => t.username == textBox_username.Text).Count();
                    var checkphone = context.Users.Where(t => t.phone == textBox_phone.Text).Count();
                    var checkemail = context.Users.Where(t => t.email == textBox_email.Text).Count();

                    if (checkusername > 0)
                    {
                        MessageBox.Show("Username has already existed.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (checkphone > 0)
                    {
                        MessageBox.Show("Phone has already existed.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (checkemail > 0)
                    {
                        MessageBox.Show("Email has already existed.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    if (checkcardIDman > 0)
                    {
                        MessageBox.Show("Card ID has already existed.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (checkcardIDfix > 0)
                    {
                        MessageBox.Show("Card ID has already existed.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (checkcardIDkeep > 0)
                    {
                        MessageBox.Show("Card ID has already existed.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (pictureBox_image == null)
                    {
                        MessageBox.Show("Please choose picture");
                        return;
                    }

                    

                    if (comboBox_typeWorker.SelectedIndex == 0)
                    {
                        var baseSalary = context.BaseSalaries.Where(t => t.typeWorker == "FixWorker").FirstOrDefault();
                        var manager = context.Users.OfType<Model.Manager>().Where(t => t.ID == ManagerMainForm.ManID).FirstOrDefault();
                        var fixWorker = new Model.FixWorker
                        {
                            cardID = textBox_cardID.Text,
                            facilityID = manager.facilityID,
                            username = textBox_username.Text,
                            password = textBox_password.Text,
                            firstName = textBox_firstName.Text,
                            lastName = textBox_lastName.Text,
                            gender = comboBox_gender.SelectedItem.ToString(),
                            phone = textBox_phone.Text,
                            email = textBox_email.Text,
                            address = textBox_address.Text,
                            birthday = birthday_picker.Value.Date,
                            picture = converterDemo(pictureBox_image.Image),
                            coefficients = 1,
                            baseSalary = baseSalary.baseSalary,
                            active = true


                        };
                           
                        try
                        {
                            context.Users.Add(fixWorker);
                            context.SaveChanges();

                            MessageBox.Show("Add successfully.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.InnerException.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else if (comboBox_typeWorker.SelectedIndex == 1)
                    {
                        var baseSalary = context.BaseSalaries.Where(t => t.typeWorker == "KeepWorker").FirstOrDefault();
                        var manager = context.Users.OfType<Model.Manager>().Where(t => t.ID == ManagerMainForm.ManID).FirstOrDefault();
                        var keepWorker = new Model.KeepWorker
                        {
                            cardID = textBox_cardID.Text,
                            facilityID = manager.facilityID,
                            username = textBox_username.Text,
                            password = textBox_password.Text,
                            firstName = textBox_firstName.Text,
                            lastName = textBox_lastName.Text,
                            gender = comboBox_gender.SelectedItem.ToString(),
                            phone = textBox_phone.Text,
                            email = textBox_email.Text,
                            address = textBox_address.Text,
                            birthday = birthday_picker.Value.Date,
                            picture = converterDemo(pictureBox_image.Image),
                            coefficients = 1,
                            baseSalary = baseSalary.baseSalary,
                            active = true

                        };
                       
                        try
                        {
                            context.Users.Add(keepWorker);
                            context.SaveChanges();

                            MessageBox.Show("Add successfully.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.InnerException.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else
                    {
                        MessageBox.Show("Please choose type of worker to add", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
               
            }
            catch (Exception ex)
            { MessageBox.Show(ex.InnerException.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
