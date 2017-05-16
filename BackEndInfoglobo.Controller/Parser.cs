using BackEndInfoglobo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BackEndInfoglobo.Controller
{
    public class Parser
    {
        private List<Tag> tags;
        private XDocument xDocument;

        public Parser(string xml)
        {
            xDocument = XDocument.Parse(xml);
            tags = new List<Tag>();
        }

        public List<Item> ParseItems()
        {
            var listItems = new List<Item>();

            var nodesItems = SelectNodes("//item");

            foreach (var nodeItem in nodesItems)
            {
                ParseDescription(nodeItem);

                var item = new Item()
                {
                    title = SelectNode("./title", nodeItem).Value,
                    link = SelectNode("./link", nodeItem).Value,
                    description = tags
                };
                
                listItems.Add(item);
            }

            return listItems;
        }

        public void ParseDescription(XElement nodeItem)
        {
            var nodeTags = SelectNode("./description", nodeItem);

            if (nodeTags == null)
                throw new Exception("Error while parsing description's internal elements.");

            var html = System.Web.HttpUtility.HtmlDecode(nodeTags.Value);
            html = Regex.Replace(html, @"<iframe.*</iframe>", string.Empty);

            var parserDescription = new Parser(string.Format("<root>{0}</root>", html));
            parserDescription.ParseDescription();

            tags = parserDescription.tags;
        }

        private void ParseDescription()
        {
            ParseDescendants(xDocument);
        }

        private IEnumerable<XElement> ParseParagraphNodes()
        {
            var nodes = SelectNodes("//p");
            
            return nodes.Where(node => node.Value.Trim() != string.Empty);
        }

        private void ParseDescendants(XDocument xDocument)
        {
            var paragraphs = ParseParagraphNodes();
            var images = SelectNodes("//div/img");
            var links = SelectNodes("//div/ul");

            foreach (var descendant in xDocument.Descendants())
            {
                if (paragraphs.Contains(descendant))
                    ParseParagraph(descendant);
                else if (images.Contains(descendant))
                    ParseImage(descendant);
                else if (links.Contains(descendant))
                    ParseLinks(descendant);
            }
        }

        private void ParseLinks(XElement descendant)
        {
            var nodesLinks = SelectNodes("//ul/li/a", descendant);

            var tag = new Tag
            {
                type = "links"
            };

            foreach (var nodeLink in nodesLinks)
            {
                tag.content.Add(nodeLink.Attribute("href").Value);
            }

            tags.Add(tag);
        }

        private void ParseImage(XElement descendant)
        {
            Tag tag = new Tag
            {
                type = "image",
                content = new List<string> { descendant.Attribute("src").Value }
            };

            tags.Add(tag);
        }

        private void ParseParagraph(XElement descendant)
        {
            Tag tag = new Tag
            {
                type = "text",
                content = new List<string> { descendant.Value }
            };

            tags.Add(tag);
        }

        private IEnumerable<XElement> SelectNodes(string xpath, XElement xElement = null)
        {
            IEnumerable<XElement> nodes;

            if (xElement == null)
                nodes = xDocument.XPathSelectElements(xpath);
            else
                nodes = xElement.XPathSelectElements(xpath);
            
            return nodes;
        }

        private XElement SelectNode(string xpath, XElement xElement)
        {
            return xElement.XPathSelectElement(xpath);
        }
    }
}
