using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EffoftAPIService.Connectors
{
    public enum ClientMethod
    {
        GET, POST, PATCH
    }

    public static class tfsConnector
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
                    .AddJsonFile("appsettings.Development.json");

            Configuration = builder.Build();
            UseDefCreds = Convert.ToBoolean(Configuration["TFSServer:UseDefCreds"]);
            ServerURL = Configuration["TFSServer:url"];
            Collection = Configuration["TFSServer:Collection"];
            AccessToken = Configuration["TFSServer:AccessToken"];
            Domain = Configuration["TFSServer:Domain"];
            userName = Configuration["TFSServer:Login"];
            Password = Configuration["TFSServer:Password"];
        }

        public static async Task<string> GetWorkItemForIdAsync(int id)
        {
            ReadConfig();
            try
            {
                var personalaccesstoken = AccessToken;

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                        Convert.ToBase64String(
                            System.Text.ASCIIEncoding.ASCII.GetBytes($"{userName}:{AccessToken}")));

                    using (HttpResponseMessage response = await client.GetAsync(
                                $"https://{ServerURL}/{Collection}/_apis/wit/workitems/{id}?$expand=relations&api-version=4.1"))
                    {
                        response.EnsureSuccessStatusCode();
                        return response.Content.ReadAsStringAsync().Result;
                    }
                        
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
