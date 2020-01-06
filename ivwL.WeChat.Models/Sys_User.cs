using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivwL.WeChat.Models
{
    /// <summary>
    /// 系统用户实体
    /// </summary>
    public class Sys_User
    {
        /// <summary>
        /// 系统用户主键ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户代码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string Password { get; set; }
    }
}
