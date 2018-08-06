using ecvAdminUI.Factories.Catalog;
using ecvAdminUI.Models.Catalog;
using System.Collections.Generic;
using System.Web.Http;

namespace ecvAdminUI.Controllers.Api
{
    public class CategoryController : ApiController
    {
        ICatalogModelFactory _catalogModelFactory;

        public CategoryController(ICatalogModelFactory catalogModelFactory)
        {
            _catalogModelFactory = catalogModelFactory;
        }


        //GET Api/Category
        public IEnumerable<CategoryListModel> GetCategoryList()
        {

            var query = _catalogModelFactory.GetCategoryList(false) as IEnumerable<CategoryListModel>;

            return query;
        }

        // GET api/<controller>
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

    }// End of -- public class CategoryController : ApiController
}