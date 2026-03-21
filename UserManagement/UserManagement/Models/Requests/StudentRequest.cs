using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserManagement.Models.stu
{
    public class StudentRequest
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }
        
        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }
        
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        
        [Required(ErrorMessage = "Pin Code is required")]
        public string PinCode { get; set; }
        [Required(ErrorMessage = "Mobile No is required")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        //[Display(Name = "Upload Photo")]
        //public HttpPostedFileBase Photo { get; set; }
    }
}