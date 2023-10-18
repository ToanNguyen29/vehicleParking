using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWindow.Model
{
    internal class Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int? fixWorkerID { get; set; }
        public FixWorker FixWorker { get; set; }

        public int? keepWorkerID { get; set; }
        public KeepWorker KeepWorker { get; set; }

        public DateTime dateWork { get; set; }

        public float? hourWork { get; set; }

        public float? baseSalary { get; set; }

        public float? bonusSalary { get; set; }

        public float? penaltySalary { get; set; }

        public float? totalSalary { get; set; }      
    }
}
