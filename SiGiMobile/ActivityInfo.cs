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
    [Activity(Label = "ActivityInfo")]
    public class ActivityInfo : Activity
    {
        LinearLayout boton;
        ImageButton btnatras;
        TextView txtatras;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.info);
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

       
    }
}