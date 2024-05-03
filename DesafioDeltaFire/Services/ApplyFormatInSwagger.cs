﻿using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DesafioDeltaFire.Services
{
    public class ApplyFormatInSwagger : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(DateTime))
            {
                schema.Example = new OpenApiString(DateTime.Now.ToString("dd/MM/yyyy"));
            }
        }
    }
}