using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWindow.Model
{
    internal class Shift
    {
        [Key]
        public int ID { get; set; }     
        public TimeSpan startTime { get; set; }

        public TimeSpan endTime { get; set; }

        public int? quantityKeep { get; set; }

        public int? quantityFix { get; set; }

        public virtual ICollection<FixWorker> FixWorkers { get; set; }
        public virtual ICollection<KeepWorker> KeepWorkers { get; set; }
        


    }
}
