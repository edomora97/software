using System;
using System.Windows.Forms;
using Ini;
using System.IO.Ports;

namespace Parametri_in_MODBUS
{
    public partial class Opzioni : Form
    {
        #region Variabili e chiamate
        // Variabili defoult
        private string Porta_D = "COM11";
        private string Baud_D = "9600";
        private string Bits_D = "8";
        private string StopBits_D = "One";
        private string Parity_D = "None"; 
        private string ReadTimeout_D = "1000";
        private string WriteTimeout_D = "1000";
        
        private string Loop_D = "15";
        private string Ritardo_D = "2000";

        private string Formato_D = "xls";
        private string Nome_D = "Data";
        // Variabili
        public string Porta;
        public string Baud;
        public string Bits;
        public string StopBits;
        public string Parity;
        public string ReadTimeout;
        public string WriteTimeout;

        public string Loop;
        public string Ritardo;

        public string Formato;
        public string Nome;
        public bool firstOpen = true;
        // Chiamate
        Funzioni funzioni = new Funzioni();
        IniFile ini = new IniFile();

        #endregion
        public Opzioni()
        {
            InitializeComponent();
        }
        private void Opzioni_Load(object sender, EventArgs e)
        {
            if (firstOpen == true)
            {
                if (ini.IniReadValue("Settings", "FirstOpen") != "false")
                {
                    string Sezione;
                    Sezione = "SerialPort";
                    ini.IniWriteValue(Sezione, "Porta", Porta_D);
                    ini.IniWriteValue(Sezione, "Baud", Baud_D);
                    ini.IniWriteValue(Sezione, "Bits", Bits_D);
                    ini.IniWriteValue(Sezione, "StopBits", StopBits_D);
                    ini.IniWriteValue(Sezione, "Parity", Parity_D);
                    ini.IniWriteValue(Sezione, "ReadTimeout", ReadTimeout_D);
                    ini.IniWriteValue(Sezione, "WriteTimeout", WriteTimeout_D);
                    Sezione = "Loop";
                    ini.IniWriteValue(Sezione, "Loop", Loop_D);
                    ini.IniWriteValue(Sezione, "Ritardo", Ritardo_D);
                    Sezione = "Save";
                    ini.IniWriteValue(Sezione, "Formato", Formato_D);
                    ini.IniWriteValue(Sezione, "Nome", Nome_D);
                    Sezione = "Settings";
                    ini.IniWriteValue(Sezione, "FirstOpen", "false");
                }
                Porta = ini.IniReadValue("SerialPort", "Porta").ToString();
                Baud = ini.IniReadValue("SerialPort", "Baud").ToString();
                Bits = ini.IniReadValue("SerialPort", "Bits").ToString();
                StopBits = ini.IniReadValue("SerialPort", "StopBits").ToString();
                Parity = ini.IniReadValue("SerialPort", "Parity").ToString();
                ReadTimeout = ini.IniReadValue("SerialPort", "ReadTimeout").ToString();
                WriteTimeout = ini.IniReadValue("SerialPort", "WriteTimeout").ToString();
                Loop = ini.IniReadValue("Loop", "Loop").ToString();
                Ritardo = ini.IniReadValue("Loop", "Ritardo").ToString();
                Formato = ini.IniReadValue("Save", "Formato").ToString();
                Nome = ini.IniReadValue("Save", "Nome").ToString();

                this.cbPorta.Text = Porta;
                this.cbBaud.Text = Baud;
                this.cbBits.Text = Bits;
                this.cbStopBits.Text = StopBits;
                this.cbParity.Text = Parity;
                this.tbReadTimeout.Text = ReadTimeout;
                this.tbWriteTimeout.Text = WriteTimeout;
                this.tbLoop.Text = Loop;
                this.tbRitardo.Text = Ritardo;
                this.tbNome.Text = Nome;
                if (Formato == "xls")
                {
                    this.rbXls.Checked = true;
                }
                if (Formato == "xlsx")
                {
                    this.rbXlsx.Checked = true;
                }
                if (Formato == "ods")
                {
                    this.rbOds.Checked = true;
                }
                if (Formato == "csv")
                {
                    this.rbCsv.Checked = true;
                }
                if (Formato == "html")
                {
                    this.rbHtlm.Checked = true;
                }
                if (Formato == "none")
                {
                    this.rbNone.Checked = true;
                }
                foreach (string port in SerialPort.GetPortNames())
                {
                    cbPorta.Items.Add(port);
                }
                {
                    cbBaud.Items.Add("300");
                    cbBaud.Items.Add("1200");
                    cbBaud.Items.Add("2400");
                    cbBaud.Items.Add("4800");
                    cbBaud.Items.Add("9600");
                    cbBaud.Items.Add("14400");
                    cbBaud.Items.Add("28800");
                    cbBaud.Items.Add("36000");
                    cbBaud.Items.Add("115000");
                }
                {
                    cbBits.Items.Add("7");
                    cbBits.Items.Add("8");
                    cbBits.Items.Add("9");
                }
                foreach (string sBits in Enum.GetNames(typeof(StopBits)))
                {
                    cbStopBits.Items.Add(sBits);
                }  
                foreach (string parity in Enum.GetNames(typeof(Parity)))
                {
                    cbParity.Items.Add(parity);
                }                               
            }
        }

