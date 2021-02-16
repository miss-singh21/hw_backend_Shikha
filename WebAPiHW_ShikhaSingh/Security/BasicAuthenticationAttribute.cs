using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebAPiHW_ShikhaSingh.Security
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No user credential provided");
            }
            else
            {
                if (actionContext.Request.Headers.Authorization.Parameter != null)
                {
                    string authDetail = actionContext.Request.Headers.Authorization.Parameter;
                    string decodeAuthDetail = Encoding.UTF8.GetString(Convert.FromBase64String(authDetail));
                    string[] authArray = decodeAuthDetail.Split(':');
                    if (authArray!=null && authArray.Length > 1)
                    {
                        string username = authArray[0];
                        string password = authArray[1];

                        if (!ValidateUser.Login(username, password))
                        {
                            actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid Credentials provided");
                        }
                    }
                    else
                    {
                        actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid request");
                    }
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid request");
                }
            }
            base.OnAuthorization(actionContext);
        }
    }
}