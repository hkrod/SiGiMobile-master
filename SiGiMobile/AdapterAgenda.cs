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
    class AdapterAgenda : BaseAdapter
    {
        Activity context;
        List<Global.Telefono> lista;

        public AdapterAgenda(Activity context, List<Global.Telefono> lista)
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
                view = context.LayoutInflater.Inflate(Resource.Layout.itemagenda, null);
            view.FindViewById<TextView>(Resource.Id.textView1).Text = item.Unidad;
            view.FindViewById<TextView>(Resource.Id.textView2).Text = item.Oficina;
            view.FindViewById<TextView>(Resource.Id.textView4).Text = item.Tel+","+ item.Ext;

            return view;
        }
    }
}