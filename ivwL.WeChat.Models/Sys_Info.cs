using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivwL.WeChat.Models
{
    /// <summary>
    /// 系统信息实体
    /// </summary>
    public class Sys_Info
    {
        /// <summary>
        /// 系统信息主键ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 系统代码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 系统名称
        /// </summary>
        public string Name { get; set; }
    }
}
