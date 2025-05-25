using EntidadFinanciera2M6.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Forms;

namespace EntidadFinanciera2M6
{
    public partial class TransferenciaForms : Form
    {
        public decimal Monto { get; set; }
        private int _cuentaOrignId;
        private int _cuentaDestinoId;
        private EntidadFinancieraContext _Ef;
        public TransferenciaForms(int cuentaOrigenId, int cuentaDestinoId)
        {
            _cuentaOrignId = cuentaOrigenId;
            _cuentaDestinoId = cuentaDestinoId;
            _Ef = new EntidadFinancieraContext();
            InitializeComponent();
            CargarCuentas();
        }
        private void CargarCuentas()
        {
            var cuentaOrigen = _Ef.Cuentas.
                Include(c => c.Cliente).
                First(c => c.CuentaId == _cuentaOrignId);

            var cuentaDestino = _Ef.Cuentas.
                Include(c => c.Cliente).
                First(c => c.CuentaId == _cuentaDestinoId);

            lblCuentaOrigen.Text = $"Cuenta Origen: {cuentaOrigen.Cliente.Nombre} - {cuentaOrigen.NumeroCuenta}";
            lblCuentaDestino.Text = $"Cuenta Destino: {cuentaDestino.Cliente.Nombre} - {cuentaDestino.NumeroCuenta}";
            lblSaldo.Text = $"Saldo Disponible {cuentaOrigen.Saldo:c}";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (numMonto.Value > 0)
            {
                Monto = numMonto.Value;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("El monto tiene que ser mayor a 0");
            }
        }
    }
}
