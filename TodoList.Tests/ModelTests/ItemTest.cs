using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;
using Xunit;

namespace TodoList.Tests
{
    public class ItemTest
    {
        [Fact]
        public void GetDescriptionTest()
        {
            var item = new Item();
            item.Description = "Wash the dog";

            var result = item.Description;

            Assert.Equal("Wash the dog", result);
        }
    }
}
