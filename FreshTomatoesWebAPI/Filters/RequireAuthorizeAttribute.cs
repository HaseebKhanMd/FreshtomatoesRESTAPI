using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Text;

namespace FreshTomatoesWebAPI.Filters
{
    public class RequireAuthorizeAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var authHeader = actionContext.Request.Headers.Authorization;

            if (authHeader != null)
            { 
                if (authHeader.Scheme.Equals("basic",StringComparison.OrdinalIgnoreCase) 
                    && string.IsNullOrWhiteSpace(authHeader.Parameter)==false)
                {
                    var rawCredentials = authHeader.Parameter;
                    var encoding = Encoding.GetEncoding("iso-8859-1");
                    var credentials = encoding.GetString(Convert.FromBase64String(rawCredentials));

                    // Spit the credentials to password 
                    var credentialsArray = credentials.Split(':');
                    var username = credentialsArray[0];
                    var password = credentialsArray[1];

                    /* REPLACE THIS WITH REAL AUTHENTICATION
                    ----------------------------------------------*/
                    //WebSecurity.Login(username, password);
                    if (Authenticate(username,password))
                    {
                        return;
                    }
                }
            }

            actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
            actionContext.Request.Headers.Add("WWW-Authenticate", "Basic Schema='' location=''");
            actionContext.Response.Content = new StringContent("Access Denied");
        }

        private bool Authenticate(string username, string password)
        {
            if (string.Equals(username,"haseeb") && string.Equals(password,"password"))
                return true;
            else
                return false;
        }
    }
}