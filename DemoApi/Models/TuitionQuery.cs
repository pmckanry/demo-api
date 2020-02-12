using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApi.Models
{
    public class TuitionQuery
    {
        public string Name { get; set; }
        public bool IsInState { get; set; }
        public bool IncludeRoomBoard { get; set; }
    }
}
