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
    [Activity(Label = "ActivityCuenta")]
    public class ActivityCuenta : Activity
    {
        ImageButton btnatras;

        decimal creditos = 0, abonos = 0, saldo = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.cuenta);
            btnatras = FindViewById<ImageButton>(Resource.Id.imageButton2);
            btnatras.Click += Btnatras_Click;


            FindViewById<TextView>(Resource.Id.txtnombre).Text= ClienteApi.UserPerfil.Nombres + " " + ClienteApi.UserPerfil.Apellidos;
            if (ClienteApi.GetEstadoCuenta())
            {
                creditos = ClienteApi.Cuentas.Where(x=>x.CodigoDelTipoDeMovimiento=="C").Sum(x => x.Monto);
                abonos = ClienteApi.Cuentas.Where(x => x.CodigoDelTipoDeMovimiento == "A").Sum(x => x.Monto);
                saldo = creditos - abonos;
                FindViewById<TextView>(Resource.Id.txtcreditos).Text = "Total créditos: C$ " + creditos;
                FindViewById<TextView>(Resource.Id.txtabonos).Text = "Total abonos: C$ " + abonos;
                FindViewById<TextView>(Resource.Id.txttotal).Text = "C$ " + saldo;

                FindViewById<ListView>(Resource.Id.lvmovimientos).Adapter = new Adaptermovimientos(this, ClienteApi.Cuentas);
            }
            else
            {
                UtilsAppsNica.Msg(this, ClienteApi.error);
            }
        }

        private void Btnatras_Click(object sender, EventArgs e)
        {
            this.Finish();
        }
    }
}