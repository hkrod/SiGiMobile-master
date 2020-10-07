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
    [Activity(Label = "ActivityMarca")]
    public class ActivityMarca:Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.marca);
            FindViewById<TextView>(Resource.Id.txttotal).Text = Global.Marcas.Count.ToString();

            FindViewById<ListView>(Resource.Id.lvmarca).Adapter=new AdapterMarca(this,Global.Marcas);

        }
    }
}