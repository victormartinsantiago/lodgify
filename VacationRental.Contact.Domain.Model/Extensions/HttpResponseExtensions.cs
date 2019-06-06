namespace VacationRental.Contact.Domain.Common.Extensions
{
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public static class HttpResponseExtensions
    {
        private static JsonSerializerSettings SerializerSettings => new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented,
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };

        public static async Task WriteErrorResponseAsync(this HttpResponse response, ProblemDetails details)
        {
            response.ContentType = "application/json";
            response.StatusCode = details.Status ?? (int)HttpStatusCode.InternalServerError;

            var json = JsonConvert.SerializeObject(details, SerializerSettings);
            await response.WriteAsync(json);
        }
    }
}
