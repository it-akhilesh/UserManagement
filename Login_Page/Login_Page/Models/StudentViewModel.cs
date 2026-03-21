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
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public List<SelectListItem> CountryList { get; set; }
        public string State { get; set; }
        public List<SelectListItem> StateList { get; set; }
        public string City { get; set; }
        public List<SelectListItem> CityList { get; set; }

        public string PinCode { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }

        [Display(Name = "Upload Photo")]
        public HttpPostedFileBase Photo { get; set; }
    }
}