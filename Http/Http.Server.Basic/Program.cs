using System;
using System.Net;

namespace Http.Server.Basic
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpListener listener = new HttpListener();
            // Add the prefixes.
            string baseUrl = "http://localhost:8081";
            string urlA = $"{baseUrl}/a/";
            string urlB = $"{baseUrl}/b/";
            string urlC = $"{baseUrl}/c/";

            listener.Prefixes.Add(urlA);
            listener.Prefixes.Add(urlB);
            listener.Prefixes.Add(urlC);
            listener.Start();

            // Note: The GetContext method blocks while waiting for a request.
            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;
            System.IO.Stream output = response.OutputStream;

            if (request.Url == new Uri(urlA))
            {
                // Obtain a response object.
                // Construct a response.
                string responseString = "<HTML><BODY> Hello world A</BODY></HTML>";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                // Get a response stream and write the response to it.
                response.ContentLength64 = buffer.Length;
                output.Write(buffer, 0, buffer.Length);
            }

            // You must close the output stream.
            output.Close();
            listener.Stop();
        }
    }
}
