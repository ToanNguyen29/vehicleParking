using FinalWindow.SalaryDecorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWindow.SalaryDecoratorPattern
{
    internal class FineLie : SalaryDecoratorClass
    {
        private float fine = 0;

        public FineLie(float fine)
        {
            this.fine = fine;
        }

        public override float ModifySalary(float currentSalary)
        {
            return currentSalary - fine;
        }
    }
}
