##Discord OAuth

### Features

- Makes HTTP Listener to read your OAuth callback
- Allows you to edit the HTML of your OAuth Callback
- Libary Lets you get all the infomation required to get your OAuth infomation
- Compatible with all OAuth Scopes
- No async required when calling the function
- function returns HTTP Errors, This allows you to read 401 errors
- Returns RAW Output this allows you to read with a JSON Format
---


####Inline code
Donwloading the OAuth NuGet Packages, Run this command to download OAuth.

`dotnet add package Khiv`

---
####OAuth Template Code

```cs
OAuth _OAuth = new OAuth("<OAuth URL>", "<OAuth Callback>");
_OAuth.Response("Hello Welocme to OAuth Callback");
string text = Global.GetOAuth(_OAuth, Global.GetCred("<Client_ID>","<Client_Secret>")).Result;
Console.WriteLine(text);
```
----
 ###Classes
                    

| Function name | Description                    |
| ------------- | ------------------------------ |
| `DiscordOAuth.DiscordOAuth`      | Private Discord OAuth Functions. |
| `DiscordOAuth.Global`  | Global Discord OAuth Functions. |
----

###Functions
                    

| Function name | Description                    |
| ------------- | ------------------------------ |
| `DiscordOAuth()`      |  Private Discord OAuth Class Function.  |
| `Response()`   |  Defines HTML Repsone Code.  |
----
###Functions
| Function name | Description                    |
| ------------- | ------------------------------ |
| `GetOAuth()`      | Getting OAuth via OAuth Class. |
| `GetCred()`   |  Creates a Base64 Fromat of the OAuth Token.  |
| `GetToken()`   |  Getting OAuth data from Discords API.  |
----
