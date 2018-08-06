using ecvAdminUI.Factories.Catalog;
using ecvAdminUI.Factories.Vendors;
using ecvLib.Core;
using ecvLibDAL.ecvRepositories;
using ecvLibDAL.ecvRepositories.Catalog;
using ecvLibDAL.ecvUnitOfWork;
using ecvLibServices.ecvServices.Catalog;
using ecvLibServices.ecvServices.Vendors;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ecvAdminUI.Infrastructure
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

            //kernel.Bind(typeof(IRepository<>)).To(typeof(ecvRepository<>));
            //kernel.Bind(typeof(IDbContext)).To<ecvObjectContext>().WithConstructorArgument("nameOrConnectionString", ConfigurationManager.ConnectionStrings["ecvObjectContext"].ConnectionString);

            kernel.Bind<IUnitOfWork>().To<ecvUnitOfWork>();
            kernel.Bind<IRepository<object>>().To<ecvRepository<object>>();

            kernel.Bind<ICategoryService>().To<CategoryService>();
            kernel.Bind<ICategoryRepository>().To<CategoryRepository>();
            kernel.Bind<ICatalogModelFactory>().To<CatalogModelFactory>();

            kernel.Bind<IProductRepository>().To<ProductRepository>();
            kernel.Bind<IProductTypeRepository>().To<ProductTypeRepository>();
            kernel.Bind<IProductModelFactory>().To<ProductModelFactory>();
            kernel.Bind<IManufacturerModelFactory>().To<ManufacturerModelFactory>();

            kernel.Bind<IVendorService>().To<VendorService>();
            kernel.Bind<IVendorModelFactory>().To<VendorModelFactory>();
            kernel.Bind<IPagedList>().To<IPagedList>();


        }

    }// End of -- public class NinjectDependencyResolver
}