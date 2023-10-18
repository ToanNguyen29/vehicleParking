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

namespace FinalWindow.View.Manager.ShiftCRUD
{
    public partial class ShiftWorkForm : Form
    {
        
        public ShiftWorkForm()
        {
            InitializeComponent();
        }

        private void ShiftWorkForm_Load(object sender, EventArgs e)
        {
            loadShiftComboBox();
            //loadLabel();
            comboBox_typeWorker.SelectedIndex = 0;
            comboBox_shift.SelectedIndex = 0;
            //if(comboBox_typeWorker.SelectedIndex == 0 )
            //{
            //    labelkeep.Visible = false;
            //    label_quantityKeep.Visible = false;
            //}
            //else if(comboBox_typeWorker.SelectedIndex == 1 )
            //{
            //    labelfix.Visible = false;
            //    label_quantityFix.Visible = false;
            //}


        }

        void loadLabel()
        {
            if(comboBox_shift.SelectedIndex == 0)
            {
                int shiftID = (int)comboBox_shift.SelectedValue;

                using (var context = new DatabaseContext())
                {
                    var shift = context.Shifts.Where(t => t.ID == shiftID).FirstOrDefault();
                    label_quantityFix.Text = shift.quantityFix.ToString();
                    label_quantityKeep.Text = shift.quantityKeep.ToString();
                }
            }
            else if(comboBox_shift.SelectedIndex == 1)
            {
                int shiftID = (int)comboBox_shift.SelectedValue;
                using (var context = new DatabaseContext())
                {
                    var shift = context.Shifts.Where(t => t.ID == shiftID).FirstOrDefault();
                    label_quantityFix.Text = shift.quantityFix.ToString();
                    label_quantityKeep.Text = shift.quantityKeep.ToString();
                }
            }
            else if(comboBox_shift.SelectedIndex == 2)
            {
                int shiftID = (int)comboBox_shift.SelectedValue;
                using (var context = new DatabaseContext())
                {
                    var shift = context.Shifts.Where(t => t.ID == shiftID).FirstOrDefault();
                    label_quantityFix.Text = shift.quantityFix.ToString();
                    label_quantityKeep.Text = shift.quantityKeep.ToString();
                }
            }
            
        }

        void loadShiftComboBox()
        {
            using (var context = new DatabaseContext())
            {
                comboBox_shift.DataSource = context.Shifts.ToList();
                comboBox_shift.DisplayMember = "startTime";
                comboBox_shift.ValueMember = "ID";
                comboBox_shift.SelectedIndex = 0;
            }
        }

        void loadDataGridView()
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    var manager = context.Users.OfType<Model.Manager>().Where(t => t.ID == ManagerMainForm.ManID).FirstOrDefault();

