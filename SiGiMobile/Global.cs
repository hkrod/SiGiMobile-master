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
    class Global
    {
        public class Nota
        {
            string cod;
            string asignatura;
            string notanf;
            string notane;
            string periodo;
            string grupo;
            string plan;

            public Nota(string cod,string asignatura,string notanf,string notane,string periodo,string grupo,string plan)
            {
                this.Cod = cod;
                this.Asignatura = asignatura;
                this.Notanf = notanf;
                this.Notane = notane;
                this.Periodo = periodo;
                this.Grupo = grupo;
                this.Plan = plan;
            }

            public string Cod { get => cod; set => cod = value; }
            public string Asignatura { get => asignatura; set => asignatura = value; }
            public string Notanf { get => notanf; set => notanf = value; }
            public string Notane { get => notane; set => notane = value; }
            public string Periodo { get => periodo; set => periodo = value; }
            public string Grupo { get => grupo; set => grupo = value; }
            public string Plan { get => plan; set => plan = value; }
        }
        public class Telefono
        {
            string unidad;
            string oficina;
            string tel;
            string ext;

            public Telefono(string unidad,string oficina,string tel,string ext)
            {
                this.Unidad = unidad;
                this.Oficina = oficina;
                this.Tel = tel;
                this.Ext = ext;
            }

            public string Unidad { get => unidad; set => unidad = value; }
            public string Oficina { get => oficina; set => oficina = value; }
            public string Tel { get => tel; set => tel = value; }
            public string Ext { get => ext; set => ext = value; }
        }

        public class Marca {
            string codigo;
            string descripcion;
            string nivel;

            public Marca(string codigo,string descripcion,string nivel)
            {
                this.codigo = codigo;
                this.descripcion = descripcion;
                this.nivel = nivel;
            }

            public string Codigo { get => codigo; set => codigo = value; }
            public string Descripcion { get => descripcion; set => descripcion = value; }
            public string Nivel { get => nivel; set => nivel = value; }
        }

        public static List<Marca> Marcas = new List<Marca> {
            new Marca("001","debe libro","1")
            ,new Marca("002","debe riales","2")
            ,new Marca("003","robo","3")
            ,new Marca("004","daño a la infraestructura","4")
        };
        public static List<string> Periodos = new List<string> {"Todos", "2006-1", "2006-2" , "2007-1", "2007-2" };
        public static List<Nota> Calificaciones = new List<Nota>
        {
             new Nota("99COM014","INGLES TECNICO", "82","0","2006-1" ,"IC11M",  "99")
            ,new Nota("99COM014","ESPAÑOL GENERAL", "87","0","2006-1" ,"IC11M",  "99")
            ,new Nota("99COM014","SEMINARIO DE FORMACIÓN INTEGRAL", "82","0","2006-1" ,"IC11M",  "99")
            ,new Nota("99COM014","Calculo I", "90","0","2006-2" ,"IC11M",  "99")
            ,new Nota("99COM014","INTRODUCION A LA FISICA", "90","0","2006-2" ,"IC11M",  "99")
            ,new Nota("99COM014"," INTRODUCCION A LA QUIMICA", "77","0","2006-2" ,"IC11M",  "99")
            ,new Nota("99COM014","INGLES TECNICO III", "0","75","2007-1" ,"IC11M",  "99")
            ,new Nota("99COM014","PROGRAMACION II", "87","0","2007-1" ,"IC11M",  "99")
            ,new Nota("99COM014","ESTRUCTURA DE DISCRETAS", "90","0","2007-2" ,"IC11M",  "99")
            ,new Nota("99COM014","ALGORITMOS Y ESTRUCTURAS DE DATOS I", "75","0","2007-2" ,"IC11M",  "99")
        };

        public static List<Telefono> Agenda = new List<Telefono> {
            new Telefono("Rectoría","Central Telefónica (PBX)","22786769","")
           ,new Telefono("Rectoría","Central Telefónica (PBX)","22786764","")
            ,new Telefono("Vice Rectoría General","Central Telefónica (PBX)","22786764","")
            ,new Telefono("Rectoría","Central Telefónica (PBX)","22786764","")
            ,new Telefono("Vice Rectoría General","Dirección SIU-DT","22786764","")
            ,new Telefono("Vice Rectoría General","Central Telefónica (PBX)","22786764","")
            ,new Telefono("Vice Rectoría General","Fondo Social	","22771090","")
            ,new Telefono("Vice Rectoría General","SIUDT- Área Sistemas de Información	","22786769","6028")
            ,new Telefono("Rectoría","Central Telefónica (PBX)","22786764","")
            ,new Telefono("Vice Rectoría General","Central Telefónica (PBX)","22786764","")
            ,new Telefono("Rectoría","Central Telefónica (PBX)","22786764","")
            ,new Telefono("Vice Rectoría General","Dirección SIU-DT","22786764","")
            ,new Telefono("Vice Rectoría General","Central Telefónica (PBX)","22786764","")
            ,new Telefono("Vice Rectoría General","Fondo Social	","22771090","")
            ,new Telefono("Vice Rectoría General","SIUDT- Área Sistemas de Información	","22786769","6028")
        };
            
    
        public static bool Validar(string carnet, string clave)
        {
            bool band = false;
            if (carnet == "10101011" && clave == "123456")
                band = true;
            return band;
        }
    }
}