using FinalWindow.Database;
using FinalWindow.Model;
using FinalWindow.VehicleFactoryPattern;
using FinalWindow.View.KeepWorker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalWindow
{
    public partial class KeepWorkerMainForm : Form
    {
        public KeepWorkerMainForm()
        {
            InitializeComponent();
        }

        private void button_addVehicle_Click(object sender, EventArgs e)
        {

        }

        private HttpClient myhttpClient;

        private static int keepID;

        public static int KeepID { get => keepID; set => keepID = value; }

        private static byte[] converterDemo(System.Drawing.Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }

        private string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            char[] stringChars = new char[length];

            for (int i = 0; i < length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(stringChars);
        }


        private void KeepWorkerMainForm_Load(object sender, EventArgs e)
        {
            loadProfile();
            radioButton_In.Checked = true;
            textBox_LicensePlate.ReadOnly = true;
            textBox_Key.ReadOnly = true;
            button_InOut.Text = "In";
            myhttpClient = new HttpClient();
        }

        void loadProfile()
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    var keeper = context.Users.OfType<KeepWorker>().Where(t => t.ID == keepID).FirstOrDefault();
                    if (keeper.picture != null)
                    {
                        byte[] imageData = (byte[])keeper.picture;
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            pictureBox_profile.Image = Image.FromStream(ms);
                        }
                    }

                    label_username.Text = keeper.username;
                    label_firstName.Text = keeper.firstName;
                    label_lastName.Text = keeper.lastName;
                    label_gender.Text = keeper.gender;
                    label_birthDate.Text = keeper.birthday.Value.Date.ToString("dd/MM/yyyy");
                    label_email.Text = keeper.email;
                    label_phone.Text = keeper.phone;
                    label_address.Text = keeper.address;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }




        private void button_UploadPlate_Click(object sender, EventArgs e)
        {

        }

        private void button_In_Click(object sender, EventArgs e)
        {

        }

        private void button_select_Click(object sender, EventArgs e)
        {
            if (radioButton_In.Checked == true)
            {
                button_InOut.Text = "In";
                textBox_LicensePlate.ReadOnly = true;
                textBox_Key.ReadOnly = true;
            }
            else
            {
                button_InOut.Text = "Out";
                
                textBox_Key.ReadOnly = false;
            }
            textBox_LicensePlate.Clear();
            comboBox_TypeVehicle.Text = "";
            pictureBox_ImagePlate.Image = null;
            textBox_Key.Clear();

        }

        private async void button_UploadPlate_Click_1(object sender, EventArgs e)
        {
            if (comboBox_TypeVehicle.Text == null)
            {
                MessageBox.Show("Please choose type of vehicle");
                return;
            }

            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (.jpg;.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
    
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox_ImagePlate.Image = new Bitmap(opnfd.FileName);
                var content = new MultipartFormDataContent();
                var fileContent = new StreamContent(File.OpenRead(opnfd.FileName));
                content.Add(fileContent, "file", Path.GetFileName(opnfd.FileName));
                HttpResponseMessage response = await myhttpClient.PostAsync("http://127.0.0.1:5000/upload-image", content);
                string responseText = await response.Content.ReadAsStringAsync();
                MessageBox.Show(responseText);
                if (responseText.Substring(1, responseText.Length - 2) == "No detection")

                {
                    string numberplates = responseText.Substring(1, responseText.Length - 2);
                    MessageBox.Show(numberplates, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }
                else
                {
                    string numberplates = responseText.Substring(2, responseText.Length - 4);

                    bool hasLetters = numberplates.Any(c => Char.IsLetter(c));


                    if (numberplates.Length >= 7 && numberplates.Length <= 12 && hasLetters)
                    {
                        textBox_LicensePlate.Text = numberplates;

                    }
                    else
                    {
                        MessageBox.Show("Detect is faill", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }


                }
            }

            if (radioButton_In.Checked == true)
            {

                using (var context = new DatabaseContext())
                {
                    var checkVehicle = context.Vehicles.Where(t => t.licensePlates == textBox_LicensePlate.Text && t.status == "In").Count();
                    if (checkVehicle > 0)
                    {
                        MessageBox.Show("Vehicle has already Parking, Please check again");
                        return;
                    }

                    else
                    {
                        int check = 0;

                        if (comboBox_TypeVehicle.Text == "Car")
                        {
                            var checkVehicleInLoan = context.Vehicles.OfType<Model.Car>().Where(t => t.licensePlates == textBox_LicensePlate.Text && t.status == "Out")
                            .Join(context.Contracts.OfType<Model.LoanContract>().Where(t => t.status == "Active"),
                            Vehicle => Vehicle.ID,
                            Contract => Contract.carID,
                            (Vehicle, Contract) => new
                            {
                                Vehicle.licensePlates,
                                Contract.key,
                                Contract.dateEnd,
                                Contract.dateEndActual,
                                Vehicle.ID

                            });

                            if (checkVehicleInLoan.Count() > 0)
                            {
                                if (checkVehicleInLoan.FirstOrDefault().dateEnd > DateTime.Now && checkVehicleInLoan.FirstOrDefault().dateEndActual == null)
                                {
                                    textBox_Key.Text = checkVehicleInLoan.FirstOrDefault().key;
                                    var car = context.Vehicles.OfType<Model.Car>().Where(t => t.ID == checkVehicleInLoan.FirstOrDefault().ID).FirstOrDefault();
                                    car.status = "In";
                                    context.SaveChanges();
                                    MessageBox.Show("Vehicle in Loan contract, Accept in");
                                    comboBox_TypeVehicle.Text = "";
                                    textBox_LicensePlate.Text = "";
                                    pictureBox_ImagePlate.Image = null;
                                    textBox_Key.Text = "";
                                    return;
                                }
                                else if (checkVehicleInLoan.FirstOrDefault().dateEnd <= DateTime.Now)
                                {
                                    MessageBox.Show("Vehicle Loan contract expires");
                                    return;
                                }

                            }
                            else
                            {
                                check = 1;
                            }
                        }
                        else if (comboBox_TypeVehicle.Text == "Motor")
                        {
                            var checkVehicleInLoan = context.Vehicles.OfType<Model.Motor>().Where(t => t.licensePlates == textBox_LicensePlate.Text && t.status == "Out")
                            .Join(context.Contracts.OfType<Model.LoanContract>().Where(t => t.status == "Active"),
                            Vehicle => Vehicle.ID,
                            Contract => Contract.carID,
                            (Vehicle, Contract) => new
                            {
                                Vehicle.licensePlates,
                                Contract.key,
                                Contract.dateEnd,
                                Contract.dateEndActual,
                                Vehicle.ID
                            });

                            if (checkVehicleInLoan.Count() > 0)
                            {
                                if (checkVehicleInLoan.FirstOrDefault().dateEnd > DateTime.Now && checkVehicleInLoan.FirstOrDefault().dateEndActual == null)
                                {
                                    textBox_Key.Text = checkVehicleInLoan.FirstOrDefault().key;
                                    var car = context.Vehicles.OfType<Model.Car>().Where(t => t.ID == checkVehicleInLoan.FirstOrDefault().ID).FirstOrDefault();
                                    car.status = "In";
                                    context.SaveChanges();
                                    MessageBox.Show("Vehicle in Loan contract, Accept in");
                                    comboBox_TypeVehicle.Text = "";
                                    textBox_LicensePlate.Text = "";
                                    pictureBox_ImagePlate.Image = null;
                                    textBox_Key.Text = ""; ;
                                    return;
                                }
                                else if (checkVehicleInLoan.FirstOrDefault().dateEnd <= DateTime.Now)
                                {
                                    MessageBox.Show("Vehicle Loan contract expires");
                                    return;
                                }
                            }
                            else
                            {
                                check = 1;
                            }
                        }
                        else
                        {
                            var checkVehicleInLoan = context.Vehicles.OfType<Model.Truck>().Where(t => t.licensePlates == textBox_LicensePlate.Text && t.status == "Out")
                            .Join(context.Contracts.OfType<Model.LoanContract>().Where(t => t.status == "Active"),
                            Vehicle => Vehicle.ID,
                            Contract => Contract.carID,
                            (Vehicle, Contract) => new
                            {
                                Vehicle.licensePlates,
                                Contract.key,
                                Contract.dateEnd,
                                Contract.dateEndActual,
                                Vehicle.ID
                            });

                            if (checkVehicleInLoan.Count() > 0)
                            {
                                if (checkVehicleInLoan.FirstOrDefault().dateEnd > DateTime.Now && checkVehicleInLoan.FirstOrDefault().dateEndActual == null)
                                {
                                    textBox_Key.Text = checkVehicleInLoan.FirstOrDefault().key;
                                    var car = context.Vehicles.OfType<Model.Car>().Where(t => t.ID == checkVehicleInLoan.FirstOrDefault().ID).FirstOrDefault();
                                    car.status = "In";
                                    context.SaveChanges();
                                    MessageBox.Show("Vehicle in Loan contract, Accept in");
                                    comboBox_TypeVehicle.Text = "";
                                    textBox_LicensePlate.Text = "";
                                    pictureBox_ImagePlate.Image = null;
                                    textBox_Key.Text = "";
                                    return;
                                }
                                else if (checkVehicleInLoan.FirstOrDefault().dateEnd <= DateTime.Now)
                                {
                                    MessageBox.Show("Vehicle Loan contract expires");
                                    return;
                                }
                            }
                            else
                            {
                                check = 1;
                            }
                        }

                        if (check == 1)
                        {
                            if (comboBox_TypeVehicle.Text == "Car")
                            {
                                var checkVehicleInLong = context.Vehicles.OfType<Model.Car>().Where(t => t.licensePlates == textBox_LicensePlate.Text && t.status == "Out")
                                .Join(context.Contracts.OfType<Model.LongTermKeepContract>().Where(t => t.status == "Active"),
                                Vehicle => Vehicle.ID,
                                Contract => Contract.carID,
                                (Vehicle, Contract) => new
                                {
                                    Vehicle.licensePlates,
                                    Contract.key,
                                    Contract.dateEnd,
                                    Contract.dateEndActual,
                                    Vehicle.ID
                                });

                                if (checkVehicleInLong.Count() > 0)
                                {

                                    textBox_Key.Text = checkVehicleInLong.FirstOrDefault().key;
                                    var car = context.Vehicles.OfType<Model.Car>().Where(t => t.ID == checkVehicleInLong.FirstOrDefault().ID).FirstOrDefault();
                                    car.status = "In";
                                    context.SaveChanges();
                                    MessageBox.Show("Accept");
                                    comboBox_TypeVehicle.Text = "";
                                    textBox_LicensePlate.Text = "";
                                    pictureBox_ImagePlate.Image = null;
                                    textBox_Key.Text = "";
                                    return;
                                }
                            }
                            else if (comboBox_TypeVehicle.Text == "Motor")
                            {
                                var checkVehicleInLong = context.Vehicles.OfType<Model.Motor>().Where(t => t.licensePlates == textBox_LicensePlate.Text && t.status == "Out")
                                .Join(context.Contracts.OfType<Model.LongTermKeepContract>().Where(t => t.status == "Active"),
                                Vehicle => Vehicle.ID,
                                Contract => Contract.carID,
                                (Vehicle, Contract) => new
                                {
                                    Vehicle.licensePlates,
                                    Contract.key,
                                    Contract.dateEnd,
                                    Contract.dateEndActual,
                                    Vehicle.ID
                                });

                                if (checkVehicleInLong.Count() > 0)
                                {
                                    textBox_Key.Text = checkVehicleInLong.FirstOrDefault().key;
                                    var motor = context.Vehicles.OfType<Model.Motor>().Where(t => t.ID == checkVehicleInLong.FirstOrDefault().ID).FirstOrDefault();
                                    motor.status = "In";
                                    context.SaveChanges();
                                    MessageBox.Show("Accept");
                                    comboBox_TypeVehicle.Text = "";
                                    textBox_LicensePlate.Text = "";
                                    pictureBox_ImagePlate.Image = null;
                                    textBox_Key.Text = "";
                                    return;
                                }
                            }
                            else
                            {
                                var checkVehicleInLong = context.Vehicles.OfType<Model.Truck>().Where(t => t.licensePlates == textBox_LicensePlate.Text && t.status == "Out")
                                .Join(context.Contracts.OfType<Model.LongTermKeepContract>().Where(t => t.status == "Active"),
                                Vehicle => Vehicle.ID,
                                Contract => Contract.carID,
                                (Vehicle, Contract) => new
                                {
                                    Vehicle.licensePlates,
                                    Contract.key,
                                    Contract.dateEnd,
                                    Contract.dateEndActual,
                                    Vehicle.ID
                                });

                                if (checkVehicleInLong.Count() > 0)
                                {
                                    textBox_Key.Text = checkVehicleInLong.FirstOrDefault().key;
                                    var truck = context.Vehicles.OfType<Model.Motor>().Where(t => t.ID == checkVehicleInLong.FirstOrDefault().ID).FirstOrDefault();
                                    truck.status = "In";
                                    context.SaveChanges();
                                    MessageBox.Show("Accept");
                                    comboBox_TypeVehicle.Text = "";
                                    textBox_LicensePlate.Text = "";
                                    pictureBox_ImagePlate.Image = null;
                                    textBox_Key.Text = "";
                                    return;
                                }
                            }
                        }
                    }

                    textBox_Key.Text = GenerateRandomString(10);
                }
            }

                /*else if (radioButton_Out.Checked == true)
                {
                    OpenFileDialog opnfd = new OpenFileDialog();
                    opnfd.Filter = "Image Files (.jpg;.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
                    if (opnfd.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox_ImagePlate.Image = new Bitmap(opnfd.FileName);
                    }
                    textBox_LicensePlate.Text = "1";
                }
                else
                {

                    return;
                }*/

            }

            private void button_InOut_Click(object sender, EventArgs e)
            {

            if (radioButton_In.Checked == true)
            {

                if (string.IsNullOrEmpty(textBox_Key.Text) || string.IsNullOrEmpty(textBox_LicensePlate.Text) || string.IsNullOrEmpty(comboBox_TypeVehicle.Text) || pictureBox_ImagePlate == null)
                {
                    MessageBox.Show("Please choose type of vehicle or license plate");
                    return;
                }
                using (var context = new DatabaseContext())
                {

                    try
                    {
                        Vehicle vehicle;
                        if (comboBox_TypeVehicle.Text == "Motor")
                        {
                            /*vehicle = new Model.Motor
                            {
                                licensePlates = textBox_LicensePlate.Text,
                                picture = converterDemo(pictureBox_ImagePlate.Image),
                                status = "In"
                            };*/

                            string a = "Motor";
                            vehicle = VehicleFactory.CreateVehicle(a);
                            vehicle.licensePlates = textBox_LicensePlate.Text;
                            vehicle.picture = converterDemo(pictureBox_ImagePlate.Image);
                            vehicle.status = "In";
                        }
                        else if (comboBox_TypeVehicle.Text == "Car")
                        {
                            string a = "Car";
                            vehicle = VehicleFactory.CreateVehicle(a);
                            vehicle.licensePlates = textBox_LicensePlate.Text;
                            vehicle.picture = converterDemo(pictureBox_ImagePlate.Image);
                            vehicle.status = "In";
                        }
                        else
                        {
                            string a = "Truck";
                            vehicle = VehicleFactory.CreateVehicle(a);
                            vehicle.licensePlates = textBox_LicensePlate.Text;
                            vehicle.picture = converterDemo(pictureBox_ImagePlate.Image);
                            vehicle.status = "In";
                        }
                        context.Vehicles.Add(vehicle);
                        context.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("In fail");
                        return;
                    }
                }
                using (var context = new DatabaseContext())
                {
                    try
                    {
                        var newVehicle = context.Vehicles.Where(t => t.licensePlates == textBox_LicensePlate.Text).FirstOrDefault();

                        DayKeepContract contract = new DayKeepContract();
                        contract.dateCreate = DateTime.Now;
                        contract.key = textBox_Key.Text;
                        contract.status = "Active";
                        if (comboBox_TypeVehicle.Text == "Motor")
                        {
                            contract.motorID = newVehicle.ID;


                        }
                        else if (comboBox_TypeVehicle.Text == "Car")
                        {
                            contract.carID = newVehicle.ID;
                        }
                        else
                        {
                            contract.truckID = newVehicle.ID;
                        }

                        context.Contracts.Add(contract);
                        context.SaveChanges();
                        MessageBox.Show("Accept");
                        textBox_Key.Text = "";
                        textBox_LicensePlate.Text = "";
                        pictureBox_ImagePlate.Image = null;

                    }
                    catch
                    {
                        MessageBox.Show("Accept fail");
                        var newVehicle = context.Vehicles.Where(t => t.licensePlates == textBox_LicensePlate.Text).FirstOrDefault();
                        context.Vehicles.Remove(newVehicle);
                        return;
                    }
                }

            }
            else if (radioButton_Out.Checked == true)
            {
                if (string.IsNullOrEmpty(comboBox_TypeVehicle.Text) || string.IsNullOrEmpty(textBox_LicensePlate.Text) || string.IsNullOrEmpty(textBox_Key.Text))
                {
                    MessageBox.Show("Please enter all information");
                    return;
                }

                if (comboBox_TypeVehicle.Text == "Motor")
                {
                    using (var context = new DatabaseContext())
                    {
                        var checkVehicle = context.Vehicles.OfType<Model.Motor>().Where(t => t.licensePlates == textBox_LicensePlate.Text && t.status == "In")
                                    .Join(context.Contracts.OfType<Model.LoanContract>().Where(t => t.key == textBox_Key.Text && t.status == "Active"),
                                    Vehicle => Vehicle.ID,
                                    Contract => Contract.motorID,
                                    (Vehicle, Contract) => new
                                    {
                                        Vehicle.licensePlates,
                                        vehicleID = Vehicle.ID,
                                        contractID = Contract.ID,
                                        Contract.fee,
                                        
                                        Contract.dateEnd,
                                        Contract.dateEndActual
                                    }).FirstOrDefault();
                        if (checkVehicle != null)
                        {
                            if (checkVehicle.dateEnd > DateTime.Now)
                            {
                                DialogResult dialogResult = MessageBox.Show("Vehicle in Loan contract", "Fee keep vehicle", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                if (dialogResult == DialogResult.OK)
                                {
                                    try
                                    {
                                        var vehicle = context.Vehicles.OfType<Model.Motor>().Where(t => t.ID == checkVehicle.vehicleID).FirstOrDefault();
                                        vehicle.status = "Out";

                                        context.SaveChanges();
                                        MessageBox.Show("Accept out");
                                        comboBox_TypeVehicle.Text = "";
                                        textBox_LicensePlate.Text = "";
                                        pictureBox_ImagePlate.Image = null;
                                        textBox_Key.Text = "";

                                        return;

                                    }
                                    catch
                                    {
                                        MessageBox.Show("Accept out fail");
                                        return;
                                    }
                                }
                                else
                                {

                                    return;
                                }
                            }

                            else
                            {
                                MessageBox.Show("Loan contract ended, reject out");
                                return;
                            }


                        }


                        var checkVehicle1 = context.Vehicles.OfType<Model.Motor>().Where(t => t.licensePlates == textBox_LicensePlate.Text && t.status == "In")
                                    .Join(context.Contracts.OfType<Model.LongTermKeepContract>().Where(t => t.key == textBox_Key.Text && t.status == "Active"),
                                    Vehicle => Vehicle.ID,
                                    Contract => Contract.motorID,
                                    (Vehicle, Contract) => new
                                    {
                                        Vehicle.licensePlates,
                                        vehicleID = Vehicle.ID,
                                        contractID = Contract.ID,
                                        Contract.fee,
                                        Contract.dateEnd
                                    }).FirstOrDefault();

                        if (checkVehicle1 != null)
                        {
                            if (checkVehicle1.dateEnd > DateTime.Now)
                            {
                                DialogResult dialogResult = MessageBox.Show("Vehicle in Long term contract", "Fee keep vehicle", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                if (dialogResult == DialogResult.OK)
                                {
                                    try
                                    {
                                        var vehicle = context.Vehicles.OfType<Model.Motor>().Where(t => t.ID == checkVehicle1.vehicleID).FirstOrDefault();
                                        vehicle.status = "Out";

                                        context.SaveChanges();
                                        MessageBox.Show("Accept out");
                                        comboBox_TypeVehicle.Text = "";
                                        textBox_LicensePlate.Text = "";
                                        pictureBox_ImagePlate.Image = null;
                                        textBox_Key.Text = "";

                                        return;

                                    }
                                    catch
                                    {
                                        MessageBox.Show("Accept out fail");
                                        return;
                                    }
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Long term contract expired");
                                return;
                            }

                        }
                        var checkVehicle2 = context.Vehicles.OfType<Model.Motor>().Where(t => t.licensePlates == textBox_LicensePlate.Text && t.status == "In")
                                    .Join(context.Contracts.OfType<Model.DayKeepContract>().Where(t => t.key == textBox_Key.Text && t.status == "Active"),
                                    Vehicle => Vehicle.ID,
                                    Contract => Contract.motorID,
                                    (Vehicle, Contract) => new
                                    {
                                        Vehicle.licensePlates,
                                        vehicleID = Vehicle.ID,
                                        contractID = Contract.ID,
                                        Contract.dateCreate,
                                        Contract.dateEnd
                                    }).FirstOrDefault();
                        if (checkVehicle2 != null)
                        {
                            var feeKeep = context.FeeKeeps.Where(t => t.typeVehicle == "Motor").FirstOrDefault();
                            var contract = context.Contracts.OfType<Model.DayKeepContract>().Where(t => t.ID == checkVehicle2.contractID).FirstOrDefault();
                            DateTime dateCreate = contract.dateCreate ?? DateTime.MinValue;
                            int time = (DateTime.Now - dateCreate).Days;
                            DialogResult dialogResult = MessageBox.Show("Fee: " + ((time + 1) * feeKeep.dayPrice).ToString() + " USD", "Fee keep vehicle", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            if (dialogResult == DialogResult.OK)
                            {
                                try
                                {
                                    var vehicle = context.Vehicles.OfType<Model.Motor>().Where(t => t.ID == checkVehicle2.vehicleID).FirstOrDefault();
                                    contract.dateEnd = DateTime.Now;
                                    contract.fee = (time + 1) * feeKeep.dayPrice;
                                    vehicle.status = "Out";
                                    contract.status = "Done";
                                    context.SaveChanges();
                                    MessageBox.Show("Accept out");
                                    comboBox_TypeVehicle.Text = "";
                                    textBox_LicensePlate.Text = "";
                                    pictureBox_ImagePlate.Image = null;
                                    textBox_Key.Text = "";

                                    return;

                                }
                                catch
                                {
                                    MessageBox.Show("Reject out");
                                    return;
                                }
                            }
                            else
                            {
                                return;
                            }


                        }
                        else
                        {
                            MessageBox.Show("Key is not valid");
                            return;
                        }

                    }
                }

                else if (comboBox_TypeVehicle.Text == "Car")
                {
                    using (var context = new DatabaseContext())
                    {
                        var checkVehicle = context.Vehicles.OfType<Model.Car>().Where(t => t.licensePlates == textBox_LicensePlate.Text && t.status == "In")
                                    .Join(context.Contracts.OfType<Model.LoanContract>().Where(t => t.key == textBox_Key.Text && t.status == "Active"),
                                    Vehicle => Vehicle.ID,
                                    Contract => Contract.carID,
                                    (Vehicle, Contract) => new
                                    {
                                        Vehicle.licensePlates,
                                        vehicleID = Vehicle.ID,
                                        contractID = Contract.ID,
                                        Contract.fee,
                                        
                                        Contract.dateEnd,
                                        Contract.dateEndActual
                                    }).FirstOrDefault();
                        if (checkVehicle != null)
                        {
                            if (checkVehicle.dateEnd > DateTime.Now)
                            {
                                DialogResult dialogResult = MessageBox.Show("Vehicle in Loan contract", "Fee keep vehicle", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                if (dialogResult == DialogResult.OK)
                                {
                                    try
                                    {
                                        var vehicle = context.Vehicles.OfType<Model.Car>().Where(t => t.ID == checkVehicle.vehicleID).FirstOrDefault();
                                        vehicle.status = "Out";

                                        context.SaveChanges();
                                        MessageBox.Show("Accept out");
                                        comboBox_TypeVehicle.Text = "";
                                        textBox_LicensePlate.Text = "";
                                        pictureBox_ImagePlate.Image = null;
                                        textBox_Key.Text = "";

                                        return;

                                    }
                                    catch
                                    {
                                        MessageBox.Show("Accept out fail");
                                        return;
                                    }
                                }
                                else
                                {

                                    return;
                                }
                            }

                            else
                            {
                                MessageBox.Show("Loan contract ended, reject out");
                                return;
                            }

                        }
                        var checkVehicle1 = context.Vehicles.OfType<Model.Car>().Where(t => t.licensePlates == textBox_LicensePlate.Text && t.status == "In")
                                    .Join(context.Contracts.OfType<Model.LongTermKeepContract>().Where(t => t.key == textBox_Key.Text && t.status == "Active"),
                                    Vehicle => Vehicle.ID,
                                    Contract => Contract.carID,
                                    (Vehicle, Contract) => new
                                    {
                                        Vehicle.licensePlates,
                                        vehicleID = Vehicle.ID,
                                        contractID = Contract.ID,
                                        Contract.fee,
                                        Contract.dateEnd
                                    }).FirstOrDefault();

                        if (checkVehicle1 != null)
                        {
                            if (checkVehicle1.dateEnd > DateTime.Now)
                            {
                                DialogResult dialogResult = MessageBox.Show("Vehicle in Long term contract", "Fee keep vehicle", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                if (dialogResult == DialogResult.OK)
                                {
                                    try
                                    {
                                        var vehicle = context.Vehicles.OfType<Model.Car>().Where(t => t.ID == checkVehicle1.vehicleID).FirstOrDefault();
                                        vehicle.status = "Out";

                                        context.SaveChanges();
                                        MessageBox.Show("Accept out");
                                        comboBox_TypeVehicle.Text = "";
                                        textBox_LicensePlate.Text = "";
                                        pictureBox_ImagePlate.Image = null;
                                        textBox_Key.Text = "";

                                        return;

                                    }
                                    catch
                                    {
                                        MessageBox.Show("Accept out fail");
                                        return;
                                    }
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Long term contract expired");
                                return;
                            }

                        }

                        var checkVehicle2 = context.Vehicles.OfType<Model.Car>().Where(t => t.licensePlates == textBox_LicensePlate.Text && t.status == "In")
                                    .Join(context.Contracts.OfType<Model.DayKeepContract>().Where(t => t.key == textBox_Key.Text && t.status == "Active"),
                                    Vehicle => Vehicle.ID,
                                    Contract => Contract.carID,
                                    (Vehicle, Contract) => new
                                    {
                                        Vehicle.licensePlates,
                                        vehicleID = Vehicle.ID,
                                        contractID = Contract.ID,
                                        Contract.dateCreate,
                                        Contract.dateEnd
                                    }).FirstOrDefault();
                        if (checkVehicle2 != null)
                        {
                            var feeKeep = context.FeeKeeps.Where(t => t.typeVehicle == "Car").FirstOrDefault();
                            var contract = context.Contracts.OfType<Model.DayKeepContract>().Where(t => t.ID == checkVehicle2.contractID).FirstOrDefault();
                            DateTime dateCreate = contract.dateCreate ?? DateTime.MinValue;
                            int time = (DateTime.Now - dateCreate).Days;
                            DialogResult dialogResult = MessageBox.Show("Fee: " + ((time + 1) * feeKeep.dayPrice).ToString() + " USD", "Fee keep vehicle", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            if (dialogResult == DialogResult.OK)
                            {
                                try
                                {
                                    var vehicle = context.Vehicles.OfType<Model.Car>().Where(t => t.ID == checkVehicle2.vehicleID).FirstOrDefault();
                                    contract.dateEnd = DateTime.Now;
                                    contract.fee = (time + 1) * feeKeep.dayPrice;
                                    vehicle.status = "Out";
                                    contract.status = "Done";
                                    context.SaveChanges();
                                    MessageBox.Show("Accept out");
                                    comboBox_TypeVehicle.Text = "";
                                    textBox_LicensePlate.Text = "";
                                    pictureBox_ImagePlate.Image = null;
                                    textBox_Key.Text = "";

                                    return;

                                }
                                catch
                                {
                                    MessageBox.Show("Reject out");
                                    return;
                                }
                            }
                            else
                            {
                                return;
                            }


                        }
                        else
                        {
                            MessageBox.Show("Key is not valid");
                            return;
                        }
                    }
                }
                else
                {
                    using (var context = new DatabaseContext())
                    {
                        var checkVehicle = context.Vehicles.OfType<Model.Truck>().Where(t => t.licensePlates == textBox_LicensePlate.Text && t.status == "In")
                                    .Join(context.Contracts.OfType<Model.LoanContract>().Where(t => t.key == textBox_Key.Text && t.status == "Active"),
                                    Vehicle => Vehicle.ID,
                                    Contract => Contract.truckID,
                                    (Vehicle, Contract) => new
                                    {
                                        Vehicle.licensePlates,
                                        vehicleID = Vehicle.ID,
                                        contractID = Contract.ID,
                                        Contract.fee,
                                        
                                        Contract.dateEnd,
                                        Contract.dateEndActual
                                    }).FirstOrDefault();
                        if (checkVehicle != null)
                        {
                            if (checkVehicle.dateEnd > DateTime.Now)
                            {
                                DialogResult dialogResult = MessageBox.Show("Vehicle in Loan contract", "Fee keep vehicle", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                if (dialogResult == DialogResult.OK)
                                {
                                    try
                                    {
                                        var vehicle = context.Vehicles.OfType<Model.Truck>().Where(t => t.ID == checkVehicle.vehicleID).FirstOrDefault();
                                        vehicle.status = "Out";

                                        context.SaveChanges();
                                        MessageBox.Show("Accept out");
                                        comboBox_TypeVehicle.Text = "";
                                        textBox_LicensePlate.Text = "";
                                        pictureBox_ImagePlate.Image = null;
                                        textBox_Key.Text = "";

                                        return;

                                    }
                                    catch
                                    {
                                        MessageBox.Show("Accept out fail");
                                        return;
                                    }
                                }
                                else
                                {

                                    return;
                                }
                            }

                            else
                            {
                                MessageBox.Show("Loan contract ended, reject out");
                                return;
                            }

                        }
                        var checkVehicle1 = context.Vehicles.OfType<Model.Truck>().Where(t => t.licensePlates == textBox_LicensePlate.Text && t.status == "In")
                                    .Join(context.Contracts.OfType<Model.LongTermKeepContract>().Where(t => t.key == textBox_Key.Text && t.status == "Active"),
                                    Vehicle => Vehicle.ID,
                                    Contract => Contract.truckID,
                                    (Vehicle, Contract) => new
                                    {
                                        Vehicle.licensePlates,
                                        vehicleID = Vehicle.ID,
                                        contractID = Contract.ID,
                                        Contract.fee,
                                        Contract.dateEnd
                                    }).FirstOrDefault();

                        if (checkVehicle1 != null)
                        {
                            if (checkVehicle1.dateEnd > DateTime.Now)
                            {
                                DialogResult dialogResult = MessageBox.Show("Vehicle in Long term contract", "Fee keep vehicle", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                if (dialogResult == DialogResult.OK)
                                {
                                    try
                                    {
                                        var vehicle = context.Vehicles.OfType<Model.Truck>().Where(t => t.ID == checkVehicle1.vehicleID).FirstOrDefault();
                                        vehicle.status = "Out";

                                        context.SaveChanges();
                                        MessageBox.Show("Accept out");
                                        comboBox_TypeVehicle.Text = "";
                                        textBox_LicensePlate.Text = "";
                                        pictureBox_ImagePlate.Image = null;
                                        textBox_Key.Text = "";

                                        return;

                                    }
                                    catch
                                    {
                                        MessageBox.Show("Accept out fail");
                                        return;
                                    }
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Long term contract expired");
                                return;
                            }

                        }


                        var checkVehicle2 = context.Vehicles.OfType<Model.Truck>().Where(t => t.licensePlates == textBox_LicensePlate.Text && t.status == "In")
                                        .Join(context.Contracts.OfType<Model.DayKeepContract>().Where(t => t.key == textBox_Key.Text && t.status == "Active"),
                                        Vehicle => Vehicle.ID,
                                        Contract => Contract.truckID,
                                        (Vehicle, Contract) => new
                                        {
                                            Vehicle.licensePlates,
                                            vehicleID = Vehicle.ID,
                                            contractID = Contract.ID,
                                            Contract.dateCreate,
                                            Contract.dateEnd
                                        }).FirstOrDefault();
                        if (checkVehicle2 != null)
                        {
                            var feeKeep = context.FeeKeeps.Where(t => t.typeVehicle == "Truck").FirstOrDefault();
                            var contract = context.Contracts.OfType<Model.DayKeepContract>().Where(t => t.ID == checkVehicle2.contractID).FirstOrDefault();
                            DateTime dateCreate = contract.dateCreate ?? DateTime.MinValue;
                            int time = (DateTime.Now - dateCreate).Days;
                            DialogResult dialogResult = MessageBox.Show("Fee: " + ((time + 1) * feeKeep.dayPrice).ToString() + " USD", "Fee keep vehicle", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            if (dialogResult == DialogResult.OK)
                            {
                                try
                                {
                                    var vehicle = context.Vehicles.OfType<Model.Truck>().Where(t => t.ID == checkVehicle.vehicleID).FirstOrDefault();
                                    contract.dateEnd = DateTime.Now;
                                    contract.fee = (time + 1) * feeKeep.dayPrice;
                                    vehicle.status = "Out";
                                    contract.status = "Done";
                                    context.SaveChanges();
                                    MessageBox.Show("Accept out");
                                    comboBox_TypeVehicle.Text = "";
                                    textBox_LicensePlate.Text = "";
                                    pictureBox_ImagePlate.Image = null;
                                    textBox_Key.Text = "";

                                    return;

                                }
                                catch
                                {
                                    MessageBox.Show("Reject out");
                                    return;
                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Key is not valid");
                            return;
                        }


                    }
                }
            }

            }

            private void button_editInformation_Click(object sender, EventArgs e)
            {
                KeepWorkerEditInformationForm keepWorkerEditInformationForm = new KeepWorkerEditInformationForm();
                keepWorkerEditInformationForm.Show();
            }

            private void button_reset_Click(object sender, EventArgs e)
            {
                loadProfile();
            }
        

    }
}
