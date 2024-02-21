using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sanitizeObject
{
    class Payment
    {
        public AmountInfo Amount { get; set; }
        public string Message { get; set; }
        public string RefCode { get; set; }
    }
}
