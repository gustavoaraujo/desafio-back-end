using BackEndInfoglobo.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndInfoglobo.Tests
{
    /// <summary>
    /// Teste de requisição.
    /// Como estamos testando algo que está em constante mudança (o feed)
    /// o resultado sempre será diferente. Logo, não há porquê verificar 
    /// o resultado.
    /// 
    /// Caso aconteçam erros na requisição ou no resultado, eles serão 
    /// verificados e testados em outros métodos.
    /// </summary>
    [TestClass]
    public class CrawlerTest
    {
        private Crawler crawler;

        public CrawlerTest()
        {
            crawler = new Crawler();
        }

        [TestMethod]
        public void Request_Test()
        {
            var url = "http://revistaautoesporte.globo.com/rss/ultimas/feed.xml";
            var response = crawler.Request(url);

            Assert.IsFalse(response.Contains("Response Error: "));
        }

        [TestMethod]
        public void Crawler_Test()
        {
            Assert.IsFalse(crawler.Crawl().Contains("Response Error: "));
        }
    }
}
