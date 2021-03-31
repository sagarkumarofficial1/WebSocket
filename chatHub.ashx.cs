using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.WebSockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Web.WebSockets;

namespace WebSocketDemo
{
    /// <summary>
    /// Summary description for chatHub
    /// </summary>
    public class chatHub : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(new MicrosofWebSocketHandler());
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}