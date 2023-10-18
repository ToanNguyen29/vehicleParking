using FinalWindow.SalaryDecorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWindow.SalaryDecoratorPattern
{
    class HourWork : SalaryDecoratorClass
    {
        private float salary = 0;

        public HourWork(float salary)
        {
            this.salary = salary;
        }

        public override float ModifySalary(float currentSalary)
        {
            return currentSalary + salary;
        }
    }
}
