using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTester.Models
{
    public class Request
    {
        public string CompileUrlLeft { get; set; }
        public string CompileUrlRight { get; set; }
        public string UrlLeft { get; set; }
        public string UrlRight { get; set; }
        public string jsonLeft { get; set; }
        public string jsonRight { get; set; }
    }
}
