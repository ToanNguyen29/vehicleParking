using FinalWindow.Database;
using FinalWindow.Model;
using FinalWindow.SalaryDecorator;
using FinalWindow.SalaryDecoratorPattern;
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

namespace FinalWindow.View.Manager
{
    public partial class CalculateSalaryDayWorkerForm : Form
    {
        private float salary;
        private float bonusSalary;
        private float penaltySalary;
        private List<SalaryDecoratorClass> modifiers;
        public CalculateSalaryDayWorkerForm()
        {
            InitializeComponent();
            modifiers = new List<SalaryDecoratorClass>();
        }
        private void ApplyModifiers()
        {
            float updatedSalary = salary;

            foreach (var modifier in modifiers)
            {
                updatedSalary = modifier.ModifySalary(updatedSalary);
            }

            label_totalSalary.Text = updatedSalary.ToString();
            textBox_Bonus.Text = bonusSalary.ToString();
            textBox_Penalty.Text = penaltySalary.ToString();
        }

        private void CalculateWorkerSalaryForm_Load(object sender, EventArgs e)
        {
            salary = float.Parse(label_totalSalary.Text);
            bonusSalary = float.Parse(textBox_Bonus.Text);
            penaltySalary = float.Parse(textBox_Penalty.Text);
        }

        private void checkBox_Harworking_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Harworking.Checked)
            {
                modifiers.Add(new HardworkingBonus(float.Parse(textBox_BaseSalary.Text)/2));
                bonusSalary += float.Parse(textBox_BaseSalary.Text) / 2;
            }
            else
            {
                modifiers.RemoveAll(m => m is HardworkingBonus);
                bonusSalary -= float.Parse(textBox_BaseSalary.Text) / 2;
            }

            ApplyModifiers();
        }

        private void checkBox_laziness_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_laziness.Checked)
            {
                modifiers.Add(new FineLaziness(float.Parse(textBox_BaseSalary.Text)));
                penaltySalary += float.Parse(textBox_BaseSalary.Text);

            }
            else
            {
                modifiers.RemoveAll(m => m is FineLaziness);
                penaltySalary -= float.Parse(textBox_BaseSalary.Text);
            }

            ApplyModifiers();
        }

        private void checkBox_late_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_late.Checked)
            {
                modifiers.Add(new FineLate(float.Parse(textBox_BaseSalary.Text) / 2));
                penaltySalary += float.Parse(textBox_BaseSalary.Text)/2;
            }
            else
            {
                modifiers.RemoveAll(m => m is FineLate);
                penaltySalary -= float.Parse(textBox_BaseSalary.Text) / 2;
            }

            ApplyModifiers();
        }

        private void textBox_HourWorked_Leave(object sender, EventArgs e)
        {
            float floatValue;
            if(string.IsNullOrEmpty(textBox_HourWorked.Text) == false)
            {
                if (float.TryParse(textBox_HourWorked.Text, out floatValue) == false)
                {
                    MessageBox.Show("Please enter hour work again");
                    return;
                    
                }
                else
                {
                    if(floatValue<0 || floatValue > 24)
                    {
                        MessageBox.Show("Hour work value is invalid");
                        return;
                    }    
                    modifiers.Add(new HourWork(floatValue * float.Parse(textBox_BaseSalary.Text)));
                }    

            }   
            else
            {
                MessageBox.Show("Please enter hour work");
                return;
            }
            ApplyModifiers();

        }

        private void checkBox_goodCusReview_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_goodCusReview.Checked)
            {
                modifiers.Add(new GoodCusReview(float.Parse(textBox_BaseSalary.Text)/2));
                bonusSalary += float.Parse(textBox_BaseSalary.Text) / 2;
            }    
            else
            {
                modifiers.RemoveAll(m => m is GoodCusReview);
                bonusSalary -= float.Parse(textBox_BaseSalary.Text) / 2;
            }
            ApplyModifiers();
        }

        private void checkBox_Lie_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Lie.Checked)
            {
                modifiers.Add(new FineLie(float.Parse(textBox_BaseSalary.Text)*2));
                penaltySalary += float.Parse(textBox_BaseSalary.Text) * 2;
            }
            else
            {
                modifiers.RemoveAll(m => m is FineLie);
                penaltySalary -= float.Parse(textBox_BaseSalary.Text) * 2;
            }
            ApplyModifiers();
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox_HourWorked.Text))
            {
                MessageBox.Show("Please enter hour work");
                return;
            } 
            using(var context = new DatabaseContext())
            {
                int id = int.Parse(textBox_ID.Text);
                if (textBox_TypeWorker.Text == "FixWorker")
                {
                    var attendance = context.Attendances.Where(t => t.dateWork.Day == DateTime.Now.Day && t.dateWork.Month == DateTime.Now.Month && t.dateWork.Year == DateTime.Now.Year && t.fixWorkerID == id).FirstOrDefault();
                    attendance.hourWork = float.Parse(textBox_HourWorked.Text);
                    attendance.bonusSalary = float.Parse(textBox_Bonus.Text);
                    attendance.penaltySalary = float.Parse(textBox_Penalty.Text);
                    attendance.totalSalary = float.Parse(label_totalSalary.Text);

                    var salary = context.Salaries.Where(t => t.fixWorkerID == id && t.month == DateTime.Now.Month && t.year == DateTime.Now.Year).FirstOrDefault();
                    salary.totalSalary += attendance.totalSalary;
                }
                else
                {
                    var attendance = context.Attendances.Where(t => t.dateWork.Day == DateTime.Now.Day && t.dateWork.Month == DateTime.Now.Month && t.dateWork.Year == DateTime.Now.Year && t.keepWorkerID == id).FirstOrDefault();
                    attendance.hourWork = float.Parse(textBox_HourWorked.Text);
                    attendance.bonusSalary = float.Parse(textBox_Bonus.Text);
                    attendance.penaltySalary = float.Parse(textBox_Penalty.Text);
                    attendance.totalSalary = float.Parse(label_totalSalary.Text);

                    var salary = context.Salaries.Where(t => t.keepWorkerID == id && t.month == DateTime.Now.Month && t.year == DateTime.Now.Year).FirstOrDefault();
                    salary.totalSalary += attendance.totalSalary;
                }
                try
                {
                    context.SaveChanges();
                    MessageBox.Show("Attendance successful");
                }
                catch
                {
                    MessageBox.Show("Attendance fail");
                }
                
            }    
               
        }
    }
}
