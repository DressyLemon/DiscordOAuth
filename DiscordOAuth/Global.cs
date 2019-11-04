using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DiscordOAuth
{
    namespace Web
    {
        public class OAuth
        {
            public string OAuth_Code;
            public string OAuth_CallBack;
            public string OAuth_URL;
            public HttpListenerContext URL_Response;
            public string Value;
            public OAuth(string _OAuth, string _CallBack)
            {
                HttpListener listener = new HttpListener();
                listener.Prefixes.Add(_CallBack);

                listener.Start();
                Process.Start(_OAuth);

                URL_Response = listener.GetContext();
                HttpListenerRequest request = URL_Response.Request;
                string id = request.QueryString["code"];
                OAuth_Code = id;
                string[] Split = Regex.Split(_OAuth,"redirect_uri=");
                Split = Regex.Split(Split[1], "response_type=");
                OAuth_URL = Split[0];
            }
            public void Response(string Text)
            {
                HttpListenerResponse Response = URL_Response.Response;

                Stream ResponseBody = Response.OutputStream;
                byte[] buffer = Encoding.UTF8.GetBytes(Text);
                Response.ContentLength64 = buffer.Length;
                ResponseBody.Write(buffer, 0, buffer.Length);
            }
        }
    }
    public class Global
    {
        public static async Task<string> GetOAuth(Web.OAuth _OAuth, string _Cred)
        {
            using (var httpClient = new HttpClient())
            {
                using (var requestpage = new HttpRequestMessage(new HttpMethod("POST"), "https://discordapp.com/api/oauth2/token?grant_type=authorization_code&code=" + _OAuth.OAuth_Code + "&redirect_uri=" + _OAuth.OAuth_URL))
                {
                    requestpage.Headers.TryAddWithoutValidation("Authorization", "Basic " + _Cred);

                    var responsepage = await httpClient.SendAsync(requestpage);

                    string Data = await responsepage.Content.ReadAsStringAsync();
                    dynamic JSON = JObject.Parse(Data);
                    _OAuth.OAuth_Code = JSON.access_token;

                }
            }
            using (var httpClient = new HttpClient())
            {
                using (var requestpage = new HttpRequestMessage(new HttpMethod("GET"), "https://discordapp.com/api/v6/users/@me"))
                {
                    requestpage.Headers.TryAddWithoutValidation("Authorization", "Bearer " + _OAuth.OAuth_Code);

                    var responsepage = await httpClient.SendAsync(requestpage);

                    string Data = await responsepage.Content.ReadAsStringAsync();
                    return Data;
                }
            }
        }
        public static string GetCred(string Client_ID, string Client_Secret)
        {
            var _Cred = System.Text.Encoding.UTF8.GetBytes(Client_ID + ":" + Client_Secret);
            return System.Convert.ToBase64String(_Cred);
        }

        public static async Task<string> GetToken(Web.OAuth _OAuth, string _Cred)
        {
            using (var httpClient = new HttpClient())
            {
                using (var requestpage = new HttpRequestMessage(new HttpMethod("POST"), "https://discordapp.com/api/oauth2/token?grant_type=authorization_code&code=" + _OAuth.OAuth_Code + "&redirect_uri=" + _OAuth.OAuth_URL))
                {
                    requestpage.Headers.TryAddWithoutValidation("Authorization", "Basic " + _Cred);

                    var responsepage = await httpClient.SendAsync(requestpage);

                    string Data = await responsepage.Content.ReadAsStringAsync();
                    return Data;
                }
            }
        }
    }
}

