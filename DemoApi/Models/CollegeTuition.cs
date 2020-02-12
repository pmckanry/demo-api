using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApi.Models
{
    public class CollegeTuition
    {
        public string College { get; set; }
        public decimal InStateTuition { get; set; }
        public decimal? OutStateTuition { get; set; }
        public decimal RoomBoard { get; set; }
    }
}
