using System;
using System.Windows.Forms;
using EntidadFinanciera2M6.Models;

namespace EntidadFinanciera2M6
{
    /// <summary>
    /// Formulario para agregar una nueva cuenta
    /// </summary>
    public partial class AgregarCuetasForm : Form
    {
        private const string MensajeCamposRequeridos = "Por favor complete todos los campos";
        private const string MensajeNumeroCuentaDuplicado = "Ya existe una cuenta con este número";
        private const string MensajeSaldoInvalido = "El saldo inicial debe ser mayor o igual a 0";

        private readonly int _clienteId;

        /// <summary>
        /// Obtiene la nueva cuenta creada
        /// </summary>
        public Cuenta NuevaCuenta { get; private set; }

        /// <summary>
        /// Constructor del formulario
        /// </summary>
        /// <param name="clienteId">ID del cliente al que se le asignará la cuenta</param>
        public AgregarCuetasForm(int clienteId)
        {
            InitializeComponent();
            _clienteId = clienteId;
        }

        /// <summary>
        /// Maneja el evento de clic en el botón de guardar
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNumCuenta.Text))
                {
                    MessageBox.Show(MensajeCamposRequeridos, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal saldo = numSaldoInicial.Value;
                if (saldo < 0)
                {
                    MessageBox.Show(MensajeSaldoInvalido, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                NuevaCuenta = new Cuenta
                {
                    NumeroCuenta = txtNumCuenta.Text.Trim(),
                    Saldo = saldo,
                    Activa = true,
                    ClienteId = _clienteId
                };

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la cuenta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el botón de cancelar
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Valida que solo se ingresen números y un punto decimal en el campo de saldo
        /// </summary>
        private void txtSaldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Solo permitir un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }
}

