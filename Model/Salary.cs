using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWindow.Model
{
    internal class Salary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int? fixWorkerID { get; set; }
        public FixWorker FixWorker { get; set; }

        public int? keepWorkerID { get; set; }
        public KeepWorker KeepWorker { get; set; }

        public int month { get; set; }

        public int year { get; set; }

        public float? totalSalary { get; set; }
    }
}
