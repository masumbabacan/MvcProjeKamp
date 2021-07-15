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
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _imageFileDal;

        public ImageFileManager(IImageFileDal imageFileDal)
        {
            _imageFileDal = imageFileDal;
        }

        public void Add(ImageFile imageFile)
        {
            _imageFileDal.Insert(imageFile);
        }

        public void Delete(ImageFile imageFile)
        {
            _imageFileDal.Delete(imageFile);
        }

        public List<ImageFile> GetAll()
        {
            return _imageFileDal.List();
        }

        public ImageFile GetById(int id)
        {
            return _imageFileDal.Get(x => x.Id == id);
        }

        public void Update(ImageFile imageFile)
        {
            _imageFileDal.Update(imageFile);
        }
    }
}
