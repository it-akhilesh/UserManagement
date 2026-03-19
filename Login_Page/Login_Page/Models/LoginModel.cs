using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Login_Page.Models
{
    public class LoginModel
    {
        
        public string UserName { get; set; } = string.Empty;
       
       
        public string UserPassword { get; set; } = string.Empty;
    }
}