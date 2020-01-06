using ivwL.WeChat.Models;
using ivwL.WeChat.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivwL.WeChat.Controllers
{
    public class AccountController : BaseController
    {
        public async Task<IActionResult> Index() => await Task.Run(() => View());

        [HttpPost]
        public async Task<JsonResult> Login([FromBody]Sys_User model)
        {
            try
            {
                var sys_User = (await ServiceHelper.Sys_UserService.GetList(a => a.Code == model.Code && a.Password == model.Password)).SingleOrDefault();
                if (sys_User == null)
                {
                    return await Error("账号或密码错误");
                }
                return await Success(sys_User.ToJson());
            }
            catch (Exception ex)
            {
                return await Error(ex.Message);
            }
        }
    }
}
