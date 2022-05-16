using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Entities.ComplexType
{
    public class ResponseModel
    {
        public int StatusCode { get; set; }
        public object ResponseMessage{ get; set; }
    }
}
