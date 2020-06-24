using BlueBank.Model;
using BlueBank.Service;
using BlueBank.WebFrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BlueBank.WebFrontEnd.Controllers
{
    public class LoginController : Controller
    {
        LoginService service = new LoginService();

        public ActionResult Index()
        {
            return View(new Login());
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(Login login)
        {
            byte[] passtohash = System.Text.Encoding.UTF8.GetBytes(login.Password);
            login.Password = Md5hash(passtohash);
            LoginDTO loginDTO = service.GetLoginInformation(login);

            if (login.EmployeeId < 10000000 || login.EmployeeId > 99999999)
            {
                login.AddError(new Error(8, "Employee ID must be an 8 digit number", "Model"));
                return View(login);
            }
            if (loginDTO == null)
            {
                login.AddError(new Error(9, "Employee ID and/or Password incorrect", "Model"));
                return View(login);
            }
            else if (loginDTO.Status != EmploymentStatus.Active)
            {
                login.AddError(new Error(10, "Employee is not active", "Business"));
                return View(login);
            }

            System.Web.HttpContext.Current.Session["employeeId"] = loginDTO.EmployeeId;
            System.Web.HttpContext.Current.Session["employeeName"] = loginDTO.EmployeeName;
            System.Web.HttpContext.Current.Session["employeeType"] = (int)loginDTO.EmployeeType;
            System.Web.HttpContext.Current.Session["department"] = loginDTO.Department;

            if (Session["browsePoId"] != null)
            {
                ActionResult actionResult = RedirectToAction("Browse", "PO", new { purchaseOrderId = Convert.ToInt32(Session["browsePoId"]) });
                Session.Remove("browsePoId");
                return actionResult;
            }

            return RedirectToAction("Welcome", loginDTO);
        }

        public ActionResult Logout()
        {
            Session.Remove("employeeId");
            Session.Remove("employeeName");
            Session.Remove("employeeType");
            Session.Remove("department");
            return RedirectToAction("Index");
        }

        public ActionResult Welcome(LoginDTO loginDTO)
        {
            if (Session["employeeId"] == null)
            {
                return RedirectToAction("Index");
            }

            return View(loginDTO);
        }

        private string Md5hash(byte[] value)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                var hash = md5.ComputeHash(value);

                return Convert.ToBase64String(hash);
            }
        }
    }
}