using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTOs;
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

        [HttpPost]
        [Route("api/user")]
        public HttpResponseMessage Post([FromBody] UserDTO userDto)
        { 
            try
            {
                var data = UserService.Create(userDto);
                return Request.CreateResponse(HttpStatusCode.Created, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPut]
        [Route("api/user/{id}")]
        public HttpResponseMessage Put(int id, [FromBody] UserDTO userDto)
        {
            try
            {
                
                if (id <= 0 || userDto == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid input parameters.");
                }

                
                var data = UserService.Update(id, userDto);

                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "User not found or not updated.");
                }

                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        [HttpDelete]
        [Route("api/user/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = UserService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/user/signin")]
        public HttpResponseMessage SignIn([FromBody] UserDTO signInRequest)
        {
            try
            {
                if (signInRequest == null || string.IsNullOrEmpty(signInRequest.Email) || string.IsNullOrEmpty(signInRequest.Password))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid request data");
                }

                var signedInUser = UserService.SignIn(signInRequest.Email, signInRequest.Password);

                if (signedInUser != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, signedInUser);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid email or password");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
