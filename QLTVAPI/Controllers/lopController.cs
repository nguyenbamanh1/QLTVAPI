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
    public class lopController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage getall()
        {
            List<Lop> docGias = LopDAO.getall();
            return Request.CreateResponse(HttpStatusCode.OK, docGias);
        }

        [HttpGet]
        public HttpResponseMessage get(string id)
        {
            Lop dg = LopDAO.get(id);
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
        public HttpResponseMessage create(Lop docGia)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, LopDAO.put(docGia));
        }

        [HttpPut]
        public HttpResponseMessage update(Lop docGia)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, LopDAO.update(docGia));
        }

        [HttpDelete]
        public HttpResponseMessage delete(string id)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, LopDAO.delete(id));
        }
    }
}
