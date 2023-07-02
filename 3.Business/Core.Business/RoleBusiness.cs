using Core.Enum;
using Core.IBusiness;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
    public class RoleBusiness:IRoleBusiness
    {
        
































        public Task<int> Add(params Role[] items)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(params int[] ids)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Enable(int id, EnumEnable enable)
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(params Role[] items)
        {
            throw new NotImplementedException();
        }
    }
}
