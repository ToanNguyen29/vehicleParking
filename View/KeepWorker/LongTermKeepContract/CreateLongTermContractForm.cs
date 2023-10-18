using FinalWindow.CustomerBuilderPattern;
using FinalWindow.Database;
using FinalWindow.Model;
using FinalWindow.Tool;
using FinalWindow.VehicleFactoryPattern;
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
    public partial class CreateLongTermContractForm : Form
    {
        public CreateLongTermContractForm()
        {
            InitializeComponent();
        }

        private void CreateLongTermContractForm_Load(object sender, EventArgs e)
        {
            NumericUpDown_period.Minimum = 1;
            using (var context = new DatabaseContext())
            {

                var rule = context.Rules.Where(t => t.nameContract == "LongTermContract").FirstOrDefault();
                textBox_Rule.Text = rule.description;

                comboBox_facility.DataSource = context.Facilities.ToList();
                comboBox_facility.DisplayMember = "address";
                comboBox_facility.ValueMember = "ID";
                comboBox_facility.SelectedItem = null;
            }
            
        }
       

        

        private void comboBox_TypePeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_TypePeriod.Text == "Week")
            {
                NumericUpDown_period.Maximum = 3;
            }
            else if (comboBox_TypePeriod.Text == "Month")
            {
                NumericUpDown_period.Maximum = 12;
            }
        }

        private float CalculateFee()
        {
            using (var context = new DatabaseContext())
            {
                var fee = context.FeeKeeps.Where(t => t.typeVehicle == comboBox_TypeVehicle.Text).FirstOrDefault();
                float result = 0;
                if (comboBox_TypePeriod.Text == "Week")
                {
                    result = float.Parse(fee.weekPrice.ToString()) * float.Parse(NumericUpDown_period.Value.ToString());

                }
                else
                {
                    result = float.Parse(fee.monthPrice.ToString()) * float.Parse(NumericUpDown_period.Value.ToString());

                }
                return result;
            }
        }

        private void button_CalculatePrice_Click(object sender, EventArgs e)
        {
            
        }

        private void button_CreateLongContract_Click(object sender, EventArgs e)
        {
            





        }

        private void button_CalculatePrice_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox_facility.Text) || string.IsNullOrEmpty(textBox_firstName.Text) || string.IsNullOrEmpty(textBox_lastName.Text) || string.IsNullOrEmpty(textBox_email.Text) || string.IsNullOrEmpty(textbox_phone.Text)
                || string.IsNullOrEmpty(textBox_branchVehicle.Text) || string.IsNullOrEmpty(textBox_nameVehicle.Text) || string.IsNullOrEmpty(textBox_licensePlate.Text) || string.IsNullOrEmpty(comboBox_TypeVehicle.Text)
                || string.IsNullOrEmpty(comboBox_TypePeriod.Text) || string.IsNullOrEmpty(comboBox_facility.Text))
            {
                MessageBox.Show("Please enter all information");
                return;
            }
            textBox_Fee.Text = CalculateFee().ToString();
        }

        private void button_CreateLongContract_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox_facility.Text) || string.IsNullOrEmpty(textBox_firstName.Text) || string.IsNullOrEmpty(textBox_lastName.Text) || string.IsNullOrEmpty(textbox_phone.Text)
                || string.IsNullOrEmpty(textBox_branchVehicle.Text) || string.IsNullOrEmpty(textBox_nameVehicle.Text) || string.IsNullOrEmpty(textBox_licensePlate.Text) || string.IsNullOrEmpty(comboBox_TypeVehicle.Text)
                || string.IsNullOrEmpty(comboBox_TypePeriod.Text) || string.IsNullOrEmpty(comboBox_Loan.Text))
            {
                MessageBox.Show("Please enter all information");
                return;
            }

            using (var context = new DatabaseContext())
            {
                var checkVehicle = context.Vehicles.Where(t => t.licensePlates == textBox_licensePlate.Text && t.status == "In").Count();
                if (checkVehicle > 0)
                {
                    MessageBox.Show("License plate has alreally in my parking, please check again");
                    return;
                }

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

            using (var context = new DatabaseContext())
            {
                try
                {
                    Vehicle vehicle;
                    if (comboBox_TypeVehicle.Text == "Motor")
                    {
                        
                        string a = "Motor";
                        vehicle = VehicleFactory.CreateVehicle(a);
                        vehicle.name = textBox_nameVehicle.Text;
                        vehicle.branch = textBox_branchVehicle.Text;
                        vehicle.licensePlates = textBox_licensePlate.Text;

                    }
                    else if (comboBox_TypeVehicle.Text == "Car")
                    {
                        string a = "Car";
                        vehicle = VehicleFactory.CreateVehicle(a);
                        vehicle.name = textBox_nameVehicle.Text;
                        vehicle.branch = textBox_branchVehicle.Text;
                        vehicle.licensePlates = textBox_licensePlate.Text;


                    }
                    else
                    {
                        string a = "Truck";
                        vehicle = VehicleFactory.CreateVehicle(a);
                        vehicle.name = textBox_nameVehicle.Text;
                        vehicle.branch = textBox_branchVehicle.Text;
                        vehicle.licensePlates = textBox_licensePlate.Text;
                    }

                    vehicle.status = "Out";
                    context.Vehicles.Add(vehicle);
                    context.SaveChanges();

                    MessageBox.Show("Create vehicle successfully");


                }
                catch
                {
                    MessageBox.Show("Create vehicle fail");
                    return;
                }
            }

            using (var context = new DatabaseContext())
            {
                try
                {
                    Vehicle vehicle;
                    if (comboBox_TypeVehicle.Text == "Car")
                    {
                        vehicle = context.Vehicles.OfType<Model.Car>().Where(t => t.licensePlates == textBox_licensePlate.Text).FirstOrDefault();

                    }
                    else if (comboBox_TypeVehicle.Text == "Motor")
                    {
                        vehicle = context.Vehicles.OfType<Model.Motor>().Where(t => t.licensePlates == textBox_licensePlate.Text).FirstOrDefault();

                    }
                    else
                    {
                        vehicle = context.Vehicles.OfType<Model.Truck>().Where(t => t.licensePlates == textBox_licensePlate.Text).FirstOrDefault();
                    }
                    //var vehicle = context.Vehicles.Where(t => t.licensePlates == textBox_licensePlate.Text).FirstOrDefault();
                    if (vehicle == null)
                    {
                        MessageBox.Show("Error");
                        return;
                    }

                    var cus = context.Users.OfType<Model.Customer>().Where(t => t.phone == textbox_phone.Text).FirstOrDefault();
                    var contract = new Model.LongTermKeepContract
                    {
                        name = comboBox_TypePeriod.Text + " contract",
                        rule = textBox_Rule.Text,
                        dateCreate = DateTime.Now,
                        facilityId = (int)comboBox_facility.SelectedValue,
                        customerID = cus.ID,
                        status = "Booked",
                        fee = CalculateFee(),

                        period = float.Parse(NumericUpDown_period.Value.ToString())

                    };

                    if (comboBox_TypeVehicle.Text == "Car")
                    {
                        contract.carID = vehicle.ID;
                    }
                    else if (comboBox_TypeVehicle.Text == "Motor")
                    {
                        contract.motorID = vehicle.ID;
                    }
                    else
                    {
                        contract.truckID = vehicle.ID;
                    }

                    if (comboBox_TypePeriod.Text == "Week")
                    {
                        contract.typeContract = "Week";
                        contract.dateEnd = DateTime.Now.AddDays(7 * double.Parse(NumericUpDown_period.Value.ToString()));
                    }
                    else
                    {
                        contract.typeContract = "Month";
                        contract.dateEnd = DateTime.Now.AddMonths(int.Parse(NumericUpDown_period.Value.ToString()));
                    }

                    if (comboBox_Loan.Text == "Loan")
                    {
                        contract.is_Loan = true;
                    }
                    else
                    {
                        contract.is_Loan = false;
                    }

                    context.Contracts.Add(contract);
                    context.SaveChanges();

                    MessageBox.Show("Create contract successfully!!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException.ToString());
                    var vehicle = context.Vehicles.Where(t => t.licensePlates == textBox_licensePlate.Text).FirstOrDefault();
                    context.Vehicles.Remove(vehicle);
                    return;
                }
            }
            
        }

        private void button_fine_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textbox_phone.Text))
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
