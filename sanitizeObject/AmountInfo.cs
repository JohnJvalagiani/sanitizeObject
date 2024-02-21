using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sanitizeObject
{
    class AmountInfo
    {
        public double Amount { get; set; }
        public string Currency { get; set; }
        public Payment owner { get; set; }
    }

}
