namespace EntidadFinanciera2M6
{
    partial class AgregarCuetasForm
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
            label1 = new Label();
            txtNumCuenta = new TextBox();
            numSaldoInicial = new NumericUpDown();
            btnAceptar = new Button();
            label2 = new Label();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)numSaldoInicial).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 24);
            label1.Name = "label1";
            label1.Size = new Size(113, 20);
            label1.TabIndex = 0;
            label1.Text = "Numero Cuenta";
            // 
            // txtNumCuenta
            // 
            txtNumCuenta.Location = new Point(174, 21);
            txtNumCuenta.Name = "txtNumCuenta";
            txtNumCuenta.Size = new Size(148, 27);
            txtNumCuenta.TabIndex = 1;
            // 
            // numSaldoInicial
            // 
            numSaldoInicial.Location = new Point(173, 78);
            numSaldoInicial.Name = "numSaldoInicial";
            numSaldoInicial.Size = new Size(149, 27);
            numSaldoInicial.TabIndex = 2;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(36, 151);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(116, 37);
            btnAceptar.TabIndex = 3;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 80);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 4;
            label2.Text = "Saldo";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(329, 151);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(116, 37);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // AgregarCuetasForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(601, 205);
            Controls.Add(btnCancelar);
            Controls.Add(label2);
            Controls.Add(btnAceptar);
            Controls.Add(numSaldoInicial);
            Controls.Add(txtNumCuenta);
            Controls.Add(label1);
            Name = "AgregarCuetasForm";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)numSaldoInicial).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNumCuenta;
        private NumericUpDown numSaldoInicial;
        private Button btnAceptar;
        private Label label2;
        private Button btnCancelar;
    }
}