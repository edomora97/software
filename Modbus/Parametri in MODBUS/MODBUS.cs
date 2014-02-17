using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.IO.Ports;
using GemBox.Spreadsheet;
using Ini;

namespace Parametri_in_MODBUS
{
    public partial class MODBUS : Form
    {
        #region Variabili e chiamate
        //----CHIAMTE-----
        Funzioni funzioni = new Funzioni();                                             // riferimento al file delle funzioni
        IniFile ini = new IniFile();                                                    // riferimento al file delle funzioni INI
        Opzioni opzioni = new Opzioni();                                                // riferimento al file delle opzioni
        //----VARIABILI---
        int indirizzo;                                                                  // Variabile indirizzo del dispositivo
        int funzione;                                                                   // Variabile funzione 03/06 = Lettura/Scrittura
        int valore;                                                                     // Variabile valore (permette virgola)
        int count = 0;                                                                  // Variabile conteggio del loop
        string DatiRx = "";                                                             // Variabile contenente dati ricevuti
        #endregion
        public MODBUS()
        {
            InitializeComponent();
        }
        private void MODBUS_Load(object sender, EventArgs e)
        {
            funzioni.NewSheet();                                                        // Crea un foglio di Excel
        }
        #region Pulsanti

        private void btnCalcolaEInvia_Click(object sender, EventArgs e)
        {
            try
            {

                calcolaToolStripMenuItem_Click(sender, e);
                if (portaSeriale.IsOpen == false)                                           // Si verifica se la porta seriale non è aperta
                {
                    this.portaSeriale.PortName = ini.IniReadValue("SerialPort", "Porta");
                    this.portaSeriale.BaudRate = int.Parse(ini.IniReadValue("SerialPort", "Baud"));
                    this.portaSeriale.DataBits = int.Parse(ini.IniReadValue("SerialPort", "Bits"));
                    this.portaSeriale.StopBits = (StopBits)Enum.Parse(typeof(StopBits), ini.IniReadValue("SerialPort", "StopBits"));
                    this.portaSeriale.Parity = (Parity)Enum.Parse(typeof(Parity), ini.IniReadValue("SerialPort", "Parity"));
                    this.portaSeriale.ReadTimeout = int.Parse(ini.IniReadValue("SerialPort", "ReadTimeout"));
                    this.portaSeriale.WriteTimeout = int.Parse(ini.IniReadValue("SerialPort", "WriteTimeout"));
                    portaSeriale.Open();                                                    // Apre la porta seriale
                }
                portaSeriale.Write(this.tbCalcolated.Text + "\r\n");                        // Invia il testo con il CR-LF
                int data = 0;                                                               // Variabile data = 0
                if (this.lblData.Text != "-")                                               // Si verifica se il testo del data è diverso da "-"
                {
                    data = int.Parse(this.lblData.Text);                                    // Converte il testo di data in int
                }
                string ora = System.DateTime.Now.ToString("HH:mm.ss");                      // Variabile contenente l'ora
                if (indirizzo != 0 || funzione != 0)                                        // Si verifica se 'indirizzo o la funzione sono diversi da 0
                {
                    funzioni.FileXLS(indirizzo, funzione, valore, data, ora);               // Genera il file XLS
                }
                timerData.Start();                                                          // Avvia il timer della ricezione
            }
            catch
            { }
        }

        private void opzioniToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            try
            {
                opzioni.ShowDialog();
                opzioni.firstOpen = false;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
        }
        private void calcolaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (portaSeriale.IsOpen == false)
            {
                this.portaSeriale.PortName = ini.IniReadValue("SerialPort", "Porta");
                this.portaSeriale.BaudRate = int.Parse(ini.IniReadValue("SerialPort", "Baud"));
                this.portaSeriale.DataBits = int.Parse(ini.IniReadValue("SerialPort", "Bits"));
                this.portaSeriale.StopBits = (StopBits)Enum.Parse(typeof(StopBits), ini.IniReadValue("SerialPort", "StopBits"));
                this.portaSeriale.Parity = (Parity)Enum.Parse(typeof(Parity), ini.IniReadValue("SerialPort", "Parity"));
                this.portaSeriale.ReadTimeout = int.Parse(ini.IniReadValue("SerialPort", "ReadTimeout"));
                this.portaSeriale.WriteTimeout = int.Parse(ini.IniReadValue("SerialPort", "WriteTimeout"));
            }

