using BackEndInfoglobo.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BackEndInfoglobo.Tests
{
    [TestClass]
    public class ItemTest
    {
        [TestMethod]
        public void ToStringTest()
        {
            var item = new Item
            {
                title = "Title",
                link = "Link",
                description = new List<Tag>
                {
                    new Tag
                    {
                        type = "text",
                        content = new List<string>
                        {
                            "texttexttext"
                        }
                    },
                    new Tag
                    {
                        type = "image",
                        content = new List<string>
                        {
                            "http://imageurl",
                        }
                    },
                    new Tag
                    {
                        type = "links",
                        content = new List<string>
                        {
                            "Site1",
                            "Site2",
                            "Site3"
                        }
                    },
                }
            };
            
            Assert.AreEqual("{ 'title': 'Title', 'link': 'Link', 'description' : [  { 'type': 'text', 'content': 'texttexttext' }, { 'type': 'image', 'content': 'http://imageurl' }, { 'type': 'links', 'content': [ 'Site1',  'Site2',  'Site3' ] } ] }", item.ToString());
        }
    }
}
