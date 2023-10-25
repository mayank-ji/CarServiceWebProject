using CarDispensaryV1.Controllers;
using CarDispensaryV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CarDispensaryV1.Authentication
{
   
    public class Auth : AuthorizationFilterAttribute
    {
        CarDispensaryEntities CD = new CarDispensaryEntities();
        CustomerLogin customerLogin = new CustomerLogin();  

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {

                actionContext.Response = actionContext.Request.CreateErrorResponse(
                    HttpStatusCode.Unauthorized, " login please...!");
            }
            else
            {
                String authToken = actionContext.Request.Headers.Authorization.Parameter;

                String deCodeAuthToken =Encoding.UTF8.GetString( Convert.FromBase64String(authToken));

                String[] userNamePassword = deCodeAuthToken.Split(':');
                String userName = userNamePassword[0];
                string password = userNamePassword[1];

                if(customerLogin.CheckCredentials(userName , password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(userName),null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateErrorResponse(
                    HttpStatusCode.Unauthorized, " Invalid userName and Password...!");
                }
            }

        }

    }
}