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
    public class taikhoanController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage getall()
        {
            List<TaiKhoan> docGias = TaiKhoanDAO.getall();
            return Request.CreateResponse(HttpStatusCode.OK, docGias);
        }

        [HttpGet]
        public HttpResponseMessage get(string id)
        {
            TaiKhoan dg = TaiKhoanDAO.get(id);
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
        public HttpResponseMessage create(TaiKhoan docGia)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, TaiKhoanDAO.put(docGia));
        }

        [HttpPut]
        public HttpResponseMessage update(TaiKhoan docGia)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, TaiKhoanDAO.update(docGia));
        }

        [HttpDelete]
        public HttpResponseMessage delete(string id)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, TaiKhoanDAO.delete(id));
        }

        [HttpPost]
        public HttpResponseMessage login(TaiKhoan tk)
        {
            Message message = new Message();
            if (TaiKhoanDAO.login(tk))
            {
                message.TYPE = 0;
                message.MSG = "Đăng nhập thành công";
            }
            else
            {
               
                message.TYPE = 1;
                message.MSG = "Sai tài khoản hoặc mật khẩu";
            }
            return Request.CreateResponse(HttpStatusCode.OK, message);
        }
    }
}
