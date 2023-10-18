using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWindow.Model
{
    internal class Truck : Vehicle
    {
        public float tonnage { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
