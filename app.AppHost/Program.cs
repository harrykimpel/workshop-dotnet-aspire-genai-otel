var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.app_ApiService>("apiservice");

builder.AddProject<Projects.app_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
