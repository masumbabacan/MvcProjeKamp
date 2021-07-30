using Business.Abstract;
using Business.Concrete;
using DataAccess.EntityFramework;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Core.Logging;

namespace MvcProjeKamp.Infrastructure
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        IKernel _ninjectKernel;

        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddBllBindings();
        }

        private void AddBllBindings()
        {
            _ninjectKernel.Bind<IAbilityService>().To<AbilityManager>().WithConstructorArgument("abilityDal",new EfAbilityDal());
            _ninjectKernel.Bind<IAboutService>().To<AboutManager>().WithConstructorArgument("aboutDal", new EfAboutDal());
            _ninjectKernel.Bind<IAdminService>().To<AdminManager>().WithConstructorArgument("adminDal", new EfAdminDal());
            _ninjectKernel.Bind<ICategoryService>().To<CategoryManager>().WithConstructorArgument("categoryDal", new EfCategoryDal());
            _ninjectKernel.Bind<IContactService>().To<ContactManager>().WithConstructorArgument("contactDal", new EfContactDal());
            _ninjectKernel.Bind<IContentService>().To<ContentManager>().WithConstructorArgument("contentDal", new EfContentDal());
            _ninjectKernel.Bind<IHeadingService>().To<HeadingManager>().WithConstructorArgument("headingDal", new EfHeadingDal());
            _ninjectKernel.Bind<IImageFileService>().To<ImageFileManager>().WithConstructorArgument("imageFileDal", new EfImageFileDal());
            _ninjectKernel.Bind<IMessageService>().To<MessageManager>().WithConstructorArgument("messageDal", new EfMessageDal());
            _ninjectKernel.Bind<IWriterService>().To<WriterManager>().WithConstructorArgument("writerDal", new EfWriterDal());

            _ninjectKernel.Intercept(p => (true)).With(new LoggingInterceptor());
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_ninjectKernel.Get(controllerType);
        }
    }
}