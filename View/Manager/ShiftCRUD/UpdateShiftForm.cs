using FinalWindow.Database;
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

namespace FinalWindow.View.Manager.ShiftCRUD
{
    public partial class UpdateShiftForm : Form
    {
        DateTime temp = new DateTime(1,1,1,0,0,0);
        public UpdateShiftForm()
        {
            InitializeComponent();
            dateTimePicker_From.MinDate = new DateTime(1900, 1, 1);
            dateTimePicker_From.MaxDate = new DateTime(2100, 12, 31);
            dateTimePicker_To.MinDate = new DateTime(1900, 1, 1);
            dateTimePicker_To.MaxDate = new DateTime(2100, 12, 31);
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    try
                    {
                        Model.Shift shift = context.Shifts.Where(u => u.startTime == dateTimePicker_From.Value.TimeOfDay).FirstOrDefault();

                        if (shift == null)
                        {
                            dateTimePicker_From.Value = temp;


                            MessageBox.Show("Don't exist this shift");

                        }
                        else
                        {

                            shift.startTime = dateTimePicker_From.Value.TimeOfDay;
                            shift.endTime = dateTimePicker_To.Value.TimeOfDay;

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

        private void UpdateShiftForm_Load(object sender, EventArgs e)
        {

        }
    }
}
