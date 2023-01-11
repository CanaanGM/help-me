using System.Text.Json.Serialization;

public class Request {
    public Request()
    {
        
    }
    public Request(string model, string prompt, int temperature, int maxToken)
    {
        Model = model;
        Prompt = prompt;
        Temperature = temperature;
        MaxToken = maxToken;
    }
    
    [JsonPropertyName("model")]
    public string Model { get; set; }  = "text-davinci-003";
    
    [JsonPropertyName("prompt")]
    public string Prompt { get; set; } 
    
    [JsonPropertyName("temperature")]
    public int Temperature { get; set; } = 1;
    
    [JsonPropertyName("max_tokens")]
    public int MaxToken { get; set; } = 100; 
}