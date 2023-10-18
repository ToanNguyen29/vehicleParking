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
    public partial class DetailLoanContractForm : Form
    {

        public bool isDone = false;
        public bool isActive = false;
        public bool isBooked = false;
        public DetailLoanContractForm()
        {
            InitializeComponent();
        }

        private void radioButton_active_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_active.Checked == true)
            {
                isActive = true;
            }
            else
            {
                isActive = false;
            }
        }

        private void radioButton_done_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_done.Checked == true) { isDone = true; }
            else { isDone = false; }
        }

        private void radioButton_booked_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_booked.Checked == true) { isBooked = true; }
            else { isBooked = false; }
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox_fee.Text))
            {
                MessageBox.Show("Enter fee");
                return;
            }    
            if (isActive!=true && radioButton_active.Checked)
            {
                try
                {
                    using (var context = new DatabaseContext())
                    {
                        try
                        {

                            int contractID = int.Parse(label_contractID.Text);
                            Model.Contract contract = context.Contracts.OfType<Model.LoanContract>().Where(u => u.ID == contractID).FirstOrDefault();

                            if (contract == null)
                            {
                                MessageBox.Show("Don't exist this contract");
                            }
                            else
                            {
                                contract.status = "Active";
                                contract.dateStartActual = DateTime.Now;
                                contract.fee = float.Parse(textBox_fee.Text);
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
           /* else if (isBooked!= true && radioButton_booked.Checked)
            {
                try
                {
                    using (var context = new DatabaseContext())
                    {
                        try
                        {

                            int contractID = int.Parse(label_contractID.Text);
                            Model.Contract contract = context.Contracts.OfType<Model.LoanContract>().Where(u => u.ID == contractID).FirstOrDefault();

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
            else if (isDone!=true && radioButton_done.Checked)
            {
                try
                {
                    using (var context = new DatabaseContext())
                    {
                        try
                        {

                            int contractID = int.Parse(label_contractID.Text);
                            Model.Contract contract = context.Contracts.OfType<Model.LoanContract>().Where(u => u.ID == contractID).FirstOrDefault();

                            if (contract == null)
                            {
                                MessageBox.Show("Don't exist this contract");
                            }
                            else
                            {

                                contract.status = "Done";
                                contract.dateEndActual = DateTime.Now;
                                contract.fee = float.Parse(textBox_fee.Text);
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

        private void DetailLoanContractForm_Load(object sender, EventArgs e)
        {
            using(var context = new DatabaseContext())
            {
                var con = context.Contracts.OfType<Model.LoanContract>().Where(t => t.ID == int.Parse(label_contractID.Text)).FirstOrDefault();
                textBox_fee.Text = con.fee.ToString();
            }    
        }
    }
}
