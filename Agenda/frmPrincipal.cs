﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Agenda
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btContato_Click(object sender, EventArgs e)
        {
            frmCadastroContato f = new frmCadastroContato();
            f.ShowDialog();
            f.Dispose();
        }
    }
}
