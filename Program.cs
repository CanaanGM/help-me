using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();

string APIKEY = config["APIKEY"];
string APIURL = "https://api.openai.com/v1/completions";


if(args.Length > 0){
    HttpClient Client = new HttpClient();
    Client.DefaultRequestHeaders.Add("authorization", $"Bearer {APIKEY}" );

    var request = new Request() {Prompt =args[0] };
    string jsonReq = System.Text.Json.JsonSerializer.Serialize<Request>(request);
    var content = new StringContent(jsonReq, Encoding.UTF8, "application/json");
    
    HttpResponseMessage res = await Client.PostAsync(APIURL, content);
    var response = await res.Content.ReadAsStringAsync();
    try 
    {
        Response data = JsonConvert.DeserializeObject<Response>(response);
        string guess = GetAnswer(data.Choices[0].Text);

        Console.ResetColor();
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

}
else{
    Console.WriteLine("Usage: help-me <QUERY>");
}

static string GetAnswer(string rawAnswer){
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine(rawAnswer);

    var lastIndex = rawAnswer.LastIndexOf('\n');
    string guess = rawAnswer.Substring(lastIndex + 1 );

    Console.ResetColor();

    TextCopy.ClipboardService.SetText(guess);

    return guess;
}