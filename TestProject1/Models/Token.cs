using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Models
{
    public class Token
    {
        public string token { get; set; }
        public DateTime expires { get; set; }
        public string status { get; set; }
        public string result { get; set; }
    }
}
