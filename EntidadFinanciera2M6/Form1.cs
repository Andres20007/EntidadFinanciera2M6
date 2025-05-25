using EntidadFinanciera2M6.Data;
using Microsoft.EntityFrameworkCore;
using EntidadFinanciera2M6.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace EntidadFinanciera2M6
{
    /// <summary>
    /// Formulario principal de la aplicación
    /// </summary>
    public partial class Form1 : Form
    {
        private readonly EntidadFinancieraContext _dbContext;
        private const string MensajeSeleccionCliente = "Seleccione un cliente primero";
        private const string MensajeSeleccionCuenta = "Seleccione una cuenta para desactivar";

        public Form1()
        {
            InitializeComponent();
            _dbContext = new EntidadFinancieraContext();
            CargarDatos();
        }

        /// <summary>
        /// Carga los datos iniciales en los DataGridViews
        /// </summary>
        private void CargarDatos()
        {
            try
            {
                var clientes = _dbContext.Clientes
                    .Include(c => c.Cuentas)
                    .ToList();

                var cuentas = _dbContext.Cuentas
                    .Include(c => c.Cliente)
                    .Where(c => c.Activa)
                    .Select(c => new
                    {
                        c.CuentaId,
                        c.NumeroCuenta,
                        c.Saldo,
                        c.Activa,
                        c.ClienteId,
                        c.Cliente.Nombre
                    })
                    .ToList();

                dgvClientes.DataSource = clientes;
                dgvCuentas.DataSource = cuentas;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el botón de agregar cliente
        /// </summary>
        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                using var form = new AgregarClienteForm();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _dbContext.Clientes.Add(form.NuevoCliente);
                    _dbContext.SaveChanges();
                    CargarDatos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el botón de agregar cuenta
        /// </summary>
        private void btnAgregarCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClientes.SelectedRows.Count == 0)
                {
                    MessageBox.Show(MensajeSeleccionCliente, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var clienteId = (int)dgvClientes.SelectedRows[0].Cells["ClienteId"].Value;
                using var form = new AgregarCuetasForm(clienteId);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _dbContext.Cuentas.Add(form.NuevaCuenta);
                    _dbContext.SaveChanges();
                    CargarDatos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar cuenta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el botón de desactivar cuenta
        /// </summary>
        private void btnDesctivarCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCuentas.SelectedRows.Count == 0)
                {
                    MessageBox.Show(MensajeSeleccionCuenta, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var cuentaId = (int)dgvCuentas.SelectedRows[0].Cells["CuentaId"].Value;
                var cuenta = _dbContext.Cuentas.Find(cuentaId);

                if (cuenta != null)
                {
                    cuenta.Activa = false;
                    _dbContext.SaveChanges();
                    CargarDatos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al desactivar cuenta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Realiza una transacción entre cuentas
        /// </summary>
        private void RealizarTransaccion(int origenCuenta, int destinoCuenta, decimal monto)
        {
            using var transaccion = _dbContext.Database.BeginTransaction(System.Data.IsolationLevel.Serializable);
            try
            {
                var cuentaOrigen = _dbContext.Cuentas.FirstOrDefault(c => c.CuentaId == origenCuenta);
                var cuentaDestino = _dbContext.Cuentas.FirstOrDefault(c => c.CuentaId == destinoCuenta);

                if (cuentaOrigen == null || cuentaDestino == null)
                {
                    throw new InvalidOperationException("Una o ambas cuentas no existen");
                }

                if (!cuentaOrigen.Activa || !cuentaDestino.Activa)
                {
                    throw new InvalidOperationException("Una o ambas cuentas están inactivas");
                }

                if (cuentaOrigen.Saldo < monto)
                {
                    throw new InvalidOperationException("Saldo insuficiente en la cuenta origen");
                }

                cuentaOrigen.Saldo -= monto;
                cuentaDestino.Saldo += monto;

                var nuevaTransaccion = new Transaccion
                {
                    Monto = monto,
                    Fecha = DateTime.Now,
                    Tipo = "Transferencia",
                    Descripcion = $"Transferencia de {cuentaOrigen.NumeroCuenta} a {cuentaDestino.NumeroCuenta}",
                    CuentaOrigenId = origenCuenta,
                    CuentaDestinoId = destinoCuenta,
                    CuentaOrigen = cuentaOrigen,
                    CuentaDestino = cuentaDestino
                };

                _dbContext.Transacciones.Add(nuevaTransaccion);
                _dbContext.SaveChanges();
                transaccion.Commit();
            }
            catch (Exception)
            {
                transaccion.Rollback();
                throw;
            }
        }

        private void btnTransferencia_Click(object sender, EventArgs e)
        {
            if (dgvCuentas.SelectedRows.Count != 2)
            {
                MessageBox.Show("Seleccione exactamente 2 cuentas");
                return;
            }
            else
            {
                var cuentaOrigenId = (int)dgvCuentas.SelectedRows[0].Cells["CuentaId"].Value;
                var cuentaDestinoId = (int)dgvCuentas.SelectedRows[1].Cells["CuentaId"].Value;

                var form = new TransferenciaForms(cuentaOrigenId, cuentaDestinoId);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    RealizarTransaccion(cuentaOrigenId, cuentaDestinoId, form.Monto);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new Form2();
            form.ShowDialog();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _dbContext?.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
