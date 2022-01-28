using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminLoginManager : IAdminLoginService
    {
        IAdminLoginDal _adminLoginDal;

        public AdminLoginManager(IAdminLoginDal adminLoginDal)
        {
            _adminLoginDal = adminLoginDal;
        }

        public bool IsAdmin(string userName, string password)
        {
            var admin = _adminLoginDal.Get(x => x.AdminUserName == userName && x.AdminPassword == password);

            if (admin != null)
                return true;

            return false;
        }
    }
}