            int indDec = int.Parse(this.tbIndirizzo.Text);                              // Converte l'indirizzo in int
            int funzioneDec = int.Parse(this.cbFunzione.Text);                          // Converte la funzione in int
            int indStartDec = int.Parse(this.tbStart.Text);                             // Converte l'indirizzo di partenza in int
            int valoreDec;                                                              // Variabile con il valore in scrittura
            if (this.tbValore.Enabled == true && this.tbValore.Text != "")              // Si verifica se la tb del valore è abilitata e non è vuota
            {
                valoreDec = int.Parse(this.tbValore.Text);                              // Converte il valore in int
            }
            else                                                                        // Si verifica se la tb del valore è disabilitata e/o è vuota
            {
                valoreDec = 0;                                                          // Il valore è 0
            }
            funzioni.CalcoloLRCTx(indDec, funzioneDec, indStartDec, valoreDec);         // Richiama la funzione per il calcolo dell'LRC
            string LRCTx = funzioni.LRCTx;                                              // Variabile contenente l'LRC
            if (this.cbFunzione.Text == "03")                                           // Si verifica se la funzione è 03 (Lettura)
            {
                this.tbCalcolated.Text = ":" +                                              // Il testo della tb è la stringa da inviare al dispositivo, iniz. stringa con :
                    funzioni.indHex.ToString() +                                            // L'indirizzo del dispositivo
                    funzioni.funzioneHex.ToString() +                                       // La funzione (03)
                    funzioni.indStartHex1.ToString() + funzioni.indStartHex2.ToString() +   // Indirizzo di start (8+8bit)
                    "0001" +                                                                // La quantità di dati
                    LRCTx.ToString() +                                                      // L'LRC
                    "\r\n";                                                                 // Il CR-LF
            }
            if (this.cbFunzione.Text == "06")                                           // Si verifica se la funzione è 06 (Scrittura)
            {
                this.tbCalcolated.Text = ":" +                                          // Il testo della tb è la stringa da inviare al dispositivo, iniz. stringa con :
                funzioni.indHex.ToString() +                                            // L'indirizzo del dispositivo
                funzioni.funzioneHex.ToString() +                                       // La funzione (06)
                funzioni.indStartHex1.ToString() + funzioni.indStartHex2.ToString() +   // Indirizzo di start (8+8bit)
                funzioni.valoreHex1.ToString() + funzioni.valoreHex2.ToString() +       // Il valore (8+8bit)
                LRCTx.ToString() +                                                      // L'LRC
                "\r\n";                                                                 // Il CR-LF
            }
        }

