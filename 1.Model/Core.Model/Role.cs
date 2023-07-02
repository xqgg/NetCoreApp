using Core.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class Role : BaseModel
    {

  
        public string Name { get; set; }
        public string? Description { get; set; }

    }
}
