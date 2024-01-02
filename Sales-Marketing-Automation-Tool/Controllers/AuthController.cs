using BLL.Services;
using Sales_Marketing_Automation_Tool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sales_Marketing_Automation_Tool.Controllers
{
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("api/auth/sigin")]
        public HttpResponseMessage SignIn(SignInModel signin)
        {
            try
            {
                var res = AuthService.Authenticate(signin.Email, signin.Password);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid credentials");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpPost]
        [Route("api/auth/signout")]
        public HttpResponseMessage SignOut(SignOutModel signout)
        {
           try
            {
                var res = AuthService.SignOut(signout.TKey);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Signed out successfully");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid token");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
    }
}
