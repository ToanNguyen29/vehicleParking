using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWindow.SalaryDecorator
{
    internal class HardworkingBonus : SalaryDecoratorClass
    {
        private float bonus = 0;

        public HardworkingBonus(float bonus)
        {
            this.bonus = bonus;
        }

        public override float ModifySalary(float currentSalary)
        {
            return currentSalary + bonus;
        }
    }
}
