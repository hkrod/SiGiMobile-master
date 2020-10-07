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
    [Activity(Label = "ActivityAgenda")]
    public class ActivityAgenda : Activity
    {
        ListView lista;
        LinearLayout boton;
        ImageButton btnatras;
        TextView txtatras;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.agenda);
            lista = FindViewById<ListView>(Resource.Id.listView1);

            lista.Adapter = new AdapterAgenda(this, Global.Agenda);

            lista.ItemClick += Lista_ItemClick;

            btnatras = FindViewById<ImageButton>(Resource.Id.imageButton2);
            btnatras.Click += Btnatras_Click;

            txtatras = FindViewById<TextView>(Resource.Id.textView2);
            txtatras.Click += Txtatras_Click;
            boton = FindViewById<LinearLayout>(Resource.Id.lymenu);
            boton.Click += Boton_Click;
            
        }

        private void Txtatras_Click(object sender, EventArgs e)
        {
            this.Finish();
        }

        private void Btnatras_Click(object sender, EventArgs e)
        {
            this.Finish();
        }

        private void Boton_Click(object sender, EventArgs e)
        {
            this.Finish();
        }

        private void Lista_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            string phoneCallUri = "tel:"+ Global.Agenda[e.Position].Tel+","+ Global.Agenda[e.Position].Ext;
            var uri = Android.Net.Uri.Parse(phoneCallUri);
            var intent = new Intent(Intent.ActionDial, uri);
            StartActivity(intent);
        }
    }
}