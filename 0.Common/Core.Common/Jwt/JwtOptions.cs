using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.Common.Jwt
{
    public class JwtOptions
    {
        /// <summary>
        /// 发行人
        /// </summary>
        [Display(Name = "发行人")]
        public string Issuer { get; set; }

        /// <summary>
        /// 受众人
        /// </summary>
        [Display(Name = "受众人")]
        public string Audience { get; set; }

        /// <summary>
        /// 密钥
        /// </summary>
        [Display(Name = "密钥")]
        public string SecurityKey { get; set; }
    }
}
