using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;

namespace Take2.Filter
{
    public class RequireHttps : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var req = actionContext.Request;
            
            if(req.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                var html = "<p>HTTPS is requrired </p>";

                if(req.Method.Method == "GET")
                {
                    actionContext.Response = req.CreateResponse(System.Net.HttpStatusCode.Found);
                    actionContext.Response.Content = new StringContent(html, System.Text.Encoding.UTF8, "text/html");
                    var uriBuilder = new UriBuilder(req.RequestUri);
                    uriBuilder.Scheme = Uri.UriSchemeHttps;
                    uriBuilder.Port = 443;

                    actionContext.Response.Headers.Location = uriBuilder.Uri;

                }
                else
                {
                    actionContext.Response = req.CreateResponse(System.Net.HttpStatusCode.NotFound);
                    actionContext.Response.Content = new StringContent(html, System.Text.Encoding.UTF8, "text/html");
                }
            }
            base.OnAuthorization(actionContext);
        }

    }
}