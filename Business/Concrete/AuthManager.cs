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

        public AuthManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public Admin GetAdmin(string userName, string password)
        {
            return _adminDal.Get(x => x.AdminUserName == userName && x.AdminPassword == password);
        }
    }
}
