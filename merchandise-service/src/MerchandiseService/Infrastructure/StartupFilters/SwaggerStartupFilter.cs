using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace MerchandiseService.Infrastructure.StartupFilters
{
    public class SwaggerStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.UseSwagger();
                app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", ""));
                next(app);
            };
        }
    }
}