using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IImageFileService
    {
        List<ImageFile> GetAll();

        ImageFile GetById(int id);

        void Add(ImageFile imageFile);

        void Delete(ImageFile imageFile);

        void Update(ImageFile imageFile);
    }
}

