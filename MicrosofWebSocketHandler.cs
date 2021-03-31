using Microsoft.Web.WebSockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSocketDemo
{
    public class MicrosofWebSocketHandler : WebSocketHandler
    {
        private static WebSocketCollection clients = new WebSocketCollection();
        private string name;

        public override void OnOpen()
        {
            name = this.WebSocketContext.QueryString["name"];
            clients.Add(this);
            clients.Broadcast(name + " is connectd");
        }

        public override void OnClose()
        {
            name = this.WebSocketContext.QueryString["name"];
            clients.Remove(this);
            clients.Broadcast(name + " is disconnted");
        }

        public override void OnMessage(string message)
        {
            var sender = clients.SingleOrDefault(x => ((MicrosofWebSocketHandler)x).name == "mohit");
            if (sender != null)
            {
                sender.Send(message);
            }
        }
    }
}