namespace TP4.Forms
{
    partial class Euler
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
            this.dgvEuler = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSegundoPico = new System.Windows.Forms.Label();
            this.btnGraficar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEuler)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEuler
            // 
            this.dgvEuler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEuler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvEuler.Location = new System.Drawing.Point(12, 42);
            this.dgvEuler.Name = "dgvEuler";
            this.dgvEuler.Size = new System.Drawing.Size(445, 396);
            this.dgvEuler.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "t";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "X1";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "X2";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "DX2";
            this.Column4.Name = "Column4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Segundo Pico";
            // 
            // lblSegundoPico
            // 
            this.lblSegundoPico.AutoSize = true;
            this.lblSegundoPico.Location = new System.Drawing.Point(94, 13);
            this.lblSegundoPico.Name = "lblSegundoPico";
            this.lblSegundoPico.Size = new System.Drawing.Size(13, 13);
            this.lblSegundoPico.TabIndex = 3;
            this.lblSegundoPico.Text = "0";
            // 
            // btnGraficar
            // 
            this.btnGraficar.Location = new System.Drawing.Point(380, 444);
            this.btnGraficar.Name = "btnGraficar";
            this.btnGraficar.Size = new System.Drawing.Size(75, 23);
            this.btnGraficar.TabIndex = 4;
            this.btnGraficar.Text = "Graficar";
            this.btnGraficar.UseVisualStyleBackColor = true;
            this.btnGraficar.Click += new System.EventHandler(this.btnGraficar_Click);
            // 
            // Euler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 471);
            this.Controls.Add(this.btnGraficar);
            this.Controls.Add(this.lblSegundoPico);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvEuler);
            this.Name = "Euler";
            this.Text = "Euler";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEuler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEuler;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSegundoPico;
        private System.Windows.Forms.Button btnGraficar;
    }
}