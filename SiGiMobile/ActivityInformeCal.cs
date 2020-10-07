using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;

namespace SiGiMobile
{
    [Activity(Label = "ActivityInformeCal")]
    public class ActivityInformeCal : Activity
    {
        ImageButton btnatras;
        WebView webView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.informecal);

            btnatras = FindViewById<ImageButton>(Resource.Id.imageButton2);
            btnatras.Click += Btnatras_Click;

            webView = FindViewById<WebView>(Resource.Id.webView1);
           webView.SetWebViewClient(new WebViewClient());
            webView.LoadUrl("https://sigi.unan.edu.ni/RegistroAcademico/Reportes/ReporteCatalogo.aspx?Reporte=historialEstudianteId&carne=%2BiKV%2BdvpLD4qStAzGbTXhw%3D%3D&EsEstudiante=1");

            
        }

        private void Btnatras_Click(object sender, EventArgs e)
        {
            this.Finish();
        }
    }
}