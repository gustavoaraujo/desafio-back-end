﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndInfoglobo.Service.Models
{
    public class Usuario
    {
        public string login { get; set; }
        public string senha { get; set; }

        public bool IsCadastrado()
        {
            return login == "admin" && senha == "admin";
        }
    }
}