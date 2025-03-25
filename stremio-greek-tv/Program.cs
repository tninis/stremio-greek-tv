using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using stremio_greek_tv;
using stremio_greek_tv.Helpers;
using stremio_greek_tv.Interfaces;
using stremio_greek_tv.StreamRetrievers;
using System;
using System.IO;

var builder = WebApplication.CreateBuilder(args);
ManifestHelpers.Initialize(builder.Environment);
builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddMemoryCache();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSingleton<IStreamRetriever>(sp =>
    {
        var fullPath = Path.Combine(AppContext.BaseDirectory, Constants.TVChannelsFilePath);
        return ActivatorUtilities.CreateInstance<FileStreamRetriever>(sp, fullPath);
    });
}
else
{
    builder.Services.AddSingleton<IStreamRetriever>(sp =>
    {
        return ActivatorUtilities.CreateInstance<URLStreamRetriever>(sp, Constants.TVChannelsFileUrl);
    });
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors(builder => builder.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod());



app.UseRouting().UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

await app.RunAsync();
