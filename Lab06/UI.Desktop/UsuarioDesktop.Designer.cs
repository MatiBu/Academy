namespace UI.Desktop
{
    partial class UsuarioDesktop
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
            this.chkHabilitado = new System.Windows.Forms.CheckBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtConfirmarClave = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.Label();
            this.tlUsuario = new System.Windows.Forms.TableLayoutPanel();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.moduleGrid = new System.Windows.Forms.DataGridView();
            this.modulos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alta = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.baja = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.modificacion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tlUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moduleGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // chkHabilitado
            // 
            this.chkHabilitado.AutoSize = true;
            this.chkHabilitado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHabilitado.Location = new System.Drawing.Point(336, 14);
            this.chkHabilitado.Margin = new System.Windows.Forms.Padding(8);
            this.chkHabilitado.Name = "chkHabilitado";
            this.chkHabilitado.Size = new System.Drawing.Size(89, 20);
            this.chkHabilitado.TabIndex = 16;
            this.chkHabilitado.Text = "Habilitado";
            this.chkHabilitado.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(560, 322);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(88, 28);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(409, 322);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(6);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(88, 28);
            this.btnAceptar.TabIndex = 14;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtConfirmarClave
            // 
            this.txtConfirmarClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmarClave.Location = new System.Drawing.Point(455, 114);
            this.txtConfirmarClave.Margin = new System.Windows.Forms.Padding(6);
            this.txtConfirmarClave.Name = "txtConfirmarClave";
            this.txtConfirmarClave.Size = new System.Drawing.Size(218, 22);
            this.txtConfirmarClave.TabIndex = 13;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(455, 81);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(6);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(218, 22);
            this.txtUsuario.TabIndex = 12;
            // 
            // txtApellido
            // 
            this.txtApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.Location = new System.Drawing.Point(455, 48);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(6);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(218, 22);
            this.txtApellido.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(336, 116);
            this.label7.Margin = new System.Windows.Forms.Padding(8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Confirmar Clave";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(336, 83);
            this.label6.Margin = new System.Windows.Forms.Padding(8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Usuario";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(336, 50);
            this.label5.Margin = new System.Windows.Forms.Padding(8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Apellido";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 116);
            this.label4.Margin = new System.Windows.Forms.Padding(8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Clave";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 83);
            this.label3.Margin = new System.Windows.Forms.Padding(8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre";
            // 
            // id
            // 
            this.id.AutoSize = true;
            this.id.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id.Location = new System.Drawing.Point(14, 14);
            this.id.Margin = new System.Windows.Forms.Padding(8);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(21, 16);
            this.id.TabIndex = 0;
            this.id.Text = "ID";
            // 
            // tlUsuario
            // 
            this.tlUsuario.ColumnCount = 4;
            this.tlUsuario.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlUsuario.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tlUsuario.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tlUsuario.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tlUsuario.Controls.Add(this.id, 0, 0);
            this.tlUsuario.Controls.Add(this.label2, 0, 1);
            this.tlUsuario.Controls.Add(this.label3, 0, 2);
            this.tlUsuario.Controls.Add(this.label4, 0, 3);
            this.tlUsuario.Controls.Add(this.label5, 2, 1);
            this.tlUsuario.Controls.Add(this.label6, 2, 2);
            this.tlUsuario.Controls.Add(this.label7, 2, 3);
            this.tlUsuario.Controls.Add(this.txtID, 1, 0);
            this.tlUsuario.Controls.Add(this.txtNombre, 1, 1);
            this.tlUsuario.Controls.Add(this.txtEmail, 1, 2);
            this.tlUsuario.Controls.Add(this.txtClave, 1, 3);
            this.tlUsuario.Controls.Add(this.txtApellido, 3, 1);
            this.tlUsuario.Controls.Add(this.txtUsuario, 3, 2);
            this.tlUsuario.Controls.Add(this.txtConfirmarClave, 3, 3);
            this.tlUsuario.Controls.Add(this.chkHabilitado, 2, 0);
            this.tlUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlUsuario.Location = new System.Drawing.Point(0, 0);
            this.tlUsuario.Name = "tlUsuario";
            this.tlUsuario.Padding = new System.Windows.Forms.Padding(6);
            this.tlUsuario.RowCount = 4;
            this.tlUsuario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.51515F));
            this.tlUsuario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.48485F));
            this.tlUsuario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tlUsuario.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlUsuario.Size = new System.Drawing.Size(685, 149);
            this.tlUsuario.TabIndex = 0;
            this.tlUsuario.Paint += new System.Windows.Forms.PaintEventHandler(this.tlUsuario_Paint);
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(112, 12);
            this.txtID.Margin = new System.Windows.Forms.Padding(6);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(210, 22);
            this.txtID.TabIndex = 7;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(112, 48);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(6);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(210, 22);
            this.txtNombre.TabIndex = 8;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(112, 81);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(6);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(210, 22);
            this.txtEmail.TabIndex = 9;
            // 
            // txtClave
            // 
            this.txtClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClave.Location = new System.Drawing.Point(112, 114);
            this.txtClave.Margin = new System.Windows.Forms.Padding(6);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(210, 22);
            this.txtClave.TabIndex = 10;
            // 
            // moduleGrid
            // 
            this.moduleGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.moduleGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.modulos,
            this.alta,
            this.baja,
            this.modificacion});
            this.moduleGrid.Location = new System.Drawing.Point(0, 145);
            this.moduleGrid.Name = "moduleGrid";
            this.moduleGrid.Size = new System.Drawing.Size(685, 168);
            this.moduleGrid.TabIndex = 16;
            // 
            // modulos
            // 
            this.modulos.DataPropertyName = "Descripcion";
            this.modulos.HeaderText = "Modulos";
            this.modulos.Name = "modulos";
            this.modulos.ReadOnly = true;
            this.modulos.Width = 310;
            // 
            // alta
            // 
            this.alta.DataPropertyName = "PermiteAlta";
            this.alta.HeaderText = "Alta";
            this.alta.Name = "alta";
            this.alta.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.alta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.alta.Width = 110;
            // 
            // baja
            // 
            this.baja.DataPropertyName = "PermiteBaja";
            this.baja.HeaderText = "Baja";
            this.baja.Name = "baja";
            this.baja.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.baja.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.baja.Width = 110;
            // 
            // modificacion
            // 
            this.modificacion.DataPropertyName = "PermiteModificacion";
            this.modificacion.HeaderText = "Modificacion";
            this.modificacion.Name = "modificacion";
            this.modificacion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.modificacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.modificacion.Width = 110;
            // 
            // UsuarioDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 365);
            this.Controls.Add(this.moduleGrid);
            this.Controls.Add(this.tlUsuario);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Name = "UsuarioDesktop";
            this.Text = "UsuarioDesktop";
            this.tlUsuario.ResumeLayout(false);
            this.tlUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moduleGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkHabilitado;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtConfirmarClave;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label id;
        private System.Windows.Forms.TableLayoutPanel tlUsuario;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.DataGridView moduleGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn modulos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn alta;
        private System.Windows.Forms.DataGridViewCheckBoxColumn baja;
        private System.Windows.Forms.DataGridViewCheckBoxColumn modificacion;
    }
}