using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DataAccess;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    //[ApiController]
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [EnableCors("Policy")]
        [Route("Login")]

        public JsonResult Login(string email, string password)
        {
            var dbargs = new DynamicParameters(new { email = email, password = password });
            {
                string qry = $@"Select TOP(1) * From SEC_SM_LOGIN where LOGIN_Name=@email AND LOGIN_PASS=@password";
                var a = SqlDataAccess.GetDataModel<Account>(qry, dbargs);
                if (a == null)
                {
                    return Json(new Dictionary<string, string>
            {
                {"Code","Invalid Login" },
                {"Description","Make Sure Your Credentials"}
            });
                }
                else
                {
                    return Json(new Dictionary<string, string>
            {
                {"Code","Success" },
                {"Description","Successfully Signed In"}
            });
                }
            }
        }
        //public IActionResult Login()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[EnableCors("Policy")]
        //[Route("Login")]
        //public IActionResult Login(string email, string password)
        //{
        //    var a = BussinessLogics.AccountProcessor.Login(email, password);
        //    return View(a);
        //}
    }
}