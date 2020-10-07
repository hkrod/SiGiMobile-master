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
    [Activity(Label = "ActivityCalificaciones")]
    public class ActivityCalificaciones : Activity
    {
        ImageButton btnatras, btnimprimir;
        ListView lista;
        Spinner periodos;
        AdapterCal adaptador;
        EditText txtbuqueda;
        TextView txttotal;
        int total=0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.calificaciones);
            btnatras = FindViewById<ImageButton>(Resource.Id.imageButton2);
            btnatras.Click += Btnatras_Click;

            txtbuqueda = FindViewById<EditText>(Resource.Id.txtbusqueda);
            txtbuqueda.TextChanged += Txtbuqueda_TextChanged;

            btnimprimir= FindViewById<ImageButton>(Resource.Id.imageButton3);
            btnimprimir.Click += Btnimprimir_Click;



            lista = FindViewById<ListView>(Resource.Id.listView1);
              
           // lista.Adapter = new AdapterCal(this, Global.Calificaciones);
            lista.ChoiceMode = ChoiceMode.Multiple;

            //Mostrar total calificaciones
            total = Global.Calificaciones.Count;
            txttotal = FindViewById<TextView>(Resource.Id.txttotal);
            //txttotal.Text = total.ToString() + "/" + total.ToString() + " asignaturas";

            periodos = FindViewById<Spinner>(Resource.Id.spinner1);
            periodos.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, Global.Periodos.ToArray());

            periodos.ItemSelected += Periodos_ItemSelected;
        }

        private void Txtbuqueda_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
           
            string valor = txtbuqueda.Text;

            List<Global.Nota> filtrado = Global.Calificaciones.Where(x => x.Asignatura.ToUpperInvariant().Contains(valor.ToUpper())).ToList();
            //List<string> filtrado = Global.Periodos.Where(x => x.Contains(valor)).ToList()
            lista.Adapter = new AdapterCal(this, filtrado);
            txttotal.Text = filtrado.Count.ToString() + "/" + total.ToString() + " asignaturas";
        }

        private void Periodos_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            if(!(e.Position==0))
            {
                string periodo = Global.Periodos[e.Position];
                List<Global.Nota> filtrado = Global.Calificaciones.Where(x => x.Periodo == periodo).ToList();
                
                lista.Adapter = new AdapterCal(this, filtrado);
                txttotal.Text = filtrado.Count.ToString() + "/" + total.ToString() + " asignaturas";
                lista.ChoiceMode = ChoiceMode.Multiple;
            }
            else
            {
                lista.Adapter = new AdapterCal(this, Global.Calificaciones);
                txttotal.Text = total.ToString() + "/" + total.ToString() + " asignaturas";
            }
            

        }

        private void Btnimprimir_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(ActivityInformeCal));
            StartActivity(i);
        }

        private void Periodos_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            
            //lista.Adapter = new AdapterCal(this, Global.Calificaciones.Where(x=>x.Periodo==Global.Periodos[e.Position]).ToList());
        }

        private void Btnatras_Click(object sender, EventArgs e)
        {
            this.Finish();
        }
    }
}