using SIS.HTTP.Common;
using SIS.HTTP.Exceptions;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Results;
using SIS.WebServer.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SIS.WebServer
{
    public class ConnectionHandler
    {
        private readonly Socket client;

        private readonly IServerRoutingTable serverRoutingTable;

        public ConnectionHandler(Socket client, IServerRoutingTable serverRoutingTable)
        {
            CoreValidator.ThrowIfNull(client, nameof(client));
            CoreValidator.ThrowIfNull(serverRoutingTable, nameof(serverRoutingTable));

            this.client = client;
            this.serverRoutingTable = serverRoutingTable;
        }

        public async Task ProcessRequestAsync()
        {

            try
            {
                var httpRequest = await this.ReadRequst();

                if (httpRequest != null)
                {
                    Console.WriteLine($"Processing: {httpRequest.RequestMethod} {httpRequest.Path}...");

                    var httpResponse = this.HandleRequest(httpRequest);
                   await this.PrepareResponseAsync(httpResponse);
                }
            }
            catch (BadRequestException e)
            {

                await this.PrepareResponseAsync(new TextResult(e.ToString(), HTTP.Enums.HttpResponseStatusCode.BadRequest));
            }

            catch (Exception e)
            {

                await this.PrepareResponseAsync(new TextResult(e.ToString(), HTTP.Enums.HttpResponseStatusCode.InternalServerError));
            }

            this.client.Shutdown(SocketShutdown.Both);
        }

        private async Task PrepareResponseAsync(IHttpResponse httpResponse)
        {
            byte[] byteSegments = httpResponse.GetBytes();
            await this.client.SendAsync(byteSegments, SocketFlags.None);
        }

        private IHttpResponse HandleRequest(IHttpRequest httpRequest)
        {
            if (!this.serverRoutingTable.Contains(httpRequest.RequestMethod,httpRequest.Path))
            {
                return new TextResult($"Route with method {httpRequest.RequestMethod} and path \"{httpRequest.Path}\" not found.", HTTP.Enums.HttpResponseStatusCode.NotFound);
            }

            return this.serverRoutingTable.Get(httpRequest.RequestMethod, httpRequest.Path).Invoke(httpRequest);
        }

        private async Task<IHttpRequest> ReadRequst()
        {
            var result = new StringBuilder();
            var data = new ArraySegment<byte>(new byte[1024]);

            while (true)
            {
                int numberOfBytesRead = await this.client.ReceiveAsync(data.Array!, SocketFlags.None);

                if (numberOfBytesRead == 0)
                {
                    break;
                }

                var bytesAsString = Encoding.UTF8.GetString(data.Array!, 0, numberOfBytesRead);
                result.Append(bytesAsString);

                if (numberOfBytesRead < 1023)
                {
                    break;
                }
            }

            if (result.Length==0)
            {
                return null!;
            }

            return new HttpRequest(result.ToString());
        }
    }
}
