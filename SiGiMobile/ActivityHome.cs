using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SiGiMobile
{
    [Activity(Label = "ActivityHome", Theme = "@style/AppTheme")]
    public class ActivityHome : Activity
    {
        Button btnentrar,btnlogin,btnsalir;
        ImageButton btnagenda, btninfo;
        bool band = false;
        LinearLayout cplogin, cpuser;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.home);
            btnentrar = FindViewById<Button>(Resource.Id.button1);
            btnlogin = FindViewById<Button>(Resource.Id.btnlogin);
            btnsalir = FindViewById<Button>(Resource.Id.btnlogout);

            btnagenda = FindViewById<ImageButton>(Resource.Id.imageButton2);
            btninfo = FindViewById<ImageButton>(Resource.Id.imageButton3);

            //Panel logeo y panel usuario logeado
            cplogin = FindViewById<LinearLayout>(Resource.Id.cplogin);
            cpuser = FindViewById<LinearLayout>(Resource.Id.cpuser);

            btnagenda.Click += Btnagenda_Click;
            btninfo.Click += Btninfo_Click;

            btnentrar.Click += Btnentrar_Click;
            //Toast.MakeText(this, "Datos ", ToastLength.Long).Show();

            btnlogin.Click += Btnlogin_Click;
            btnsalir.Click += Btnsalir_Click;

            if (UtilsAppsNica.GetOnePreference("User")!= null)
                band = true;

            if (!band)
            {
                cplogin.Visibility = ViewStates.Visible;
                cpuser.Visibility = ViewStates.Invisible;
                
            }
            else
            {
                cplogin.Visibility = ViewStates.Invisible;
                cpuser.Visibility = ViewStates.Visible;
                ClienteApi.GetPerfil();
                btnlogin.Text = "Entrar como " + ClienteApi.UserPerfil.Nombres;

            }

        }

        private void Btnsalir_Click(object sender, EventArgs e)
        {
           // UtilsAppsNica.Alerta(this, "Logout", "Quiere cerrar la sesion?");
            //remover credenciales
            UtilsAppsNica.ClearLoginPreferences();
            band = false;
            UtilsAppsNica.RestartApp(this);
        }

        private void Btnlogin_Click(object sender, EventArgs e)
        {
            band = true;
            OpenHome();
        }

        private void Btninfo_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(ActivityInfo));
            StartActivity(i);
        }

        private void Btnagenda_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(ActivityAgenda));
            StartActivity(i);
        }

        private void Btnentrar_Click(object sender, EventArgs e)
        {
            string carnet = FindViewById<EditText>(Resource.Id.editText1).Text;
            string clave = FindViewById<EditText>(Resource.Id.editText2).Text;
            Toast.MakeText(this, "Datos hola "+clave, ToastLength.Long).Show();
            if (ClienteApi.GetPostToken(carnet, clave))
            {
                //Guardar credenciales
                UtilsAppsNica.SaveLoginPreferences(carnet, clave);
                UtilsAppsNica.SaveOnePreference("Token", ClienteApi.LoginResult.tokenDelUsuario);
                band = true;
                UtilsAppsNica.RestartApp(this);
            } else
            {
                UtilsAppsNica.Msg(this, ClienteApi.error);
            }
        }

        private void OpenHome()
        {
             Intent i = new Intent(this, typeof(ActivityPanelEstudiante));
             StartActivity(i);
        }

        
    }
}