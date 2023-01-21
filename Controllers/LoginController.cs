using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CarzRentals.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Employee model)
        {
            DBCarzRentalEntities db = new DBCarzRentalEntities();

            Employee employee = db.Employees.Find(model.EmployeeId);
            if(employee != null)
            {
                if(employee.Password == model.Password)
                {
                    FormsAuthentication.SetAuthCookie(model.EmployeeId.ToString(), false);
                    Response.Redirect("~/", true);
                }
                else
                {
                    ViewData["MESSAGE"] = "Invalid Password";
                }
            }
            else
            {
                ViewData["MESSAGE"] = "Employee not found";
            }

            return View();
        }
    }
}