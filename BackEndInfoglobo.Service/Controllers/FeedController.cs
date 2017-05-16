using BackEndInfoglobo.Service.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BackEndInfoglobo.Service.Controllers
{
    public class FeedController : ApiController
    {
        public static string feed { get; set; }

        [Route("Feed")]
        [HttpPost]
        public JObject ObterFeed(Usuario u)
        {
            if (u.IsCadastrado())
                return JObject.Parse(feed);
            
            return JObject.Parse("{'Erro':'Dados inválidos de login.'}");
        }
    }
}
