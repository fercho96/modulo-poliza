using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaLogica;

namespace capaPresentacion
{
    public partial class cuenta : Form
    {
        claselogica cl = new claselogica(); //se coloca un alias para llamar a las funciones de la claselogica de capaLogica
        String campos;
        String tablas;
        String condicion;
        String consulta;
        String celda;
        String insertar;
        bool activado = false;
        bool aumento = false;
        DataTable tablaDatos;
        int nomenclaturacuenta = 0;
        int contador = 0;
        int contadorauxiliar = 0;
        int nivelcuenta = 2;

        public cuenta()
        {
            InitializeComponent();
            campos = "nomenclatura, nombre, saldo, naturaleza, tipo, nivel";
            tablas = "cuentacontabilidad";
            condicion = " ORDER BY nomenclatura LIMIT 1,99999999999";
            consulta = cl.queryConsulta(campos, tablas, condicion);
            tablaDatos = new DataTable();
            cl.llenar(tablaDatos, consulta);
            Dgv_Cuenta.DataSource = tablaDatos;
        }

        private void Btn_Agregar_Click(object sender, EventArgs e)
        {
            Dgv_nuevacuenta.Visible = true;
            Dgv_nuevacuenta.Enabled = true;
            Txt_nomenclatura.Visible = true;
            Txt_nomenclatura.Enabled = true;
            Btn_Agregar.Enabled = false;
            Dgv_nuevacuenta.Rows.Add();//se agrega una nueva fila para insertar datos de cuenta
            Dgv_nuevacuenta.Rows[0].Cells["nombre"].Selected = false;
            /*Dgv_nuevacuenta.Rows[0].Cells["nombre"].Value = " ";
            Dgv_nuevacuenta.Rows[0].Cells["saldo"].Value = 0;
            Dgv_nuevacuenta.Rows[0].Cells["naturaleza"].Value = 0;
            Dgv_nuevacuenta.Rows[0].Cells["tipo"].Value = 0;*/
        }

        private void Dgv_nuevacuenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Dgv_nuevacuenta_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            /* if (Dgv_nuevacuenta.Rows[e.RowIndex].Cells["nomenclatura"].Value != null)
             {
                 celda = Dgv_nuevacuenta.Rows[e.RowIndex].Cells["nomenclatura"].Value.ToString();
                 buscar();
             }
             else
             {
                 campos = "nomenclatura, nombre, saldo, naturaleza, tipo, nivel";
                 tablas = "cuentacontabilidad";
                 condicion = " ";
                 consulta = cl.queryConsulta(campos, tablas, condicion);
                 tablaDatos = new DataTable();
                 cl.llenar(tablaDatos, consulta);
                 Dgv_Cuenta.DataSource = tablaDatos;
             }*/
        }

        private void buscar()
        {
            campos = "nomenclatura, nombre, saldo, naturaleza, tipo, nivel";
            tablas = "cuentacontabilidad";
            condicion = "WHERE nomenclatura LIKE '" + celda + "%' ORDER BY nomenclatura LIMIT 1,99999999999";
            consulta = cl.queryConsulta(campos, tablas, condicion);
            tablaDatos = new DataTable();
            cl.llenar(tablaDatos, consulta);
            Dgv_Cuenta.DataSource = tablaDatos;
        }

