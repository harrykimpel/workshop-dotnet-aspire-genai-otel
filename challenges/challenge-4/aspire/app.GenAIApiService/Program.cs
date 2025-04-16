var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapPost("/prompt", async (Prompt prompt) =>
{
    //var prompt = await request.ReadFromJsonAsync<String>();
    Console.WriteLine("Prompt: " + prompt.prompt);
    // make POST request to localhost:5004/prompt with body { "prompt": "What is the weather like today?" }
    var client = new HttpClient();
    client.BaseAddress = new Uri("http://localhost:5004/");
    var request = new HttpRequestMessage(HttpMethod.Post, "prompt")
    {
        Content = new StringContent("{\"prompt\": \"" + prompt.prompt + "\"}", System.Text.Encoding.UTF8, "application/json")
    };
    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
    var res = Results.Problem("Error calling GenAI service.");
    if (response.IsSuccessStatusCode)
    {
        var result = response.Content.ReadAsStringAsync().Result;
        // return ok result
        res = Results.Ok(result);
    }
    return res;
})
.WithName("GetGenAIResult");

app.MapDefaultEndpoints();

app.Run();

public record Prompt(string prompt);