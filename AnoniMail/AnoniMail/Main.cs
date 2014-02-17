using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;

namespace AnoniMail
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            ttAddAllegato.SetToolTip(btnAddAllegato, "Consente di aggiungere un allegato al messaggio");
            ttAllegati.SetToolTip(lbAllegati, "La lista degli allegati del messaggio");
            ttDestinatario.SetToolTip(tbDestinatario, "Indirizzo email del destinatario.\nEs. indirizzo@e-mail.com");
            ttMittente.SetToolTip(tbMittente, "Indirizzo email del mittente.\nes. indirizzo@e-mail.com");
            ttOggetto.SetToolTip(tbOggetto, "Oggetto del messaggio");
            ttRemoveAllegato.SetToolTip(btnRemoveAllegato, "Rimuove gli allegati selezionati dal messaggio");
            ttSend.SetToolTip(btnSend, "Invia il messaggio con la configurazione indicata");
            ttSMTP.SetToolTip(tbSMTP, "Nome del server SMTP con cui inviare il messaggio");
            ttSSL.SetToolTip(cbSSL, "Indica se inviare il messaggio utilizzando una connessione protetta SSL");
            ttText.SetToolTip(rtbText, "Testo del messaggio da inviare");

            smtp.SendCompleted += new SendCompletedEventHandler(smtp_SendCompleted);
        }


        SmtpClient smtp = new SmtpClient();


        private void btnAddAllegato_Click(object sender, EventArgs e)
        {
            if (ofdAllegato.ShowDialog() == DialogResult.OK)
            {
                lbAllegati.Items.AddRange(ofdAllegato.FileNames);
            }
        }

        private void btnRemoveAllegato_Click(object sender, EventArgs e)
        {
            for (int i = lbAllegati.SelectedIndices.Count - 1; i >= 0; i--)
            {
                lbAllegati.Items.RemoveAt(lbAllegati.SelectedIndices[i]);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            smtp.Host = tbSMTP.Text;
            smtp.EnableSsl = cbSSL.Checked;
            MailMessage message = new MailMessage(tbMittente.Text, tbDestinatario.Text);
            message.Subject = tbOggetto.Text;
            message.Body = rtbText.Text;
            foreach (string path in lbAllegati.Items)
            {
                message.Attachments.Add(new Attachment(path));
            }

            if (btnSend.Text == "Annulla")
                btnSend.Text = "INVIA";
            else if (btnSend.Text == "INVIA")
                btnSend.Text = "Annulla";
            try
            {
                if (btnSend.Text == "Annulla")
                    smtp.SendAsyncCancel();
                else if (btnSend.Text == "INVIA")
                    smtp.SendAsync(message, new object());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSend.Text = "INVIA";
            }            
        }

        void smtp_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Invio del messaggio completato");
            btnSend.Text = "INVIA";
        }
    }
}
