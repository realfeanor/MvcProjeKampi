using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterLoginManager : IWriterLoginService
    {
        IWriterLoginDal _writerLoginDal;

        public WriterLoginManager(IWriterLoginDal writerLoginDal)
        {
            _writerLoginDal = writerLoginDal;
        }

        public bool IsUser(string userName, string password)
        {
            var user = _writerLoginDal.Get(x => x.WriterMail == userName && x.WriterPassword == password);

            if (user != null)
                return true;

            return false;
        }
    }
}