                    if (comboBox_typeWorker.SelectedIndex == 0)
                    {

                        var fixerData = context.Users.OfType<Model.FixWorker>().Where(t => t.facilityID == manager.facilityID && t.shiftID == null)
                            .Select(u => new
                            {
                                CardID = u.cardID,
                                FisrtName = u.firstName,
                                LastName = u.lastName,


                            })
                            .ToList();

                        dataGridView_listWorker.DataSource = fixerData;



                        var fixer = context.Users.OfType<Model.FixWorker>().Where(t => t.facilityID == manager.facilityID).Join(context.Shifts,
                            User => User.shiftID,
                            Shift => Shift.ID,
                            (User, Shift) => new
                            {
                                ShiftID = Shift.ID,
                                StartTime = Shift.startTime,
                                EndTime = Shift.endTime,
                                FacilityAddress = User.Facility.address,
                                CardID = User.cardID,
                                FisrtName = User.firstName,
                                LastName = User.lastName,


                            })
                            .ToList();


                        dataGridView_shiftInfor.DataSource = fixer;



                    }
                    else if (comboBox_typeWorker.SelectedIndex == 1)
                    {

                        var keeperData = context.Users.OfType<Model.KeepWorker>().Where(t => t.facilityID == manager.facilityID && t.shiftID == null)
                            .Select(u => new
                            {
                                CardID = u.cardID,
                                FisrtName = u.firstName,
                                LastName = u.lastName,


                            })
                            .ToList();

                        dataGridView_listWorker.DataSource = keeperData;




                        var keeper = context.Users.OfType<Model.KeepWorker>().Where(t => t.facilityID == manager.facilityID).Join(context.Shifts,
                            User => User.shiftID,
                            Shift => Shift.ID,
                            (User, Shift) => new
                            {
                                ShiftID = Shift.ID,
                                StartTime = Shift.startTime,
                                EndTime = Shift.endTime,
                                FacilityAddress = User.Facility.address,
                                CardID = User.cardID,
                                FisrtName = User.firstName,
                                LastName = User.lastName,


                            })
                            .ToList();

                        dataGridView_shiftInfor.DataSource = keeper;

                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        

        private void comboBox_typeWorker_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    var manager = context.Users.OfType<Model.Manager>().Where(t => t.ID == ManagerMainForm.ManID).FirstOrDefault();

                    if (comboBox_typeWorker.SelectedIndex == 0)
                    {

                        var fixerData = context.Users.OfType<Model.FixWorker>().Where(t => t.facilityID == manager.facilityID && t.shiftID == null)
                            .Select(u => new
                            {
                                CardID = u.cardID,
                                FisrtName = u.firstName,
                                LastName = u.lastName,


                            })
                            .ToList();

                        dataGridView_listWorker.DataSource = fixerData;



                        var fixer = context.Users.OfType<Model.FixWorker>().Where(t => t.facilityID == manager.facilityID).Join(context.Shifts,
                            User => User.shiftID,
                            Shift => Shift.ID,
                            (User, Shift) => new
                            {
                                ShiftID = Shift.ID,
                                StartTime = Shift.startTime,
                                EndTime = Shift.endTime,
                                FacilityAddress = User.Facility.address,
                                CardID = User.cardID,
                                FisrtName = User.firstName,
                                LastName = User.lastName,
                            //QuantityFix = Shift.quantityFix,


                        })
                            .ToList();



                        dataGridView_shiftInfor.DataSource = fixer;



                    }
                    else if (comboBox_typeWorker.SelectedIndex == 1)
                    {

                        var keeperData = context.Users.OfType<Model.KeepWorker>().Where(t => t.facilityID == manager.facilityID && t.shiftID == null)
                            .Select(u => new
                            {
                                CardID = u.cardID,
                                FisrtName = u.firstName,
                                LastName = u.lastName,


                            })
                            .ToList();

                        dataGridView_listWorker.DataSource = keeperData;


                        var keeper = context.Users.OfType<Model.KeepWorker>().Where(t => t.facilityID == manager.facilityID).Join(context.Shifts,
                            User => User.shiftID,
                            Shift => Shift.ID,
                            (User, Shift) => new
                            {
                                ShiftID = Shift.ID,
                                StartTime = Shift.startTime,
                                EndTime = Shift.endTime,
                                FacilityAddress = User.Facility.address,
                                CardID = User.cardID,
                                FisrtName = User.firstName,
                                LastName = User.lastName,
                            //QuantityKeep = Shift.quantityKeep
                        })
                            .ToList();



                        dataGridView_shiftInfor.DataSource = keeper;

                    }
                }

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    if (comboBox_typeWorker.SelectedIndex == 0)
                    {
                        try
                        {
                            string cardID = dataGridView_listWorker.CurrentRow.Cells["CardID"].Value.ToString();
                            Model.FixWorker fixer = context.Users.OfType<Model.FixWorker>().Where(u => u.cardID == cardID).FirstOrDefault();


                            fixer.shiftID = (int?)comboBox_shift.SelectedValue;
                            context.SaveChanges();
                            loadDataGridView();
                            MessageBox.Show("Add successfully.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }


                        try
                        {
                            int shiftID = (int)comboBox_shift.SelectedValue;
                            var fixer = context.Users.OfType<Model.FixWorker>().Where(u => u.shiftID == shiftID).Count();

                            Model.Shift shift = context.Shifts.Where(t => t.ID == shiftID).FirstOrDefault();
                            shift.quantityFix = fixer;


                            context.SaveChanges();


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (comboBox_typeWorker.SelectedIndex == 1)
                    {
                        try
                        {
                            string cardID = dataGridView_listWorker.CurrentRow.Cells["CardID"].Value.ToString();
                            Model.KeepWorker keeper = context.Users.OfType<Model.KeepWorker>().Where(u => u.cardID == cardID).FirstOrDefault();


                            keeper.shiftID = (int?)comboBox_shift.SelectedValue;
                            context.SaveChanges();
                            loadDataGridView();
                            MessageBox.Show("Add successfully.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }


                        try
                        {
                            int shiftID = (int)comboBox_shift.SelectedValue;
                            var keeper = context.Users.OfType<Model.KeepWorker>().Where(u => u.shiftID == shiftID).Count();

                            Model.Shift shift = context.Shifts.Where(t => t.ID == shiftID).FirstOrDefault();
                            shift.quantityKeep = keeper;


                            context.SaveChanges();


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    var manager = context.Users.OfType<Model.Manager>().Where(t => t.ID == ManagerMainForm.ManID).FirstOrDefault();

                    if (comboBox_typeWorker.SelectedIndex == 0)
                    {

                        var fixerData = context.Users.OfType<Model.FixWorker>().Where(t => t.facilityID == manager.facilityID && t.shiftID == null)
                            .Select(u => new
                            {
                                CardID = u.cardID,
                                FisrtName = u.firstName,
                                LastName = u.lastName,


                            })
                            .ToList();

                        dataGridView_listWorker.DataSource = fixerData;



                        int shiftid = (int)comboBox_shift.SelectedValue;
                        var fixer = context.Users.OfType<Model.FixWorker>().Where(t => t.facilityID == manager.facilityID && t.shiftID == shiftid).Join(context.Shifts,
                            User => User.shiftID,
                            Shift => Shift.ID,
                            (User, Shift) => new
                            {
                                ShiftID = Shift.ID,
                                StartTime = Shift.startTime,
                                EndTime = Shift.endTime,
                                FacilityAddress = User.Facility.address,
                                CardID = User.cardID,
                                FisrtName = User.firstName,
                                LastName = User.lastName,


                            })
                            .ToList();



                        dataGridView_shiftInfor.DataSource = fixer;
                        labelfix.Visible = true;
                        label_quantityFix.Visible = true;
                        label_quantityFix.Text = dataGridView_shiftInfor.RowCount.ToString();
                        label_quantityKeep.Visible = false;
                        labelkeep.Visible = false;

                    }
                    else if (comboBox_typeWorker.SelectedIndex == 1)
                    {

                        var keeperData = context.Users.OfType<Model.KeepWorker>().Where(t => t.facilityID == manager.facilityID && t.shiftID == null)
                            .Select(u => new
                            {
                                CardID = u.cardID,
                                FisrtName = u.firstName,
                                LastName = u.lastName,


                            })
                            .ToList();

                        dataGridView_listWorker.DataSource = keeperData;




                        int shiftid = (int)comboBox_shift.SelectedValue;
                        var keeper = context.Users.OfType<Model.KeepWorker>().Where(t => t.facilityID == manager.facilityID && t.shiftID == shiftid).Join(context.Shifts,
                            User => User.shiftID,
                            Shift => Shift.ID,
                            (User, Shift) => new
                            {
                                ShiftID = Shift.ID,
                                StartTime = Shift.startTime,
                                EndTime = Shift.endTime,
                                FacilityAddress = User.Facility.address,
                                CardID = User.cardID,
                                FisrtName = User.firstName,
                                LastName = User.lastName,


                            })
                            .ToList();

                        dataGridView_shiftInfor.DataSource = keeper;
                        label_quantityFix.Visible = false;
                        labelfix.Visible = false;
                        labelkeep.Visible = true;
                        label_quantityKeep.Visible = true;
                        label_quantityKeep.Text = dataGridView_shiftInfor.RowCount.ToString();

                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            try
            {
                string cardID = dataGridView_shiftInfor.CurrentRow.Cells["CardID"].Value.ToString();
                using (var context = new DatabaseContext())
                {
                    if (comboBox_typeWorker.SelectedIndex == 0)
                    {
                        Model.FixWorker fixer = context.Users.OfType<Model.FixWorker>().Where(t => t.cardID == cardID).FirstOrDefault();
                        fixer.shiftID = null;
                        context.SaveChanges();
                        loadDataGridView();
                        MessageBox.Show("Remove successfully.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else if (comboBox_typeWorker.SelectedIndex == 1)
                    {
                        Model.KeepWorker keeper = context.Users.OfType<Model.KeepWorker>().Where(t => t.cardID == cardID).FirstOrDefault();
                        keeper.shiftID = null;
                        context.SaveChanges();
                        loadDataGridView();
                        MessageBox.Show("Remove successfully.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch(Exception ex)
            {
                { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            
        }

        private void comboBox_shift_SelectedIndexChanged(object sender, EventArgs e)
        {

            

            

        }
    }
}
