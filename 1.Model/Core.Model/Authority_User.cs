using Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Authority_User : BaseModel
    {
        public string Account { get; set; }


        public string Password { get; set; }
    }
}
