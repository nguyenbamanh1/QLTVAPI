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
    public class TheLoaiController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage getall()
        {
            List<Entity> docGias = TheLoaiDAO.getall();
            return Request.CreateResponse(HttpStatusCode.OK, docGias);
        }

        [HttpGet]
        public HttpResponseMessage get(string id)
        {
            Entity dg = TheLoaiDAO.get(id);
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
        public HttpResponseMessage create(Entity docGia)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, TheLoaiDAO.put(docGia));
        }

        [HttpPut]
        public HttpResponseMessage update(Entity docGia)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, TheLoaiDAO.update(docGia));
        }

        [HttpDelete]
        public HttpResponseMessage delete(string id)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, TheLoaiDAO.delete(id));
        }
    }
}
