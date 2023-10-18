using FinalWindow.CustomerBuilderPattern;
using FinalWindow.Database;
using FinalWindow.Model;
using FinalWindow.Tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalWindow.View.Customer.LoanContractForm
{
    public partial class CreateLoanContract : Form
    {
        public CreateLoanContract()
        {
            InitializeComponent();
        }

        private void load()
        {
            using (var context = new DatabaseContext())
            {

                var rule = context.Rules.Where(t => t.nameContract == "LoanContract").FirstOrDefault();
                label_Rule.Text = rule.description;
                if (LoanServiceForm.VehicleType == "Car")
                {
                    var vehicle = context.Vehicles.OfType<Car>().Where(t => t.ID == LoanServiceForm.VehicleID).FirstOrDefault();
                    textBox_Vehicle.Text = vehicle.name + " - " + vehicle.branch;
                }
                if (LoanServiceForm.VehicleType == "Motor")
                {
                    var vehicle = context.Vehicles.OfType<Model.Motor>().Where(t => t.ID == LoanServiceForm.VehicleID).FirstOrDefault();
                    textBox_Vehicle.Text = vehicle.name + " - " + vehicle.branch;
                }
                if (LoanServiceForm.VehicleType == "Truck")
                {
                    var vehicle = context.Vehicles.OfType<Model.Truck>().Where(t => t.ID == LoanServiceForm.VehicleID).FirstOrDefault();
                    textBox_Vehicle.Text = vehicle.name + " - " + vehicle.branch;
                }
            }


        }

        private void CreateLoanContract_Load(object sender, EventArgs e)
        {
            load();
        }

        private void button_CreateContract_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(textBox_firstName.Text) || string.IsNullOrEmpty(textBox_lastName.Text) || string.IsNullOrEmpty(textbox_phone.Text))
            {
                MessageBox.Show("Please enter all information");
                return;
            }
            using (var context = new DatabaseContext())
            {
                var cus = context.Users.OfType<Model.Customer>().Where(t => t.phone == textbox_phone.Text).FirstOrDefault();
                if (cus != null)
                {
                    if (CheckInput.checkEmailIsValid(textBox_email.Text) == false)
                    {
                        MessageBox.Show("Invalid email");
                        return;
                    }
                    var checkemail = context.Users.OfType<Model.Customer>().Where(t => t.phone == textbox_phone.Text && t.email == textBox_email.Text).Count();
                    if (checkemail > 0)
                    {
                        MessageBox.Show("Email has been used!!");
                        return;
                    }

                    cus.firstName = textBox_firstName.Text;
                    cus.lastName = textBox_lastName.Text;
                    cus.email = textBox_email.Text;
                    cus.phone = textbox_phone.Text;

                    try
                    {
                        context.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("Fail");
                        return;
                    }
                }
                else
                {
                    CustomerBuilder customerBuilder = new CustomerBuilder();
                    Model.Customer customer = customerBuilder.SetPhone(textbox_phone.Text).SetEmail(textBox_email.Text).SetAddress(textBox_address.Text).SetFirstName(textBox_firstName.Text).SetLastName(textBox_lastName.Text).SetActive(true).Build();
                    
                    try
                    {
                        context.Users.Add(customer);
                        context.SaveChanges();
                        MessageBox.Show("Add new customer successfully");
                    }
                    catch
                    {
                        MessageBox.Show("Add new customer failed");
                        return;
                    }
                }
            }
            DialogResult dialogResult = MessageBox.Show("Are you sure create this contract?", "Create contract", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                using (var context = new DatabaseContext())
                {
                    var contractLong = context.Contracts.OfType<Model.LongTermKeepContract>().Where(t => t.ID == LoanServiceForm.ContractID).FirstOrDefault();
                    contractLong.status = "Rented";

                    var cusLoan = context.Users.OfType<Model.Customer>().Where(t => t.phone == textbox_phone.Text).FirstOrDefault();
                    var contract = new LoanContract
                    {
                        name = "Loan Contract",
                        rule = label_Rule.Text,
                        dateCreate = DateTime.Now,
                        dateEnd = DateTime.Now.AddDays(double.Parse(LoanServiceForm.Period1)),
                        customerID = cusLoan.ID,
                        status = "Booked",
                        fee = 0
                    };
                    if (LoanServiceForm.VehicleType == "Car")
                    {
                        contract.carID = LoanServiceForm.VehicleID;
                    }
                    else if (LoanServiceForm.VehicleType == "Truck")
                    {
                        contract.truckID = LoanServiceForm.VehicleID;
                    }
                    else
                    {
                        contract.motorID = LoanServiceForm.VehicleID;
                    }

                    try
                    {
                        context.Contracts.Add(contract);
                        context.SaveChanges();
                        MessageBox.Show("Create loan contract successfully");
                    }
                    catch
                    {
                        MessageBox.Show("Create fail");
                    }
                }
            }
            

        }

        private void button_CalculatePrice_Click(object sender, EventArgs e)
        {

        }

        private void button_fine_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textbox_phone.Text))
            {
                MessageBox.Show("Please enter phone number of custumer");
                return;
            }
            if (CheckInput.IsPhoneNbr(textbox_phone.Text) == false)
            {
                MessageBox.Show("Invalid phone number");
                return;
            }
            using (var context = new DatabaseContext())
            {
                var cus = context.Users.OfType<Model.Customer>().Where(t => t.phone == textbox_phone.Text).FirstOrDefault();
                if (cus != null)
                {
                    textBox_firstName.Text = cus.firstName;
                    textBox_lastName.Text = cus.lastName;
                    if (cus.email != null)
                    {
                        textBox_email.Text = cus.email;
                    }
                    else
                    {
                        textBox_email.Text = "Unknow";
                    }

                    if (cus.address != null)
                    {
                        textBox_address.Text = cus.address;
                    }
                    else
                    {
                        textBox_address.Text = "Unknow";
                    }

                }
                else
                {
                    MessageBox.Show("New customer");
                }
            }
        }
    }
}
