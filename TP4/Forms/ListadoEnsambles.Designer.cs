namespace TP4.Forms
{
    partial class ListadoEnsambles
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
            this.dvgEnsambles = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPorc = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEnsamblesPorHora = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dvgEnsambles)).BeginInit();
            this.SuspendLayout();
            // 
            // dvgEnsambles
            // 
            this.dvgEnsambles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgEnsambles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6,
            this.Column5});
            this.dvgEnsambles.Location = new System.Drawing.Point(12, 25);
            this.dvgEnsambles.Name = "dvgEnsambles";
            this.dvgEnsambles.Size = new System.Drawing.Size(586, 373);
            this.dvgEnsambles.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Id Ensamble";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Entrada";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Salida";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Tiempo De Ensamble";
            this.Column4.Name = "Column4";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "AC Tiempo Ensamble";
            this.Column6.Name = "Column6";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Promedio Ensamble";
            this.Column5.Name = "Column5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(357, 438);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tiene Una Probabilidad de: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblPorc
            // 
            this.lblPorc.AutoSize = true;
            this.lblPorc.Location = new System.Drawing.Point(502, 438);
            this.lblPorc.Name = "lblPorc";
            this.lblPorc.Size = new System.Drawing.Size(13, 13);
            this.lblPorc.TabIndex = 2;
            this.lblPorc.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 413);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cantidad Ensambles por Hora:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblEnsamblesPorHora
            // 
            this.lblEnsamblesPorHora.AutoSize = true;
            this.lblEnsamblesPorHora.Location = new System.Drawing.Point(169, 413);
            this.lblEnsamblesPorHora.Name = "lblEnsamblesPorHora";
            this.lblEnsamblesPorHora.Size = new System.Drawing.Size(35, 13);
            this.lblEnsamblesPorHora.TabIndex = 4;
            this.lblEnsamblesPorHora.Text = "label3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 438);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(253, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cantidad para la probabilidad de hacerlos en 1 hora:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(271, 435);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(64, 20);
            this.txtCantidad.TabIndex = 6;
            this.txtCantidad.TextChanged += new System.EventHandler(this.CalcularProbabilidad);
            // 
            // ListadoEnsambles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 516);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblEnsamblesPorHora);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPorc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dvgEnsambles);
            this.Name = "ListadoEnsambles";
            this.Text = "ListadoEnsambles";
            ((System.ComponentModel.ISupportInitialize)(this.dvgEnsambles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgEnsambles;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPorc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblEnsamblesPorHora;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCantidad;
    }
}