using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWindow.Model
{
    internal class Director : User
    {
        public string cardID { get; set; }

        [MaxLength(50)]
        public string address { get; set; }

        public byte[] picture { get; set; }
    }
}
