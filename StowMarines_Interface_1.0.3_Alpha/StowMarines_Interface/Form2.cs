﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StowMarines_Interface
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void testButton2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Close();
            form.Show();
        }
    }
}