using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Take2.Models;

namespace Take2.Controllers
{
    public class FoodsController : ApiController
    {
        public object Get()
        {
            ReturnData data = new ReturnData() { ID = 1, Address = "123 1321", Name = "Mike" };
            return data;
        }
    }
}
