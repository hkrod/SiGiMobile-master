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
    class AdapterMarca:BaseAdapter
    {
        Activity context;
        List<Global.Marca> lista;

        public AdapterMarca(Activity context,List<Global.Marca> lista)
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

        public override View GetView(int position,View convertView,ViewGroup parent)
        {
            var item = lista[position];
            View view = convertView;

            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.itemmarca,null);

            view.FindViewById<TextView>(Resource.Id.txtcodigo).Text = item.Codigo;
            view.FindViewById<TextView>(Resource.Id.txtdescripcion).Text = item.Descripcion;
           // view.FindViewById<TextView>(Resource.Id.txtfecha).Text = item.Periodo + " | " + item.Grupo + " | " + item.Plan;

            view.FindViewById<TextView>(Resource.Id.txtnivel).Text = item.Nivel;
            
            return view;
        }
    }
}