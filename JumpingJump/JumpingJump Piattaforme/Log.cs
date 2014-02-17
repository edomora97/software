using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using JumpingJump.Classi;

namespace JumpingJump.Piattaforme
{
    public partial class Log : Form
    {
        public Log()
        {
            InitializeComponent();
        }  
        delegate void AddItemToListBox(string text);
        public void AddItem(string text)
        {
            if (lbLog.InvokeRequired)
            {
                AddItemToListBox d = new AddItemToListBox(AddItem);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                lbLog.Items.Add(Helper.DateTimeToString(DateTime.Now) + "\t\t" + text);
                lbLog.SelectedIndex = lbLog.Items.Count - 1;
                lbLog.SelectedIndex = -1;
            }
        }
        public void AddItemWithoutTime(string text)
        {
            if (lbLog.InvokeRequired)
            {
                AddItemToListBox d = new AddItemToListBox(AddItemWithoutTime);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                lbLog.Items.Add(text);
                lbLog.SelectedIndex = lbLog.Items.Count - 1;
                lbLog.SelectedIndex = -1;
            }
        }


        delegate void ExitDelegate();
        public void Exit()
        {
            if (this.InvokeRequired)
            {
                ExitDelegate d = new ExitDelegate(Exit);
                this.Invoke(d);
            }
            else
                this.Close();
        }

        private void Log_FormClosing(object sender, FormClosingEventArgs e)
        {
            StreamWriter stream = new StreamWriter(File.Create("log.txt"));
            stream.WriteLine("File di log dell'applicazione JumpingJump - Piattaforme");
            stream.WriteLine("File creato il {0} alle ore {1}", DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString(), DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);
            stream.WriteLine();
            stream.WriteLine();
            foreach (object item in lbLog.Items)
            {
                stream.WriteLine(item.ToString());
            }
            stream.Close();
        }
    }
}
