using FinalWindow.Database;
using FinalWindow.View.Customer.LoanContractForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalWindow.View.Customer
{
    public partial class LoanServiceForm : Form
    {

        public LoanServiceForm()
        {
            InitializeComponent();
        }

        private static int contractID;
        private static string vehicleType;
        private static string period;
        private static int vehicleID;

        public static string VehicleType { get => vehicleType; set => vehicleType = value; }
        public static string Period1 { get => period; set => period = value; }
        public static int VehicleID { get => vehicleID; set => vehicleID = value; }
        public static int ContractID { get => contractID; set => contractID = value; }

        private void load()
        {
            
           
        }

        private void LoanServiceForm_Load(object sender, EventArgs e)
        {
            

        }

        private void button_Find_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(comboBox_vehicle.Text) || String.IsNullOrEmpty(textBox_period.Text))
            {
                MessageBox.Show("Please choose option");
                return;
            }
            DateTime today = DateTime.Now;
            DateTime check = today.AddDays(double.Parse(textBox_period.Text));
            MessageBox.Show(check.ToString());
            if (comboBox_vehicle.Text == "Car")
            {
                try
                {
                    using (var context = new DatabaseContext())
                    {

                        var vehicle = context.Vehicles.OfType<Model.Car>().Where(t => t.status == "In")
                            .Join(context.Contracts.OfType<Model.LongTermKeepContract>().Where(t => t.is_Loan == true && t.dateEnd > check && t.status == "Active"),
                            Vehicle => Vehicle.ID,
                            contract => contract.carID,
                            (Vehicle, contract) => new
                            {
                                Vehicle.ID,
                                Vehicle.name,
                                Vehicle.branch,
                                contractID = contract.ID,
                                Vehicle.seat,
                                Vehicle.picture,

                            });
                        if (vehicle.FirstOrDefault() == null)
                        {
                            MessageBox.Show("No option for you");
                            return;
                        }


                        dataGridView_listLoanVehicle.DataSource = vehicle.ToList();
                        dataGridView_listLoanVehicle.Columns[3].Visible = false;
                        DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                        if((DataGridViewImageColumn)dataGridView_listLoanVehicle.Columns[5] != null)
                        {
                            picCol = (DataGridViewImageColumn)dataGridView_listLoanVehicle.Columns[5];
                            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                        }
                        
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            

           else if (comboBox_vehicle.Text == "Truck")
            {
                try
                {
                    using (var context = new DatabaseContext())
                    {
                        var vehicle = context.Vehicles.OfType<Model.Truck>().Where(t => t.status == "In")
                            .Join(context.Contracts.OfType<Model.LongTermKeepContract>().Where(t => t.is_Loan == true && t.dateEnd > check && t.status == "Active"),
                            Vehicle => Vehicle.ID,
                            contract => contract.carID,
                            (Vehicle, contract) => new
                            {
                                Vehicle.ID,
                                Vehicle.name,
                                Vehicle.branch,
                                contractID = contract.ID,
                                Vehicle.tonnage,
                                Vehicle.picture

                            });

                        if (vehicle.FirstOrDefault() == null)
                        {
                            MessageBox.Show("No option for you");
                            return;
                        }

                        dataGridView_listLoanVehicle.DataSource = vehicle.ToList();
                        dataGridView_listLoanVehicle.Columns[3].Visible = false;

                        DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                        picCol = (DataGridViewImageColumn)dataGridView_listLoanVehicle.Columns[5];
                        picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.InnerException.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }    

            else
            {
                try
                {
                    using (var context = new DatabaseContext())
                    {
                        var vehicle = context.Vehicles.OfType<Model.Motor>().Where(t => t.status == "In")
                            .Join(context.Contracts.OfType<Model.LongTermKeepContract>().Where(t => t.is_Loan == true && t.dateEnd > check && t.status == "Active"),
                            Vehicle => Vehicle.ID,
                            contract => contract.carID,
                            (Vehicle, contract) => new
                            {
                                Vehicle.ID,
                                Vehicle.name,
                                Vehicle.branch,
                                contractID = contract.ID,
                                Vehicle.picture
                            });
                            

                        if (vehicle.FirstOrDefault() == null)
                        {
                            MessageBox.Show("No option for you");
                            return;
                        }

                        dataGridView_listLoanVehicle.DataSource = vehicle.ToList();
                        dataGridView_listLoanVehicle.Columns[3].Visible = false;
                        DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                        picCol = (DataGridViewImageColumn)dataGridView_listLoanVehicle.Columns[4];
                        picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.InnerException.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }    
                
        }

        private void dataGridView_listLoanVehicle_DoubleClick(object sender, EventArgs e)
        {
            CreateLoanContract createLoan = new CreateLoanContract();
            createLoan.textBox_Vehicle.Text = dataGridView_listLoanVehicle.CurrentRow.Cells[1].ToString() +" - "+ dataGridView_listLoanVehicle.CurrentRow.Cells[2].ToString();
            vehicleType = comboBox_vehicle.Text;
            period = textBox_period.Text;
            contractID = int.Parse(dataGridView_listLoanVehicle.CurrentRow.Cells[3].Value.ToString());
            vehicleID = int.Parse( dataGridView_listLoanVehicle.CurrentRow.Cells[0].Value.ToString() );
            createLoan.Show();

        }

        private void dataGridView_listLoanVehicle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
