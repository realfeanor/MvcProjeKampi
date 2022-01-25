using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class LoginManager : ILoginService
    {
        ILoginDal _loginDal;

        public LoginManager(ILoginDal loginDal)
        {
            _loginDal = loginDal;
        }

        public bool IsAdmin(string userName, string password)
        {
            var admin = _loginDal.Get(x => x.AdminUserName == userName && x.AdminPassword == password);

            if (admin != null)
                return true;

            return false;
        }

        public bool IsUser(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
