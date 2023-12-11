namespace OdinEye.Extensions
{
    using System.Text;
    using Utf8Json;
    using WebSocketSharp.Net;

    public static class HttpListenerResponseExtensions
    {
        public static void Ok<TInstance>(this HttpListenerResponse response, TInstance instance)
        {
            var serialized = JsonSerializer.Serialize(instance);

            response.StatusCode = 200;
            response.ContentType = "application/json";
            response.ContentLength64 = serialized.Length;
            response.ContentEncoding = Encoding.UTF8;
            response.OutputStream.Write(serialized, 0, serialized.Length);
            response.Close();
        }
    }
}