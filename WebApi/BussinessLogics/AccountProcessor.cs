using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DataAccess;
using WebApi.Models;

namespace WebApi.BussinessLogics
{
    public class AccountProcessor
    {
        public static Account Login(string email, string password)
        {

            string qry = $@"Select top(1) *FROM SEC_SM_LOGIN where LOGIN_NAME = @email AND LOGIN_PASS =@password";
            return SqlDataAccess.GetSingleDataValues<Account>(qry, new DynamicParameters());
        }
    }
}
