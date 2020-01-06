using ivwL.WeChat.IDao;
using ivwL.WeChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivwL.WeChat.Services
{
    public class Sys_UserService : BaseService<Sys_User>
    {
        public Sys_UserService(IBaseDao<Sys_User> dao) : base(dao)
        {
        }
    }
}
