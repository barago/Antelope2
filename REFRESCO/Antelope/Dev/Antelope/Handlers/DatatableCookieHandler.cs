using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks; 
using Antelope.Constants;
 
namespace Antelope.Handlers
{

    /// <summary>
    /// Handler pour la gestion des cookies d'un datatable.
    /// </summary>
    public class DatatableCookieHandler : DelegatingHandler
    {
        /// <summary>Sends an HTTP request to the inner handler to send to the server as an asynchronous operation.</summary>
        /// <returns>Returns <see cref="T:System.Threading.Tasks.Task`1" />. The task object representing the asynchronous operation.</returns>
        /// <param name="request">The HTTP request message to send to the server.</param>
        /// <param name="cancellationToken">A cancellation token to cancel operation.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="request" /> was null.</exception>
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await base.SendAsync(request, cancellationToken);

                if (request.Properties.ContainsKey(Cookies.DATATABLE_LENGTH))
                {
                    var cookie = new CookieHeaderValue(Cookies.DATATABLE_LENGTH, request.Properties[Cookies.DATATABLE_LENGTH].ToString());
                    cookie.Expires = DateTimeOffset.Now.AddDays(365);
                    //cookie.Domain = request.RequestUri.Host;
                    cookie.Path = "/";
                    response.Headers.AddCookies(new[] { cookie }); 
                }
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}