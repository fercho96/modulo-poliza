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
    public partial class poliza : Form
    {
        claselogica cl = new claselogica(); //se coloca un alias para llamar a las funciones de la claselogica de capaLogica
        int totalfilas = 0;
        int totaldetalle = 0;
        String campos;
        String tablas;
        String condicion;
        String consulta;
        String celda;
        String insertar;
        ComboBox combo;
        TextBox tdebe;
        TextBox thaber;
        DataTable tablaDatos;
        // TextBox texto;
        bool pasado = false;
        double sumadebe = 0;
        double sumahaber = 0;
        double diferencia = 0;
        bool d = false;
        bool h = false;
        double valueEntered1 = 0, valueEntered2 = 0;

        public poliza()
        {
            InitializeComponent();
            campos = "idPartida,numeroPartida as numero,fecha,definicionPartida as razon,total";
            tablas = "partida";
            condicion = " WHERE estado='online' ORDER BY idPartida";
            consulta = cl.queryConsulta(campos, tablas, condicion);
            tablaDatos = new DataTable();
            cl.llenar(tablaDatos, consulta);
            Dgv_partida.DataSource = tablaDatos;
            Dgv_partida.Columns[0].Visible = false;
            totalfilas = tablaDatos.Rows.Count;
           // MessageBox.Show(tablaDatos.Rows.Count.ToString());           
        }

        public void ajustesaldo(double cargo, double abono, string nom)
        {
            insertar = "UPDATE cuentacontabilidad SET cargoMes = cargoMes + " + cargo + " WHERE nomenclatura=" + nom;
            cl.agregar(insertar);

            insertar = "UPDATE cuentacontabilidad SET abonoMes = abonoMes + " + abono + " WHERE nomenclatura=" + nom;
            cl.agregar(insertar);

            insertar = "UPDATE cuentacontabilidad SET saldoActual = ABS(cargoMes - abonoMes) WHERE nomenclatura=" + nom;
            cl.agregar(insertar);
        }

        private void Btn_agregarfila_Click(object sender, EventArgs e)
        {
            //int fila = Dgv_detalle_partida.RowCount - 1;           
            try
            {
                int fila = Dgv_detalle_partida.CurrentRow.Index;
                double sd = Convert.ToDouble(Dgv_detalle_partida.Rows[fila].Cells["debe"].Value);
                double sh = Convert.ToDouble(Dgv_detalle_partida.Rows[fila].Cells["haber"].Value);
                String combo = Dgv_detalle_partida.Rows[fila].Cells["cuenta"].Value.ToString();
                if ((sd == 0.00 && sh == 0.00))
                {
                    MessageBox.Show("No se ha registrado información en la fila " + fila + 1);
                }
                else if ((sd != 0.00 && sh != 0.00))
                {
                    MessageBox.Show("Debe ingresar un dato únicamente en debe o en haber en fila " + fila + 1);
                }
                
                else
                {
                    foreach (DataGridViewRow row1 in Dgv_detalle_partida.Rows)
                    {
                        sumadebe += Convert.ToDouble(row1.Cells["debe"].Value);
                        sumahaber += Convert.ToDouble(row1.Cells["haber"].Value);
                    }


                    Txt_Debe.Text = sumadebe.ToString();
                    Txt_Haber.Text = sumahaber.ToString();

                    sumahaber = 0;
                    sumadebe = 0;

                    sd = Convert.ToDouble(Txt_Debe.Text);
                    sh = Convert.ToDouble(Txt_Haber.Text);

                    Dgv_detalle_partida.Rows.Add();
                    totaldetalle++;
                    int calculo = Dgv_detalle_partida.Rows.Count-1;
                    Dgv_detalle_partida.Rows[calculo].Cells["nump"].Value = totaldetalle;
                    


                }
            }
            catch(NullReferenceException en)
            {
                MessageBox.Show("Se ha encontrado un error. Para solucionarlo:\n-Seleccione una cuenta válida.\n-Ingrese un dato en debe o un dato en haber.");
            }
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            int fila = Dgv_detalle_partida.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            Dgv_detalle_partida.Rows.RemoveAt(fila);

            foreach (DataGridViewRow row1 in Dgv_detalle_partida.Rows)
            {
                sumadebe += Convert.ToDouble(row1.Cells["debe"].Value);
                sumahaber += Convert.ToDouble(row1.Cells["haber"].Value);
            }


            Txt_Debe.Text = sumadebe.ToString();
            Txt_Haber.Text = sumahaber.ToString();

            sumahaber = 0;
            sumadebe = 0;

            double sd = Convert.ToDouble(Txt_Debe.Text);
            double sh = Convert.ToDouble(Txt_Haber.Text);
        }

        private void Btn_agregarpoliza_Click(object sender, EventArgs e)
        {
            if (Btn_agregarpoliza.Text == "Nueva Póliza")
            {
                Dgv_partida.Visible = false;
                Dgv_insertar_partida.Visible = true;
                Dgv_insertar_partida.Rows.Add();
                Dgv_insertar_partida.Rows[0].Cells["nm"].Value = totalfilas + 1;
                DateTime Hoy = DateTime.Today;
                string fecha_actual = Hoy.ToString("yyyy-MM-dd");
                Dgv_insertar_partida.Rows[0].Cells["fecha"].Value = fecha_actual;
                Btn_agregarpoliza.Text = "Listo";
                Dgv_partida.AllowUserToAddRows = false;
            }
            else if (Btn_agregarpoliza.Text == "Listo")
            {
                DataGridViewComboBoxColumn cb = Dgv_detalle_partida.Columns["cuenta"] as DataGridViewComboBoxColumn;
                try {                   
                    if (String.IsNullOrEmpty(Dgv_insertar_partida.Rows[0].Cells["razon"].Value.ToString()))
                        MessageBox.Show("Ingrese una razón de póliza válida");
                    else
                    {                       
                        Dgv_detalle_partida.Rows.Add();
                        totaldetalle = 1;
                        Dgv_detalle_partida.Rows[0].Cells["nump"].Value = totaldetalle;
                        campos = "nomenclatura, CONCAT(nomenclatura,'-',nombre) as nom";
                        tablas = "cuentacontabilidad";
                        condicion = " WHERE tipo='detalle' ORDER BY nomenclatura";
                        consulta = cl.queryConsulta(campos, tablas, condicion);
                        tablaDatos = new DataTable();
                        cl.llenar(tablaDatos, consulta);
                        cb.DataSource = tablaDatos;
                        cb.ValueMember = "nomenclatura";
                        cb.DisplayMember = "nom";
                        Btn_agregarpoliza.Enabled = false;
                        Btn_agregarfila.Enabled = true;
                        Btn_eliminar.Enabled = true;
                        Btn_saldos.Enabled = true;
                        Dgv_auxiliar.Visible = false;
                        Dgv_detalle_partida.Visible = true;
                    }
                }
                catch (NullReferenceException ne)
                {
                    MessageBox.Show("Ingrese una razón de póliza válida");
                }
            }
        }

        private void Btn_saldos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row1 in Dgv_detalle_partida.Rows)
            {
                sumadebe += Convert.ToDouble(row1.Cells["debe"].Value);
            }

            foreach (DataGridViewRow row1 in Dgv_detalle_partida.Rows)
            {
                sumahaber += Convert.ToDouble(row1.Cells["haber"].Value);
            }

            Txt_Debe.Text = sumadebe.ToString();
            Txt_Haber.Text = sumahaber.ToString();

            sumahaber = 0;
            sumadebe = 0;

            double sd = Convert.ToDouble(Txt_Debe.Text);
            double sh = Convert.ToDouble(Txt_Haber.Text);

            if ((sd == 0.00 && sh == 0.00))
            {
                MessageBox.Show("No se ha registrado información");
            }
            else
            {
                if ((sd < sh) || (sd > sh))
                {
                    Txt_Debe.BackColor = Color.Red;
                    Txt_Haber.BackColor = Color.Red;
                    MessageBox.Show("Las columnas no están balanceadas a 0.");
                }
                else if (sd == sh)
                {
                    Txt_Debe.BackColor = Color.Lime;
                    Txt_Haber.BackColor = Color.Lime;
                   // MessageBox.Show(Dgv_insertar_partida.Rows[0].Cells["fecha"].Value.ToString());
                    String id = Dgv_insertar_partida.Rows[0].Cells["nm"].Value.ToString() + Dgv_insertar_partida.Rows[0].Cells["fecha"].Value.ToString();
                    //MessageBox.Show(id);
                    insertar = "'"+id+"'";
                    insertar = insertar + "," +Dgv_insertar_partida.Rows[0].Cells["nm"].Value.ToString();
                    insertar = insertar + ",'" + Dgv_insertar_partida.Rows[0].Cells["razon"].Value.ToString() + "'";
                    insertar = insertar + "," + sd.ToString();
                    insertar = insertar + ",'" + Dgv_insertar_partida.Rows[0].Cells["fecha"].Value.ToString() + "'";
                    insertar = insertar + ",'online'";
                    cl.agregar("INSERT INTO partida VALUES(" + insertar + ")");

                    foreach (DataGridViewRow row1 in Dgv_detalle_partida.Rows)
                    {
                        bool uno = false; //indica si ya sumo la columna debe
                        double valor=0;
                        double cargo = 0;
                        double abono = 0;
                        String tipo="";
                        String nome = row1.Cells["cuenta"].Value.ToString();
                        //MessageBox.Show(nome);
                        try
                        {
                            valor = Convert.ToDouble(row1.Cells["debe"].Value);
                            if (valor != 0)
                            {
                                tipo = "debe";
                                cargo = valor;
                                abono = 0;
                                //MessageBox.Show(sumadebe.ToString());
                                uno = true;
                            }
                            else
                            {
                                valor = Convert.ToDouble(row1.Cells["haber"].Value);
                                cargo = 0;
                                abono = valor;
                                tipo = "haber";
                                uno = false;
                            }                         
                        }
                        catch (FormatException f)
                        {
                            if (!uno)
                            {
                                tipo = "haber";
                                valor = Convert.ToDouble(row1.Cells["haber"].Value);
                            }
                            else
                            {
                                tipo = "debe";
                            }
                        }

                        insertar = row1.Cells["nump"].Value.ToString();
                        insertar = insertar + "," + valor.ToString();
                        insertar = insertar + "," + nome ;
                        insertar = insertar + ",'" + tipo+ "'";
                        insertar = insertar + ",'" + id + "'";                       
                        cl.agregar("INSERT INTO detallepartida VALUES(" + insertar + ")");

                        String nivelar = nome;
                        MessageBox.Show(nivelar.Length.ToString());
                        

                        while (nivelar.Length > 0)
                        {
                            if(nivelar.Length == 1) {
                                ajustesaldo(cargo, abono, nivelar);
                                nivelar = nivelar.Remove(0);
                                MessageBox.Show(nivelar);
                            }

                            else if (nivelar.Length == 2) {
                                ajustesaldo(cargo, abono, nivelar);
                                nivelar = nivelar.Remove(1);
                                MessageBox.Show(nivelar);
                            }

                            else {
                                ajustesaldo(cargo, abono, nivelar);
                                nivelar = nivelar.Remove(nivelar.Length-3, 3);
                                MessageBox.Show(nivelar);
                            }
                        }

                    }

                        //MessageBox.Show("Póliza guardada exitosamente.");
                        Dgv_detalle_partida.Rows.Clear();
                    Dgv_insertar_partida.Rows.Clear();

                    Btn_agregarfila.Enabled = false;
                    Btn_eliminar.Enabled = false;
                    Btn_agregarpoliza.Enabled = true;
                    Btn_saldos.Enabled = false;
                    Dgv_detalle_partida.Visible = false;
                    Dgv_auxiliar.Visible = true;
                    Dgv_partida.Visible = true;
                    Dgv_insertar_partida.Visible = false;
                    campos = "idPartida,numeroPartida as numero,fecha,definicionPartida as razon,total";
                    tablas = "partida";
                    condicion = " WHERE estado='online' ORDER BY idPartida";
                    consulta = cl.queryConsulta(campos, tablas, condicion);
                    tablaDatos = new DataTable();
                    cl.llenar(tablaDatos, consulta);
                    Dgv_partida.DataSource = tablaDatos;
                    Dgv_partida.Columns[0].Visible = false;
                    totalfilas = tablaDatos.Rows.Count;
                    Txt_Debe.BackColor = Color.White;
                    Txt_Haber.BackColor = Color.White;
                    Btn_agregarpoliza.Text = "Nueva Póliza";
                }

                
            }
        }

        private void Dgv_detalle_partida_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            combo = e.Control as ComboBox;
            if (combo != null)
            {
                pasado = true;
                combo.SelectedIndexChanged -= new EventHandler(combo_SelectedIndexChanged);
                combo.SelectedIndexChanged += combo_SelectedIndexChanged;
            }
        }

        private void combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string selected = (sender as ComboBox).SelectedItem.ToString();
           // DataGridViewComboBoxColumn cb = Dgv_detalle_partida.Columns["cuenta"] as DataGridViewComboBoxColumn;
            string selected = (sender as ComboBox).SelectedValue.ToString();
            //MessageBox.Show(selected);
            if (selected.Equals("0"))
            {
                cuenta cd = new cuenta();
                cd.Show();
               /* campos = "nomenclatura, CONCAT(nomenclatura,'-',nombre) as nom";
                tablas = "cuentacontabilidad";
                condicion = " WHERE tipo='detalle' ORDER BY nomenclatura";
                consulta = cl.queryConsulta(campos, tablas, condicion);
                tablaDatos = new DataTable();
                cl.llenar(tablaDatos, consulta);
                cb.DataSource = tablaDatos;
                cb.ValueMember = "nomenclatura";
                cb.DisplayMember = "nom";*/
            }
        }

        private void poliza_Load(object sender, EventArgs e)
        {

           /* campos = "d.numeroDetallePartida, c.nombre, d.total, d.tipoPartida";
            tablas = "detallepartida d, cuentacontabilidad c";
            condicion = "d.partida_idPartida='"+celda+"' AND d.cuentacontabilidad_nomenclatura= c.nomenclatura ORDER BY d.numeroDetallePartida";
            cl.queryConsulta(campos, tablas, condicion);*/
        }

        private void Dgv_partida_SelectionChanged(object sender, EventArgs e)
        {
            
            int fila = Dgv_partida.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (fila >= 0)
              celda = Dgv_partida.Rows[fila].Cells[0].Value.ToString(); 
            //MessageBox.Show("Entro");
           // MessageBox.Show("celda " + celda);          
            campos = "d.numeroDetallePartida as num, c.nombre as cuenta, d.total as total, d.tipoPartida as tipo";
            tablas = "detallepartida d, cuentacontabilidad c";
            condicion = "WHERE d.partida_idPartida='" + celda + "' AND d.cuentacontabilidad_nomenclatura= c.nomenclatura ORDER BY d.numeroDetallePartida";
            consulta = cl.queryConsulta(campos, tablas, condicion);
            tablaDatos = new DataTable();
            cl.llenar(tablaDatos, consulta);
            Dgv_mostrarDetalle.DataSource = tablaDatos;
            int contador = 0;
            Dgv_auxiliar.Rows.Clear();

            foreach (DataGridViewRow row1 in Dgv_mostrarDetalle.Rows)
            {
                Dgv_auxiliar.Rows.Add();
                Dgv_auxiliar.Rows[contador].Cells["num"].Value = row1.Cells[0].Value.ToString();
                Dgv_auxiliar.Rows[contador].Cells["cnta"].Value = row1.Cells[1].Value.ToString();
               
                if (row1.Cells[3].Value.ToString().Equals("debe"))
                {
                    Dgv_auxiliar.Rows[contador].Cells["db"].Value = row1.Cells[2].Value.ToString();
                    Dgv_auxiliar.Rows[contador].Cells["hb"].Value = " ";                   
                }

                else if (row1.Cells[3].Value.ToString().Equals("haber"))
                {
                    Dgv_auxiliar.Rows[contador].Cells["hb"].Value = row1.Cells[2].Value.ToString();
                    Dgv_auxiliar.Rows[contador].Cells["db"].Value = " ";
                }
                contador++;
            }

            sumadebe = 0;
            sumahaber = 0;

            foreach (DataGridViewRow row1 in Dgv_auxiliar.Rows)
            {
                bool uno = false; //indica si ya sumo la columna debe
                try
                {
                    sumadebe += Convert.ToDouble(row1.Cells["db"].Value);
                    //MessageBox.Show(sumadebe.ToString());
                    uno = true;
                    sumahaber += Convert.ToDouble(row1.Cells["hb"].Value);
                    //MessageBox.Show(sumahaber.ToString());
                    uno = false;
                }
                catch (FormatException f)
                {
                    if (!uno)
                    {
                        sumahaber += Convert.ToDouble(row1.Cells["hb"].Value);
                        sumadebe += 0.00;
                    }
                    else
                    {
                        sumahaber += 0.00;
                    }
                }
            }

            Txt_Debe.Text = sumadebe.ToString();
            Txt_Haber.Text = sumahaber.ToString();

            sumahaber = 0;
            sumadebe = 0;

            double sd = Convert.ToDouble(Txt_Debe.Text);
            double sh = Convert.ToDouble(Txt_Haber.Text);

        }

        private void Dgv_mostrarDetalle_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void Dgv_mostrarDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Dgv_partida_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
