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
    class UtilsAppsNica
    {
        class Preferencia
        {
            string key;
            string value;

            public Preferencia(string key, string value)
            {
                this.Key = key;
                this.Value = value;
            }

            public string Key { get => key; set => key = value; }
            public string Value { get => value; set => this.value = value; }
        }
       public static string appname = "Sigimobile";

        public static void SaveLoginPreferences(string user, string pass)
        {
            var prefs = Application.Context.GetSharedPreferences(appname, FileCreationMode.Private);
            var prefEditor = prefs.Edit();
            prefEditor.PutString("User", user);
            prefEditor.PutString("Pass", pass);

            prefEditor.Commit();
        }
        /// <summary>
        /// <para>Guardar un valor en las preferencias del usuario</para>
        /// </summary>
        /// <param name="key">nombre del campo a guardar</param>
        /// <param name="value">valor del campo </param>
        public static void SaveOnePreference(string key, string value)
        {
            var prefs = Application.Context.GetSharedPreferences(appname, FileCreationMode.Private);
            var prefEditor = prefs.Edit();
            prefEditor.PutString(key, value);
            prefEditor.Commit();
        }

        public static string GetOnePreference(string key)
        {
            var prefs = Application.Context.GetSharedPreferences(appname, FileCreationMode.Private);

            return prefs.GetString(key, null);

        }

        public static void ClearLoginPreferences()
        {
            var editor = Application.Context.GetSharedPreferences(appname, FileCreationMode.Private).Edit();
            editor.Remove("Pass");
            editor.Remove("User");
            editor.Remove("photo");
            editor.Remove("Token");
            editor.Remove("PerfilJson");
            ///editor.Clear();
            editor.Commit();

        }
        public static void RestartApp(Activity Context)
        {
            Intent i = Context.BaseContext.PackageManager.GetLaunchIntentForPackage(Context.BaseContext.PackageName);

            i.AddFlags(ActivityFlags.ClearTop);//clear the stack
            i.AddFlags(ActivityFlags.NewTask);
            Context.Finish();//don`t forget to finish before starting again

            Context.StartActivity(i);
            Context.RunOnUiThread(() => Toast.MakeText(Context, "Actualizando preferencias" , ToastLength.Long).Show());
        }
        public static void Msg(Activity Context, string Mensaje)
        {
            Toast.MakeText(Context, Mensaje, ToastLength.Long).Show();
        }
        /// <summary>
        /// <para>Cambia el color de la barra de titulo</para>
        /// </summary>
        /// <param name="Context"></param>
        /// <param name="Color">Numero en Hexadecimal Ej.: #FFFFFF</param>

        public static void SetHeader(Activity Context, Android.Graphics.Color Color)
        {

            if (Build.VERSION.SdkInt >= Build.VERSION_CODES.Lollipop)
            {

                Window window = Context.Window;
                window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
                //window.ClearFlags(WindowManagerFlags.TranslucentStatus);
                window.SetStatusBarColor(Color);

            }

            Context.ActionBar.SetBackgroundDrawable(new Android.Graphics.Drawables.ColorDrawable(Color));
        }

        ///<summary>
        ///<para>Muestra en pantalla una Alerta. Debe Activar el permiso de SYSTEM_ALERT_WINDOWS</para>
        ///<para>Show alert on screem. You should have actived SYSTEM_ALERT_WINDOWS  permission</para>
        ///</summary>
        ///<param name="context"> contexto actual. Usualmente use this</param>
        ///<param name="Titulo">Texto que se desplegara en el titulo de la ventana</param>
        ///<param name="Msg">Texto o mensaje a mostrar</param>
        public static void Alerta(Context context, string Titulo, string Msg)
        {
            var alert = new Android.App.AlertDialog.Builder(context);
            alert.SetTitle(Titulo);

            alert.SetMessage(Msg);
            alert.SetPositiveButton("OK", (senderAlert, args) =>
            {
                Toast.MakeText(context, "Ok Tapped!", ToastLength.Short).Show();
            });

            Dialog dialog = alert.Create();
            dialog.Window.SetType(Android.Views.WindowManagerTypes.SystemAlert);
            dialog.Show();
        }
    }
}