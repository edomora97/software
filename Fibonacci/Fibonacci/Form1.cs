using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Numerics;

namespace Fibonacci
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch st = new System.Diagnostics.Stopwatch();
            st.Start();
            BigInteger num = new BigInteger();
            listBox1.Items.Clear();
            List<BigInteger> fibonacci = new List<BigInteger>();
            fibonacci.Add(0);
            listBox1.Items.Add(0);
            fibonacci.Add(1);
            listBox1.Items.Add(1);
            for (int i = 0; i < 10000; i++)
            {
                num = fibonacci[i] + fibonacci[i + 1];
                fibonacci.Add(num);
                listBox1.Items.Add((i+1).ToString() + ". " + num.ToString());
                //listBox1.SelectedIndex = i + 2;
            }
            st.Stop();
            MessageBox.Show("Tempo impiegato: " + st.Elapsed.ToString() + "\nL'ultimo numero ha " + fibonacci[10000].ToString().Length.ToString() + " cifre");
        }
    }
}
