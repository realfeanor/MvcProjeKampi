using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class RoleManager : IRoleService
    {
        public Heading GetByRoleId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Role> GetRoleList()
        {
            throw new NotImplementedException();
        }

        public void RoleAddBl(Role role)
        {
            throw new NotImplementedException();
        }

        public void RoleDelete(Role role)
        {
            throw new NotImplementedException();
        }

        public void RoleUpdate(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
