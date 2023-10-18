using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWindow.Model
{
    internal class Facility
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [MaxLength(50)]
        public string address { get; set; }

        public int? quatityFix { get; set; }

        public int? quantityKeep { get; set; }

        public virtual ICollection<FixWorker> FixWorkers { get; set; }
        public virtual ICollection<KeepWorker> KeepWorkers { get; set; }
        public virtual ICollection<Manager> Managers { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Revenue> Revenues { get; set; }
        public virtual ICollection<BillFix> BillFixes { get; set; }

    }
}
