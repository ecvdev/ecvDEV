using ecvAdminUI.Factories.Vendors;
using ecvAdminUI.Models.Vendors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ecvAdminUI.Controllers.Api
{
    public class VendorController : ApiController
    {
        IVendorModelFactory _vendorModelFactory;
        public VendorController(IVendorModelFactory vendorModelFactory)
        {
            _vendorModelFactory = vendorModelFactory;
        }

        // GET api/<controller>

        public IEnumerable<VendorListModel> GetVendorList()
        {
            var query = _vendorModelFactory.GetVendorsList(false) as IEnumerable<VendorListModel>;

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

    }// End of -- public class VendorController : ApiController
}