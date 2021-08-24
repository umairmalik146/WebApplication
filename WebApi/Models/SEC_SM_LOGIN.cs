using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class SEC_SM_LOGIN
    {
        public int LOGIN_ID { get; set; }
        public string LOGIN_NAME { get; set; }
        public string LOGIN_PASS { get; set; }
        public string LOGIN_EMP_CODE { get; set; }
        public string LOGIN_COMPUTER_NAME { get; set; }
        public DateTime LOGIN_FROMDATE { get; set; }
        public DateTime LOGIN_TODATE { get; set; }
        public string LOGIN_ROLE_CODE { get; set; }
        public char LOGIN_STATUS { get; set; }
        public string LOGIN_TOKEN { get; set; }
        public string LOGIN_USER_TYPE { get; set; }
    }
}
