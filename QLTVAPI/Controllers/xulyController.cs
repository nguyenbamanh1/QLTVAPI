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
    public class xulyController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage getall()
        {
            List<XuLy> docGias = XuLyDAO.getall();
            return Request.CreateResponse(HttpStatusCode.OK, docGias);
        }

        [HttpGet]
        public HttpResponseMessage get(string id)
        {
            XuLy dg = XuLyDAO.get(id);
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
        public HttpResponseMessage create(XuLy docGia)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, XuLyDAO.put(docGia));
        }

        [HttpPut]
        public HttpResponseMessage update(XuLy docGia)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, XuLyDAO.update(docGia));
        }


        [HttpDelete]
        public HttpResponseMessage delete(string id)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, XuLyDAO.delete(id));
        }
    }
}
