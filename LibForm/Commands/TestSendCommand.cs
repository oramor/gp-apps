using LibCore;
using System;
using System.Net.Http;
using System.Text.Json;

namespace LibForm
{
    internal class TestSendCommand : BaseCommand
    {
        struct Test
        {
            public string Name;
        }

        public async override void Execute(object? parameter)
        {
            using (var client = new HttpClient())
            using (var content = new MultipartFormDataContent()) {
                client.DefaultRequestHeaders.Add("Authorization", "ssdsd");
                //var field = JsonContent.Create(new Test { Name = "dfdf" });
                var fieldValue = new StringContent("fgff");
                var fieldName = JsonNamingPolicy.CamelCase.ConvertName("Login");
                var fieldValue2 = new StringContent("sssdddds");
                var fieldName2 = JsonNamingPolicy.CamelCase.ConvertName("Password");
                content.Add(fieldValue, fieldName);
                content.Add(fieldValue2, fieldName2);

                var endpoint = new Uri("http://localhost/api/v1/subjects/login");
                HttpResponseMessage rs = await client.PostAsync(endpoint, content);
                var a = rs.Content;
            };


        }

        //private static HttpStringContent MakeStringContent()
    }
}
