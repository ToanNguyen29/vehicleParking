﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWindow.SalaryDecorator
{
    internal class FineLate : SalaryDecoratorClass
    {
        private float fine = 0;

        public FineLate(float fine)
        {
            this.fine = fine;
        }

        public override float ModifySalary(float currentSalary)
        {
            return currentSalary - fine;
        }
    }
}
