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

namespace FinalWindow.View.Director.FacilityCRUD
{
    public partial class AddFacilityForm : Form
    {
        public AddFacilityForm()
        {
            InitializeComponent();
        }

        private void button_addFacility_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_facilityAddress.Text) || comboBox_Manager.SelectedItem == null)
            {
                MessageBox.Show("Please type all information to add.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                using (var db = new DatabaseContext())
                {

                    var facility = new Facility
                    {
                        address = textBox_facilityAddress.Text,
                        quantityKeep = 0,
                        quatityFix = 0
                    };
                    db.Facilities.Add(facility);
                    MessageBox.Show("Add Successfully", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    db.SaveChanges();

                    string value = comboBox_Manager.SelectedValue.ToString();

                    var manager = db.Users.OfType<Model.Manager>().Where(t => t.cardID == value).FirstOrDefault();
                    var facilityAddress = db.Facilities.Where(t => t.address == textBox_facilityAddress.Text).FirstOrDefault();
                    manager.facilityID = facilityAddress.ID;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void AddFacilityForm_Load(object sender, EventArgs e)
        {
            using (var context = new DatabaseContext())
            {
                comboBox_Manager.DataSource = context.Users.OfType<Model.Manager>().Where(t => t.facilityID == null).ToList();
                comboBox_Manager.DisplayMember = "firstName";
                comboBox_Manager.ValueMember = "cardID";
                comboBox_Manager.SelectedIndex = -1;
            }
            
        }
    }
}
