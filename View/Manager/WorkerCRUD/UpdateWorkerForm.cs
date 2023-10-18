using FinalWindow.Database;
using FinalWindow.Model;
using FinalWindow.View.Director;
using FinalWindow.View.Manager.ListWorker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalWindow.View.Manager.WorkerCRUD
{
    public partial class UpdateWorkerForm : Form
    {
        string temp = null;
        public UpdateWorkerForm()
        {
            InitializeComponent();
        }

        private void button_selectManager_Click(object sender, EventArgs e)
        {
            if(comboBox_typeWorker.SelectedIndex == 0)
            {
                ListFixWorkerForm listFixWorkerForm = new ListFixWorkerForm();
                listFixWorkerForm.Show();
                this.Hide();
            }
            else if(comboBox_typeWorker.SelectedIndex == 1)
            {
                ListKeepWorkerForm listKeepWorkerForm = new ListKeepWorkerForm();
                listKeepWorkerForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please choose type of worker to add", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void button_update_Click(object sender, EventArgs e)
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

            try
            {
                using (var context = new DatabaseContext())
                {

                    if (comboBox_typeWorker.SelectedIndex == 0)
                    {
                        try
                        {

                            Model.FixWorker fixer = context.Users.OfType<Model.FixWorker>().Where(u => u.cardID == textBox_cardID.Text).FirstOrDefault();

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


                            if (fixer == null)
                            {
                                textBox_cardID.Text = temp;

                                MessageBox.Show("Don't exist this worker");

                            }

                            else
                            {

                                fixer.username = textBox_username.Text;
                                fixer.password = textBox_password.Text;
                                fixer.picture = UpdateManagerForm.converterDemo(pictureBox_image.Image);
                                fixer.firstName = textBox_firstName.Text;
                                fixer.lastName = textBox_lastName.Text;
                                fixer.gender = comboBox_gender.SelectedItem.ToString();
                                fixer.birthday = birthday_picker.Value;
                                fixer.phone = textBox_phone.Text;
                                fixer.email = textBox_email.Text;
                                fixer.address = textBox_address.Text;
                                fixer.coefficients = float.Parse(textBox_CoE.Text);

                                if (checkBox_status.Checked)
                                {
                                    fixer.active = true;
                                }
                                else
                                {
                                    fixer.active = false;
                                }

                                context.SaveChanges();
                                MessageBox.Show("Update successfully !!!");
                            }


                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    else if (comboBox_typeWorker.SelectedIndex == 1)
                    {
                        try
                        {
                            Model.KeepWorker keeper = context.Users.OfType<Model.KeepWorker>().Where(u => u.cardID == textBox_cardID.Text).FirstOrDefault();
                            var checkcardIDman = context.Users.OfType<Model.Manager>().Where(t => t.cardID == textBox_cardID.Text).Count();
                            var checkcardIDfix = context.Users.OfType<Model.FixWorker>().Where(t => t.cardID == textBox_cardID.Text).Count();
                            var checkcardIDkeep = context.Users.OfType<Model.KeepWorker>().Where(t => t.cardID == textBox_cardID.Text).Count();

                            if (checkcardIDman > 0)
                            {
                                MessageBox.Show("Card ID already exist.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            if (checkcardIDfix > 0)
                            {
                                MessageBox.Show("Card ID already exist.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            if (checkcardIDkeep > 0)
                            {
                                MessageBox.Show("Card ID already exist.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }


                            if (keeper == null)
                            {
                                textBox_cardID.Text = temp;


                                MessageBox.Show("Don't exist this worker");

                            }
                            else
                            {

                                keeper.username = textBox_username.Text;
                                keeper.password = textBox_password.Text;
                                keeper.picture = UpdateManagerForm.converterDemo(pictureBox_image.Image);
                                
                                keeper.firstName = textBox_firstName.Text;
                                keeper.lastName = textBox_lastName.Text;
                                keeper.gender = comboBox_gender.SelectedItem.ToString();
                                keeper.birthday = birthday_picker.Value;
                                keeper.phone = textBox_phone.Text;
                                keeper.email = textBox_email.Text;
                                keeper.address = textBox_address.Text;
                                keeper.coefficients = float.Parse(textBox_CoE.Text);

                                if (checkBox_status.Checked)
                                {
                                    keeper.active = true;
                                }
                                else
                                {
                                    keeper.active = false;
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
            }   
            catch
            {
                MessageBox.Show("Update fail");
            }
        }

        private void UpdateWorkerForm_Load(object sender, EventArgs e)
        {
            using (var context = new DatabaseContext())
            {
                
            }
        }
    }
}
