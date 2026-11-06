using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSMS.Models
{
 
        public class Restaurant
        {
            public int RestaurantID { get; set; }

            public string RestaurantName { get; set; }

            public string Phone { get; set; }

            public string Address { get; set; }

            public string Status { get; set; }

            public DateTime CreatedDate { get; set; }
        }
    }

