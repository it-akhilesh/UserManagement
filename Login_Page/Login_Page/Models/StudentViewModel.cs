using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login_Page.Models
{
    public class StudentViewModel
    {
        [Required(ErrorMessage = "Name is required")]    
        public string Name { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }
        
        public List<SelectListItem> CountryList { get; set; }
        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }
        
        public List<SelectListItem> StateList { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        public List<SelectListItem> CityList { get; set; }
        [Required(ErrorMessage = "Pin Code is required")]
        public string PinCode { get; set; }
        [Required(ErrorMessage = "Mobile No is required")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Display(Name = "Upload Photo")]
        public HttpPostedFileBase Photo { get; set; }
    }
}