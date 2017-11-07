namespace capaPresentacion
{
    partial class cuenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Btn_Agregar = new System.Windows.Forms.Button();
            this.Dgv_Cuenta = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Dgv_nuevacuenta = new System.Windows.Forms.DataGridView();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.naturaleza = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.nivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Txt_nomenclatura = new System.Windows.Forms.TextBox();
            this.guardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Cuenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_nuevacuenta)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Agregar
            // 
            this.Btn_Agregar.Location = new System.Drawing.Point(355, 390);
            this.Btn_Agregar.Name = "Btn_Agregar";
            this.Btn_Agregar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Agregar.TabIndex = 5;
            this.Btn_Agregar.Text = "Agregar";
            this.Btn_Agregar.UseVisualStyleBackColor = true;
            this.Btn_Agregar.Click += new System.EventHandler(this.Btn_Agregar_Click);
            // 
            // Dgv_Cuenta
            // 
            this.Dgv_Cuenta.AllowUserToAddRows = false;
            this.Dgv_Cuenta.AllowUserToOrderColumns = true;
            this.Dgv_Cuenta.BackgroundColor = System.Drawing.Color.DarkBlue;
            this.Dgv_Cuenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Cuenta.Location = new System.Drawing.Point(49, 105);
            this.Dgv_Cuenta.Name = "Dgv_Cuenta";
            this.Dgv_Cuenta.Size = new System.Drawing.Size(642, 178);
            this.Dgv_Cuenta.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(351, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cuentas";
            // 
            // Dgv_nuevacuenta
            // 
            this.Dgv_nuevacuenta.AllowUserToAddRows = false;
            this.Dgv_nuevacuenta.AllowUserToDeleteRows = false;
            this.Dgv_nuevacuenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_nuevacuenta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.Dgv_nuevacuenta.BackgroundColor = System.Drawing.Color.DarkBlue;
            this.Dgv_nuevacuenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Dgv_nuevacuenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_nuevacuenta.ColumnHeadersVisible = false;
            this.Dgv_nuevacuenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombre,
            this.saldo,
            this.naturaleza,
            this.tipo,
            this.nivel});
            this.Dgv_nuevacuenta.Enabled = false;
            this.Dgv_nuevacuenta.Location = new System.Drawing.Point(185, 288);
            this.Dgv_nuevacuenta.Name = "Dgv_nuevacuenta";
            this.Dgv_nuevacuenta.RowHeadersVisible = false;
            this.Dgv_nuevacuenta.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Dgv_nuevacuenta.Size = new System.Drawing.Size(506, 45);
            this.Dgv_nuevacuenta.TabIndex = 6;
            this.Dgv_nuevacuenta.Visible = false;
            this.Dgv_nuevacuenta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_nuevacuenta_CellContentClick);
            this.Dgv_nuevacuenta.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.Dgv_nuevacuenta_CellValidating);
            this.Dgv_nuevacuenta.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_nuevacuenta_CellValueChanged);
            this.Dgv_nuevacuenta.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.Dgv_nuevacuenta_EditingControlShowing);
            // 
            // nombre
            // 
            this.nombre.HeaderText = "nombre";
            this.nombre.Name = "nombre";
            // 
            // saldo
            // 
            this.saldo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.saldo.HeaderText = "saldo";
            this.saldo.Items.AddRange(new object[] {
            "acreedor",
            "deudor"});
            this.saldo.Name = "saldo";
            // 
            // naturaleza
            // 
            this.naturaleza.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.naturaleza.HeaderText = "naturaleza";
            this.naturaleza.Items.AddRange(new object[] {
            "balance general",
            "costos de producción",
            "estado de resultados"});
            this.naturaleza.Name = "naturaleza";
            // 
            // tipo
            // 
            this.tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tipo.HeaderText = "tipo";
            this.tipo.Items.AddRange(new object[] {
            "mayor",
            "detalle"});
            this.tipo.Name = "tipo";
            // 
            // nivel
            // 
            this.nivel.HeaderText = "nivel";
            this.nivel.Name = "nivel";
            // 
            // Txt_nomenclatura
            // 
            this.Txt_nomenclatura.Enabled = false;
            this.Txt_nomenclatura.Location = new System.Drawing.Point(49, 289);
            this.Txt_nomenclatura.Name = "Txt_nomenclatura";
            this.Txt_nomenclatura.Size = new System.Drawing.Size(136, 20);
            this.Txt_nomenclatura.TabIndex = 7;
            this.Txt_nomenclatura.Visible = false;
            this.Txt_nomenclatura.TextChanged += new System.EventHandler(this.Txt_nomenclatura_TextChanged);
            this.Txt_nomenclatura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_nomenclatura_KeyPress);
            // 
            // guardar
            // 
            this.guardar.Location = new System.Drawing.Point(191, 390);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(75, 23);
            this.guardar.TabIndex = 8;
            this.guardar.Text = "guardar";
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // cuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(736, 463);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.Txt_nomenclatura);
            this.Controls.Add(this.Dgv_nuevacuenta);
            this.Controls.Add(this.Btn_Agregar);
            this.Controls.Add(this.Dgv_Cuenta);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "cuenta";
            this.Text = "cuenta";
            this.Load += new System.EventHandler(this.cuenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Cuenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_nuevacuenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Agregar;
        private System.Windows.Forms.DataGridView Dgv_Cuenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Dgv_nuevacuenta;
        private System.Windows.Forms.TextBox Txt_nomenclatura;
        private System.Windows.Forms.Button guardar;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewComboBoxColumn saldo;
        private System.Windows.Forms.DataGridViewComboBoxColumn naturaleza;
        private System.Windows.Forms.DataGridViewComboBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nivel;
    }
}