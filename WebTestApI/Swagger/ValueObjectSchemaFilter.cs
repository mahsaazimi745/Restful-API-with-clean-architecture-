using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using WebTestApI.CoreLayer.ValueObjects;

namespace WebTestApI.Swagger
{
    public class ValueObjectSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            var type = context.Type;

            // اگر کلاس از ValueObjectها بود (یعنی فقط پراپرتی Value داشت)، اسکیمارو اصلاح کن
            if (type.Name == "NationalCode" || type.Name == "PhoneNumber" || type.Name == "Email") // یا هر کلاس دیگه
            {
                schema.Type = "string";
                schema.Properties.Clear();
                schema.Format = null;
            }
            if (type == typeof(Password))
            {
                schema.Type = "string";
                schema.Format = "password"; // فقط برای نمایش بهتر در Swagger
                schema.Properties = null;
                return;
            }
        }
    }
}
