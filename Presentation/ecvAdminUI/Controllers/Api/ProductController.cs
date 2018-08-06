using ecvAdminUI.Factories.Catalog;
using ecvAdminUI.Models.Catalog;
using ecvLib.Core.ecvDomain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace ecvAdminUI.Controllers.Api
{
    public class ProductController : ApiController
    {
        IProductModelFactory _productModelFactory;

        public ProductController(IProductModelFactory productModelFactory)
        {
            _productModelFactory = productModelFactory;
        }

        //GET Api/Products
        public IEnumerable<ProductListModel> GetProductList()
        {
            //_productModelFactory = productModelFactory;
            var query = _productModelFactory.GetAllProductsList() as IEnumerable<ProductListModel> ;
            
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

    }// End of -- public class ProductController : ApiController
}
