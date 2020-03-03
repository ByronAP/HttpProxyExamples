using System;
using System.IO;
using System.Net;

namespace CSharpExample
{
    class Program
    {
        private const string ProxyAddress  = "http://rotate.proxy.services";
        private const int    ProxyPort     = 8989;
        private const string ProxyUsername = "Username";
        private const string ProxyPassword = "Password";
        private const string Url           = "https://echo.proxy.services";

        public static void Main(string[] args)
        {
            var creds = new NetworkCredential(ProxyUsername, ProxyPassword);
            var proxy = new WebProxy()
            {
                Address = new Uri($"{ProxyAddress}:{ProxyPort}"),
                Credentials = creds
            };

            var request = WebRequest.Create(Url);
            request.Proxy = proxy;

            using var responseStream = request.GetResponse().GetResponseStream();
            using var responseReader = new StreamReader(responseStream);
            var responseData = responseReader.ReadToEnd();

            Console.Write(responseData);
            Console.ReadLine();
        }
    }
}
