using ivwL.WeChat.IDao;
using ivwL.WeChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivwL.WeChat.Dao
{
    public class Sys_InfoDao : BaseDao<Sys_Info>, ISys_InfoDao
    {
        public Sys_InfoDao(string sqlConn, string sqlDataBaseType) : base(sqlConn,sqlDataBaseType)
        {
        }
    }
}
