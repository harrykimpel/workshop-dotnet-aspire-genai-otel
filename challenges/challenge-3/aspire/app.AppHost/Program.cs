var builder = DistributedApplication.CreateBuilder(args);

// New Relic configuration
var NEW_RELIC_REGION = Environment.GetEnvironmentVariable("NEW_RELIC_REGION");
string OTEL_EXPORTER_OTLP_ENDPOINT = "https://otlp.nr-data.net";
if (NEW_RELIC_REGION != null &&
    NEW_RELIC_REGION != "" &&
    NEW_RELIC_REGION == "EU")
{
    OTEL_EXPORTER_OTLP_ENDPOINT = "https://otlp.eu01.nr-data.net";
}
var NEW_RELIC_LICENSE_KEY = Environment.GetEnvironmentVariable("NEW_RELIC_LICENSE_KEY");
string OTEL_EXPORTER_OTLP_HEADERS = "api-key=" + NEW_RELIC_LICENSE_KEY;

var apiServiceName = "apiservice";
var apiService = builder.AddProject<Projects.app_ApiService>(apiServiceName)
    .WithEnvironment("OTEL_EXPORTER_OTLP_ENDPOINT", OTEL_EXPORTER_OTLP_ENDPOINT)
    .WithEnvironment("OTEL_EXPORTER_OTLP_HEADERS", OTEL_EXPORTER_OTLP_HEADERS)
    .WithEnvironment("OTEL_SERVICE_NAME", apiServiceName)
    .WithEnvironment("OTEL_RESOURCE_ATTRIBUTES", "service.name="+apiServiceName+",service.version=1.0.0,service.instance.id="+apiServiceName);

var genAIServiceName = "genaiservice";
var genAIService = builder.AddProject<Projects.app_GenAIApiService>(genAIServiceName)
    .WithEnvironment("OTEL_EXPORTER_OTLP_ENDPOINT", OTEL_EXPORTER_OTLP_ENDPOINT)
    .WithEnvironment("OTEL_EXPORTER_OTLP_HEADERS", OTEL_EXPORTER_OTLP_HEADERS)
    .WithEnvironment("OTEL_SERVICE_NAME", genAIServiceName)
    .WithEnvironment("OTEL_RESOURCE_ATTRIBUTES", "service.name="+genAIServiceName+",service.version=1.0.0,service.instance.id="+genAIServiceName);

var webFrontendName = "webfrontend";
builder.AddProject<Projects.app_Web>(webFrontendName)
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService)
    .WithReference(genAIService)
    .WaitFor(genAIService)
    .WithEnvironment("OTEL_EXPORTER_OTLP_ENDPOINT", OTEL_EXPORTER_OTLP_ENDPOINT)
    .WithEnvironment("OTEL_EXPORTER_OTLP_HEADERS", OTEL_EXPORTER_OTLP_HEADERS)
    .WithEnvironment("OTEL_SERVICE_NAME", webFrontendName)
    .WithEnvironment("OTEL_RESOURCE_ATTRIBUTES", "service.name="+webFrontendName+",service.version=1.0.0,service.instance.id="+webFrontendName);

builder.Build().Run();
