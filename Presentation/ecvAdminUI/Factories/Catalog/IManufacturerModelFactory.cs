using ecvAdminUI.Models.Catalog;
using ecvAdminUI.ViewModels.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecvAdminUI.Factories.Catalog
{
    public partial interface IManufacturerModelFactory
    {

        List<ManufacturerListModel> GetManufacturerList(bool FirstElementEmpty);

        //List<ManufacturerListModel> GetAllManufacturerList(bool FirstElementEmpty);

        ManufacturerViewModel getManufacturerVM(int manufacturerId);

        //ManufacturerViewModel deleteManufacturer(ManufacturerViewModel manufacturerViewModel);

        ManufacturerViewModel saveManufacturer(ManufacturerViewModel manufacturerViewModel);
    }
}
