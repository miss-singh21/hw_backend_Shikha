using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApi_HW_Backend_Shikhasingh.Tests
{
    public static class GlobalVariables
    {
        public static HttpClient apiClient = new HttpClient();

        static GlobalVariables()
        {
            string authinfo = "admin" + ":" + "admin";
            authinfo = Convert.ToBase64String(Encoding.Default.GetBytes(authinfo));
            apiClient.BaseAddress = new Uri("http://localhost:54651/api/");
            apiClient.DefaultRequestHeaders.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            apiClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authinfo);
        }
    }
}
