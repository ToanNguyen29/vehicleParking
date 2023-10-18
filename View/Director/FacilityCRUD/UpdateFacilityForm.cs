using FinalWindow.Database;
using FinalWindow.Model;
using FinalWindow.View.Director.List;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalWindow.View.Director.FacilityCRUD
{
    public partial class UpdateFacilityForm : Form
    {
        string temp = null;
        public UpdateFacilityForm()
        {
            InitializeComponent();
        }

        

        private void button_updateFacility_Click(object sender, EventArgs e)
        {
            try
            {
                if(comboBox_facilityAddress.SelectedItem == null || comboBox_Manager.SelectedItem == null)
                {
                    MessageBox.Show("Please type all information to update.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (var context = new DatabaseContext())
                {
                    var manager = context.Users.OfType<Model.Manager>().Where(t => t.cardID == comboBox_Manager.SelectedValue.ToString()).FirstOrDefault();
                    manager.facilityID = (int)comboBox_facilityAddress.SelectedValue;

                    context.SaveChanges();
                    MessageBox.Show("Update successfully", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateFacilityForm_Load(object sender, EventArgs e)
        {
            using (var context = new DatabaseContext())
            {


                comboBox_facilityAddress.DataSource = context.Facilities.ToList();
                comboBox_facilityAddress.DisplayMember = "address";
                comboBox_facilityAddress.ValueMember = "ID";


                comboBox_Manager.DataSource = context.Users.OfType<Model.Manager>().ToList();
                comboBox_Manager.DisplayMember = "firstName";
                comboBox_Manager.ValueMember = "cardID";
                comboBox_Manager.SelectedIndex = -1;
            }


        }
    }
}
