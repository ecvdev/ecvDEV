using System;
using ecvLibDAL.ecvRepositories.Catalog;
using ecvLibDAL.ecvRepositories.Vendors;

namespace ecvLibDAL.ecvUnitOfWork
{
    public class ecvUnitOfWork : IUnitOfWork
    {
        private readonly ecvDBContext _context;
        string _ecvError = "";

        public ecvUnitOfWork(ecvDBContext context)
        {
            _context = context;
            categoryRepository = new CategoryRepository(_context);
            productRepository = new ProductRepository(_context);
            productTypeRepository = new ProductTypeRepository(_context);
            manufacturerRepository = new ManufacturerRepository(_context);
            vendorRepository = new VendorRepository(_context);
        }

        public ICategoryRepository categoryRepository
        {
            get;
            private set;
        }

        public IProductRepository productRepository
        {
            get;
            private set;
        }

        public IProductTypeRepository productTypeRepository
        {
            get;
            private set;
        }

        public IManufacturerRepository manufacturerRepository
        {
            get;
            private set;
        }

        public IVendorRepository vendorRepository
        {
            get;
            private set;
        }

        string IUnitOfWork.ecvError
        {
            get
            {
                return _ecvError;
            }
            set
            {
                _ecvError = value;
            }
        }

        public int Complete()
        {
            _ecvError = "";
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception ex1)
            {
                //throw new Exception("Error updating record : " + ex1.Message.ToString());
                _ecvError = "Error updating record : " + ex1.Message.ToString();
                return 0;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
