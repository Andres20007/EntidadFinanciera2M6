namespace EntidadFinanciera2M6
{
    partial class TransferenciaForms
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
            lblCuentaOrigen = new Label();
            btnAceptar = new Button();
            numMonto = new NumericUpDown();
            lblSaldo = new Label();
            lblCuentaDestino = new Label();
            btnCancelar = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)numMonto).BeginInit();
            SuspendLayout();
            // 
            // lblCuentaOrigen
            // 
            lblCuentaOrigen.AutoSize = true;
            lblCuentaOrigen.Location = new Point(13, 26);
            lblCuentaOrigen.Name = "lblCuentaOrigen";
            lblCuentaOrigen.Size = new Size(50, 20);
            lblCuentaOrigen.TabIndex = 0;
            lblCuentaOrigen.Text = "label1";
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(22, 189);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(104, 38);
            btnAceptar.TabIndex = 1;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // numMonto
            // 
            numMonto.Location = new Point(242, 69);
            numMonto.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numMonto.Name = "numMonto";
            numMonto.Size = new Size(105, 27);
            numMonto.TabIndex = 2;
            // 
            // lblSaldo
            // 
            lblSaldo.AutoSize = true;
            lblSaldo.Location = new Point(13, 71);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new Size(50, 20);
            lblSaldo.TabIndex = 3;
            lblSaldo.Text = "label2";
            // 
            // lblCuentaDestino
            // 
            lblCuentaDestino.AutoSize = true;
            lblCuentaDestino.Location = new Point(13, 119);
            lblCuentaDestino.Name = "lblCuentaDestino";
            lblCuentaDestino.Size = new Size(50, 20);
            lblCuentaDestino.TabIndex = 4;
            lblCuentaDestino.Text = "label3";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(367, 189);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(86, 38);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(367, 76);
            label1.Name = "label1";
            label1.Size = new Size(130, 20);
            label1.TabIndex = 6;
            label1.Text = "Monto a Transferir";
            // 
            // TransferenciaForms
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(518, 258);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(lblCuentaDestino);
            Controls.Add(lblSaldo);
            Controls.Add(numMonto);
            Controls.Add(btnAceptar);
            Controls.Add(lblCuentaOrigen);
            Name = "TransferenciaForms";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)numMonto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCuentaOrigen;
        private Button btnAceptar;
        private NumericUpDown numMonto;
        private Label lblSaldo;
        private Label lblCuentaDestino;
        private Button btnCancelar;
        private Label label1;
    }
}