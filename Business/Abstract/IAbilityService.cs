using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAbilityService
    {
        List<Ability> GetAll();

        Ability GetById(int id);

        void Add(Ability ability);

        void Delete(Ability ability);

        void Update(Ability ability);
    }
}
