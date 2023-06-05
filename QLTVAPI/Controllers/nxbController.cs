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
    public class nxbController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage getall()
        {
            List<NXB> docGias = NXBDAO.getall();
            return Request.CreateResponse(HttpStatusCode.OK, docGias);
        }

        [HttpGet]
        public HttpResponseMessage get(string id)
        {
            NXB dg = NXBDAO.get(id);
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
        public HttpResponseMessage create(NXB docGia)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, NXBDAO.put(docGia));
        }
        [HttpPut]
        public HttpResponseMessage update(NXB docGia)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, NXBDAO.update(docGia));
        }

        [HttpDelete]
        public HttpResponseMessage delete(string id)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, NXBDAO.delete(id));
        }
    }
}