        private void avviaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.loop.Interval = int.Parse(ini.IniReadValue("Loop", "Ritardo"));
            if (portaSeriale.IsOpen == false)
            {
                this.portaSeriale.PortName = ini.IniReadValue("SerialPort", "Porta");
                this.portaSeriale.BaudRate = int.Parse(ini.IniReadValue("SerialPort", "Baud"));
                this.portaSeriale.DataBits = int.Parse(ini.IniReadValue("SerialPort", "Bits"));
                this.portaSeriale.StopBits = (StopBits)Enum.Parse(typeof(StopBits), ini.IniReadValue("SerialPort", "StopBits"));
                this.portaSeriale.Parity = (Parity)Enum.Parse(typeof(Parity), ini.IniReadValue("SerialPort", "Parity"));
                this.portaSeriale.ReadTimeout = int.Parse(ini.IniReadValue("SerialPort", "ReadTimeout"));
                this.portaSeriale.WriteTimeout = int.Parse(ini.IniReadValue("SerialPort", "WriteTimeout"));
            }
            loop.Start();                                                               // Avvia il loop
        }

        private void salvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            funzioni.salvaExcel();                                                       // Salva il file XLS
        }

        private void decalocolaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (funzioni.CalcoloLRCRx(this.tbDeCalcolated.Text) == true)                // Si verifica se l'LRC del testo ricevuto è corretto
            {
                funzioni.Decript(this.tbDeCalcolated.Text);                             // Decifra il testo ricevuto e lo divide in variabili
                this.lblInd.Text = funzioni.indRx.ToString();                           // Variabile indirizzo
                this.lblFunzione.Text = funzioni.funzioneRx.ToString();                 // Variabile funzione
                this.lblData.Text = funzioni.dataRx.ToString();                         // Variabile dati
                double valore = double.Parse(funzioni.valoreRx);                        // Converte il valore in double
                double moltiplicatore = double.Parse(this.tbMoltiplicatore.Text);       // Converte il moltiplicatore in double
                double prodotto = (valore * moltiplicatore);                            // Calcola in valore * il moltiplicatore
                this.lblValore.Text = prodotto.ToString();                              // Il testo del valore è uguale al prodotto
            }
            else
            {
                MessageBox.Show("Errore: il testo ricevuto non è corretto" + funzioni.LRCCalcHex.ToString());       // Si verifica se l'LRC ricevuto non è corretto
            }
            if (funzioni.funzioneRx == "3")                                             // Si verifica se la funzione è 3 (Lettura)
            {
                this.lblData.Text = "-";                                                // Il testo del data è "-"
            }
        }

        private void calcolaEInviaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (portaSeriale.IsOpen == false)                                           // Si verifica se la porta seriale non è aperta
            {
                portaSeriale.Open();                                                    // Apre la porta seriale
            }
            calcolaToolStripMenuItem_Click(sender, e);                                  // Esegue il btnCalcola
            portaSeriale.Write(this.tbCalcolated.Text + "\r\n");                        // Invia il testo con il CR-LF
            int data = 0;                                                               // Variabile data = 0
            if (this.lblData.Text != "-")                                               // Si verifica se il testo del data è diverso da "-"
            {
                data = int.Parse(this.lblData.Text);                                    // Converte il testo di data in int
            }
            string ora = System.DateTime.Now.ToString("HH:mm.ss");                      // Variabile contenente l'ora
            if (indirizzo != 0 || funzione != 0)                                        // Si verifica se 'indirizzo o la funzione sono diversi da 0
            {
                funzioni.FileXLS(indirizzo, funzione, valore, data, ora);               // Genera il file XLS
            }
            timerData.Start();                                                          // Avvia il timer della ricezione
        }

        private void fermaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loop.Stop();
        }

        private void esciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }   
        #endregion
        #region TextBox
        private void cbFunzione_TextChanged(object sender, EventArgs e)
        {
            if (this.cbFunzione.Text == "03")                                           // Si verifica se il testo della funzione è uguale a 03
            {
                this.tbValore.Enabled = false;                                          // La tb valore non è abilitata
            }
            if (this.cbFunzione.Text == "06")                                           // Si verifica se il testo della funzione è uguale a 06
            {
                this.tbValore.Enabled = true;                                           // La tb valore è abilitata
            }
        }         
        private void lblFunzione_TextChanged(object sender, EventArgs e)
        {
            if (this.lblFunzione.Text == "3")                                           // Si verifica se il testo di funzione è 3
            {
                this.label7.Text = "Valore";                                            // Il testo è Valore
            }
            if (this.lblFunzione.Text == "6")                                           // Si verifica se il testo di funzione è 6
            {
                this.label7.Text = "Ind. start";                                        // Il testo è Ind. Start
            }
        }
        #endregion
        #region Timer
        private void timerData_Tick(object sender, EventArgs e)
        {
            if (funzioni.RxBuf != "")                                                   // Si verifica quando il buffer di ricezione non è vuoto
            {
                timerData.Stop();                                                       // Ferma il timer di ricezione
                funzioni.RxData(portaSeriale);                                          // Riceve i dati dalla seriale
                if (funzioni.msgTextRx != "")                                           // Si verifica se i dati di ricezione non sono vuoti
                {
                    DatiRx = funzioni.msgTextRx;                                        // Variabile con i dati ricevuti
                    this.tbDeCalcolated.Text = DatiRx.ToString();                       // La tb di ricezione ha i dati ricevuti
                }
            }
            portaSeriale.Close();                                                       // Chiude la porta seriale
            decalocolaToolStripMenuItem_Click(sender, e);                               // Avvia il btnDeCalcola
            try                                                                         // Prova a:
            {
                indirizzo = int.Parse(this.lblInd.Text);                                // Converte l'indirizzo in int
                funzione = int.Parse(this.lblFunzione.Text);                            // Converte la funzione in int
                valore = int.Parse(this.lblValore.Text);                                // Converte il valore in int
                string ora = System.DateTime.Now.ToString("HH:mm.ss");                  // Variabile contenente l'ora
            }
            catch (Exception)
            {

            }
        }
        private void loop_Tick(object sender, EventArgs e)
        {
            if (count != 0)                                                             // Se il conteggio è diverso da 0
            {
                this.lblLoop.Text = count.ToString();                                   // Segna il numero attuale del loop
            }
            int maxLoop = int.Parse(ini.IniReadValue("Loop", "Loop"));                  // Variabile numero max di loop
            try                                                                         // Prova a:
            {
                loop.Stop();                                                            // ferma il loop
                if (count <= maxLoop)                                                   // Si verifica se il conteggio è minore o uguale a 15
                {
                    if (portaSeriale.IsOpen == false)                                   // Si verifica se la porta seriale non è aperta
                        portaSeriale.Open();                                            // Apre la porta seriale
                    btnCalcolaEInvia_Click(sender, e);                                  // Esegue btnCalcolaEInvia                    
                    count = count+1;                                                    // incrementa il coneggio di 1
                    loop.Start();                                                       // Avvia il loop
                }
                else
                {
                    this.lblLoop.Text = "Fine";                                         // Segna la fine del loop
                    funzioni.salvaExcel();                                              // Salva il file XLS
                    count = 0;                                                          // Azzera il conteggio
                }
            }
            catch (Exception)
            {
                loop.Start();                                                           // Avvia il loop
            }            
        }
        #endregion               
        protected override void OnClosing(CancelEventArgs e)
        {
            funzioni.Esci();
            base.OnClosing(e);
        }

        private void tbStart_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(this.tbStart.Text) < 0 || int.Parse(this.tbStart.Text) > 255)
                {
                    MessageBox.Show("L'indirizzo di partenza non è valido", "Errore", MessageBoxButtons.OK);
                }
            }
            catch { }
        }
    }
}