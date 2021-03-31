using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Web.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebSocketDemo
{
    public class WebSocketHandler1 : IHttpHandler
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