using ivwL.WeChat.IDao;
using ivwL.WeChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivwL.WeChat.Dao
{
    public class Sys_UserDao : BaseDao<Sys_User>, ISys_UserDao
    {
        public Sys_UserDao(string sqlConn, string sqlDataBaseType) : base(sqlConn,sqlDataBaseType)
        {
        }
    }
}
