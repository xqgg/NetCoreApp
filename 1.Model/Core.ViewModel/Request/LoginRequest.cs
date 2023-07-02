using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModel.Request
{
    public class LoginRequest
    {
        /// <summary>
        /// 帐号
        /// </summary>
        [Required(ErrorMessage = "帐号必填")]
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "密码必填")]
        public string Password { get; set; }
    }
}
