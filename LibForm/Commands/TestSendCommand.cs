using LibCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibForm.Test
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
            using (var content = new MultipartFormDataContent())
            {
                client.DefaultRequestHeaders.Add("Authorization", "ssdsd");
                var field = JsonContent.Create(new Test { Name = "dfdf"});
                content.Add(field);

                HttpResponseMessage rs = await client.PostAsync("localhost", content);
                var a = rs.Content;
            };

            
        }

        //private static HttpStringContent MakeStringContent()
    }
}
