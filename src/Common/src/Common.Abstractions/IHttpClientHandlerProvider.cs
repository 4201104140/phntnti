using System.Net.Http;

namespace PhnTnTi.Common
{
    public interface IHttpClientHandlerProvider
    {
        HttpClientHandler GetHttpClientHandler();
    }
}