        private void Dgv_nuevacuenta_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            /* String nombrecelda = Dgv_nuevacuenta.Columns[e.ColumnIndex].Name;
             if (nombrecelda.Equals("nomenclatura"))
             {
                 if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                 {
                     campos = "nomenclatura, nombre, saldo, naturaleza, tipo, nivel";
                     tablas = "cuentacontabilidad";
                     condicion = " ";
                     consulta = cl.queryConsulta(campos, tablas, condicion);
                     tablaDatos = new DataTable();
                     cl.llenar(tablaDatos, consulta);
                     Dgv_Cuenta.DataSource = tablaDatos;
                 }
                 else
                 {
                     celda = Dgv_nuevacuenta.Rows[e.RowIndex].Cells["nomenclatura"].Value.ToString(); ;
                     buscar();
                 }
                 }
             */
        }

        private void Dgv_nuevacuenta_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
           // e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
            
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (Dgv_nuevacuenta.Rows[0].Cells[0].Value != null)
            {
                celda = Dgv_nuevacuenta.Rows[0].Cells[0].Value.ToString();
                campos = "nomenclatura, nombre, saldo, naturaleza, tipo, nivel";
                tablas = "cuentacontabilidad";
                condicion = " WHERE nomenclatura like '" + celda + "%'";
                consulta = cl.queryConsulta(campos, tablas, condicion);
                tablaDatos = new DataTable();
                cl.llenar(tablaDatos, consulta);
                Dgv_Cuenta.DataSource = tablaDatos;
            }*/
            

        }

        private void Txt_nomenclatura_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Txt_nomenclatura_TextChanged(object sender, EventArgs e)
        {
            celda = Txt_nomenclatura.Text;
            int diferencia = 0;
            Dgv_nuevacuenta.Rows[0].Cells["nivel"].ReadOnly = true;
            campos = "nomenclatura, nombre, saldo, naturaleza, tipo, nivel";
            tablas = "cuentacontabilidad";
            condicion = " WHERE nomenclatura like '%" + celda + "%' ORDER BY nomenclatura LIMIT 1,99999999999";
            consulta = cl.queryConsulta(campos, tablas, condicion);
            //MessageBox.Show(celda);
            tablaDatos = new DataTable();
            cl.llenar(tablaDatos, consulta);
            Dgv_Cuenta.DataSource = tablaDatos;

            diferencia = celda.Length - contador;

            if (celda.Length > contadorauxiliar)
            {
                contador++;
                aumento = true;
            }
            else
            {
                contador--;
                aumento = false;
            }
           
            //no hay datos
            if (celda.Length == 0)
            {
                Dgv_nuevacuenta.Rows[0].Cells["nivel"].Value = " ";
                contador = 0;
                nivelcuenta = 0;
               // contadorauxiliar = celda.Length;
            }
            //1 dato en el textbox (nivel 1)
            else if (celda.Length == 1)
            {
                nivelcuenta = 1;
                contador = 1;
                Dgv_nuevacuenta.Rows[0].Cells["nivel"].Value = "1";
                
            }

            //2 datos en textbox (nivel 2)
            else if (celda.Length == 2)
            {
                Dgv_nuevacuenta.Rows[0].Cells["nivel"].Value = "2";
                contador = 2;
                nivelcuenta = 2;
                
            }
           
            //aumento de nivel
            else if (contador >= 3)
            {               
                
                    contador=0;
                    nivelcuenta++;
                    Dgv_nuevacuenta.Rows[0].Cells["nivel"].Value = nivelcuenta;
                  
            }

            //disminucion de nivel
            else if (contador < 0)
            {

                contador = 3;
                nivelcuenta--;
                Dgv_nuevacuenta.Rows[0].Cells["nivel"].Value = nivelcuenta;
            }

            
            contadorauxiliar = celda.Length;
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            insertar = " ";
            try
            {
                if (Txt_nomenclatura.Text.Equals(""))
                    MessageBox.Show("Debe llenar todos los campos");

                else if (Txt_nomenclatura.Text.Length > 11)
                    MessageBox.Show("El código de nomenclatura no puede ser mayor a 11 dígitos.");
                else
                {
                    insertar = Txt_nomenclatura.Text;
                    insertar = insertar + ",'" + Dgv_nuevacuenta.Rows[0].Cells["nombre"].Value.ToString() + "'";
                    insertar = insertar + ",'" + Dgv_nuevacuenta.Rows[0].Cells["saldo"].Value.ToString() + "'";
                    insertar = insertar + "," + Dgv_nuevacuenta.Rows[0].Cells["nivel"].Value.ToString();
                    insertar = insertar + ",0";
                    insertar = insertar + ",0";
                    insertar = insertar + ",0";
                    insertar = insertar + ",0";
                    insertar = insertar + ",0";
                    insertar = insertar + ",0";
                    insertar = insertar + ",0";
                    insertar = insertar + ",'" + Dgv_nuevacuenta.Rows[0].Cells["naturaleza"].Value.ToString() + "'";
                    insertar = insertar + ",'" + Dgv_nuevacuenta.Rows[0].Cells["tipo"].Value.ToString() + "'";

                    cl.agregar("INSERT INTO cuentacontabilidad VALUES(" + insertar + ")");

                    Txt_nomenclatura.Text = " ";
                    Dgv_nuevacuenta.Rows.Clear();
                    Dgv_nuevacuenta.Visible = false;
                    Txt_nomenclatura.Visible = false;

                    campos = "nomenclatura, nombre, saldo, naturaleza, tipo, nivel";
                    tablas = "cuentacontabilidad";
                    condicion = "ORDER BY nomenclatura LIMIT 1,99999999999";
                    consulta = cl.queryConsulta(campos, tablas, condicion);
                    tablaDatos = new DataTable();
                    cl.llenar(tablaDatos, consulta);
                    Dgv_Cuenta.DataSource = tablaDatos;
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Se ha encontrado un error. Para solucionarlo:\n-Seleccione opciones válidas en los valores desplegables.\n-Ingrese un nombre correcto de cuenta.");
            }

            }

        private void cuenta_Load(object sender, EventArgs e)
        {
        }
    }
}
