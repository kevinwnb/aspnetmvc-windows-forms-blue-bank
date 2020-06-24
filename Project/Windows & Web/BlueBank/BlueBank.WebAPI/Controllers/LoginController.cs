using BlueBank.Model;
using BlueBank.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlueBank.WebAPI.Controllers
{
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        LoginService service = new LoginService();

        [HttpGet]
        public IHttpActionResult Login(int employeeId, string password)
        {
            try
            {
                Login login = new Login(employeeId, password);
                LoginDTO loginDTO = service.GetLoginInformation(login);
                //if (loginDTO == null)
                //{
                //    return NotFound();
                //}
                
                return Ok(loginDTO);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.ExpectationFailed, ex.Message);
            }
        }
    }
}
