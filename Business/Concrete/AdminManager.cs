using Business.Abstract;
using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Business.Concrete
{

    public class AdminManager : IAdminService
    {
        SHA1 sha = new SHA1CryptoServiceProvider();
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void Add(Admin admin)
        {
            //admin.AdminPassword = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(admin.AdminPassword)));
            _adminDal.Insert(admin);
        }

        public void Delete(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        public List<Admin> GetAll()
        {
            return _adminDal.List();
        }

        public Admin GetById(int id)
        {
            return _adminDal.Get(x => x.AdminId == id);
        }

        public Admin GetRolesForUser(string username)
        {
            return _adminDal.Get(x => x.AdminUserName == username);
        }

        public void Update(Admin admin)
        {
            _adminDal.Update(admin);
        }
    }
}
