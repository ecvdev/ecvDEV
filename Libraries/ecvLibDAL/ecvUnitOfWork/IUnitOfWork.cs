using ecvLibDAL.ecvRepositories.Catalog;
using ecvLibDAL.ecvRepositories.Vendors;
using System;

namespace ecvLibDAL.ecvUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        string ecvError { get; set; }

        ICategoryRepository categoryRepository { get; }
        IProductRepository productRepository { get; }
        IProductTypeRepository productTypeRepository { get; }
        IManufacturerRepository manufacturerRepository { get; }
        IVendorRepository vendorRepository { get; }
        int Complete();
    }
}
