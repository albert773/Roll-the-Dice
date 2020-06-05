using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RolltheDiceService.Models
{
    public class Singleton
    {
        private static Singleton instance = null;
        private Singleton() { }

        public static string Accion { get; set; }
        public static string Daño { get; set; }
        public static int Elemento { get; set; }
        public static int Emisor { get; set; }
        public static int Receptor { get; set; }
        public static int Dado { get; set; }

        public static Singleton Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Singleton();
                }

                return instance;
            }
        }
    }
}