using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Admin GetAdmin(string userName,string password);

        Writer GetWriter(string userName, string password);
    }
}

