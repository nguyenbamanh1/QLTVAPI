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
    public class PhieuMuonController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage getall()
        {
            List<PhieuMuon> PhieuMuons = PhieuMuonDAO.getall();
            return Request.CreateResponse(HttpStatusCode.OK, PhieuMuons);
        }

        [HttpGet]
        public HttpResponseMessage get(string id)
        {
            PhieuMuon dg = PhieuMuonDAO.get(id);
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
        public HttpResponseMessage create(PhieuMuon PhieuMuon)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, PhieuMuonDAO.put(PhieuMuon));
        }

        [HttpPut]
        public HttpResponseMessage update(PhieuMuon PhieuMuon)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, PhieuMuonDAO.update(PhieuMuon));
        }


        [HttpDelete]
        public HttpResponseMessage delete(string id)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, PhieuMuonDAO.delete(id));
        }
    }
}
