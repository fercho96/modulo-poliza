using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capaDatos
{
    public class clasedatos
    {
        /* 
           enlace directo con la base de datos
           conexión, inserciones en la tabla de detalle partida y detallePartida
           además de consultas hacia los valores previamente insertados para que se realicen 
           los cierres contables, presupuestos y estados de resultados
         */

        OdbcConnection conector;
        OdbcCommand selector;
        // MySqlDataAdapter adaptar;
        OdbcDataReader leer;

        public void conexion()
        {
            try
            {
                conector = new OdbcConnection("Driver ={ MySQL ODBC 5.3 Driver }; Dsn=fernanflow; UID=root; PWD = ; Database = hotelsancarlos; ");
                conector.Open();
            }
            catch (OdbcException ex)
            {
                //MessageBox.Show("No se puede conectar a la base de datos. " + ex);
            }


        }

        public void mostrar(DataTable tabla, String operar)
        {

            try
            {
                //tabla.Clear();               
                selector = new OdbcCommand();
                selector.Connection = conector;
                selector.CommandText = operar;
                //leer = selector.ExecuteReader();
                OdbcDataAdapter adaptar = new OdbcDataAdapter(selector);
                adaptar.Fill(tabla);
                
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("Error al cargar la base de datos. " + ex);
            }
            catch (ArgumentException ex)
            {
               // MessageBox.Show("Error al cargar la base de datos. " + ex);
            }
            finally
            {
                conector.Close();
            }

        }

        public void insertar(String operar)
        {

            try
            {
                //tabla.Clear();               
                selector = new OdbcCommand();
                selector.Connection = conector;
                selector.CommandText = operar;
                //leer = selector.ExecuteReader();
                selector.ExecuteNonQuery();
                //MessageBox.Show("Dato insertado o actualizado. ");

                // comboBox1.ValueMember = "id_tipo_usuario";
                // comboBox1.DisplayMember = "descripcion";
                /*d2 = "descripcion";
                Console.Write("d2=" + d2);
                MessageBox.Show("d2=" + d2);*/
                //comboBox1.DataSource = dt;
            }
            catch (OdbcException ex)
            {
                 MessageBox.Show("Error al insertar en la base de datos. " + ex);
            }
            finally
            {
                conector.Close();
            }

        }
    }
}
