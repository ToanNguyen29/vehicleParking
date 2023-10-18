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

namespace FinalWindow.View.Director.List
{
    public partial class DetailLongContractForm : Form
    {
        public bool isDone = false;
        public bool isActive = false;
        public bool isBooked = false;
        public DetailLongContractForm()
        {
            InitializeComponent();
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            if(isActive!= true && radioButton_active.Checked == true)
            {
                try
                {
                    using (var context = new DatabaseContext())
                    {
                        try
                        {

                            int contractID = int.Parse(label_contractID.Text);
                            Model.Contract contract = context.Contracts.OfType<Model.LongTermKeepContract>().Where(u => u.ID == contractID).FirstOrDefault();

                            if (contract == null)
                            {
                                MessageBox.Show("Don't exist this contract");
                            }
                            else
                            {
                                contract.status = "Active";
                                contract.dateStartActual = DateTime.Now;

                                context.SaveChanges();
                                MessageBox.Show("Update successfully !!!");
                                label_status.Text = contract.status;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Update fail");
                }

            }
            /*else if(isBooked != true && radioButton_booked.Checked == true)
            {
                try
                {
                    using (var context = new DatabaseContext())
                    {
                        try
                        {

                            int contractID = int.Parse(label_contractID.Text);
                            Model.Contract contract = context.Contracts.OfType<Model.LongTermKeepContract>().Where(u => u.ID == contractID).FirstOrDefault();

                            if (contract == null)
                            {
                                MessageBox.Show("Don't exist this contract");
                            }
                            else
                            {
                                contract.status = "Booked";

                                context.SaveChanges();
                                MessageBox.Show("Update successfully !!!");
                                label_status.Text = contract.status;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Update fail");
                }
            }*/
            else if(isDone != true && radioButton_done.Checked == true)
            {
                try
                {
                    using (var context = new DatabaseContext())
                    {
                        try
                        {

                            int contractID = int.Parse(label_contractID.Text);
                            Model.Contract contract = context.Contracts.OfType<Model.LongTermKeepContract>().Where(u => u.ID == contractID).FirstOrDefault();

                            if (contract == null)
                            {
                                MessageBox.Show("Don't exist this contract");
                            }
                            else
                            {

                                contract.status = "Done";
                                contract.dateEndActual = DateTime.Now;
                                context.SaveChanges();
                                MessageBox.Show("Update successfully !!!");
                                label_status.Text = contract.status;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Update fail");
                }
            }
            else
            {
                MessageBox.Show("Please choose the status of contract", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            
        }

        private void radioButton_active_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton_done_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton_booked_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void DetailLongContractForm_Load(object sender, EventArgs e)
        {

        }
    }
}
