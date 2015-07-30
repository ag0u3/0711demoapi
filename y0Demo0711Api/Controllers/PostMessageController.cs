using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;

namespace y0Demo0711Api.Controllers
{
    public class PostMessageController : ApiController
    {
        [HttpPost]
        public void Post(string message)
        {
            try
            {
                var connection = new HubConnection("http://y0demotestweb.azurewebsites.net");
                var hub = connection.CreateHubProxy("Echo");

                connection.Start().Wait();
                hub.Invoke("Send", "[POST]:" + message);

                connection.Stop();
            }
            catch(Exception ex)
            {
                ;
            }
        }

        [HttpGet]
        public void Get(string message)
        {
            try
            {
                var connection = new HubConnection("http://y0demotestweb.azurewebsites.net");
                var hub = connection.CreateHubProxy("Echo");

                connection.Start().Wait();
                hub.Invoke("Send", "[GET]:" + message);

                connection.Stop();
            }
            catch (Exception ex)
            {
                ;
            }
        }

    }
}
