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
    public class DocGiaController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage getall()
        {
            List<DocGia> docGias = DocGiaDAO.getall();
            return Request.CreateResponse(HttpStatusCode.OK, docGias);
        }

        [HttpGet]
        public HttpResponseMessage get(string id)
        {
            DocGia dg = DocGiaDAO.get(id);
            if(dg != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, dg);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [HttpPost]
        public HttpResponseMessage create(DocGia docGia)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, DocGiaDAO.put(docGia));
        }

        [HttpDelete]
        public HttpResponseMessage delete(string id)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, DocGiaDAO.delete(id));
        }

        [HttpPut]
        public HttpResponseMessage update(DocGia id)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, DocGiaDAO.update(id));
        }
    }
}
