using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Abc_Company.Models
{
    public class CarrierModel
    {
        [Key]
        public string id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Coordinates { get; set; }

    }
}
