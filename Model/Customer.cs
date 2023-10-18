using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWindow.Model
{
    internal class Customer : User
    {
        public string address { get; set; }

        public byte[] picture { get; set; }

        public virtual ICollection<BillFix> BillFixes { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }

    }
}
