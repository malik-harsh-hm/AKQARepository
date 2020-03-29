using AKQA.API.Models;
using AKQA.Service;
using AKQA.SharedLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AKQA.API.Controllers
{
    [EnableCors(origins: "http://localhost:60780", headers: "*", methods: "*")]
    public class PersonController : ApiController
    {
        private IServiceFactories _serviceFactories;

        public PersonController(IServiceFactories serviceFactories)
        {
            _serviceFactories = serviceFactories;
        }
        [HttpPost]
        public IHttpActionResult Convert(Person person)
        {
            IConvertService service = _serviceFactories.ConvertServiceFactory.CreateInstance();
            var res = service.GetData(person.DecimalAmount);
            return Json(res);
        }
    }
}
