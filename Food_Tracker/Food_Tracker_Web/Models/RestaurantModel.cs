using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Tracker_Model
{
    public class RestaurantModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Adress { get; set; }

        public int PhoneNumber { get; set; }

        public string Bio { get; set; }

        public int CategoryId { get; set; }

        public DateTime Since { get; set; }

        public string City { get; set; }

        public string District { get; set; }
    }
}
