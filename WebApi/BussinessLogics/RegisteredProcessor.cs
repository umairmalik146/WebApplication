using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DataAccess;
using WebApi.Models;

namespace WebApi.BussinessLogics
{
    public class RegisteredProcessor
    {
        public static int Create(SEC_SM_LOGIN a)
        {
            DynamicParameters dbargs = new DynamicParameters();
            dbargs.Add("@LOGIN_NAME", a.LOGIN_NAME);
            dbargs.Add("@LOGIN_PASS", a.LOGIN_PASS);
            dbargs.Add("@LOGIN_EMP_CODE", a.LOGIN_EMP_CODE);
            dbargs.Add("@LOGIN_COMPUTER_NAME", a.LOGIN_COMPUTER_NAME);
            dbargs.Add("@LOGIN_FROMDATE", a.LOGIN_FROMDATE);
            dbargs.Add("@LOGIN_ROLE_CODE", a.LOGIN_ROLE_CODE);
            dbargs.Add("@LOGIN_STATUS", a.LOGIN_STATUS);
            dbargs.Add("@LOGIN_TOKEN", a.LOGIN_TOKEN);
            dbargs.Add("@LOGIN_USER_TYPE", a.LOGIN_USER_TYPE);
            string b = $@"insert into SEC_SM_LOGIN VALUES(@LOGIN_NAME, @LOGIN_PASS, @LOGIN_EMP_CODE, @LOGIN_COMPUTER_NAME,@LOGIN_FROMDATE,@LOGIN_ROLE_CODE,@LOGIN_STATUS,@LOGIN_TOKEN,@LOGIN_USER_TYPE)";
            return SqlDataAccess.insertDataDapper(b, dbargs);
            //return SqlDataAccess.insertDataDapper("insert into SEC_SM_LOGIN VALUES(@LOGIN_NAME, @LOGIN_PASS, @LOGIN_EMP_CODE, @LOGIN_COMPUTER_NAME,@LOGIN_FROMDATE,@LOGIN_ROLE_CODE,@LOGIN_STATUS,@LOGIN_TOKEN,@LOGIN_USER_TYPE)", dbargs);
        }
        public static List<SEC_SM_LOGIN> Read()
        {
            return SqlDataAccess.LoadDataList<SEC_SM_LOGIN>($"Select *from SEC_SM_LOGIN", new DynamicParameters());
        }

        public static SEC_SM_LOGIN Read1()
        {
            return SqlDataAccess.GetDataModel<SEC_SM_LOGIN>($"Select * from SEC_SM_LOGIN", new DynamicParameters());
        }
        public static int Update(SEC_SM_LOGIN a)
        {
            DynamicParameters dbargs = new DynamicParameters();
            dbargs.Add("@LOGIN_ID", a.LOGIN_ID);
            dbargs.Add("@LOGIN_NAME", a.LOGIN_NAME);
            dbargs.Add("@LOGIN_PASS", a.LOGIN_PASS);
            dbargs.Add("@LOGIN_EMP_CODE", a.LOGIN_EMP_CODE);
            dbargs.Add("@LOGIN_COMPUTER_NAME", a.LOGIN_COMPUTER_NAME);
            dbargs.Add("@LOGIN_FROMDATE", a.LOGIN_FROMDATE);
            dbargs.Add("@LOGIN_TODATE", a.LOGIN_TODATE);
            dbargs.Add("@LOGIN_ROLE_CODE", a.LOGIN_ROLE_CODE);
            dbargs.Add("@LOGIN_STATUS", a.LOGIN_STATUS);
            dbargs.Add("@LOGIN_TOKEN", a.LOGIN_TOKEN);
            dbargs.Add("@LOGIN_USER_TYPE", a.LOGIN_USER_TYPE);
            string qry = $@"Update SEC_SM_LOGIN set LOGIN_NAME=@LOGIN_NAME, LOGIN_PASS=@LOGIN_PASS,LOGIN_EMP_CODE=@LOGIN_EMP_CODE,LOGIN_COMPUTER_NAME=@LOGIN_COMPUTER_NAME,LOGIN_FROMDATE=@LOGIN_FROMDATE,LOGIN_TODATE=@LOGIN_TODATE,LOGIN_ROLE_CODE=@LOGIN_ROLE_CODE,LOGIN_STATUS=@LOGIN_STATUS,LOGIN_TOKEN=@LOGIN_TOKEN,LOGIN_USER_TYPE=@LOGIN_USER_TYPE where LOGIN_ID = @LOGIN_ID";
            return SqlDataAccess.insertDataDapper(qry, dbargs);

        }
        public static int Delete(int Id)
        {
            try
            {
                return SqlDataAccess.insertDataDapper($"Delete from SEC_SM_LOGIN where  ID ={ Id}", new DynamicParameters());
            }
            catch (Exception ex)
            {
                return 2;
                throw;
            }
        }

    }
}
