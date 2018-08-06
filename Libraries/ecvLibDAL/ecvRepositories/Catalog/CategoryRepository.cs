using ecvLib.Core.ecvDomain.Catalog;
using System.Collections.Generic;
using System.Linq;

namespace ecvLibDAL.ecvRepositories.Catalog
{
    public class CategoryRepository : ecvRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ecvDBContext context)
            :base(context)
        {
        }

        public ecvDBContext ecvDBContext
        {
            get { return Context as ecvDBContext; }
        }

        public IList<Category> GetAllCategories(string categoryName = "", int storeId = 0, int pageIndex = 1, int pageSize = 6, bool showHidden = false)
        {
            return ecvDBContext.Category                 
                .OrderBy(c => c.Name)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)                
                .ToList();
             
        }

        public string markAsDeleted(int categoryId)
        {
            var _category = base.Get(categoryId);

            _category.Deleted = true;

            var parentCategoryForList = ecvDBContext.Category
                .Where(c => c.ParentCategoryId == _category.Id)
                .ToList();

            foreach(var childCategory  in parentCategoryForList)
            {
                childCategory.ParentCategoryId = 0;
            }            

            return "true";
        }


    }
}
