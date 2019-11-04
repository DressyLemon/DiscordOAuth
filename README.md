# Discord OAuth

# About

Discord OAuth allow you to use discord OAuth via C# .Net, This comes with lots of easy usage on functions this is the only working C# .NET Discord OAuth on the NuGet Packages.

# Installation and Usage

To download Discord OAuth, run `dotnet add package Discord-OAuth --version 2.19.0`

To use Discord OAuth, you can take a look at [example](#example)

Example:
```cs
using DiscordOAuth.Web;
using DiscordOAuth;

OAuth _OAuth = new OAuth("<OAuth URL>", "<Callback URL>");
_OAuth.Response(@"Hello you have used Discord OAuth");
dynamic text = JObject.Parse(Global.GetOAuth(_OAuth, Global.GetCred("<Client ID>", "<Client Secret>")).Result);
Console.WriteLine("Username: "+text.username);
```
### Class

| Name            	| Argument(s)                                 	| Description                                              	|
|-----------------	|---------------------------------------------	|----------------------------------------------------------	|
| OAuth							    	|	`_OAuth`:	`string`, `_CallBack`: `string`    | Opens Discord OAuth.						                               	|
| Global								  	| 																		                          	| Global Functions to read given OAuth Class														 	|

### Functions

| Method            	| Example                                 																 | Description                                                               	| Returns             	|
|-------------------	|--------------------------------------------------------- |----------------------------------------------------------------------------|---------------------	|
| GetOAuth						    	| `Global.GetOAuth(_OAuth, GetCred("<ID>", "<Secret>"));`  | This gets OAuth data from the `_OAuth` Class. This closes the `_OAuth`.    | `OAuth RAW Text`	 			|
| GetCred			        	| `Global.GetCred("<ID>", "<Secret>"));`																		 | Converts `_OAuth ID` and `_OAuth Secret` to a Base64 Token.																| `Base64 Token`    	  |
| GetToken									 	| `Global.GetToken(_OAuth, GetCred("<ID>", "<Secret>"));`  | Fetch `_OAuth` RAW JSON data.		                                  	         | `OAuth Client Data` 	|
| OAuth					        	| `OAuth _OAuth = new OAuth("<OAuth URL>", "<CallBack>");` | Create `_OAuth`, This opens a private class to grab and take variables     | `null`									     	|
| Response           | `_OAuth.Response("<Text>");`						      																 | Sets discord OAuth Calls back to the HTML Text entered.                    | `null`     										|
