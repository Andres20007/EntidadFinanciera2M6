namespace EntidadFinanciera2M6
{
    partial class Form1
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
            btnAgregarCliente = new Button();
            dgvClientes = new DataGridView();
            dgvCuentas = new DataGridView();
            btnAgregarCuenta = new Button();
            btnDesctivarCuenta = new Button();
            btnTransferencia = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCuentas).BeginInit();
            SuspendLayout();
            // 
            // btnAgregarCliente
            // 
            btnAgregarCliente.Location = new Point(31, 374);
            btnAgregarCliente.Name = "btnAgregarCliente";
            btnAgregarCliente.Size = new Size(121, 39);
            btnAgregarCliente.TabIndex = 0;
            btnAgregarCliente.Text = "AgregarCliente";
            btnAgregarCliente.UseVisualStyleBackColor = true;
            btnAgregarCliente.Click += btnAgregarCliente_Click;
            // 
            // dgvClientes
            // 
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(31, 13);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.RowHeadersWidth = 51;
            dgvClientes.Size = new Size(438, 328);
            dgvClientes.TabIndex = 1;
            // 
            // dgvCuentas
            // 
            dgvCuentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCuentas.Location = new Point(500, 13);
            dgvCuentas.Name = "dgvCuentas";
            dgvCuentas.RowHeadersWidth = 51;
            dgvCuentas.Size = new Size(438, 328);
            dgvCuentas.TabIndex = 2;
            // 
            // btnAgregarCuenta
            // 
            btnAgregarCuenta.Location = new Point(500, 363);
            btnAgregarCuenta.Name = "btnAgregarCuenta";
            btnAgregarCuenta.Size = new Size(121, 39);
            btnAgregarCuenta.TabIndex = 3;
            btnAgregarCuenta.Text = "Agregar Cuenta";
            btnAgregarCuenta.UseVisualStyleBackColor = true;
            btnAgregarCuenta.Click += btnAgregarCuenta_Click;
            // 
            // btnDesctivarCuenta
            // 
            btnDesctivarCuenta.Location = new Point(662, 363);
            btnDesctivarCuenta.Name = "btnDesctivarCuenta";
            btnDesctivarCuenta.Size = new Size(177, 39);
            btnDesctivarCuenta.TabIndex = 4;
            btnDesctivarCuenta.Text = "Desactivar Cuenta";
            btnDesctivarCuenta.UseVisualStyleBackColor = true;
            btnDesctivarCuenta.Click += btnDesctivarCuenta_Click;
            // 
            // btnTransferencia
            // 
            btnTransferencia.Location = new Point(500, 408);
            btnTransferencia.Name = "btnTransferencia";
            btnTransferencia.Size = new Size(121, 39);
            btnTransferencia.TabIndex = 5;
            btnTransferencia.Text = "Transferir";
            btnTransferencia.UseVisualStyleBackColor = true;
            btnTransferencia.Click += btnTransferencia_Click;
            // 
            // button1
            // 
            button1.Location = new Point(671, 408);
            button1.Name = "button1";
            button1.Size = new Size(153, 39);
            button1.TabIndex = 6;
            button1.Text = "Ver Trasnferencias";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(916, 450);
            Controls.Add(button1);
            Controls.Add(btnTransferencia);
            Controls.Add(btnDesctivarCuenta);
            Controls.Add(btnAgregarCuenta);
            Controls.Add(dgvCuentas);
            Controls.Add(dgvClientes);
            Controls.Add(btnAgregarCliente);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCuentas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnAgregarCliente;
        private DataGridView dgvClientes;
        private DataGridView dgvCuentas;
        private Button btnAgregarCuenta;
        private Button btnDesctivarCuenta;
        private Button btnTransferencia;
        private Button button1;
    }
}
