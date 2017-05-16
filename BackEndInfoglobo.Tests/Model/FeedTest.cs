using BackEndInfoglobo.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndInfoglobo.Tests.Model
{
    [TestClass]
    public class FeedTest
    {
        [TestMethod]
        public void ToStringTest()
        {
            var feed = new Feed
            {
                items = new List<Item>
                {
                    new Item
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
                    },
                    new Item
                    {
                        title = "OtherTitle",
                        link = "OtherLink",
                        description = new List<Tag>
                        {
                            new Tag
                            {
                                type = "text",
                                content = new List<string>
                                {
                                    "texttexttext"
                                }
                            }
                        }
                    }
                }
            };
            
            Assert.AreEqual("{ 'feed': [ { 'title': 'Title', 'link': 'Link', 'description' : [  { 'type': 'text', 'content': 'texttexttext' }, { 'type': 'image', 'content': 'http://imageurl' }, { 'type': 'links', 'content': [ 'Site1',  'Site2',  'Site3' ] } ] }, { 'title': 'OtherTitle', 'link': 'OtherLink', 'description' : [  { 'type': 'text', 'content': 'texttexttext' } ] } ] }", feed.ToString());
        }
    }
}
