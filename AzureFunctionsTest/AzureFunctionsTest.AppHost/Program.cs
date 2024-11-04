using Aspire.Hosting.Azure;
using Azure.Provisioning.Storage;

var builder = DistributedApplication.CreateBuilder(args);

var storage = builder.AddAzureStorage("storage").RunAsEmulator();
var queue = storage.AddQueues("queue");
var blob = storage.AddBlobs("blob");

//var eventHubs = builder.AddAzureEventHubs("eventhubs").RunAsEmulator().AddEventHub("myhub");
//var serviceBus = builder.AddAzureServiceBus("messaging").AddQueue("myqueue");

var messaging = builder.AddConnectionString("Messaging");
var messaging2 = builder.AddConnectionString("Messaging2");
var messaging3 = builder.AddConnectionString("Messaging3");
var messaging4 = builder.AddConnectionString("Messaging4");
var messaging5 = builder.AddConnectionString("Messaging5");
var messaging6 = builder.AddConnectionString("Messaging6");

builder.AddAzureFunctionsProject<Projects.AzureFunctionsTest_Functions>("funcapp")
    .WithReference(messaging)
    .WithReference(messaging2)
    .WithReference(messaging3)
    .WithReference(messaging4)
    .WithReference(messaging5)
    .WithReference(messaging6);
    //.WithReference(eventHubs);
    //.WithReference(serviceBus);

//builder.AddAzureFunctionsProject<Projects.AzureFunctionsTest_StorageFunctions>("storage-funcapp")
//    .WithReference(queue)
//    .WithReference(blob);

//var httpFuncApp = builder.AddAzureFunctionsProject<Projects.AzureFunctionsTest_HttpFunctions>("http-funcapp")
//    .WithExternalHttpEndpoints()
//    .WithHttpHealthCheck("/");

//builder.AddProject<Projects.AzureFunctionsTest_ApiService>("apiservice")
//    .WithExternalHttpEndpoints()
//    .WithReference(httpFuncApp)
//    //.WithReference(eventHubs)
//    //.WithReference(serviceBus)
//    .WithReference(blob)
//    .WithReference(queue);

builder.Build().Run();