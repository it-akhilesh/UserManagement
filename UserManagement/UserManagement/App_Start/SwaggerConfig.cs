using System.Web.Http;
using Swashbuckle.Application;

namespace UserManagement
{
    public static class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "User Management API");
                })
                .EnableSwaggerUi();
        }
    }
}
