using System;
using System.Net;

namespace Http.Core
{
    public class HttpService
    {
        private readonly string _ip;
        private readonly string _port;
        private readonly HttpListener _listener;

        public HttpService(string ip, int port)
        {
            _listener = new HttpListener();
        }

        public void Start()
        {
            _listener.Start();
        }

        public void Stop()
        {
            _listener.Stop();
            _listener.Close();
        }

        public void RegisterEndPoints(string endPoint, Action<> action)
        {

        }
    }
}
