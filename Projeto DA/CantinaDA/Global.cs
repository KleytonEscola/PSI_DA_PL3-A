using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CantinaDA
{
    internal class Global
    {
        private static string connectionString_aux = "";

        public static string connectionString
        {
            get { return connectionString_aux; }
            set { connectionString_aux = value; }
        }

        private static int tipo_aux = 1;
        public static int tipocliente
        {
            get { return tipo_aux; }
            set { tipo_aux = value; }
        }

        private static string multaid_aux = "";
        public static string multaid
        {
            get { return multaid_aux; }
            set { multaid_aux = value; }
        }

        private static string funcsec_aux = "";
        public static string funcsec
        {
            get { return funcsec_aux; }
            set { funcsec_aux = value; }
        }

        private static int tipomenu_aux = 1;
        public static int tipomenu
        {
            get { return tipomenu_aux; }
            set { tipomenu_aux = value; }
        }

        private static string datamenu_aux = "";
        public static string datamenu
        {
            get { return datamenu_aux; }
            set { datamenu_aux = value; }
        }

        private static string pratotipo_aux = "Vegetariano";
        public static string pratotipo
        {
            get { return pratotipo_aux; }
            set { pratotipo_aux = value; }
        }

        private static string reservaitems_aux = "";
        public static string reservaitems
        {
            get { return reservaitems_aux; }
            set { reservaitems_aux = value; }
        }

        private static string reservaextra_aux = "";
        public static string reservaextra
        {
            get { return reservaextra_aux; }
            set { reservaextra_aux = value; }
        }

        private static int tiporeserva_aux = 1;
        public static int tiporeserva
        {
            get { return tiporeserva_aux; }
            set { tiporeserva_aux = value; }
        }

        private static int comecoureserva_aux = 0;
        public static int comecoureserva
        {
            get { return comecoureserva_aux; }
            set { comecoureserva_aux = value; }
        }

        private static int tipopratoreserva_aux = 0;
        public static int tipopratoreserva
        {
            get { return tipopratoreserva_aux; }
            set { tipopratoreserva_aux = value; }
        }

        private static int btnres_aux = 0;
        public static int btnres
        {
            get { return btnres_aux; }
            set { btnres_aux = value; }
        }

        private static float totalreserva_aux = 0;
        public static float totalreserva
        {
            get { return totalreserva_aux; }
            set { totalreserva_aux = value; }
        }

        private static string reservanome_aux = "";
        public static string reservanome
        {
            get { return reservanome_aux; }
            set { reservanome_aux = value; }
        }

        private static string reservacod_aux = "";
        public static string reservacod
        {
            get { return reservacod_aux; }
            set { reservacod_aux = value; }
        }

        
    }
}
