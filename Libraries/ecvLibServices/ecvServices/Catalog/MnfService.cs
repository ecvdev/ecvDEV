using ecvLib.Core.ecvDomain.Catalog;
using ecvLibDAL.ecvRepositories;
using ecvLibDAL.ecvUnitOfWork;
using ecvLibDTOs.ecvDTOs.Catalog;
using ecvLibServices.ecvServices;

namespace ecvLibServices.ecvServices.Catalog
{
    public partial class MnfService: ecvService<ManufacturerDTO, ManufacturerListDTO, Manufacturer>
    {

        public MnfService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }        

        public void GetManufacturerTest()
        {
            
        }


    }// End of -- public partial class MnfService
}