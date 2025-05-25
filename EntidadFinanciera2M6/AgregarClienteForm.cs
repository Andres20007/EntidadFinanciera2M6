using System;
using System.Windows.Forms;
using EntidadFinanciera2M6.Models;

namespace EntidadFinanciera2M6
{
    /// <summary>
    /// Formulario para agregar un nuevo cliente
    /// </summary>
    public partial class AgregarClienteForm : Form
    {
        private const string MensajeCamposRequeridos = "Por favor complete todos los campos";
        private const string MensajeIdentificacionDuplicada = "Ya existe un cliente con esta identificación";

        /// <summary>
        /// Obtiene el nuevo cliente creado
        /// </summary>
        public Cliente NuevoCliente { get; private set; }

        public AgregarClienteForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Maneja el evento de clic en el botón de guardar
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtIdentificacion.Text))
                {
                    MessageBox.Show(MensajeCamposRequeridos, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                NuevoCliente = new Cliente
                {
                    Nombre = txtNombre.Text.Trim(),
                    Identificacion = txtIdentificacion.Text.Trim()
                };

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// Valida que solo se ingresen números en el campo de identificación
        /// </summary>
        private void txtIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
