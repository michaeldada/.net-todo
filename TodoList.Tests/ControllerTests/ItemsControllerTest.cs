using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Controllers;
using TodoList.Models;
using Xunit;
using Moq;

namespace TodoList.Tests.ControllerTests
{
    public class ItemsControllerTest
    {
        Mock<IItemRepository> mock = new Mock<IItemRepository>();
        private void DbSetup()
        {
            mock.Setup(m => m.Items).Returns(new Item[]
                {
                new Item { ItemId = 1, Description = "Wash the dog" },
                new Item { ItemId = 2, Description = "Do the dishes" },
                new Item { ItemId = 3, Description = "Sweep the floor" }
                }.AsQueryable());
        } 

        [Fact]
        public void Mock_Get_ViewResult_Index_Test()
        {
            DbSetup();
            ItemsController controller = new ItemsController(mock.Object);

            var result = controller.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Mock_Get_ModelList_Index_Test()
        {
            DbSetup();
            ViewResult indexView = new ItemsController(mock.Object).Index() as ViewResult;

            var result = indexView.ViewData.Model;

            Assert.IsType<List<Item>>(result);
        }

        [Fact]
        public void Mock_Post_MethodAddsItem_Test()
        {
            DbSetup();
            ItemsController controller = new ItemsController(mock.Object);
            Item testItem = new Item();
            testItem.Description = "Wash the dog";
            testItem.ItemId = 1;

            testItem.CategoryId = 1;

            
            ViewResult indexView = controller.Index() as ViewResult;
            var collection = indexView.ViewData.Model as IEnumerable<Item>;

            Assert.Contains<Item>(testItem, collection);
        }
    }
}
