using FinalWindow.Database;
using FinalWindow.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalWindow.View.Director.List
{
    public partial class ListLongContractForm : Form
    {
        private int facilityID;

        public int FacilityID { get => facilityID; set => facilityID = value; }

        public ListLongContractForm()
        {
            InitializeComponent();
        }

        private void ListLongContractForm_Load(object sender, EventArgs e)
        {
            loadDataGridview();
        }

        private void loadDataGridview()
        {
            using (var context = new DatabaseContext())
            {

                var contract1 = context.Contracts.OfType<Model.LongTermKeepContract>().Where(t => t.status == "Active" && t.facilityId == FacilityID).Select(u => new
                {
                    ContractID = u.ID,
                    ContractName = u.name,
                    CustomerFullName = u.Customer.firstName + u.Customer.lastName,
                    CustomerID = u.Customer.ID,
                    DateCreate = u.dateCreate,
                    DateEnd = u.dateEnd,
                    DateActualStart = u.dateStartActual,
                    DateActualEnd = u.dateEndActual,
                    TypeContract = u.typeContract,
                    Status = u.status
                }).ToList();

                dataGridView_listActiveLong.DataSource = contract1;

                var contract2 = context.Contracts.OfType<Model.LongTermKeepContract>().Where(t => t.status == "Done" && t.facilityId == FacilityID).Select(u => new
                {
                    ContractID = u.ID,
                    ContractName = u.name,
                    CustomerFullName = u.Customer.firstName + u.Customer.lastName,
                    CustomerID = u.Customer.ID,

                    DateCreate = u.dateCreate,
                    DateEnd = u.dateEnd,
                    DateActualStart = u.dateStartActual,
                    DateActualEnd = u.dateEndActual,
                    TypeContract = u.typeContract,
                    Status = u.status
                }).ToList();

                dataGridView_listDoneLong.DataSource = contract2;


                var contract3 = context.Contracts.OfType<Model.LongTermKeepContract>().Where(t => t.status == "Booked" && t.facilityId == FacilityID).Select(u => new
                {
                    ContractID = u.ID,
                    ContractName = u.name,
                    CustomerFullName = u.Customer.firstName + u.Customer.lastName,
                    CustomerID = u.Customer.ID,

                    DateCreate = u.dateCreate,
                    DateEnd = u.dateEnd,
                    DateActualStart = u.dateStartActual,
                    DateActualEnd = u.dateEndActual,
                    TypeContract = u.typeContract,
                    Status = u.status
                }).ToList();

                dataGridView_listBookedLong.DataSource = contract3;
            }

        }

        private void button_fineActive_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(comboBox_fineActive.Text) || string.IsNullOrEmpty(textBox_fineActive.Text))
            {
                MessageBox.Show("Please enter all information");
                return;
            }
            using (var context = new DatabaseContext())
            {
                if (comboBox_fineActive.Text == "Type contract")
                {

                    var contract = context.Contracts.OfType<Model.LongTermKeepContract>().Where(t => t.status == "Active" && t.facilityId == FacilityID && t.typeContract == textBox_fineActive.Text).Select(u => new
                    {
                        ContractID = u.ID,
                        ContractName = u.name,
                        CustomerFullName = u.Customer.firstName + u.Customer.lastName,
                        CustomerID = u.Customer.ID,

                        DateCreate = u.dateCreate,
                        DateEnd = u.dateEnd,
                        DateActualStart = u.dateStartActual,
                        DateActualEnd = u.dateEndActual,
                        TypeContract = u.typeContract,
                        Status = u.status
                    }).ToList();
                    dataGridView_listActiveLong.DataSource = contract;
                }
                else
                {
                    if (textBox_fineActive.Text == "Car" || textBox_fineActive.Text == "car")
                    {
                        var contract = context.Contracts.OfType<Model.LongTermKeepContract>().Where(t => t.status == "Active" && t.facilityId == FacilityID && t.carID != null).Select(u => new
                        {
                            ContractID = u.ID,
                            ContractName = u.name,
                            CustomerFullName = u.Customer.firstName + u.Customer.lastName,
                            CustomerID = u.Customer.ID,

                            DateCreate = u.dateCreate,
                            DateEnd = u.dateEnd,
                            DateActualStart = u.dateStartActual,
                            DateActualEnd = u.dateEndActual,
                            TypeContract = u.typeContract,
                            Status = u.status
                        }).ToList();
                        dataGridView_listActiveLong.DataSource = contract;
                    }
                    else if (textBox_fineActive.Text == "Motor" || textBox_fineActive.Text == "motor")
                    {
                        var contract = context.Contracts.OfType<Model.LongTermKeepContract>().Where(t => t.status == "Active" && t.facilityId == FacilityID && t.motorID != null).Select(u => new
                        {
                            ContractID = u.ID,
                            ContractName = u.name,
                            CustomerFullName = u.Customer.firstName + u.Customer.lastName,
                            CustomerID = u.Customer.ID,

                            DateCreate = u.dateCreate,
                            DateEnd = u.dateEnd,
                            DateActualStart = u.dateStartActual,
                            DateActualEnd = u.dateEndActual,
                            TypeContract = u.typeContract,
                            Status = u.status
                        }).ToList();
                        dataGridView_listActiveLong.DataSource = contract;
                    }
                    else if (textBox_fineActive.Text == "Truck" || textBox_fineActive.Text == "truck")
                    {
                        var contract = context.Contracts.OfType<Model.LongTermKeepContract>().Where(t => t.status == "Active" && t.facilityId == FacilityID && t.truckID != null).Select(u => new
                        {
                            ContractID = u.ID,
                            ContractName = u.name,
                            CustomerFullName = u.Customer.firstName + u.Customer.lastName,
                            CustomerID = u.Customer.ID,

                            DateCreate = u.dateCreate,
                            DateEnd = u.dateEnd,
                            DateActualStart = u.dateStartActual,
                            DateActualEnd = u.dateEndActual,
                            TypeContract = u.typeContract,
                            Status = u.status
                        }).ToList();
                        dataGridView_listActiveLong.DataSource = contract;
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

                    var contract = context.Contracts.OfType<Model.LongTermKeepContract>().Where(t => t.status == "Done" && t.facilityId == FacilityID && t.typeContract == textBox_fineDone.Text).Select(u => new
                    {
                        ContractID = u.ID,
                        ContractName = u.name,
                        CustomerFullName = u.Customer.firstName + u.Customer.lastName,
                        CustomerID = u.Customer.ID,

                        DateCreate = u.dateCreate,
                        DateEnd = u.dateEnd,
                        DateActualStart = u.dateStartActual,
                        DateActualEnd = u.dateEndActual,
                        TypeContract = u.typeContract,
                        Status = u.status
                    }).ToList();
                    dataGridView_listActiveLong.DataSource = contract;
                }
                else
                {
                    if (textBox_fineDone.Text == "Car" || textBox_fineDone.Text == "car")
                    {
                        var contract = context.Contracts.OfType<Model.LongTermKeepContract>().Where(t => t.status == "Done" && t.facilityId == FacilityID && t.carID != null).Select(u => new
                        {
                            ContractID = u.ID,
                            ContractName = u.name,
                            CustomerFullName = u.Customer.firstName + u.Customer.lastName,
                            CustomerID = u.Customer.ID,

                            DateCreate = u.dateCreate,
                            DateEnd = u.dateEnd,
                            DateActualStart = u.dateStartActual,
                            DateActualEnd = u.dateEndActual,
                            TypeContract = u.typeContract,
                            Status = u.status
                        }).ToList();
                        dataGridView_listActiveLong.DataSource = contract;
                    }
                    else if (textBox_fineDone.Text == "Motor" || textBox_fineDone.Text == "motor")
                    {
                        var contract = context.Contracts.OfType<Model.LongTermKeepContract>().Where(t => t.status == "Done" && t.facilityId == FacilityID && t.motorID != null).Select(u => new
                        {
                            ContractID = u.ID,
                            ContractName = u.name,
                            CustomerFullName = u.Customer.firstName + u.Customer.lastName,
                            CustomerID = u.Customer.ID,

                            DateCreate = u.dateCreate,
                            DateEnd = u.dateEnd,
                            DateActualStart = u.dateStartActual,
                            DateActualEnd = u.dateEndActual,
                            TypeContract = u.typeContract,
                            Status = u.status
                        }).ToList();
                        dataGridView_listActiveLong.DataSource = contract;
                    }
                    else if (textBox_fineDone.Text == "Truck" || textBox_fineDone.Text == "truck")
                    {
                        var contract = context.Contracts.OfType<Model.LongTermKeepContract>().Where(t => t.status == "Done" && t.facilityId == FacilityID && t.truckID != null).Select(u => new
                        {
                            ContractID = u.ID,
                            ContractName = u.name,
                            CustomerFullName = u.Customer.firstName + u.Customer.lastName,
                            CustomerID = u.Customer.ID,

                            DateCreate = u.dateCreate,
                            DateEnd = u.dateEnd,
                            DateActualStart = u.dateStartActual,
                            DateActualEnd = u.dateEndActual,
                            TypeContract = u.typeContract,
                            Status = u.status
                        }).ToList();
                        dataGridView_listActiveLong.DataSource = contract;
                    }
                    else
                    {
                        MessageBox.Show("Don't exist this type of vehicle");
                        return;
                    }
                }
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

                    var contract = context.Contracts.OfType<Model.LongTermKeepContract>().Where(t => t.status == "Booked" && t.facilityId == FacilityID && t.typeContract == textBox_fineBooked.Text).Select(u => new
                    {
                        ContractID = u.ID,
                        ContractName = u.name,
                        CustomerFullName = u.Customer.firstName + u.Customer.lastName,
                        CustomerID = u.Customer.ID,

                        DateCreate = u.dateCreate,
                        DateEnd = u.dateEnd,
                        DateActualStart = u.dateStartActual,
                        DateActualEnd = u.dateEndActual,
                        TypeContract = u.typeContract,
                        Status = u.status
                    }).ToList();
                    dataGridView_listActiveLong.DataSource = contract;
                }
                else
                {
                    if (textBox_fineBooked.Text == "Car" || textBox_fineBooked.Text == "car")
                    {
                        var contract = context.Contracts.OfType<Model.LongTermKeepContract>().Where(t => t.status == "Booked" && t.facilityId == FacilityID && t.carID != null).Select(u => new
                        {
                            ContractID = u.ID,
                            ContractName = u.name,
                            CustomerFullName = u.Customer.firstName + u.Customer.lastName,
                            CustomerID = u.Customer.ID,

                            DateCreate = u.dateCreate,
                            DateEnd = u.dateEnd,
                            DateActualStart = u.dateStartActual,
                            DateActualEnd = u.dateEndActual,
                            TypeContract = u.typeContract,
                            Status = u.status
                        }).ToList();
                        dataGridView_listActiveLong.DataSource = contract;
                    }
                    else if (textBox_fineBooked.Text == "Motor" || textBox_fineBooked.Text == "motor")
                    {
                        var contract = context.Contracts.OfType<Model.LongTermKeepContract>().Where(t => t.status == "Booked" && t.facilityId == FacilityID && t.motorID != null).Select(u => new
                        {
                            ContractID = u.ID,
                            ContractName = u.name,
                            CustomerFullName = u.Customer.firstName + u.Customer.lastName,
                            CustomerID = u.Customer.ID,

                            DateCreate = u.dateCreate,
                            DateEnd = u.dateEnd,
                            DateActualStart = u.dateStartActual,
                            DateActualEnd = u.dateEndActual,
                            TypeContract = u.typeContract,
                            Status = u.status
                        }).ToList();
                        dataGridView_listActiveLong.DataSource = contract;
                    }
                    else if (textBox_fineBooked.Text == "Truck" || textBox_fineBooked.Text == "truck")
                    {
                        var contract = context.Contracts.OfType<Model.LongTermKeepContract>().Where(t => t.status == "Booked" && t.facilityId == FacilityID && t.truckID != null).Select(u => new
                        {
                            ContractID = u.ID,
                            ContractName = u.name,
                            CustomerFullName = u.Customer.firstName + u.Customer.lastName,
                            CustomerID = u.Customer.ID,

                            DateCreate = u.dateCreate,
                            DateEnd = u.dateEnd,
                            DateActualStart = u.dateStartActual,
                            DateActualEnd = u.dateEndActual,
                            TypeContract = u.typeContract,
                            Status = u.status
                        }).ToList();
                        dataGridView_listActiveLong.DataSource = contract;
                    }
                    else
                    {
                        MessageBox.Show("Don't exist this type of vehicle");
                        return;
                    }
                }
            }
        }

        private void dataGridView_listBookedLong_DoubleClick(object sender, EventArgs e)
        {
            DetailLongContractForm detailLongContractForm = new DetailLongContractForm();
            detailLongContractForm.label_contractID.Text = dataGridView_listBookedLong.CurrentRow.Cells["ContractID"].Value.ToString();
            detailLongContractForm.label_contractName.Text = dataGridView_listBookedLong.CurrentRow.Cells["ContractName"].Value.ToString();
            detailLongContractForm.label_customerName.Text = dataGridView_listBookedLong.CurrentRow.Cells["CustomerFullName"].Value.ToString();
            detailLongContractForm.label_cusID.Text = dataGridView_listBookedLong.CurrentRow.Cells["CustomerID"].Value.ToString();
            //detailLongContractForm.label_vehicleType.Text = dataGridView_listBookedLong.CurrentRow.Cells["VehicleType"].Value.ToString();
            //detailLongContractForm.label_dateCreate.Text = dataGridView_listBookedLong.CurrentRow.Cells["DateCreate"].Value.ToString();
            //detailLongContractForm.label_dateActualCreate.Text = dataGridView_listBookedLong.CurrentRow.Cells["DateActualStart"].Value.ToString();
            //detailLongContractForm.label_dateEnd.Text = dataGridView_listBookedLong.CurrentRow.Cells["DateEnd"].Value.ToString();
            //detailLongContractForm.label_dateActualEnd.Text = dataGridView_listBookedLong.CurrentRow.Cells["DateActualEnd"].Value.ToString();
            detailLongContractForm.label_status.Text = dataGridView_listBookedLong.CurrentRow.Cells["Status"].Value.ToString();

            if (dataGridView_listBookedLong.CurrentRow.Cells["Status"].Value.ToString() == "Booked")
            {
                detailLongContractForm.radioButton_booked.Checked = true;
                detailLongContractForm.isBooked =true;
            }
            detailLongContractForm.Show();
        }

        private void dataGridView_listActiveLong_DoubleClick(object sender, EventArgs e)
        {
            DetailLongContractForm detailLongContractForm = new DetailLongContractForm();
            detailLongContractForm.label_contractID.Text = dataGridView_listActiveLong.CurrentRow.Cells["ContractID"].Value.ToString();
            detailLongContractForm.label_contractName.Text = dataGridView_listActiveLong.CurrentRow.Cells["ContractName"].Value.ToString();
            detailLongContractForm.label_customerName.Text = dataGridView_listActiveLong.CurrentRow.Cells["CustomerFullName"].Value.ToString();
            detailLongContractForm.label_cusID.Text = dataGridView_listActiveLong.CurrentRow.Cells["CustomerID"].Value.ToString();
            //detailLongContractForm.label_vehicleType.Text = dataGridView_listActiveLong.CurrentRow.Cells["VehicleType"].Value.ToString();
            //detailLongContractForm.label_dateCreate.Text = dataGridView_listActiveLong.CurrentRow.Cells["DateCreate"].Value.ToString();
            //detailLongContractForm.label_dateActualCreate.Text = dataGridView_listActiveLong.CurrentRow.Cells["DateActualStart"].Value.ToString();
            //detailLongContractForm.label_dateEnd.Text = dataGridView_listActiveLong.CurrentRow.Cells["DateEnd"].Value.ToString();
            //detailLongContractForm.label_dateActualEnd.Text = dataGridView_listActiveLong.CurrentRow.Cells["DateActualEnd"].Value.ToString();
            detailLongContractForm.label_status.Text = dataGridView_listActiveLong.CurrentRow.Cells["Status"].Value.ToString();

            if (dataGridView_listActiveLong.CurrentRow.Cells["Status"].Value.ToString() == "Active")
            {
                detailLongContractForm.radioButton_active.Checked = true;
                detailLongContractForm.isActive = true;
            }
            detailLongContractForm.Show();

        }

        private void dataGridView_listDoneLong_DoubleClick(object sender, EventArgs e)
        {
            DetailLongContractForm detailLongContractForm = new DetailLongContractForm();
            detailLongContractForm.label_contractID.Text = dataGridView_listDoneLong.CurrentRow.Cells["ContractID"].Value.ToString();
            detailLongContractForm.label_contractName.Text = dataGridView_listDoneLong.CurrentRow.Cells["ContractName"].Value.ToString();
            detailLongContractForm.label_customerName.Text = dataGridView_listDoneLong.CurrentRow.Cells["CustomerFullName"].Value.ToString();
            detailLongContractForm.label_cusID.Text = dataGridView_listDoneLong.CurrentRow.Cells["CustomerID"].Value.ToString();
            //detailLongContractForm.label_vehicleType.Text = dataGridView_listDoneLong.CurrentRow.Cells["VehicleType"].Value.ToString();
            //detailLongContractForm.label_dateCreate.Text = dataGridView_listDoneLong.CurrentRow.Cells["DateCreate"].Value.ToString();
            //detailLongContractForm.label_dateActualCreate.Text = dataGridView_listDoneLong.CurrentRow.Cells["DateActualStart"].Value.ToString();
            //detailLongContractForm.label_dateEnd.Text = dataGridView_listDoneLong.CurrentRow.Cells["DateEnd"].Value.ToString();
            //detailLongContractForm.label_dateActualEnd.Text = dataGridView_listDoneLong.CurrentRow.Cells["DateActualEnd"].Value.ToString();
            detailLongContractForm.label_status.Text = dataGridView_listDoneLong.CurrentRow.Cells["Status"].Value.ToString();

            if (dataGridView_listDoneLong.CurrentRow.Cells["Status"].Value.ToString() == "Done")
            {
                detailLongContractForm.radioButton_done.Checked = true;
                detailLongContractForm.isDone = true;
            }
            detailLongContractForm.Show();
        }

        
    }
}
