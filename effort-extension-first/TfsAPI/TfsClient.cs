using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace effort_extension.TfsAPI
{
    public enum ClientMethod
    {
        GET, POST, PATCH
    }
    
    public static class TfsClient
    {
        public static IConfiguration Configuration { get; set; }

        static bool UseDefCreds;
        static string ServerURL;
        static string Collection;
        static string AccessToken;
        static string Domain;
        static string userName;
        static string Password;

        public static void ReadConfig()
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
            UseDefCreds = Convert.ToBoolean(Configuration["UseDefCreds"]);
            ServerURL = Configuration["url"];
            Collection = Configuration["IPCC"];
            AccessToken = Configuration["AccessToken"];
            Domain = Configuration["Domain"];
            userName = Configuration["Login"];
            Password = Configuration["Password"];
        }

        public static async Task<HttpResponseMessage> DoRequest(string pRequest, string pBody, ClientMethod pClientMethod)
        {
            try
            {
                ReadConfig();

                HttpClientHandler _httpClientH = new HttpClientHandler();
                if (UseDefCreds) _httpClientH.Credentials = CredentialCache.DefaultCredentials;
                else if (Domain == "") _httpClientH.Credentials = new NetworkCredential(userName, Password);
                else _httpClientH.Credentials = new NetworkCredential(userName, Password, Domain);

                using (HttpClient _httpClient = new HttpClient(_httpClientH))
                {
                    switch (pClientMethod)
                    {
                        case ClientMethod.GET:
                            return await _httpClient.GetAsync(pRequest);

                        case ClientMethod.POST:
                            return await _httpClient.PostAsync(pRequest, new StringContent(pBody, Encoding.UTF8, "application/json"));

                        case ClientMethod.PATCH:
                            var _request = new HttpRequestMessage(new HttpMethod("PATCH"), pRequest);
                            _request.Content = new StringContent(pBody, Encoding.UTF8, "application/json-patch+json");
                            return await _httpClient.SendAsync(_request);

                        default:
                            return null;
                    }
                }                    
            }
            catch (Exception ex)
            {
                //addexeptionx(ex);
                return null;
            }
        }        
    }
}
