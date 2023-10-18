using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWindow.Model
{
    internal class Car : Vehicle
    {
        public int seat { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }

    }
}
