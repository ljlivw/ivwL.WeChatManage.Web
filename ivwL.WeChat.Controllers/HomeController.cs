using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ivwL.WeChat.Controllers
{
    public class HomeController : BaseController
    {
        public async Task<IActionResult> Index() => await Task.Run(() => View());
    }
}
