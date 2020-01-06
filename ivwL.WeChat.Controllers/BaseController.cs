using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ivwL.WeChat.Controllers
{
    public class BaseController : Controller
    {
        public async Task<JsonResult> Success() => await Task.Run(() => Json(new { code = 1 }));
        public async Task<JsonResult> Success(object data) => await Task.Run(() => Json(new { code = 1, data = data }));

        public async Task<JsonResult> Error(string errorMsg) => await Task.Run(() => Json(new { code = 0, errorMsg = errorMsg }));
    }
}