        private void btnApplica_Click(object sender, EventArgs e)
        {
            Porta = this.cbPorta.Text;
            Baud = this.cbBaud.Text;
            Bits = this.cbBits.Text;
            StopBits = this.cbStopBits.Text;
            Parity = this.cbParity.Text;
            ReadTimeout = this.tbReadTimeout.Text;
            WriteTimeout = this.tbWriteTimeout.Text;
            Loop = this.tbLoop.Text;
            Ritardo = this.tbRitardo.Text;
            Nome = this.tbNome.Text;
            if (this.rbXls.Checked == true)
            {
                Formato = "xls";
            }
            if (this.rbXlsx.Checked == true)
            {
                Formato = "xlsx";
            }
            if (this.rbOds.Checked == true)
            {
                Formato = "ods";
            }
            if (this.rbCsv.Checked == true)
            {
                Formato = "csv";
            }
            if (this.rbHtlm.Checked == true)
	        {
		        Formato = "html";
	        }
            if (this.rbNone.Checked == true)
            {
                Formato = "none";
            }
            string Sezione;
            Sezione = "SerialPort";
            ini.IniWriteValue(Sezione, "Porta", Porta);
            ini.IniWriteValue(Sezione, "Baud", Baud);
            ini.IniWriteValue(Sezione, "Bits", Bits);
            ini.IniWriteValue(Sezione, "StopBits", StopBits);
            ini.IniWriteValue(Sezione, "Parity", Parity);
            ini.IniWriteValue(Sezione, "ReadTimeout", ReadTimeout);
            ini.IniWriteValue(Sezione, "WriteTimeout", WriteTimeout);
            Sezione = "Loop";
            ini.IniWriteValue(Sezione, "Loop", Loop);
            ini.IniWriteValue(Sezione, "Ritardo", Ritardo);
            Sezione = "Save";
            ini.IniWriteValue(Sezione, "Formato", Formato);
            ini.IniWriteValue(Sezione, "Nome", Nome);
            this.Close();
        }

        private void btnDefoult_Click(object sender, EventArgs e)
        {
            string Sezione;
            Sezione = "SerialPort";
            ini.IniWriteValue(Sezione, "Porta", Porta_D);
            ini.IniWriteValue(Sezione, "Baud", Baud_D);
            ini.IniWriteValue(Sezione, "Bits", Bits_D);
            ini.IniWriteValue(Sezione, "StopBits", StopBits_D);
            ini.IniWriteValue(Sezione, "Parity", Parity_D);
            ini.IniWriteValue(Sezione, "ReadTimeout", ReadTimeout_D);
            ini.IniWriteValue(Sezione, "WriteTimeout", WriteTimeout_D);
            Sezione = "Loop";
            ini.IniWriteValue(Sezione, "Loop", Loop_D);
            ini.IniWriteValue(Sezione, "Ritardo", Ritardo_D);
            Sezione = "Save";
            ini.IniWriteValue(Sezione, "Formato", Formato_D);
            ini.IniWriteValue(Sezione, "Nome", Nome_D);
            Sezione = "Settings";
            ini.IniWriteValue(Sezione, "FirstOpen", "false");
            Porta = ini.IniReadValue("SerialPort", "Porta").ToString();
            Baud = ini.IniReadValue("SerialPort", "Baud").ToString();
            Bits = ini.IniReadValue("SerialPort", "Bits").ToString();
            StopBits = ini.IniReadValue("SerialPort", "StopBits").ToString();
            Parity = ini.IniReadValue("SerialPort", "Parity").ToString();
            ReadTimeout = ini.IniReadValue("SerialPort", "ReadTimeout").ToString();
            WriteTimeout = ini.IniReadValue("SerialPort", "WriteTimeout").ToString();
            Loop = ini.IniReadValue("Loop", "Loop").ToString();
            Ritardo = ini.IniReadValue("Loop", "Ritardo").ToString();
            Formato = ini.IniReadValue("Save", "Formato").ToString();

            this.cbPorta.Text = Porta;
            this.cbBaud.Text = Baud;
            this.cbBits.Text = Bits;
            this.cbStopBits.Text = StopBits;
            this.cbParity.Text = Parity;
            this.tbReadTimeout.Text = ReadTimeout;
            this.tbWriteTimeout.Text = WriteTimeout;
            this.tbLoop.Text = Loop;
            this.tbRitardo.Text = Ritardo;
            if (Formato == "xls")
            {
                this.rbXls.Checked = true;
            }
            if (Formato == "xlsx")
            {
                this.rbXlsx.Checked = true;
            }
            if (Formato == "ods")
            {
                this.rbOds.Checked = true;
            }
            if (Formato == "csv")
            {
                this.rbCsv.Checked = true;
            }
            if (Formato == "html")
            {
                this.rbHtlm.Checked = true;
            }
        }
    }
}
