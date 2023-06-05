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
    public class tailieuController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage getall()
        {
            List<TaiLieu> docGias = TaiLieuDAO.getall();
            return Request.CreateResponse(HttpStatusCode.OK, docGias);
        }

        [HttpGet]
        public HttpResponseMessage get(string id)
        {
            TaiLieu dg = TaiLieuDAO.get(id);
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
        public HttpResponseMessage create(TaiLieu docGia)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, TaiLieuDAO.put(docGia));
        }

        [HttpPut]
        public HttpResponseMessage update(TaiLieu docGia)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, TaiLieuDAO.update(docGia));
        }


        [HttpDelete]
        public HttpResponseMessage delete(string id)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, TaiLieuDAO.delete(id));
        }
    }
}
