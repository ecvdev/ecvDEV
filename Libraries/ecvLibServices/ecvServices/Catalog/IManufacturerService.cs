using ecvLib.Core.ecvDomain.Catalog;
using ecvLib.Core.ecvOperationStatus;
using ecvLibDTOs.ecvDTOs.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecvLibServices.ecvServices.Catalog
{
    public partial interface IManufacturerService
    {
        /// <summary>
        /// Gets a manufacturer by manufacturer identifier
        /// </summary>
        /// <param name="manufacturerId">Manufacturer identifier</param>
        /// <returns>Manufacturer</returns>
        ManufacturerDTO GetManufacturerById(int manufacturerId);

        /// <summary>
        /// Delete a manufacturer
        /// </summary>
        /// <param name="manufacturer">Manufacturer</param>
        ecvOperationStatus DeleteManufacturer(int manufacturerId);

        /// <summary>
        /// Gets all manufacturers
        /// </summary>        
        /// <returns>Manufacturers</returns>
        IEnumerable<ManufacturerDTO> GetAllManufacturers();
        //string name = "",int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)


        IEnumerable<ManufacturerListDTO> GetManufacturersList();

        /// <summary>
        /// Create a manufacturer
        /// </summary>
        /// <param name="manufacturer">Manufacturer</param>
        void CreateManufacturer(Manufacturer manufacturer);

        /// <summary>
        /// Updates the manufacturer
        /// </summary>
        /// <param name="manufacturer">Manufacturer</param>
        void UpdateManufacturer(Manufacturer manufacturer);


        /// <summary>
        /// Save the manufacturer
        /// </summary>
        /// <param name="manufacturer">Manufacturer</param>
        ecvOperationStatus SaveManufacturer(ManufacturerDTO manufacturerDto);

        /// <summary>
        /// Check vendro Business And Validation Rules
        /// </summary>
        /// <param name="manufacturerDTO">ManufacturerDTO</param>
        List<ecvRuleViolation> processBAVRules(ManufacturerDTO manufacturerDto);

        int Complete();
    }
}
