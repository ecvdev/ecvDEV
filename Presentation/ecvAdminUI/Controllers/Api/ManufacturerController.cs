using ecvAdminUI.Factories.Catalog;
using ecvAdminUI.Models.Catalog;
using System.Collections.Generic;
using System.Web.Http;

namespace ecvAdminUI.Controllers.Api
{
    public class ManufacturerController : ApiController
    {

        IManufacturerModelFactory _manufacturerModelFactory;

        // GET api/<controller>
        public ManufacturerController(IManufacturerModelFactory manufacturerModelFactory)
        {
            _manufacturerModelFactory = manufacturerModelFactory;
        }
        public IEnumerable<ManufacturerListModel> GetManufacturerList()
        {
            var query = _manufacturerModelFactory.GetManufacturerList(false) as IEnumerable<ManufacturerListModel>;

            return query;
        }

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

    }// End of -- public class ManufacturerController : ApiController
}