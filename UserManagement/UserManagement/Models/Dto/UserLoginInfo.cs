using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserManagement.Models.Dto
{
    public class UserLoginInfo
    {
        public bool IsValidUser { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
    }
}