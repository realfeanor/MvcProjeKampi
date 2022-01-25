using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ILoginService
    {
        bool IsAdmin(string userName, string password);

        bool IsUser(string userName, string password);
    }
}
