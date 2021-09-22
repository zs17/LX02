using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    class UserInfo
    {
        private UserInfo() { }
        private static UserInfo _instance = new UserInfo();
        public static UserInfo Instance
        {
            get
            {
                return _instance;
            }
        }
        string cns = AppConfigurtaionServices.Configuration.GetConnectionString("cns");
        public string UserCheck(string UserName)
        {
            using (IDbConnection cn = new MySqlConnection(cns))
            {
                string sql = "select password from userinfo where username=@username;";
                return cn.ExecuteScalar<string>(sql, new { username = UserName });
            }
        }
    }
}
