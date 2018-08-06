using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ecvLib.Core.ecvDomain.Catalog;
using ecvAdminUI.Controllers;
using ecvAdminUI.Factories.Catalog;
using ecvLib.Core;
using ecvAdminUI.Models.Catalog;
using ecvLibDAL.ecvUnitOfWork;

namespace ecvUnitTests.ecvAdminTest.Catalog
{
    [TestClass]
    public class utCategory
    {
        [TestMethod]
        public void CheckCategory()
        {
            ////-------------------------------Arrange---------------------\\\\
            //-----Set Unit of work
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork.Setup(m => m.categoryRepository.GetAll()).Returns(new Category[] {
                new Category {Id = 1, Name = "C1"},
                new Category {Id = 2, Name = "C2",DisplayOrder=1},
                new Category {Id = 3, Name = "C3"},
                new Category {Id = 4, Name = "C4",ParentCategoryId=2},
                new Category {Id = 5, Name = "C5"}
            });

            //--- Set CategoryModelFactory
            CatalogModelFactory _catalogModelFactory = new CatalogModelFactory(mockUnitOfWork.Object);

            //--- Set CategoryController
            CategoryController _categoryController = new CategoryController(_catalogModelFactory);


            ////-------------------------------Act---------------------\\\\
            string categoryName = "";
            int storeId = 0;
            int pageIndex = 1;
            int pageSize = 30;
            bool showHidden = false;

            var resultList = _categoryController.ListX(categoryName, storeId, pageIndex, pageSize, showHidden);

            PagedList<CategoryListModel> result = (PagedList<CategoryListModel>)((ViewResult)resultList).Model;

            ////-----------Below line is alternate to above result variable
            ///var resultA = ((ViewResult)result).Model as IList<CategoryListModel>;


            ////-------------------------------Assert---------------------\\\\
            CategoryListModel[] categoryArray = result.ToArray();
            Assert.IsTrue(categoryArray.Length == 5);
            Assert.AreEqual(categoryArray[0].CategoryName, "C1");
            Assert.AreEqual(categoryArray[1].DisplayOrder, 1);
            Assert.AreEqual(categoryArray[2].ParentCategoryId, 2);
        }
    }
}
