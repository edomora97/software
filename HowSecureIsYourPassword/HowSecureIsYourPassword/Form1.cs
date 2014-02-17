using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Numerics;

namespace HowSecureIsYourPassword
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password = tbPassword.Text;

            PasswordManager pm = new PasswordManager(password);
            lblRes.Text = pm.CalcTotalTime((BigInteger)numericUpDown1.Value);
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }
    }
}
