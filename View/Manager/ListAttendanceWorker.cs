using FinalWindow.Database;
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
    public partial class ListAttendanceWorker : Form
    {
        private int idWorker;
        private string typeWorker;
        private int monthNow;
        private int yearNow;
        public ListAttendanceWorker()
        {
            InitializeComponent();
        }

        public int IdWorker { get => idWorker; set => idWorker = value; }
        public string TypeWorker { get => typeWorker; set => typeWorker = value; }
        public int YearNow { get => yearNow; set => yearNow = value; }
        public int MonthNow { get => monthNow; set => monthNow = value; }

        private void ListAttendanceWorker_Load(object sender, EventArgs e)
        {
            if(typeWorker == "FixWorker")
            {
                try
                {
                    using (var context = new DatabaseContext())
                    {
                        
                        var FixSalary = context.Users.OfType<Model.FixWorker>().Where(t => t.ID == idWorker)
                                .Join(context.Attendances.Where(t => t.dateWork.Month == monthNow && t.dateWork.Year == yearNow),
                                KeepWorker => KeepWorker.ID,
                                Attendance => Attendance.fixWorkerID,
                                (KeepWorker, Attendance) => new
                                {
                                    Date = Attendance.dateWork,
                                    ID = KeepWorker.ID,
                                    FirstName = KeepWorker.firstName,
                                    LastName = KeepWorker.lastName,
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
            else if (typeWorker == "KeepWorker")
            {
                try
                {
                    using (var context = new DatabaseContext())
                    {

                        var KeepSalary = context.Users.OfType<Model.KeepWorker>().Where(t => t.ID == idWorker)
                                .Join(context.Attendances.Where(t => t.dateWork.Month == monthNow && t.dateWork.Year == yearNow),
                                KeepWorker => KeepWorker.ID,
                                Attendance => Attendance.keepWorkerID,
                                (KeepWorker, Attendance) => new
                                {
                                    Date = Attendance.dateWork,
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
            else
            {
                MessageBox.Show("Error");
                return;
            }
            int count = 0;
            for (int i = 0; i < dataGridView_listWorker.Rows.Count; i++)
            {
                int salary = Convert.ToInt32(dataGridView_listWorker.Rows[i].Cells[7].Value);
                if (salary == 0)
                {
                    count++;
                }
            }

            label_dayAbsent.Text = "Day absent: " + count.ToString();
        }
    }
}
