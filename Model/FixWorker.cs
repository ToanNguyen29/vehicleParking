using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWindow.Model
{
    internal class FixWorker : User
    {
        public string cardID { get; set; }

        public string address { get; set; }

        public byte[] picture { get; set; }

        public int? shiftID { get; set; }
        public Shift Shift { get; set; }

        public int? facilityID { get; set; }
        public Facility Facility { get; set; }

        public virtual ICollection<BillFix> BillFixes { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Salary> Salaries { get; set; }

        public float? coefficients { get; set; }

        public float? baseSalary { get; set; }

    }
}
