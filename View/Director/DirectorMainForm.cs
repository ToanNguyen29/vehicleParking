using FinalWindow.Database;
using FinalWindow.Model;
using FinalWindow.Tool;
using FinalWindow.View.Customer;
using FinalWindow.View.Director;
using FinalWindow.View.Director.FacilityCRUD;
using FinalWindow.View.Director.List;
using FinalWindow.View.Manager.ShiftCRUD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace FinalWindow
{
    public partial class DirectorMainForm : System.Windows.Forms.Form
    {
        private static int dirID;

        public static int DirID { get => dirID; set => dirID = value; }

        public DirectorMainForm()
        {
            InitializeComponent();
        }

        

       

        private void button_resetData_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    var managerData = context.Users.OfType<Manager>().Where(t=>t.active == true)
                       // .Where(u => u.cardID)
                        .Select(u => new
                        {
                            CardID = u.cardID,
                            FisrtName = u.firstName,
                            LastName = u.lastName,
                            Gender = u.gender,
                            Phone = u.phone,
                            Birthday = u.birthday

                            

                        })
                        .ToList();



                    dataGridView_listManager.DataSource = managerData;
                }
            } catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            
        }

       

        void loadProfile()
        {
            try
            {

                using (var context = new DatabaseContext())
                {
                    var director = context.Users.OfType<Director>().Where(t => t.ID == dirID).FirstOrDefault();
                    if (director.picture != null)
                    {
                        byte[] imageData = (byte[])director.picture;
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            pictureBox_directorImage.Image = System.Drawing.Image.FromStream(ms);
                        }
                    }
                    label_username.Text = director.username;
                    label_firstName.Text = director.firstName;
                    label_lastName.Text = director.lastName;
                    if (director.gender == null)
                    {
                        return;
                    }
                    else
                    {
                        label_gender.Text = director.gender;
                    }

                    if (director.birthday == null)
                    {
                        return;
                    }
                    else
                    {
                        label_birthDate.Text = director.birthday.Value.Date.ToString("dd/MM/yyyy");
                    }
                    label_email.Text = director.email;
                    label_phone.Text = director.phone;
                    label_address.Text = director.address;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void loadContract()
        {
            using (var context = new DatabaseContext())
            {
                var rule = context.Rules.Where(t => t.nameContract == "LongTermContract").FirstOrDefault();
                textBox_ruleLong.Text = rule.description;
                var rule2 = context.Rules.Where(t => t.nameContract == "LoanContract").FirstOrDefault();
                textBox_ruleLoan.Text = rule2.description;

                comboBox_facilityLong.DataSource = context.Facilities.ToList();
                comboBox_facilityLong.DisplayMember = "address";
                comboBox_facilityLong.ValueMember = "ID";

                comboBox_facilityLong.SelectedIndex = -1;

                comboBox_facilityLoan.DataSource = context.Facilities.ToList();
                comboBox_facilityLoan.DisplayMember = "address";
                comboBox_facilityLoan.ValueMember = "ID";

                comboBox_facilityLoan.SelectedIndex = -1;
            }

        }

        private void loadCus()
        {
            using (var context = new DatabaseContext())
            {
                var cus = context.Users.OfType<Customer>().Select(u => new
                {
                    FisrtName = u.firstName,
                    LastName = u.lastName,
                    
                    Phone = u.phone,
                    Email = u.email,
                    Address =u.address

                }).ToList();

                dataGridview_listCustomer.DataSource = cus;

            }
        }

        private void DirectorMainForm_Load(object sender, EventArgs e)
        {
            
            loadProfile();
            loadCus();
            loadContract();
            
            /*// Get a reference to the initially selected tab page
            //TabPage selectedTabPage = tabPage_managerManagement;

            //// Check if the initially selected tab page contains a DataGridView
            //foreach (System.Windows.Forms.Control control in selectedTabPage.Controls)
            //{
            //    if (control is DataGridView dataGridView)
            //    {
            //        // Load the data source for the DataGridView

            //        using (var context = new DatabaseContext())
            //        {
            //            var managerData = context.Users
            //                .Where(u => u is Manager)
            //                .Select(u => new
            //                {
            //                    FisrtName = u.firstName,
            //                    LastName = u.lastName,
            //                    Gender = u.gender,
            //                    Phone = u.phone,
            //                    Birthday = u.birthday

            //                })
            //                .ToList();



            //            dataGridView_listManager.DataSource = managerData;
            //            break;
            //        }
            //    }
            //}


            //if(selectedTabPage == tabPage_facilityManagement)
            //{
            //    foreach (System.Windows.Forms.Control control in selectedTabPage.Controls)
            //    {
            //        if (control is DataGridView dataGridView)
            //        {
            //            // Load the data source for the DataGridView

            //            using (var context = new DatabaseContext())
            //            {
            //                var facilityData = context.Facilities
            //                    .Select(f => new
            //                    {
            //                        Address = f.address,
            //                        QuantityFix = f.quatityFix,
            //                        QuantityKeep = f.quantityKeep

            //                    })
            //                    .ToList();



            //                dataGridView_listFacility.DataSource = facilityData;
            //            }
            //        }
            //    }
            //}*/
        }

        private void button_resetFacility_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    var facilityData = context.Facilities
                        .Select(f => new
                        {
                            Address = f.address,
                            QuantityFix = f.quatityFix,
                            QuantityKeep = f.quantityKeep

                        })
                        .ToList();



                    dataGridView_listFacility.DataSource = facilityData;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button_addFacility_Click(object sender, EventArgs e)
        {
            AddFacilityForm addFacilityForm = new AddFacilityForm();
            addFacilityForm.Show();
        }

        private void button_addManager_Click(object sender, EventArgs e)
        {
            AddManagerForm addManagerForm = new AddManagerForm();
            addManagerForm.Show();
        }

        private void button_editManager_Click(object sender, EventArgs e)
        {
            UpdateManagerForm updateManagerForm = new UpdateManagerForm();
            updateManagerForm.Show();
        }

        private void button_updateFacility_Click(object sender, EventArgs e)
        {
            UpdateFacilityForm updateFacilityForm = new UpdateFacilityForm();
            updateFacilityForm.Show();
        }

        

        private void button_resetListShift_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    var shiftData = context.Shifts
                        // .Where(u => u.cardID)
                        .Select(u => new
                        {
                            StartTime = u.startTime,
                            EndTime = u.endTime,
                            QuantityFix = u.quantityFix,
                            QuantityKeep = u.quantityKeep


                        })
                        .ToList();



                    dataGridView_listShift.DataSource = shiftData;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button_addShift_Click(object sender, EventArgs e)
        {
            AddShiftForm addShiftForm = new AddShiftForm();
            addShiftForm.Show();
        }

        
        private void dataGridView_listShift_Click(object sender, EventArgs e)
        {
            UpdateShiftForm updateShiftForm = new UpdateShiftForm();
            object cellValue = dataGridView_listShift.CurrentRow.Cells[0].Value;
            if (cellValue is TimeSpan)
            {
                TimeSpan timeSpanValue = (TimeSpan)cellValue;
                DateTime currentDate = DateTime.Now.Date;
                updateShiftForm.dateTimePicker_From.Value = currentDate.Add(timeSpanValue);
            }
            else if (cellValue is DateTime)
            {
                updateShiftForm.dateTimePicker_From.Value = (DateTime)cellValue;
            }

            cellValue = dataGridView_listShift.CurrentRow.Cells[1].Value;
            if (cellValue is TimeSpan)
            {
                TimeSpan timeSpanValue = (TimeSpan)cellValue;
                DateTime currentDate = DateTime.Now.Date;
                updateShiftForm.dateTimePicker_To.Value = currentDate.Add(timeSpanValue);
            }
            else if (cellValue is DateTime)
            {
                updateShiftForm.dateTimePicker_To.Value = (DateTime)cellValue;
            }
            updateShiftForm.Show();
        }

        private void button_editInformation_Click(object sender, EventArgs e)
        {
            DirectorEditInformationForm editInformationForm = new DirectorEditInformationForm();
            editInformationForm.Show();
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            loadProfile();
        }


        private void button_Update_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(comboBox_role.Text) || string.IsNullOrEmpty(textBox_baseSalary.Text))
            {
                MessageBox.Show("Please enter all information");
                return;
            }    
            using(var context = new DatabaseContext())
            {
                
                var baseSalary = context.BaseSalaries.Where(t => t.typeWorker == comboBox_role.Text).FirstOrDefault();
                baseSalary.baseSalary = float.Parse(textBox_baseSalary.Text);
                context.SaveChanges();
                 
            }    
        }


        private void button_selectLong_Click(object sender, EventArgs e)
        {
            using (var context = new DatabaseContext())
            {
                var contract1 = context.Contracts.OfType<Model.LongTermKeepContract>().Where(t => t.status == "Active" && t.facilityId == (int)comboBox_facilityLong.SelectedValue).Count();
                label_totalActiveLong.Text = contract1.ToString();
                var contract2 = context.Contracts.OfType<Model.LongTermKeepContract>().Where(t => t.status == "Done" && t.facilityId == (int)comboBox_facilityLong.SelectedValue).Count();
                label_totalDoneLong.Text = contract2.ToString();
                var contract3 = context.Contracts.OfType<Model.LongTermKeepContract>().Where(t => t.status == "Booked" && t.facilityId == (int)comboBox_facilityLong.SelectedValue).Count();
                label_totalBookedLong.Text = contract3.ToString();
            }
        }

        private void button_ShowLong_Click(object sender, EventArgs e)
        {
            ListLongContractForm form = new ListLongContractForm();
            form.FacilityID = (int)comboBox_facilityLong.SelectedValue;
            form.Show();
        }

        private void button_setRuleLong_Click(object sender, EventArgs e)
        {
            using (var context = new DatabaseContext())
            {
                var rule = context.Rules.Where(t => t.nameContract == "LongKeepContract").FirstOrDefault();
                rule.description = textBox_ruleLong.Text;
                context.SaveChanges();
                MessageBox.Show("Set rule for Long keep contract successfully");
            }
        }

        private void button_selectLoan_Click(object sender, EventArgs e)
        {
            using (var context = new DatabaseContext())
            {
                var contract1 = context.Contracts.OfType<Model.LoanContract>().Where(t => t.status == "Active" && t.facilityId == (int)comboBox_facilityLoan.SelectedValue).Count();
                label_totalActiveLoan.Text = contract1.ToString();
                var contract2 = context.Contracts.OfType<Model.LoanContract>().Where(t => t.status == "Done" && t.facilityId == (int)comboBox_facilityLoan.SelectedValue).Count();
                label_totalDoneLoan.Text = contract2.ToString();
                var contract3 = context.Contracts.OfType<Model.LoanContract>().Where(t => t.status == "Booked" && t.facilityId == (int)comboBox_facilityLoan.SelectedValue).Count();
                label_totalBookedLoan.Text = contract3.ToString();
            }
        }

        private void button_showLoan_Click(object sender, EventArgs e)
        {
            ListLoanContractForm listLoanContractForm = new ListLoanContractForm();
            listLoanContractForm.FacilityID = (int) comboBox_facilityLoan.SelectedValue;
            listLoanContractForm.Show();
        }

        private void button_setRuleLoan_Click(object sender, EventArgs e)
        {
            using (var context = new DatabaseContext())
            {
                var rule = context.Rules.Where(t => t.nameContract == "LoanContract").FirstOrDefault();
                rule.description = textBox_ruleLoan.Text;
                context.SaveChanges();
                MessageBox.Show("Set rule for Loan contract successfully");
            }
        }

        private void comboBox_role_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new DatabaseContext())
            {
                if(comboBox_role.Text == "FixWorker")
                {
                    var sa = context.BaseSalaries.Where(t => t.typeWorker == "FixWorker").FirstOrDefault();
                    textBox_baseSalary.Text = sa.baseSalary.ToString();
                }
                else if(comboBox_role.Text == "KeepWorker")
                {
                    var sa = context.BaseSalaries.Where(t => t.typeWorker == "KeepWorker").FirstOrDefault();
                    textBox_baseSalary.Text = sa.baseSalary.ToString();
                }
                else
                {
                    MessageBox.Show("Type worker is invalid");
                }
            }    
        }

        private void button_FineCus_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox_name.Text))
            {
                MessageBox.Show("Please enter customer firstname");
                return;
            }
            using (var context = new DatabaseContext())
            {
                var cus = context.Users.OfType<Customer>().Where(t=>t.firstName == textBox_name.Text)
                    .Select(u => new
                    {
                        FisrtName = u.firstName,
                        LastName = u.lastName,
                        Phone = u.phone,
                        Email = u.email,
                        Address=u.address
                    }).ToList();
                dataGridview_listCustomer.DataSource = cus;

            }
        }

        private void button_ShowAllCus_Click(object sender, EventArgs e)
        {
            loadCus();
        }

        private void button_removeFacility_Click(object sender, EventArgs e)
        {

        }
    }
}
