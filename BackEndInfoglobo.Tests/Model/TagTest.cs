using BackEndInfoglobo.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BackEndInfoglobo.Tests
{
    [TestClass]
    public class TagTest
    {
        [TestMethod]
        public void ToStringTest()
        {
            var tag = new Tag
            {
                type = "links",
                content = new List<string>
                {
                    "Site1",
                    "Site2",
                    "Site3"
                }
            };
            
            Assert.AreEqual("{ 'type': 'links', 'content': [ 'Site1',  'Site2',  'Site3' ] }", tag.ToString());
        }
    }
}
