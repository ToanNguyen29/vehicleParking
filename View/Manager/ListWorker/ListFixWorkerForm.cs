using FinalWindow.Database;
using FinalWindow.View.Director;
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
    public partial class ListFixWorkerForm : Form
    {
        public ListFixWorkerForm()
        {
            InitializeComponent();
        }

        private void ListFixWorkerForm_Load(object sender, EventArgs e)
        {
            loadData();
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            picCol = (DataGridViewImageColumn)dataGridView_listFixWorker.Columns[10];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        void loadData()
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    var manager = context.Users.OfType<Model.Manager>().Where(t => t.ID == ManagerMainForm.ManID).FirstOrDefault();
                    var fixerData = context.Users
                        .OfType<Model.FixWorker>().Where(t=>t.facilityID == manager.facilityID)
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


                    dataGridView_listFixWorker.DataSource = fixerData;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void dataGridView_listFixWorker_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateWorkerForm updateWorkerForm = new UpdateWorkerForm();

                updateWorkerForm.textBox_username.Text = dataGridView_listFixWorker.CurrentRow.Cells[0].Value.ToString();
                updateWorkerForm.textBox_password.Text = dataGridView_listFixWorker.CurrentRow.Cells[1].Value.ToString();
                updateWorkerForm.textBox_firstName.Text = dataGridView_listFixWorker.CurrentRow.Cells[2].Value.ToString();
                updateWorkerForm.textBox_lastName.Text = dataGridView_listFixWorker.CurrentRow.Cells[3].Value.ToString();
                updateWorkerForm.comboBox_gender.SelectedItem = dataGridView_listFixWorker.CurrentRow.Cells[4].Value;
                updateWorkerForm.textBox_phone.Text = dataGridView_listFixWorker.CurrentRow.Cells[5].Value.ToString();
                updateWorkerForm.textBox_email.Text = dataGridView_listFixWorker.CurrentRow.Cells[6].Value.ToString();
                updateWorkerForm.birthday_picker.Value = (DateTime)dataGridView_listFixWorker.CurrentRow.Cells[7].Value;
                updateWorkerForm.textBox_cardID.Text = dataGridView_listFixWorker.CurrentRow.Cells[8].Value.ToString();
                updateWorkerForm.textBox_address.Text = dataGridView_listFixWorker.CurrentRow.Cells[9].Value.ToString();

                byte[] imageData = (byte[])dataGridView_listFixWorker.CurrentRow.Cells[10].Value;
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    updateWorkerForm.pictureBox_image.Image = Image.FromStream(ms);
                }
                updateWorkerForm.textBox_CoE.Text = dataGridView_listFixWorker.CurrentRow.Cells[11].Value.ToString();
                
                if (dataGridView_listFixWorker.CurrentRow.Cells[13].Value.ToString() == "True")
                {
                    updateWorkerForm.checkBox_status.Checked = true;
                }
                else
                {
                    updateWorkerForm.checkBox_status.Checked = false;
                }
                updateWorkerForm.comboBox_typeWorker.SelectedIndex = 0;

                updateWorkerForm.Show();
                this.Close();
            }
            catch (Exception ex)
            { System.Windows.Forms.MessageBox.Show(ex.InnerException.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
