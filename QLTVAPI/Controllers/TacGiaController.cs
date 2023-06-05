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
    public class TacGiaController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage getall()
        {
            List<TACGIA> docGias = TacGiaDAO.getall();
            return Request.CreateResponse(HttpStatusCode.OK, docGias);
        }

        [HttpGet]
        public HttpResponseMessage get(string id)
        {
            TACGIA dg = TacGiaDAO.get(id);
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
        public HttpResponseMessage create(TACGIA docGia)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, TacGiaDAO.put(docGia));
        }

        [HttpDelete]
        public HttpResponseMessage delete(string id)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, TacGiaDAO.delete(id));
        }

        [HttpPut]
        public HttpResponseMessage update(TACGIA docGia)
        {
            return Request.CreateResponse(HttpStatusCode.OK, TacGiaDAO.update(docGia));
        }
    }
}