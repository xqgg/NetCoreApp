using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Redis
{
    public class RedisOptions
    {
        public string Connection { get; set; } = string.Empty;
        public string InstanceName { get; set; } = string.Empty;
        public int DefaultDB { get; set; }
    }
}
