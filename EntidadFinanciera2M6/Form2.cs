﻿using EntidadFinanciera2M6.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntidadFinanciera2M6
{

    public partial class Form2 : Form
    {
        private EntidadFinancieraContext ef = new EntidadFinancieraContext();
        public Form2()
        {
            InitializeComponent();
            Cargar();
        }

        private void Cargar()
        {
            dataGridView1.DataSource = ef.Transacciones.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
