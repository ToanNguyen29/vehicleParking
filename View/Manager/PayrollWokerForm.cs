using FinalWindow.Database;
using FinalWindow.Model;
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
    public partial class PayrollWokerForm : Form
    {
        public PayrollWokerForm()
        {
            InitializeComponent();
        }

        private void PayrollWokerForm_Load(object sender, EventArgs e)
        {
            using (var context = new DatabaseContext())
            {
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
                            .Join(context.Salaries.Where(t => t.month == date.Month && t.year == date.Year),
                            KeepWorker => KeepWorker.ID,
                            Salary => Salary.fixWorkerID,
                            (KeepWorker, Salary) => new
                            {
                                ID = KeepWorker.ID,
                                FirstName = KeepWorker.firstName,
                                LastName = KeepWorker.lastName,
                                
                                Salary = Salary.totalSalary

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
                using(var context = new DatabaseContext())
                {
                    var manager = context.Users.OfType<Model.Manager>().Where(t => t.ID == ManagerMainForm.ManID).FirstOrDefault();
                    var FixSalary = context.Users.OfType<Model.FixWorker>().Where(t => t.facilityID == manager.facilityID)
                            .Join(context.Salaries.Where(t => t.month == date.Month && t.year == date.Year),
                            FixWorker => FixWorker.ID,
                            Salary => Salary.fixWorkerID,
                            (FixWorker, Salary) => new
                            {
                                ID = FixWorker.ID,
                                FirstName = FixWorker.firstName,
                                LastName = FixWorker.lastName,
                                

                                Salary = Salary.totalSalary

                            }).ToList();


                    dataGridView_listWorker.DataSource = FixSalary;
                }    


            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button_selectPayroll_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox_typeWorker.Text) || dateTimePicker_date.Value == null)
            {
                MessageBox.Show("Please enter all information");
                return;
            }
            if (comboBox_typeWorker.Text == "FixWorker")
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

        private void dataGridView_listWorker_DoubleClick(object sender, EventArgs e)
        {
            ListAttendanceWorker listWorker = new ListAttendanceWorker();
            listWorker.IdWorker= int.Parse(dataGridView_listWorker.CurrentRow.Cells[0].Value.ToString());
            listWorker.TypeWorker = comboBox_typeWorker.Text;
            listWorker.MonthNow = dateTimePicker_date.Value.Month;
            listWorker.YearNow = dateTimePicker_date.Value.Year;
            listWorker.Show();
        }
    }
}
