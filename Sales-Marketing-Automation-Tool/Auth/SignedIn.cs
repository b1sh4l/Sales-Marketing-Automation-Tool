using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Sales_Marketing_Automation_Tool.Auth
{
    public class SignedIn : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var authenticationHeaderValue = actionContext.Request.Headers.Authorization;

            if (authenticationHeaderValue == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, new { Msg = "No Token Supplied." });
            }
            else
            {
                var token = authenticationHeaderValue.Parameter;

                if (!AuthService.IsTokenValid(token))
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, new { Msg = "Supplied token is not valid or expired." });
                }
            }

            base.OnAuthorization(actionContext);
        }
    }
}