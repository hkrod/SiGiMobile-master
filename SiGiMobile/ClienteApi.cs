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
using System.Net.Http;
using System.Net.Http.Headers;

namespace SiGiMobile
{
    
    class ClienteApi
    {
        public static EData LoginResult;
        public static Perfil UserPerfil;
        public static string error = "Datos erroneos!";
        public static List<Cuenta> Cuentas;
        private static readonly HttpClient client = new HttpClient();
        public static void GetPerfil()
        {
            //Tratamos de conseguir el perfil offline
            string JsonResult = UtilsAppsNica.GetOnePreference("PerfilJson");
            if (!(JsonResult==null))
             UserPerfil = Newtonsoft.Json.JsonConvert.DeserializeObject<Perfil>(UtilsAppsNica.GetOnePreference("PerfilJson"));
            else
            {
                //sino hay datos offile nos conectamos al  API
                if (LoginResult == null)
                    LoginResult.tokenDelUsuario = UtilsAppsNica.GetOnePreference("Token");

             client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginResult.tokenDelUsuario);
            var response = client.GetAsync("https://sigi.unan.edu.ni/RAServices/Api/PortalEstudiante/GetPortal");

            JsonResult = response.Result.Content.ReadAsStringAsync().Result;
            UtilsAppsNica.SaveOnePreference("PerfilJson", JsonResult);
 
            UserPerfil = Newtonsoft.Json.JsonConvert.DeserializeObject<Perfil>(JsonResult);
            }
            

        }

        public static void GetMarcas()
        {


            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginResult.tokenDelUsuario);
            var response = client.GetAsync("https://sigi.unan.edu.ni/RAServices/Api/PortalEstudiante/GetMarcas");

            //txttoken.Text = response.Result.Content.ReadAsStringAsync().Result;
        }

        public static bool GetEstadoCuenta()
        {
            bool band = false;
            try
            {

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginResult.tokenDelUsuario);
              var response = client.GetAsync("https://sigi.unan.edu.ni/RAServices/Api/PortalEstudiante/GetEstadoDeCuenta");


            Cuentas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Cuenta>>(response.Result.Content.ReadAsStringAsync().Result);
                band = true;
            }
            catch (Exception ex)
            {

                error = "Hubo un error:\n" + ex.HResult + "\r" + ex.InnerException.Message.ToString() + "\nVerifique sus datos. \nVerifique su conexión a internet y vuelva a intentarlo";

            }


            return band;
            // dataGridView2.DataSource = lista;
        }

        //conectarse

        public static bool  GetPostToken(string carnet, string clave)
        {
            bool band = false;
            //Lista de valores a pasar
            var values = new Dictionary<string, string>
                {
                      { "UserName", carnet },
                      { "Password", clave }
                      //{ "Password", "Managua.2020" }
                };

            //Formato json
            var content = new FormUrlEncodedContent(values);

            //Realizamos la peticion via Post
            var response = client.PostAsync("https://sigi.unan.edu.ni/RAServices/Api/Autorizacion/Login", content);


            //MessageBox.Show(response.Result.ToString());
            try
            {
                //MessageBox.Show(response.Result.Content.ReadAsStringAsync().Result);
                string status = response.Result.StatusCode.ToString();
                    if(status=="OK")
                    {
                        LoginResult = Newtonsoft.Json.JsonConvert.DeserializeObject<EData>(response.Result.Content.ReadAsStringAsync().Result);
                        if (LoginResult.tokenDelUsuario.Length>0)
                        band = true;
                    } else
                {
                    error="Hubo un error con el servidor!. \n Code: " + status + "\n Vuelva a intentarlo mas tarde";
                }
                     

            }
            catch (Exception ex)
            {

                error="Hubo un error:\n" +ex.HResult+"\r"+ex.InnerException.Message.ToString()+"\nVerifique sus datos. \nVerifique su conexión a internet y vuelva a intentarlo";
            }
            


            return band;

        }

        public class EData
        {

            public string cuentaDeLUsuario { get; set; }
            public string tokenDelUsuario { get; set; }
        }

        public class Perfil
        {
            public string Carnet { get; set; }
            public string Facultad { get; set; }
            public string Carrera { get; set; }
            public string PlanDeEstudio { get; set; }
            public string Modalidad { get; set; }
            public string Turno { get; set; }
            public string Nombres { get; set; }
            public string Apellidos { get; set; }
            public string Telefono { get; set; }
            public string Correo { get; set; }
            public string Sexo { get; set; }
            public string EstadoCivil { get; set; }
            public string SituacionLaboral { get; set; }
            public string Direccion { get; set; }
            public string CentroDeTrabajo { get; set; }
            public string FechaDeNacimiento { get; set; }
        }

        public class Cuenta
        {
            public string CodigoDelTipoDeMovimiento { get; set; }
            public string TipoDeMovimiento { get; set; }
            public string Periodo { get; set; }
            public string Fecha { get; set; }
            public string Recibo { get; set; }
            public string Concepto { get; set; }
            public decimal Monto { get; set; }

        }
    }


   
    
}