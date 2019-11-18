using Swashbuckle.AspNetCore.Swagger;

namespace capredv2.backend.api
{
    internal class OpenApiInfo : Info
    {
        public string Title { get; set; }
        public string Version { get; set; }
    }
}