namespace Lib.Services
{
    public interface IHttpService_FormResult
    {
        public string FormHandler { get; set; }

        /// <summary>
        /// За парсинг будет отвечать класс обработчика формы,
        /// поэтому контент передается ему в незименном виде
        /// </summary>
        public HttpContent? FormDto { get; set; }
    }

    public interface IHttpService
    {
        //public Task<DataResult> Send(HttpContent content, Uri endpoint);
        public Task<IHttpService_FormResult> SendMultipartForm(MultipartFormDataContent formData, Uri endpoint);
        //public static Task<T> DeserializeDto<T>(HttpContent content) { };
    }
}
