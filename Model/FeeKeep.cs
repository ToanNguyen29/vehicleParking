using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWindow.Model
{
    internal class FeeKeep
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string typeVehicle { get; set; }

        public float? dayPrice { get; set; }

        public float? weekPrice { get; set; }

        public float? monthPrice { get; set; }
   
    }
}
