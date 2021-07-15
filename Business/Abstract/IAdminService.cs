using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetAll();

        Admin GetById(int id);

        Admin GetRolesForUser(string username);

        void Add(Admin admin);

        void Delete(Admin admin);

        void Update(Admin admin);
    }
}

