using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.IO;

namespace SiGiMobile
{
    [Activity(Label = "ActivityPanelEstudiante")]
    public class ActivityPanelEstudiante : Activity
    {
        ImageButton btnatras, btnsalir, btnperfil, btnplan, btncuenta, btnbeca, btnmatricula, btncal,btncamera,btnmarca;
        
        ImageView photo;
        byte[] bitmapData;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.panelestudiante);
            //UtilsAppsNica.SetHeader(this,  Color.ParseColor( GetString(Resource.Color.colorFondoPanel)));
            CargarDatos();
            btnatras = FindViewById<ImageButton>(Resource.Id.btnback);
            btnsalir = FindViewById<ImageButton>(Resource.Id.btnlogout);

            btnatras.Click += Btnatras_Click;
            btnsalir.Click += Btnsalir_Click;

            btnperfil = FindViewById<ImageButton>(Resource.Id.btnperfil);
            btnperfil.Click += Btnperfil_Click;
            btnplan = FindViewById<ImageButton>(Resource.Id.btnplan);

            btncuenta = FindViewById<ImageButton>(Resource.Id.btncuenta);
            btncuenta.Click += Btncuenta_Click;
            btnbeca = FindViewById<ImageButton>(Resource.Id.btnbeca);

            btnmatricula = FindViewById<ImageButton>(Resource.Id.btnmatricula);
            btncal = FindViewById<ImageButton>(Resource.Id.btncal);

            btncal.Click += Btncal_Click;


            btncamera = FindViewById<ImageButton>(Resource.Id.btncamera);
            btncamera.Click += Btncamera_Click;

            btnmarca = FindViewById<ImageButton>(Resource.Id.btnmarca);
            btnmarca.Click += Btnmarca_Click;

            photo = FindViewById<ImageView>(Resource.Id.profile_image);
            photo.Click += Photo_Click;

            string sphoto =UtilsAppsNica.GetOnePreference("photo");

            //vericando si hay foto en las preferencias y mostrandola
            if(sphoto != null)
            {
                byte[] imageAsBytes = Base64.Decode(sphoto, Base64Flags.Default);
                Bitmap bitmap2 = BitmapFactory.DecodeByteArray(imageAsBytes, 0, imageAsBytes.Length);

                BitmapDrawable ob = new BitmapDrawable(bitmap2);
                photo.SetBackgroundDrawable(ob);
            }
        }

        private void Btnmarca_Click(object sender,EventArgs e)
        {
            Intent i = new Intent(this,typeof(ActivityMarca));
            StartActivity(i);
        }

        private void Btncuenta_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(ActivityCuenta));
            StartActivity(i);
        }

        private void CargarDatos()
        {
            FindViewById<TextView>(Resource.Id.txtnombre).Text = ClienteApi.UserPerfil.Nombres + " " + ClienteApi.UserPerfil.Apellidos;
            FindViewById<TextView>(Resource.Id.txtcarnet).Text = ClienteApi.UserPerfil.Carnet;
        }

        private void Btnsalir_Click(object sender, EventArgs e)
        {
            //remover credenciales
            UtilsAppsNica.ClearLoginPreferences();
            UtilsAppsNica.RestartApp(this);
        }

        private void Btncamera_Click(object sender, EventArgs e)
        {
            OpenCamera();
        }

        private void Photo_Click(object sender, EventArgs e)
        {
            OpenCamera();
        }
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            Bitmap bitmap = (Bitmap)data.Extras.Get("data");
            //Bitmap to Byte
            using (var stream = new MemoryStream())
            {
                bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
                bitmapData = stream.ToArray();
            }
            
            //Byte to bitmap
            Bitmap bitmap2 = BitmapFactory.DecodeByteArray(bitmapData, 0, bitmapData.Length);
            BitmapDrawable ob = new BitmapDrawable(bitmap2);
            photo.SetBackgroundDrawable(ob);

            //Guardar foto como cadena de caracteres
            UtilsAppsNica.SaveOnePreference("photo", Base64.EncodeToString(bitmapData, Base64Flags.Default));
        }
       
        private void OpenCamera()
        {
            try
            {
             Intent intent = new Intent(MediaStore.ActionImageCapture);
              StartActivityForResult(intent, 0);
            }
            catch (Exception Ex)
            {

                Toast.MakeText(this, Ex.Message, ToastLength.Long).Show();
            }
           
        }

        private void Btnperfil_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(ActivityCarnetDigital));
            StartActivity(i);
        }

        private void Btncal_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(ActivityCalificaciones));
            StartActivity(i);
        }

        private void Btnatras_Click(object sender, EventArgs e)
        {
            this.Finish();
        }
    }
}