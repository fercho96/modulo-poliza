using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;
using System.Data;

namespace capaLogica
{
    public class claselogica
    {
        clasedatos cd = new clasedatos();

        public void llenar(DataTable t, String l)
        {
            cd.conexion();
            cd.mostrar(t, l);
        }

        public void agregar (String l)
        {
            cd.conexion();
            cd.insertar(l);
        }

        public String queryConsulta(String campos, String tablas, String condicion)
        {
            String query;

            query = "SELECT " + campos + " FROM " + tablas + " " + condicion;

            return query;
        }
    }
}
