using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HolaMundoBlazor.Client.Services
{
    public class HttpRespuesta<T>
    {
        public HttpRespuesta(T respuesta, bool error, HttpResponseMessage httpResponseMessage)
        {
            Respuesta = respuesta;
            Error = error;
            this.httpResponseMessage = httpResponseMessage;
        }

        public T Respuesta { get; }
        public bool Error { get; }
        public HttpResponseMessage httpResponseMessage { get; }

        public async Task<string> GetBody()
        {
            var resp = await httpResponseMessage.Content.ReadAsStringAsync();
            return resp;
        }
    }
}
