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
using Java.Lang;

namespace SiGiMobile
{
    class Adaptermovimientos : BaseAdapter
    {
        Activity context;
        List<ClienteApi.Cuenta> lista;

        public Adaptermovimientos(Activity context, List<ClienteApi.Cuenta> lista)
        {
            this.context = context;
            this.lista = lista;
        }

        public override int Count => lista.Count;

        public override Java.Lang.Object GetItem(int position)
        {
            throw new NotImplementedException();
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = lista[position];
            View view = convertView;

            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.itemmovimiento, null);

            view.FindViewById<TextView>(Resource.Id.txtconcepto).Text = item.Concepto;
            view.FindViewById<TextView>(Resource.Id.txtrecibo).Text = item.Recibo;
            view.FindViewById<TextView>(Resource.Id.txtfecha).Text = item.Fecha;

            view.FindViewById<TextView>(Resource.Id.txtmonto).Text = item.Monto.ToString();
            view.FindViewById<TextView>(Resource.Id.txttipo).Text = item.TipoDeMovimiento;
            if (item.CodigoDelTipoDeMovimiento=="A")
            {
            view.FindViewById<TextView>(Resource.Id.txtmonto).SetTextColor(Android.Graphics.Color.DarkGreen);
            view.FindViewById<TextView>(Resource.Id.txttipo).SetTextColor(Android.Graphics.Color.DarkGreen);
            }
            
            return view;
        }
    }
}