using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.BussinessLogics;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisteredController : ControllerBase
    {
        [HttpGet]
        [EnableCors("Policy")]
        [Route("GetRegister")]

        public ActionResult GetRegister()

        {
            var a = RegisteredProcessor.Read();
            return Ok(a);
        }
        [HttpPost]
        [EnableCors("Policy")]
        [Route("SaveRegister")]
        public int SaveRegister([FromBody]SEC_SM_LOGIN obj)
        {
            return RegisteredProcessor.Create(obj);
        }
        [HttpPut]
        [EnableCors("Policy")]
        [Route("UpdateRegister")]

        public int UpdateRegister([FromBody]SEC_SM_LOGIN obj)
        {
            return RegisteredProcessor.Update(obj);
        }
        [HttpGet]
        [EnableCors("Policy")]
        [Route("DeleteRegister")]

        public int DeleteRegister(int id)
        {
            return RegisteredProcessor.Delete(id);
        }
    }
}