namespace app.Web;

public class GenAIAPIClient(HttpClient httpClient)
{
    public async Task<String> GetPromptResultAsync(string prompt, int maxItems = 10, CancellationToken cancellationToken = default)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "prompt")
        {
            Content = new StringContent("{\"prompt\": \"" + prompt + "\"}", System.Text.Encoding.UTF8, "application/json")
        };
        var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error calling GenAI service: {response.StatusCode} - {response.ReasonPhrase}");
        }
        var genAIResult = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

        if (genAIResult is null)
        {
            throw new Exception("GenAI result is null.");
        }

        Console.WriteLine("GenAI Result: " + genAIResult);

        return genAIResult.ToString() ?? string.Empty;
    }
}
