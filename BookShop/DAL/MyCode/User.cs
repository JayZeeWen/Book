using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BookShop.DAL
{
    public partial class User
    {
        public bool CheckUserName(string userName)
        {
            string sql = "select count(1) from Users where LoginId = @loginId";
            object obj = DbHelperSQL.GetSingle(sql, new SqlParameter("@loginId", userName));
            return Convert.ToInt32(obj) > 0;
        }
    }
}
