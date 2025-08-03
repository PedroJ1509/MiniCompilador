namespace MiniCompilador
{
    partial class MiniCompilador
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MiniCompilador));
            label1 = new Label();
            txtCodigo = new TextBox();
            label2 = new Label();
            toolStrip1 = new ToolStrip();
            btnNuevo = new ToolStripButton();
            btnCompilar = new ToolStripButton();
            btnEjecutar = new ToolStripButton();
            grdLexico = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            label3 = new Label();
            grdSintactico = new DataGridView();
            Mensaje = new DataGridViewTextBoxColumn();
            label4 = new Label();
            label5 = new Label();
            txtResultado = new TextBox();
            label6 = new Label();
            dgTablaSimbolos = new DataGridView();
            Nombre = new DataGridViewTextBoxColumn();
            Tipo = new DataGridViewTextBoxColumn();
            Valor = new DataGridViewTextBoxColumn();
            label7 = new Label();
            dgSemantico = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdLexico).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdSintactico).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgTablaSimbolos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgSemantico).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(1101, 25);
            label1.Name = "label1";
            label1.Size = new Size(160, 15);
            label1.TabIndex = 0;
            label1.Text = "Pedro J. De la Rosa 1-03-3398";
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(12, 66);
            txtCodigo.Multiline = true;
            txtCodigo.Name = "txtCodigo";
            txtCodigo.ScrollBars = ScrollBars.Vertical;
            txtCodigo.Size = new Size(456, 457);
            txtCodigo.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(12, 42);
            label2.Name = "label2";
            label2.Size = new Size(65, 21);
            label2.TabIndex = 2;
            label2.Text = "Código";
            label2.Click += label2_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnNuevo, btnCompilar, btnEjecutar });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1268, 25);
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnNuevo
            // 
            btnNuevo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnNuevo.Image = (Image)resources.GetObject("btnNuevo.Image");
            btnNuevo.ImageTransparentColor = Color.Magenta;
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(23, 22);
            btnNuevo.Text = "toolStripButton1";
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnCompilar
            // 
            btnCompilar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnCompilar.Image = (Image)resources.GetObject("btnCompilar.Image");
            btnCompilar.ImageTransparentColor = Color.Magenta;
            btnCompilar.Name = "btnCompilar";
            btnCompilar.Size = new Size(23, 22);
            btnCompilar.Text = "toolStripButton2";
            btnCompilar.Click += btnCompilar_Click;
            // 
            // btnEjecutar
            // 
            btnEjecutar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnEjecutar.Image = (Image)resources.GetObject("btnEjecutar.Image");
            btnEjecutar.ImageTransparentColor = Color.Magenta;
            btnEjecutar.Name = "btnEjecutar";
            btnEjecutar.Size = new Size(23, 22);
            btnEjecutar.Text = "toolStripButton3";
            btnEjecutar.Click += btnEjecutar_Click;
            // 
            // grdLexico
            // 
            grdLexico.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdLexico.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2 });
            grdLexico.Location = new Point(495, 66);
            grdLexico.Name = "grdLexico";
            grdLexico.Size = new Size(281, 457);
            grdLexico.TabIndex = 4;
            // 
            // Column1
            // 
            Column1.HeaderText = "Token";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "Tipo";
            Column2.Name = "Column2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(495, 42);
            label3.Name = "label3";
            label3.Size = new Size(146, 21);
            label3.TabIndex = 5;
            label3.Text = "Analizador Léxico";
            // 
            // grdSintactico
            // 
            grdSintactico.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdSintactico.Columns.AddRange(new DataGridViewColumn[] { Mensaje });
            grdSintactico.Location = new Point(800, 571);
            grdSintactico.Name = "grdSintactico";
            grdSintactico.Size = new Size(456, 354);
            grdSintactico.TabIndex = 6;
            // 
            // Mensaje
            // 
            Mensaje.HeaderText = "Mensaje";
            Mensaje.Name = "Mensaje";
            Mensaje.Width = 300;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(800, 547);
            label4.Name = "label4";
            label4.Size = new Size(173, 21);
            label4.TabIndex = 7;
            label4.Text = "Analizador Sintáctico";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(800, 42);
            label5.Name = "label5";
            label5.Size = new Size(86, 21);
            label5.TabIndex = 9;
            label5.Text = "Resultado";
            // 
            // txtResultado
            // 
            txtResultado.Location = new Point(800, 66);
            txtResultado.Multiline = true;
            txtResultado.Name = "txtResultado";
            txtResultado.ScrollBars = ScrollBars.Vertical;
            txtResultado.Size = new Size(456, 457);
            txtResultado.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.Location = new Point(12, 547);
            label6.Name = "label6";
            label6.Size = new Size(142, 21);
            label6.TabIndex = 11;
            label6.Text = "Tabla de Símbolo";
            // 
            // dgTablaSimbolos
            // 
            dgTablaSimbolos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgTablaSimbolos.Columns.AddRange(new DataGridViewColumn[] { Nombre, Tipo, Valor });
            dgTablaSimbolos.Location = new Point(12, 571);
            dgTablaSimbolos.Name = "dgTablaSimbolos";
            dgTablaSimbolos.Size = new Size(456, 354);
            dgTablaSimbolos.TabIndex = 10;
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.Name = "Nombre";
            // 
            // Tipo
            // 
            Tipo.HeaderText = "Tipo";
            Tipo.Name = "Tipo";
            // 
            // Valor
            // 
            Valor.HeaderText = "Valor";
            Valor.Name = "Valor";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.Location = new Point(474, 547);
            label7.Name = "label7";
            label7.Size = new Size(178, 21);
            label7.TabIndex = 13;
            label7.Text = "Analizador Semántico";
            // 
            // dgSemantico
            // 
            dgSemantico.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgSemantico.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1 });
            dgSemantico.Location = new Point(474, 571);
            dgSemantico.Name = "dgSemantico";
            dgSemantico.Size = new Size(302, 354);
            dgSemantico.TabIndex = 12;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Mensaje";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 300;
            // 
            // MiniCompilador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1268, 956);
            Controls.Add(label7);
            Controls.Add(dgSemantico);
            Controls.Add(label6);
            Controls.Add(dgTablaSimbolos);
            Controls.Add(label5);
            Controls.Add(txtResultado);
            Controls.Add(label4);
            Controls.Add(grdSintactico);
            Controls.Add(label3);
            Controls.Add(grdLexico);
            Controls.Add(toolStrip1);
            Controls.Add(label2);
            Controls.Add(txtCodigo);
            Controls.Add(label1);
            Name = "MiniCompilador";
            Text = "Mini Compilador";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grdLexico).EndInit();
            ((System.ComponentModel.ISupportInitialize)grdSintactico).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgTablaSimbolos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgSemantico).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtCodigo;
        private Label label2;
        private ToolStrip toolStrip1;
        private ToolStripButton btnNuevo;
        private ToolStripButton btnCompilar;
        private ToolStripButton btnEjecutar;
        private DataGridView grdLexico;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private Label label3;
        private DataGridView grdSintactico;
        private Label label4;
        private Label label5;
        private TextBox txtResultado;
        private Label label6;
        private DataGridView dgTablaSimbolos;
        private DataGridViewTextBoxColumn Mensaje;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Tipo;
        private DataGridViewTextBoxColumn Valor;
        private Label label7;
        private DataGridView dgSemantico;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}
