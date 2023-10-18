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

namespace FinalWindow.View.Director.List
{
    public partial class ListLoanContractForm : Form
    {
        private int facilityID;

        public int FacilityID { get => facilityID; set => facilityID = value; }

        public ListLoanContractForm()
        {
            InitializeComponent();
        }

        private void button_fineActive_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox_fineActive.Text) || string.IsNullOrEmpty(textBox_fineActive.Text))
            {
                MessageBox.Show("Please enter all information");
                return;
            }
            using (var context = new DatabaseContext())
            {
                if (comboBox_fineActive.Text == "Type contract")
                {

                    var contract = context.Contracts.OfType<Model.LoanContract>().Where(t => t.status == "Active" && t.facilityId == FacilityID).Select(u => new
                    {
                        ContractID = u.ID,
                        ContractName = u.name,
                        CustomerFullName = u.Customer.firstName + u.Customer.lastName,
                        CustomerID = u.Customer.ID,

                        DateCreate = u.dateCreate,
                        DateEnd = u.dateEnd,
                        DateActualStart = u.dateStartActual,
                        DateActualEnd = u.dateEndActual,

                        Status = u.status
                    }).ToList();
                    dataGridView_listActiveLoan.DataSource = contract;
                }
                else
                {
                    if (textBox_fineActive.Text == "Car" || textBox_fineActive.Text == "car")
                    {
                        var contract = context.Contracts.OfType<Model.LoanContract>().Where(t => t.status == "Active" && t.facilityId == FacilityID && t.carID != null).Select(u => new
                        {
                            ContractID = u.ID,
                            ContractName = u.name,
                            CustomerFullName = u.Customer.firstName + u.Customer.lastName,
                            CustomerID = u.Customer.ID,

                            DateCreate = u.dateCreate,
                            DateEnd = u.dateEnd,
                            DateActualStart = u.dateStartActual,
                            DateActualEnd = u.dateEndActual,

                            Status = u.status
                        }).ToList();
                        dataGridView_listActiveLoan.DataSource = contract;
                    }
                    else if (textBox_fineActive.Text == "Motor" || textBox_fineActive.Text == "motor")
                    {
                        var contract = context.Contracts.OfType<Model.LoanContract>().Where(t => t.status == "Active" && t.facilityId == FacilityID && t.motorID != null).Select(u => new
                        {
                            ContractID = u.ID,
                            ContractName = u.name,
                            CustomerFullName = u.Customer.firstName + u.Customer.lastName,
                            CustomerID = u.Customer.ID,

                            DateCreate = u.dateCreate,
                            DateEnd = u.dateEnd,
                            DateActualStart = u.dateStartActual,
                            DateActualEnd = u.dateEndActual,

                            Status = u.status
                        }).ToList();
                        dataGridView_listActiveLoan.DataSource = contract;
                    }
                    else if (textBox_fineActive.Text == "Truck" || textBox_fineActive.Text == "truck")
                    {
                        var contract = context.Contracts.OfType<Model.LoanContract>().Where(t => t.status == "Active" && t.facilityId == FacilityID && t.truckID != null).Select(u => new
                        {
                            ContractID = u.ID,
                            ContractName = u.name,
                            CustomerFullName = u.Customer.firstName + u.Customer.lastName,
                            CustomerID = u.Customer.ID,

                            DateCreate = u.dateCreate,
                            DateEnd = u.dateEnd,
                            DateActualStart = u.dateStartActual,
                            DateActualEnd = u.dateEndActual,

                            Status = u.status
                        }).ToList();
                        dataGridView_listActiveLoan.DataSource = contract;
                    }
                    else
                    {
                        MessageBox.Show("Don't exist this type of vehicle");
                        return;
                    }
                }
            }
        }

        private void button_fineDone_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox_fineDone.Text) || string.IsNullOrEmpty(comboBox_fineDone.Text))
            {
                MessageBox.Show("Please enter all information");
                return;
            }
            using (var context = new DatabaseContext())
            {
                if (comboBox_fineDone.Text == "Type contract")
                {

                    var contract = context.Contracts.OfType<Model.LoanContract>().Where(t => t.status == "Done" && t.facilityId == FacilityID).Select(u => new
                    {
                        ContractID = u.ID,
                        ContractName = u.name,
                        CustomerFullName = u.Customer.firstName + u.Customer.lastName,
                        CustomerID = u.Customer.ID,

                        DateCreate = u.dateCreate,
                        DateEnd = u.dateEnd,
                        DateActualStart = u.dateStartActual,
                        DateActualEnd = u.dateEndActual,

                        Status = u.status
                    }).ToList();
                    dataGridView_listActiveLoan.DataSource = contract;
                }
                else
                {
                    if (textBox_fineDone.Text == "Car" || textBox_fineDone.Text == "car")
                    {
                        var contract = context.Contracts.OfType<Model.LoanContract>().Where(t => t.status == "Done" && t.facilityId == FacilityID && t.carID != null).Select(u => new
                        {
                            ContractID = u.ID,
                            ContractName = u.name,
                            CustomerFullName = u.Customer.firstName + u.Customer.lastName,
                            CustomerID = u.Customer.ID,

                            DateCreate = u.dateCreate,
                            DateEnd = u.dateEnd,
                            DateActualStart = u.dateStartActual,
                            DateActualEnd = u.dateEndActual,

                            Status = u.status
                        }).ToList();
                        dataGridView_listActiveLoan.DataSource = contract;
                    }
                    else if (textBox_fineDone.Text == "Motor" || textBox_fineDone.Text == "motor")
                    {
                        var contract = context.Contracts.OfType<Model.LoanContract>().Where(t => t.status == "Done" && t.facilityId == FacilityID && t.motorID != null).Select(u => new
                        {
                            ContractID = u.ID,
                            ContractName = u.name,
                            CustomerFullName = u.Customer.firstName + u.Customer.lastName,
                            CustomerID = u.Customer.ID,

                            DateCreate = u.dateCreate,
                            DateEnd = u.dateEnd,
                            DateActualStart = u.dateStartActual,
                            DateActualEnd = u.dateEndActual,

                            Status = u.status
                        }).ToList();
                        dataGridView_listActiveLoan.DataSource = contract;
                    }
                    else if (textBox_fineDone.Text == "Truck" || textBox_fineDone.Text == "truck")
                    {
                        var contract = context.Contracts.OfType<Model.LoanContract>().Where(t => t.status == "Done" && t.facilityId == FacilityID && t.truckID != null).Select(u => new
                        {
                            ContractID = u.ID,
                            ContractName = u.name,
                            CustomerFullName = u.Customer.firstName + u.Customer.lastName,
                            CustomerID = u.Customer.ID,

                            DateCreate = u.dateCreate,
                            DateEnd = u.dateEnd,
                            DateActualStart = u.dateStartActual,
                            DateActualEnd = u.dateEndActual,

                            Status = u.status
                        }).ToList();
                        dataGridView_listActiveLoan.DataSource = contract;
                    }
                    else
                    {
                        MessageBox.Show("Don't exist this type of vehicle");
                        return;
                    }
                }
            }
        }

        private void ListLoanContractForm_Load(object sender, EventArgs e)
        {
            loadDataGridview();
        }

        private void loadDataGridview()
        {
            using (var context = new DatabaseContext())
            {

                var contract1 = context.Contracts.OfType<Model.LoanContract>().Where(t => t.status == "Active" && t.facilityId == FacilityID).Select(u => new
                {
                    ContractID = u.ID,
                    ContractName = u.name,
                    CustomerFullName = u.Customer.firstName + u.Customer.lastName,
                    CustomerID = u.Customer.ID,
                    DateCreate = u.dateCreate,
                    DateEnd = u.dateEnd,
                    DateActualStart = u.dateStartActual,
                    DateActualEnd = u.dateEndActual,

                    Status = u.status
                }).ToList();

                dataGridView_listActiveLoan.DataSource = contract1;

                var contract2 = context.Contracts.OfType<Model.LoanContract>().Where(t => t.status == "Done" && t.facilityId == FacilityID).Select(u => new
                {
                    ContractID = u.ID,
                    ContractName = u.name,
                    CustomerFullName = u.Customer.firstName + u.Customer.lastName,
                    CustomerID = u.Customer.ID,

                    DateCreate = u.dateCreate,
                    DateEnd = u.dateEnd,
                    DateActualStart = u.dateStartActual,
                    DateActualEnd = u.dateEndActual,

                    Status = u.status
                }).ToList();

                dataGridView_listDoneLoan.DataSource = contract2;


                var contract3 = context.Contracts.OfType<Model.LoanContract>().Where(t => t.status == "Booked" && t.facilityId == FacilityID).Select(u => new
                {
                    ContractID = u.ID,
                    ContractName = u.name,
                    CustomerFullName = u.Customer.firstName + u.Customer.lastName,
                    CustomerID = u.Customer.ID,

                    DateCreate = u.dateCreate,
                    DateEnd = u.dateEnd,
                    DateActualStart = u.dateStartActual,
                    DateActualEnd = u.dateEndActual,

                    Status = u.status
                }).ToList();

                dataGridView_listBookedLoan.DataSource = contract3;
            }

        }

        private void button_FineBooked_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox_fineBooked.Text) || string.IsNullOrEmpty(comboBox_fineBooked.Text))
            {
                MessageBox.Show("Please enter all information");
                return;
            }
            using (var context = new DatabaseContext())
            {
                if (comboBox_fineDone.Text == "Type contract")
                {

                    var contract = context.Contracts.OfType<Model.LoanContract>().Where(t => t.status == "Booked" && t.facilityId == FacilityID).Select(u => new
                    {
                        ContractID = u.ID,
                        ContractName = u.name,
                        CustomerFullName = u.Customer.firstName + u.Customer.lastName,
                        CustomerID = u.Customer.ID,

                        DateCreate = u.dateCreate,
                        DateEnd = u.dateEnd,
                        DateActualStart = u.dateStartActual,
                        DateActualEnd = u.dateEndActual,

                        Status = u.status
                    }).ToList();
                    dataGridView_listActiveLoan.DataSource = contract;
                }
                else
                {
                    if (textBox_fineBooked.Text == "Car" || textBox_fineBooked.Text == "car")
                    {
                        var contract = context.Contracts.OfType<Model.LoanContract>().Where(t => t.status == "Booked" && t.facilityId == FacilityID && t.carID != null).Select(u => new
                        {
                            ContractID = u.ID,
                            ContractName = u.name,
                            CustomerFullName = u.Customer.firstName + u.Customer.lastName,
                            CustomerID = u.Customer.ID,

                            DateCreate = u.dateCreate,
                            DateEnd = u.dateEnd,
                            DateActualStart = u.dateStartActual,
                            DateActualEnd = u.dateEndActual,

                            Status = u.status
                        }).ToList();
                        dataGridView_listActiveLoan.DataSource = contract;
                    }
                    else if (textBox_fineBooked.Text == "Motor" || textBox_fineBooked.Text == "motor")
                    {
                        var contract = context.Contracts.OfType<Model.LoanContract>().Where(t => t.status == "Booked" && t.facilityId == FacilityID && t.motorID != null).Select(u => new
                        {
                            ContractID = u.ID,
                            ContractName = u.name,
                            CustomerFullName = u.Customer.firstName + u.Customer.lastName,
                            CustomerID = u.Customer.ID,

                            DateCreate = u.dateCreate,
                            DateEnd = u.dateEnd,
                            DateActualStart = u.dateStartActual,
                            DateActualEnd = u.dateEndActual,

                            Status = u.status
                        }).ToList();
                        dataGridView_listActiveLoan.DataSource = contract;
                    }
                    else if (textBox_fineBooked.Text == "Truck" || textBox_fineBooked.Text == "truck")
                    {
                        var contract = context.Contracts.OfType<Model.LoanContract>().Where(t => t.status == "Booked" && t.facilityId == FacilityID && t.truckID != null).Select(u => new
                        {
                            ContractID = u.ID,
                            ContractName = u.name,
                            CustomerFullName = u.Customer.firstName + u.Customer.lastName,
                            CustomerID = u.Customer.ID,

                            DateCreate = u.dateCreate,
                            DateEnd = u.dateEnd,
                            DateActualStart = u.dateStartActual,
                            DateActualEnd = u.dateEndActual,

                            Status = u.status
                        }).ToList();
                        dataGridView_listActiveLoan.DataSource = contract;
                    }
                    else
                    {
                        MessageBox.Show("Don't exist this type of vehicle");
                        return;
                    }
                }
            }
        }

        private void dataGridView_listActiveLoan_DoubleClick(object sender, EventArgs e)
        {
            DetailLoanContractForm detailLoanContractForm = new DetailLoanContractForm();
            detailLoanContractForm.label_contractID.Text = dataGridView_listActiveLoan.CurrentRow.Cells["ContractID"].Value.ToString();
            detailLoanContractForm.label_contractName.Text = dataGridView_listActiveLoan.CurrentRow.Cells["ContractName"].Value.ToString();
            detailLoanContractForm.label_customerName.Text = dataGridView_listActiveLoan.CurrentRow.Cells["CustomerFullName"].Value.ToString();
            detailLoanContractForm.label_cusID.Text = dataGridView_listActiveLoan.CurrentRow.Cells["CustomerID"].Value.ToString();
            //detailLoanContractForm.label_vehicleType.Text = dataGridView_listActiveLoan.CurrentRow.Cells["VehicleType"].Value.ToString();
            //detailLoanContractForm.label_dateCreate.Text = dataGridView_listActiveLoan.CurrentRow.Cells["DateCreate"].Value.ToString();
            //detailLoanContractForm.label_dateActualCreate.Text = dataGridView_listActiveLoan.CurrentRow.Cells["DateActualStart"].Value.ToString();
            //detailLoanContractForm.label_dateEnd.Text = dataGridView_listActiveLoan.CurrentRow.Cells["DateEnd"].Value.ToString();
            //detailLoanContractForm.label_dateActualEnd.Text = dataGridView_listActiveLoan.CurrentRow.Cells["DateActualEnd"].Value.ToString();
            detailLoanContractForm.label_status.Text = dataGridView_listActiveLoan.CurrentRow.Cells["Status"].Value.ToString();

            if (dataGridView_listActiveLoan.CurrentRow.Cells["Status"].Value.ToString() == "Active")
            {
                detailLoanContractForm.radioButton_active.Checked = true;
                detailLoanContractForm.isActive = true;
            }
            detailLoanContractForm.Show();
        }

        private void dataGridView_listDoneLoan_DoubleClick(object sender, EventArgs e)
        {
            DetailLoanContractForm detailLoanContractForm = new DetailLoanContractForm();
            detailLoanContractForm.label_contractID.Text = dataGridView_listDoneLoan.CurrentRow.Cells["ContractID"].Value.ToString();
            detailLoanContractForm.label_contractName.Text = dataGridView_listDoneLoan.CurrentRow.Cells["ContractName"].Value.ToString();
            detailLoanContractForm.label_customerName.Text = dataGridView_listDoneLoan.CurrentRow.Cells["CustomerFullName"].Value.ToString();
            detailLoanContractForm.label_cusID.Text = dataGridView_listDoneLoan.CurrentRow.Cells["CustomerID"].Value.ToString();
            //detailLoanContractForm.label_vehicleType.Text = dataGridView_listDoneLoan.CurrentRow.Cells["VehicleType"].Value.ToString();
            //detailLoanContractForm.label_dateCreate.Text = dataGridView_listDoneLoan.CurrentRow.Cells["DateCreate"].Value.ToString();
            //detailLoanContractForm.label_dateActualCreate.Text = dataGridView_listDoneLoan.CurrentRow.Cells["DateActualStart"].Value.ToString();
            //detailLoanContractForm.label_dateEnd.Text = dataGridView_listDoneLoan.CurrentRow.Cells["DateEnd"].Value.ToString();
            //detailLoanContractForm.label_dateActualEnd.Text = dataGridView_listDoneLoan.CurrentRow.Cells["DateActualEnd"].Value.ToString();
            detailLoanContractForm.label_status.Text = dataGridView_listDoneLoan.CurrentRow.Cells["Status"].Value.ToString();

            if (dataGridView_listDoneLoan.CurrentRow.Cells["Status"].Value.ToString() == "Active")
            {
                detailLoanContractForm.radioButton_done.Checked = true;
                detailLoanContractForm.isDone   = true;
            }
            detailLoanContractForm.Show();
        }

        private void dataGridView_listBookedLoan_DoubleClick(object sender, EventArgs e)
        {
            DetailLoanContractForm detailLoanContractForm = new DetailLoanContractForm();
            detailLoanContractForm.label_contractID.Text = dataGridView_listBookedLoan.CurrentRow.Cells["ContractID"].Value.ToString();
            detailLoanContractForm.label_contractName.Text = dataGridView_listBookedLoan.CurrentRow.Cells["ContractName"].Value.ToString();
            detailLoanContractForm.label_customerName.Text = dataGridView_listBookedLoan.CurrentRow.Cells["CustomerFullName"].Value.ToString();
            detailLoanContractForm.label_cusID.Text = dataGridView_listBookedLoan.CurrentRow.Cells["CustomerID"].Value.ToString();
            //detailLoanContractForm.label_vehicleType.Text = dataGridView_listBookedLoan.CurrentRow.Cells["VehicleType"].Value.ToString();
            //detailLoanContractForm.label_dateCreate.Text = dataGridView_listBookedLoan.CurrentRow.Cells["DateCreate"].Value.ToString();
            //detailLoanContractForm.label_dateActualCreate.Text = dataGridView_listBookedLoan.CurrentRow.Cells["DateActualStart"].Value.ToString();
            //detailLoanContractForm.label_dateEnd.Text = dataGridView_listBookedLoan.CurrentRow.Cells["DateEnd"].Value.ToString();
            //detailLoanContractForm.label_dateActualEnd.Text = dataGridView_listBookedLoan.CurrentRow.Cells["DateActualEnd"].Value.ToString();
            detailLoanContractForm.label_status.Text = dataGridView_listBookedLoan.CurrentRow.Cells["Status"].Value.ToString();

            if (dataGridView_listBookedLoan.CurrentRow.Cells["Status"].Value.ToString() == "Active")
            {
                detailLoanContractForm.radioButton_booked.Checked = true;
                detailLoanContractForm.isBooked = true;
            }
            detailLoanContractForm.Show();
        }
    }
}
