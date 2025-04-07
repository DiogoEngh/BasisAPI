using Basis.API.Middlewares;
using Basis.Infrastructure.Configuration;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var apiResult = new
            {
                status = 400,
                errors = new List<string>()
            };

            if (!context.ModelState.IsValid)
            {
                context.ModelState.Values.ToList().ForEach(s =>
                {
                    var errors = s.Errors
                        .Select(s => s.ErrorMessage)
                        .ToList();

                    apiResult.errors.AddRange(errors);
                });
            }

            return new BadRequestObjectResult(apiResult);
        };
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddServices();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();