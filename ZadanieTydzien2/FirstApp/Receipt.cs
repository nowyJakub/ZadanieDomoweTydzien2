using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    class Receipt
    {
        public int Id { get; set; } // type of Receipt
        public int Cost { get; set; }
        public string Details { get; set; }
        
        public int Day { get; set; }  
        public int Month { get; set; }  

    }
}
