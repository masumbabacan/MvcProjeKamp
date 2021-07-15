﻿using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfImageFileDal : GenericRepository<ImageFile>, IImageFileDal
    {
    }
}