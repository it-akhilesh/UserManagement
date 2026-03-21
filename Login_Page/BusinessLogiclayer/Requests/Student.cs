using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogiclayer.Requests
{
    public class Student
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }

        //[Display(Name = "Upload Photo")]
        //public HttpPostedFileBase Photo { get; set; }
    }
}
