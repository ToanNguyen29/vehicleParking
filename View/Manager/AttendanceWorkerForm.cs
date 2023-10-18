using FinalWindow.Database;
using FinalWindow.Model;
using FinalWindow.View.Director;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalWindow.View.Manager
{
    public partial class AttendanceWorkerForm : Form
    {
        public AttendanceWorkerForm()
        {
            InitializeComponent();
        }

        private void PayRollWorkerForm_Load(object sender, EventArgs e)
        {
            using (var context = new DatabaseContext())
            {
                var check = context.Attendances.Where(t => t.dateWork.Day == DateTime.Now.Day && t.dateWork.Month == DateTime.Now.Month && t.dateWork.Year == DateTime.Now.Year).Count();
                if (check == 0)
                {
                    try
                    {
                        var data = context.Users.OfType<Model.KeepWorker>().Select(a => new { a.ID, a.baseSalary, a.coefficients });
                        foreach (var item in data)
                        {
                            var newRecord = new Attendance
                            {
                                keepWorkerID = item.ID,
                                dateWork = DateTime.Now,
                                hourWork = 0,
                                baseSalary = item.baseSalary * item.coefficients,
                                bonusSalary = 0,
                                penaltySalary = 0,
                                totalSalary = 0
                            };
                            context.Attendances.Add(newRecord);
                        }

                        var data1 = context.Users.OfType<Model.FixWorker>().Select(a => new { a.ID, a.baseSalary, a.coefficients });
                        foreach (var item in data1)
                        {
                            var newRecord = new Attendance
                            {
                                fixWorkerID = item.ID,
                                dateWork = DateTime.Now,
                                hourWork = 0,
                                baseSalary = item.baseSalary * item.coefficients,
                                bonusSalary = 0,
                                penaltySalary = 0,
                                totalSalary = 0
                            };
                            context.Attendances.Add(newRecord);
                        }

                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }

                }

                var check1 = context.Salaries.Where(t => t.month == DateTime.Now.Month && t.year == DateTime.Now.Year).Count();
                if (check1 == 0)
                {
                    try
                    {
                        var data = context.Users.OfType<Model.KeepWorker>().Select(a => new { a.ID });
                        foreach (var item in data)
                        {
                            var newRecord = new Salary
                            {
                                keepWorkerID = item.ID,
                                month = DateTime.Now.Month,
                                year = DateTime.Now.Year,
                                totalSalary = 0
                            };
                            context.Salaries.Add(newRecord);
                        }

                        var data1 = context.Users.OfType<Model.FixWorker>().Select(a => new { a.ID });
                        foreach (var item in data1)
                        {
                            var newRecord = new Salary
                            {
                                fixWorkerID = item.ID,
                                month = DateTime.Now.Month,
                                year = DateTime.Now.Year,
                                totalSalary = 0
                            };
                            context.Salaries.Add(newRecord);
                        }

                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                }

                comboBox_typeWorker.SelectedIndex = 0;
                dateTimePicker_date.Value = DateTime.Now;
                dateTimePicker_date.MaxDate = DateTime.Now;
                
            }
        }

        void loadKeepDataGridView(DateTime date)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    var manager = context.Users.OfType<Model.Manager>().Where(t => t.ID == ManagerMainForm.ManID).FirstOrDefault();
                    var KeepSalary = context.Users.OfType<Model.KeepWorker>().Where(t => t.facilityID == manager.facilityID)
                            .Join(context.Attendances.Where(t => t.dateWork.Day == date.Day && t.dateWork.Month == date.Month && t.dateWork.Year == date.Year),
                            KeepWorker => KeepWorker.ID,
                            Attendance => Attendance.keepWorkerID,
                            (KeepWorker, Attendance) => new
                            {
                                ID = KeepWorker.ID,
                                FirstName = KeepWorker.firstName,
                                LastName = KeepWorker.lastName,
                               
                                BaseSalary = Attendance.baseSalary,
                                BonusSalary = Attendance.bonusSalary,
                                PenaltySalary = Attendance.penaltySalary,
                                Salary = Attendance.totalSalary

                            }).ToList();


                    dataGridView_listWorker.DataSource = KeepSalary;
                }
 
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        void loadFixDataGridView(DateTime date)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    var manager = context.Users.OfType<Model.Manager>().Where(t => t.ID == ManagerMainForm.ManID).FirstOrDefault();
                    var FixSalary = context.Users.OfType<Model.FixWorker>().Where(t => t.facilityID == manager.facilityID)
                            .Join(context.Attendances.Where(t => t.dateWork.Day == date.Day && t.dateWork.Month == date.Month && t.dateWork.Year == date.Year),
                            FixWorker => FixWorker.ID,
                            Attendance => Attendance.fixWorkerID,
                            (FixWorker, Attendance) => new
                            {
                                ID = FixWorker.ID,
                                FirstName = FixWorker.firstName,
                                LastName = FixWorker.lastName,
                                BaseSalary = Attendance.baseSalary,
                                BonusSalary = Attendance.bonusSalary,
                                PenaltySalary = Attendance.penaltySalary,
                                Salary = Attendance.totalSalary

                            }).ToList();


                    dataGridView_listWorker.DataSource = FixSalary;
                }

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void comboBox_typeWorker_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView_listWorker_Click(object sender, EventArgs e)
        {
            if(DateTime.Now.Day == dateTimePicker_date.Value.Day && DateTime.Now.Month == dateTimePicker_date.Value.Month && DateTime.Now.Year == dateTimePicker_date.Value.Year)
            {
                CalculateSalaryDayWorkerForm calculateSalaryForm = new CalculateSalaryDayWorkerForm();
                calculateSalaryForm.textBox_ID.Text = dataGridView_listWorker.CurrentRow.Cells[0].Value.ToString();
                calculateSalaryForm.textBox_FName.Text = dataGridView_listWorker.CurrentRow.Cells[1].Value.ToString();
                calculateSalaryForm.textBox_LName.Text = dataGridView_listWorker.CurrentRow.Cells[2].Value.ToString();
                calculateSalaryForm.textBox_TypeWorker.Text = comboBox_typeWorker.Text;
                calculateSalaryForm.textBox_BaseSalary.Text= dataGridView_listWorker.CurrentRow.Cells[3].Value.ToString();
                calculateSalaryForm.textBox_Bonus.Text = dataGridView_listWorker.CurrentRow.Cells[4].Value.ToString();
                calculateSalaryForm.textBox_Penalty.Text = dataGridView_listWorker.CurrentRow.Cells[5].Value.ToString();
                calculateSalaryForm.label_totalSalary.Text = dataGridView_listWorker.CurrentRow.Cells[6].Value.ToString();
                calculateSalaryForm.Show();
            }    
            else
            {
                MessageBox.Show("You can't take attendance for last day");
            }    
                
            /* CalculateWorkerSalaryForm calculateSalaryForm = new CalculateWorkerSalaryForm();


             if (dataGridView_listWorker.CurrentRow.Cells["SalaryID"].Value != null)
             {
                 int value = (int)dataGridView_listWorker.CurrentRow.Cells["SalaryID"].Value;
                 string firstName = dataGridView_listWorker.CurrentRow.Cells["FirstName"].Value.ToString();
                 string cardID = dataGridView_listWorker.CurrentRow.Cells["CardID"].Value.ToString();
                 using (DatabaseContext context = DatabaseContext.Instance)
                 {
                     var salary = context.Salaries.Where(t => t.salaryID == value).FirstOrDefault();
                     if (comboBox_typeWorker.SelectedIndex == 0)
                     {
                         var fixer = context.Users.OfType<Model.FixWorker>().Where(t => t.salaryID == value).FirstOrDefault();

                         if (salary != null && fixer != null)
                         {
                             float? totalSalary = salary.BasicSalary * fixer.coefficients;
                             fixer.totalSalary = totalSalary;

                             context.SaveChanges();


                             calculateSalaryForm.label_totalSalary.Text = totalSalary.ToString();
                             calculateSalaryForm.label_workerCardID.Text = cardID;
                             calculateSalaryForm.label_FirstName.Text = firstName;

                         }
                     }
                     else if (comboBox_typeWorker.SelectedIndex == 1)
                     {
                         var keeper = context.Users.OfType<Model.KeepWorker>().Where(t => t.salaryID == value).FirstOrDefault();

                         if (salary != null && keeper != null)
                         {
                             float? totalSalary = salary.BasicSalary * keeper.coefficients;
                             keeper.totalSalary = totalSalary;

                             context.SaveChanges();


                             calculateSalaryForm.label_totalSalary.Text = totalSalary.ToString();
                             calculateSalaryForm.label_workerCardID.Text = cardID;
                             calculateSalaryForm.label_FirstName.Text = firstName;

                         }
                     }

                 }
                 calculateSalaryForm.Show();
             }*/
        }

        private void button_resetPayroll_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(comboBox_typeWorker.Text) || dateTimePicker_date.Value==null)
            {
                MessageBox.Show("Please enter all information");
                return;
            }    
            if(comboBox_typeWorker.Text == "FixWorker")
            {
                loadFixDataGridView(dateTimePicker_date.Value);
            }
            else
            {
                loadKeepDataGridView(dateTimePicker_date.Value);
            } 
                
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox_typeWorker.Text) || dateTimePicker_date.Value == null)
            {
                MessageBox.Show("Please enter all information");
                return;
            }
            if (comboBox_typeWorker.Text == "Fix Worker")
            {
                loadFixDataGridView(dateTimePicker_date.Value);
            }
            else
            {
                loadKeepDataGridView(dateTimePicker_date.Value);
            }
        }
    }
}
