using ivwL.WeChat.IDao;
using ivwL.WeChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivwL.WeChat.Services
{
    public class Sys_InfoService : BaseService<Sys_Info>
    {
        public Sys_InfoService(IBaseDao<Sys_Info> dao) : base(dao)
        {
        }
    }
}
