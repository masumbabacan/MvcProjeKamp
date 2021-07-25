using Business.Abstract;
using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IAdminDal _adminDal;
        IWriterDal _writerDal;

        public AuthManager(IAdminDal adminDal, IWriterDal writerDal)
        {
            _adminDal = adminDal;
            _writerDal = writerDal;
        }

        public Admin GetAdmin(string userName, string password)
        {
            return _adminDal.Get(x => x.AdminUserName == userName && x.AdminPassword == password);
        }

        public Writer GetWriter(string userName, string password)
        {
            return _writerDal.Get(x => x.WriterMail == userName && x.WriterPassword == password);
        }
    }
}
