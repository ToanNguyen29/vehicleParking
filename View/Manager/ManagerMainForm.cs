using FinalWindow.Database;
using FinalWindow.Model;
using FinalWindow.View.Customer;
using FinalWindow.View.Director.List;
using FinalWindow.View.Manager;
using FinalWindow.View.Manager.ShiftCRUD;
using FinalWindow.View.Manager.WorkerCRUD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalWindow
{
    public partial class ManagerMainForm : Form
    {
        private static int manID =0;

        public static int ManID { get => manID; set => manID = value; }

        public ManagerMainForm()
        {
            InitializeComponent();
        }

        void loadKeepDataGridView()
        {

            using (var context = new DatabaseContext())
            {
                var manager = context.Users.OfType<Model.Manager>().Where(t => t.ID == ManagerMainForm.ManID).FirstOrDefault();
                var keeperData = context.Users.OfType<KeepWorker>().Where(t => t.facilityID == manager.facilityID && t.active == true)
                    .Select(u => new
                    {
                        CardID = u.cardID,
                        FisrtName = u.firstName,
                        LastName = u.lastName,
                        Gender = u.gender,
                        Phone = u.phone,
                        FacilityID = u.facilityID

                    })
                    .ToList();


                dataGridView_listKeepWorker.DataSource = keeperData;
            }
            
        }
        void loadFixDataGridView()
        {

            using (var context = new DatabaseContext())
            {
                var manager = context.Users.OfType<Model.Manager>().Where(t => t.ID == ManagerMainForm.ManID).FirstOrDefault();

                var fixerData = context.Users.OfType<FixWorker>().Where(t => t.facilityID == manager.facilityID && t.active == true)
                    // .Where(u => u.cardID)
                    .Select(u => new
                    {
                        CardID = u.cardID,
                        FisrtName = u.firstName,
                        LastName = u.lastName,
                        Gender = u.gender,
                        Phone = u.phone,
                        FacilityID = u.facilityID

                    })
                    .ToList();



                dataGridView_listFixWorker.DataSource = fixerData;
            }
                
        }

        private void button_resetFix_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    var manager = context.Users.OfType<Model.Manager>().Where(t => t.ID == ManagerMainForm.ManID).FirstOrDefault();
                
                    var fixerData = context.Users.OfType<FixWorker>().Where(t => t.facilityID == manager.facilityID)
                        // .Where(u => u.cardID)
                        .Select(u => new
                        {
                            CardID = u.cardID,
                            FisrtName = u.firstName,
                            LastName = u.lastName,
                            Gender = u.gender,
                            Phone = u.phone,
                            FacilityID = u.facilityID

                        })
                        .ToList();



                    dataGridView_listFixWorker.DataSource = fixerData;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button_addFixWorker_Click(object sender, EventArgs e)
        {
            AddWorkerForm addWorkerForm = new AddWorkerForm();
            addWorkerForm.Show();
            addWorkerForm.comboBox_typeWorker.SelectedIndex = 0;
        }

        private void button_addKeepWorker_Click(object sender, EventArgs e)
        {
            AddWorkerForm addWorkerForm = new AddWorkerForm();
            addWorkerForm.Show();
            addWorkerForm.comboBox_typeWorker.SelectedIndex = 1;
        }

        private void button_resetKeep_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    var manager = context.Users.OfType<Model.Manager>().Where(t => t.ID == ManagerMainForm.ManID).FirstOrDefault();
                
                    var keeperData = context.Users.OfType<KeepWorker>().Where(t => t.facilityID == manager.facilityID)
                        .Select(u => new
                        {
                            CardID = u.cardID,
                            FisrtName = u.firstName,
                            LastName = u.lastName,
                            Gender = u.gender,
                            Phone = u.phone,
                            FacilityID = u.facilityID

                        })
                        .ToList();

                    dataGridView_listKeepWorker.DataSource = keeperData;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button_updateFixWorker_Click(object sender, EventArgs e)
        {
            UpdateWorkerForm updateWorkerForm = new UpdateWorkerForm();
            updateWorkerForm.Show();
        }

        private void ManagerMainForm_Load(object sender, EventArgs e)
        {
            loadProfile();
            loadFixDataGridView();
            loadKeepDataGridView();
            
        }

        void loadProfile()
        {

            using (var context = new DatabaseContext())
            {
                var manager = context.Users.OfType<Manager>().Where(t => t.ID == manID).FirstOrDefault();
                if (manager.picture != null)
                {
                    byte[] imageData = (byte[])manager.picture;
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        pictureBox_managerImage.Image = Image.FromStream(ms);
                    }
                }
                label_username.Text = manager.username;
                label_firstName.Text = manager.firstName;
                label_lastName.Text = manager.lastName;
                label_gender.Text = manager.gender;
                if (manager.birthday.HasValue)
                {
                    label_birthDate.Text = manager.birthday.Value.ToString("dd/MM/yyyy");
                }
                else
                {
                    label_birthDate.Text = "Unknown";
                }
                label_email.Text = manager.email;
                label_phone.Text = manager.phone;
                label_address.Text = manager.address;
            }

        }

        private void button_updateKeepWorker_Click(object sender, EventArgs e)
        {
            UpdateWorkerForm updateWorkerForm = new UpdateWorkerForm();
            updateWorkerForm.Show();
        }

       
        private void button_shiftWork_Click(object sender, EventArgs e)
        {
            ShiftWorkForm shiftWorkForm = new ShiftWorkForm();
            shiftWorkForm.Show();
        }

        

        private void button_shiftKeep_Click(object sender, EventArgs e)
        {
            ShiftWorkForm shiftWorkForm = new ShiftWorkForm();
            shiftWorkForm.Show();
        }

        private void button_shiftFix_Click(object sender, EventArgs e)
        {
            ShiftWorkForm shiftWorkForm = new ShiftWorkForm();
            shiftWorkForm.Show();
        }

        private void button_editInformation_Click(object sender, EventArgs e)
        {
            ManagerEditInformationForm editInformationForm = new ManagerEditInformationForm();
            editInformationForm.Show();
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            loadProfile();
        }

        private void button_payRollfix_Click(object sender, EventArgs e)
        {
            AttendanceWorkerForm payRollWorkerForm = new AttendanceWorkerForm();
            payRollWorkerForm.Show();
        }

        private void button_payrollkeep_Click(object sender, EventArgs e)
        {
            AttendanceWorkerForm payRollWorkerForm = new AttendanceWorkerForm();
            payRollWorkerForm.Show();
        }

        private void button_listLong_Click(object sender, EventArgs e)
        {
            using (var context = new DatabaseContext())
            {
                var manFacilityID = context.Users.OfType<Model.Manager>().Where(t => t.ID == ManagerMainForm.ManID).FirstOrDefault();
                ListLongContractForm listLongContractForm = new ListLongContractForm();
                listLongContractForm.FacilityID = (int)manFacilityID.facilityID;
                listLongContractForm.Show();
            }
        }

        private void button_listLoan_Click(object sender, EventArgs e)
        {
            using (var context = new DatabaseContext())
            {
                var manFacilityID = context.Users.OfType<Model.Manager>().Where(t => t.ID == ManagerMainForm.ManID).FirstOrDefault();
                ListLoanContractForm listLoanContractForm = new ListLoanContractForm();
                listLoanContractForm.FacilityID = (int)manFacilityID.facilityID;
                listLoanContractForm.Show();
            }
        }

        private void button_attendance_Click(object sender, EventArgs e)
        {
            AttendanceWorkerForm atten = new AttendanceWorkerForm();
            atten.Show();
        }

        private void button_payroll_Click(object sender, EventArgs e)
        {
            PayrollWokerForm pay = new PayrollWokerForm();
            pay.Show();
        }
    }
}
