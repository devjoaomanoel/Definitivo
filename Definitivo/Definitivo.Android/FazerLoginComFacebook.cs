using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Xamarin.Auth;
using Definitivo;
using Definitivo.Views;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Xamarin.Essentials;

[assembly: ExportRenderer(typeof(LoginPage), typeof(Aplicativo.Droid.FazerLoginComFacebook))]

namespace Aplicativo.Droid
{
    public class FazerLoginComFacebook : PageRenderer
    {
        [Obsolete]
        public FazerLoginComFacebook()
        {
            var activity = this.Context as Activity;

            var auth = new OAuth2Authenticator(
                clientId: "1154359511743951",
                scope: "",
                authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                redirectUrl: new Uri("https://www.facebook.com/connect/login_success.html"));

            auth.Completed += async (sender, eventArgs) => {
                if (eventArgs.IsAuthenticated)
                {
                    var accessToken = eventArgs.Account.Properties["access_token"].ToString();
                    var expiresIn = Convert.ToDouble(eventArgs.Account.Properties["expires_in"]);
                    var expiryDate = DateTime.Now + TimeSpan.FromSeconds(expiresIn);

                    var request = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me"), null, eventArgs.Account);
                    var response = await request.GetResponseAsync();
                    var obj = JObject.Parse(response.GetResponseText());

                    var id = obj["id"].ToString().Replace("\"", "");
                    var name = obj["name"].ToString().Replace("\"", "");

                    await App.NavigateToProfile(string.Format("Olá {0}, seja bem-vindo", name));
                }
                else
                {
                    await App.NavigateToProfile("O usuário Cancelou o login");
                }
            };

            activity.StartActivity(auth.GetUI(activity));
        }


    }
}