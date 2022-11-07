using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services
{
    public interface IHttpService
    {
        //public Task<DataResult> Send(HttpContent content, Uri endpoint);
        public Task<FormResult> SendMultipartForm(MultipartFormDataContent formData, Uri endpoint);
        //public static Task<T> DeserializeDto<T>(HttpContent content) { };
    }
}
