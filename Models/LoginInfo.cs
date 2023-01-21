using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarzRentals.Models
{
    public class LoginInfo
    {
        public int EmployeeID { get; set; }
        public String Password { get; set; }
        public string FullName { get; set; }
    }
}