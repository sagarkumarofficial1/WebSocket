﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebSocketDemo.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="scripts/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="scripts/modernizr-2.5.3.js"></script>

    <script type="text/javascript">
        var socket;
        var x = new URL(location.href)
        $(document).ready(function () {
            if (!Modernizr.websockets) {
                alert("This browser doesn't support HTML5 Web Sockets!");
                return;
            }

            socket = new WebSocket("ws://localhost:1046/chatHub.ashx?name=" + x.searchParams.get("name"));

            socket.addEventListener("open", function (evt) {
                $("#divHistory").append('<h3>Connection Opened with the server.</h3>');
            }, false);

            socket.addEventListener("close", function (evt) {
                $("#divHistory").append('<h3>Connection was closed. :' + evt.reason + '</h3>');
            }, false);

            socket.addEventListener("message", function (evt) {
                $("#divHistory").append('<h3>' + evt.data + '</h3>');
            }, false);
            socket.onmessage = function (evt) {
                console.log(evt);
            };
            socket.addEventListener("error", function (evt) {
                alert('Error : ' + evt.message);
            }, false);

            $("#btnSend").click(function () {
                if (socket.readyState == WebSocket.OPEN) {
                    socket.send($("#txtMsg").val());
                }
                else {
                    $("#divHistory").append('<h3>The underlying connection is closed.</h3>');
                }
            });

            $("#btnStop").click(function () {
                socket.close();
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
       <span>Enter some text :</span><br />
      <input type="text" id="txtMsg"/>    
      <input type="button" id="btnSend" value="Send" />
      <input type="button" id="btnStop" value="Stop" />
      <div id="divHistory"></div>
    </form>
</body>
</html>

