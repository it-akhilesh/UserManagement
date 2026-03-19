using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogiclayer.Response
{
    public class UserInfo
    {
        public bool IsSuccess { get; set; }
        public string Username { get; set; }
        public string RoleName { get; set; }
        public string Message { get; set; }
    }
}
