using AfishaVoenmeh.EventService.Application;
using AfishaVoenmeh.EventService.Infrastructure;
using AfishaVoenmeh.EventService.WebAPI;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    if(app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseExceptionHandler();

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
