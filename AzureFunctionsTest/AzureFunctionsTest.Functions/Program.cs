using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Configuration;

var builder = FunctionsApplication.CreateBuilder(args);

builder.AddServiceDefaults();

var value = builder.Configuration.GetConnectionString("Messaging");
var value2 = builder.Configuration.GetConnectionString("Messaging2");
var value3 = builder.Configuration.GetConnectionString("Messaging3");
var value4 = builder.Configuration.GetConnectionString("Messaging4");
var value5 = builder.Configuration.GetConnectionString("Messaging5");
var value6 = builder.Configuration.GetConnectionString("Messaging6");

var host = builder.Build();

host.Run();
