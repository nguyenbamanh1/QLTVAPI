using QLTVAPI.Models;
using QLTVAPI.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLTVAPI.Controllers
{
    public class thedangkyController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage getall()
        {
            List<TheDangKy> TheDangKys = TheDangKIDAO.getall();
            return Request.CreateResponse(HttpStatusCode.OK, TheDangKys);
        }

        [HttpGet]
        public HttpResponseMessage get(string id)
        {
            TheDangKy dg = TheDangKIDAO.get(id);
            if (dg != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, dg);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [HttpPost]
        public HttpResponseMessage create(TheDangKy TheDangKy)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, TheDangKIDAO.put(TheDangKy));
        }


        [HttpDelete]
        public HttpResponseMessage delete(string id)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, TheDangKIDAO.delete(id));
        }

        [HttpPut]
        public HttpResponseMessage update(TheDangKy id)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, TheDangKIDAO.update(id));
        }
    }
}
