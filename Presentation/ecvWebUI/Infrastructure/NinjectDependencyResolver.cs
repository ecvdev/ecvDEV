using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecvWebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {

        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {

            //kernel.Bind<IProductRepository>().ToConstant(mock.Object);
            //kernel.Bind<IProductRepository>().To<EFRepostory>();             

            //////kernel.Bind(typeof(IRepository<>)).To(typeof(EFRepostory<>));
            //////kernel.Bind(typeof(IDbContext)).To<ecvObjectContext>().WithConstructorArgument("nameOrConnectionString", ConfigurationManager.ConnectionStrings["ecvObjectContext"].ConnectionString);
            //////kernel.Bind<ICategoryService>().To<CategoryService>();
            //////kernel.Bind<IPictureService>().To<PictureService>();
            //////kernel.Bind<IProductService>().To<ProductService>();

            //kernel.Bind<ISpecificationAttributeService>().To<SpecificationAttributeService>();

        }

    }// End of -- public class NinjectDependencyResolver
}