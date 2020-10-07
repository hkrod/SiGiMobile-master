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
    [Activity(Label = "ActivityCarnetDigital")]
    public class ActivityCarnetDigital : Activity
    {
        ImageButton btnatras;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.carnetdigital);
            btnatras = FindViewById<ImageButton>(Resource.Id.imageButton2);
            btnatras.Click += Btnatras_Click;
        }

        private void Btnatras_Click(object sender, EventArgs e)
        {
            this.Finish();
        }
    }
}