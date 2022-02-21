using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Tracker_Model
{
    internal class UserCommentsModel
    {
        public int Id { get; set; }

        public int RestaurantId { get; set; }

        public string Comment { get; set; }

        public int StarNumberId { get; set; }

        public int UserId { get; set; }
    }
}
