### What's this ?!
a simple CLI app that integrates with OpenApiChatGPT which anserws questions thy might have . . . 

reference code and idea by [Les Jackson](https://www.youtube.com/watch?v=25i-Dh6U6Cw) : 
### Setup
for now to run this correctly u need to add your api-key as a dotnet secret -[Docs](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-7.0&tabs=windows)-, will think of a better way later.
[GET YOUR APIKEY](https://beta.openai.com/account/api-keys)

```powershell
dotnet user-secrets init
dotnet user-secrets set "APIKEY" "YOUR KEY"
```
### usage:

```powershell
help-me <QUERY>
help-me "powershell forlop syntax"
```


TODO:
- [ ] make this a bona fide CLI app ; make it look and behave like one !
- [ ] get a user API key, save it in a .config file in the same directory, or as an enviornment variable then try to get that . . .
- [ ] make a rust\python implementation.
- [ ] maybe some tests 