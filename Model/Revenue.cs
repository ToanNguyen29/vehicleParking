using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWindow.Model
{
    class Revenue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int? facilityID { get; set; }
        public Facility Facility { get; set; }

        public int month { get; set; }
        public int year { get; set; }

        public float fixFee { get; set; }

        public float KeepFee { get; set; }
    }
}
