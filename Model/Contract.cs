using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWindow.Model
{
    internal abstract class Contract
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string name { get; set; }

        public string key { get; set; }

        public string rule { get; set; }

        public DateTime? dateStartActual { get; set; }
        public DateTime? dateEnd { get; set; }
        public DateTime? dateCreate { get; set; }
        public DateTime? dateEndActual { get; set; }

        public float? fee { get; set; }

        

        public int? customerID { get; set; }
        public Customer Customer { get; set; }

        public int? carID { get; set; }
        public Car Car { get; set; }

        public int? motorID { get; set; }
        public Motor Motor { get; set; }

        public int? truckID { get; set; }
        public Truck Truck { get; set; }

        public int? facilityId { get; set; }
        public Facility Facility { get; set; }

        [MaxLength(50)]
        public string status { get; set; }

    }
}
