using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWindow.Model
{
    internal class BillFix
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public DateTime? dateCreate { get; set; }

        public string description { get; set; }

        public string vehicle { get; set; }

        public int? fixWorkerID { get; set; }
        public FixWorker FixWorker { get; set; }

        public int? customerID { get; set; }
        public Customer Customer { get; set; }

        public float? totalBill { get; set; }

        public int? facilityID { get; set; }
        public Facility Facility { get; set; }

    }
}
