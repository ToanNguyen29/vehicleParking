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

namespace FinalWindow.View.Manager.ShiftCRUD
{
    public partial class AddShiftForm : Form
    {
        public AddShiftForm()
        {
            InitializeComponent();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    var shift = new Model.Shift
                    {
                        startTime = dateTimePicker_From.Value.TimeOfDay,
                        endTime = dateTimePicker_To.Value.TimeOfDay
                    };
                    try
                    {
                        context.Shifts.Add(shift);
                        context.SaveChanges();
                        MessageBox.Show("Add successfully.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
                

        }

        private bool IsDateTimeValid()
        {
            // Lấy giá trị thời gian từ DateTimePicker
            DateTime fromDate =dateTimePicker_From.Value;
            DateTime toDate = dateTimePicker_To.Value;

            // So sánh thời gian của FROM và TO
            if (fromDate <= toDate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void AddShiftForm_Load(object sender, EventArgs e)
        {

        }
    }
}
