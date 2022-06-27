namespace TP4.Forms
{
    partial class PantallaRK
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
            this.dgvRK = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGraficar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSegundoPico = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRK)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRK
            // 
            this.dgvRK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRK.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12});
            this.dgvRK.Location = new System.Drawing.Point(7, 28);
            this.dgvRK.Name = "dgvRK";
            this.dgvRK.Size = new System.Drawing.Size(1243, 474);
            this.dgvRK.TabIndex = 1;
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
            this.Column3.HeaderText = "K1";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "K2";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "K3";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "K4";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "X2";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "L1";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "L2";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "L3";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "L4";
            this.Column11.Name = "Column11";
            // 
            // Column12
            // 
            this.Column12.HeaderText = "DX2";
            this.Column12.Name = "Column12";
            // 
            // btnGraficar
            // 
            this.btnGraficar.Location = new System.Drawing.Point(1152, 528);
            this.btnGraficar.Name = "btnGraficar";
            this.btnGraficar.Size = new System.Drawing.Size(98, 32);
            this.btnGraficar.TabIndex = 2;
            this.btnGraficar.Text = "Graficos";
            this.btnGraficar.UseVisualStyleBackColor = true;
            this.btnGraficar.Click += new System.EventHandler(this.btnGraficar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Segundo Pico:";
            // 
            // lblSegundoPico
            // 
            this.lblSegundoPico.AutoSize = true;
            this.lblSegundoPico.Location = new System.Drawing.Point(96, 9);
            this.lblSegundoPico.Name = "lblSegundoPico";
            this.lblSegundoPico.Size = new System.Drawing.Size(13, 13);
            this.lblSegundoPico.TabIndex = 4;
            this.lblSegundoPico.Text = "0";
            // 
            // PantallaRK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 565);
            this.Controls.Add(this.lblSegundoPico);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGraficar);
            this.Controls.Add(this.dgvRK);
            this.Name = "PantallaRK";
            this.Text = "RK";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRK;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.Button btnGraficar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSegundoPico;
    }
}