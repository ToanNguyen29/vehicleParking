using FinalWindow.Database;
using FinalWindow.View.Manager.WorkerCRUD;
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

namespace FinalWindow.View.Manager.ListWorker
{
    public partial class ListKeepWorkerForm : Form
    {
        public ListKeepWorkerForm()
        {
            InitializeComponent();
        }

        private void ListKeepWorkerForm_Load(object sender, EventArgs e)
        {
            loadData();
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            picCol = (DataGridViewImageColumn)dataGridView_listKeepWorker.Columns[10];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        void loadData()
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    var manager = context.Users.OfType<Model.Manager>().Where(t => t.ID == ManagerMainForm.ManID).FirstOrDefault();
                    var keeperData = context.Users
                        .OfType<Model.KeepWorker>().Where(t=>t.facilityID == manager.facilityID)
                        .Select(u => new
                        {
                            Username = u.username,
                            Password = u.password,
                            FisrtName = u.firstName,
                            LastName = u.lastName,
                            Gender = u.gender,
                            Phone = u.phone,
                            Email = u.email,
                            Birthday = u.birthday,
                            CardID = u.cardID,
                            Address = u.address,
                            Picture = u.picture,
                            CoE = u.coefficients,
                            
                            Status = u.active.ToString()
                        })
                        .ToList();


                    dataGridView_listKeepWorker.DataSource = keeperData;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void dataGridView_listKeepWorker_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateWorkerForm updateWorkerForm = new UpdateWorkerForm();

                updateWorkerForm.textBox_username.Text = dataGridView_listKeepWorker.CurrentRow.Cells[0].Value.ToString();
                updateWorkerForm.textBox_password.Text = dataGridView_listKeepWorker.CurrentRow.Cells[1].Value.ToString();
                updateWorkerForm.textBox_firstName.Text = dataGridView_listKeepWorker.CurrentRow.Cells[2].Value.ToString();
                updateWorkerForm.textBox_lastName.Text = dataGridView_listKeepWorker.CurrentRow.Cells[3].Value.ToString();
                updateWorkerForm.comboBox_gender.SelectedItem = dataGridView_listKeepWorker.CurrentRow.Cells[4].Value;
                updateWorkerForm.textBox_phone.Text = dataGridView_listKeepWorker.CurrentRow.Cells[5].Value.ToString();
                updateWorkerForm.textBox_email.Text = dataGridView_listKeepWorker.CurrentRow.Cells[6].Value.ToString();
                updateWorkerForm.birthday_picker.Value = (DateTime)dataGridView_listKeepWorker.CurrentRow.Cells[7].Value;
                updateWorkerForm.textBox_cardID.Text = dataGridView_listKeepWorker.CurrentRow.Cells[8].Value.ToString();
                updateWorkerForm.textBox_address.Text = dataGridView_listKeepWorker.CurrentRow.Cells[9].Value.ToString();

                byte[] imageData = (byte[])dataGridView_listKeepWorker.CurrentRow.Cells[10].Value;
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    updateWorkerForm.pictureBox_image.Image = Image.FromStream(ms);
                }
                updateWorkerForm.textBox_CoE.Text = dataGridView_listKeepWorker.CurrentRow.Cells[11].Value.ToString();
                
                if (dataGridView_listKeepWorker.CurrentRow.Cells[13].Value.ToString() == "True")
                {
                    updateWorkerForm.checkBox_status.Checked = true;
                }
                else
                {
                    updateWorkerForm.checkBox_status.Checked = false;
                }
                updateWorkerForm.comboBox_typeWorker.SelectedIndex = 1;

                updateWorkerForm.Show();
            }
            catch (Exception ex)
            { System.Windows.Forms.MessageBox.Show(ex.InnerException.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
