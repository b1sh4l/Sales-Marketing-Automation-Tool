using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.Services;

namespace Sales_Marketing_Automation_Tool.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/user")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = UserService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/user/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = UserService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
