using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Redis
{
    public class RedisHelper
    {
        private readonly IOptionsSnapshot<RedisOptions> _optionsSnapshot;
        public RedisHelper(IOptionsSnapshot<RedisOptions> optionsSnapshot)
        {
            _optionsSnapshot = optionsSnapshot;
        }

        public void Test()
        {
            Console.WriteLine(_optionsSnapshot.Value.Connection);
        }

    }
}
