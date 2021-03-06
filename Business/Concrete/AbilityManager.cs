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
    public class AbilityManager : IAbilityService
    {
        IAbilityDal _abilityDal;

        public AbilityManager(IAbilityDal abilityDal)
        {
            _abilityDal = abilityDal;
        }

        public void Add(Ability ability)
        {
            _abilityDal.Insert(ability);
        }

        public void Delete(Ability ability)
        {
            _abilityDal.Delete(ability);
        }

        public List<Ability> GetAll()
        {
            return _abilityDal.List();
        }

        public Ability GetById(int id)
        {
            return _abilityDal.Get(x => x.Id == id);
        }

        public void Update(Ability ability)
        {
            _abilityDal.Update(ability);
        }
    }
}
