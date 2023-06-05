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
    public class KhoaController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage getall()
        {
            List<Khoa> docGias = KhoaDAO.getall();
            return Request.CreateResponse(HttpStatusCode.OK, docGias);
        }

        [HttpGet]
        public HttpResponseMessage get(string id)
        {
            Khoa dg = KhoaDAO.get(id);
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
        public HttpResponseMessage create(Khoa docGia)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, KhoaDAO.put(docGia));
        }

        [HttpDelete]
        public HttpResponseMessage delete(string id)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, KhoaDAO.delete(id));
        }

        [HttpPut]
        public HttpResponseMessage update(Khoa docGia)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, KhoaDAO.update(docGia));
        }
    }
}
