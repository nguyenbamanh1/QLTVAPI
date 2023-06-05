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
    public class thuthuController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage getall()
        {
            List<ThuThu> docGias = ThuThuDAO.getall();
            return Request.CreateResponse(HttpStatusCode.OK, docGias);
        }

        [HttpGet]
        public HttpResponseMessage get(string id)
        {
            ThuThu dg = ThuThuDAO.get(id);
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
        public HttpResponseMessage create(ThuThu docGia)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, ThuThuDAO.put(docGia));
        }

        [HttpPut]
        public HttpResponseMessage update(ThuThu docGia)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, ThuThuDAO.update(docGia));
        }

        [HttpDelete]
        public HttpResponseMessage delete(string id)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, ThuThuDAO.delete(id));
        }
    }
}
