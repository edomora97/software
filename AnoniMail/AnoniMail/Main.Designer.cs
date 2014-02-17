namespace AnoniMail
{
    partial class Main
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMittente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDestinatario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSMTP = new System.Windows.Forms.TextBox();
            this.rtbText = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRemoveAllegato = new System.Windows.Forms.Button();
            this.btnAddAllegato = new System.Windows.Forms.Button();
            this.lbAllegati = new System.Windows.Forms.ListBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbOggetto = new System.Windows.Forms.TextBox();
            this.ofdAllegato = new System.Windows.Forms.OpenFileDialog();
            this.cbSSL = new System.Windows.Forms.CheckBox();
            this.ttMittente = new System.Windows.Forms.ToolTip(this.components);
            this.ttDestinatario = new System.Windows.Forms.ToolTip(this.components);
            this.ttSMTP = new System.Windows.Forms.ToolTip(this.components);
            this.ttOggetto = new System.Windows.Forms.ToolTip(this.components);
            this.ttSSL = new System.Windows.Forms.ToolTip(this.components);
            this.ttText = new System.Windows.Forms.ToolTip(this.components);
            this.ttAddAllegato = new System.Windows.Forms.ToolTip(this.components);
            this.ttRemoveAllegato = new System.Windows.Forms.ToolTip(this.components);
            this.ttAllegati = new System.Windows.Forms.ToolTip(this.components);
            this.ttSend = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mittente";
            // 
            // tbMittente
            // 
            this.tbMittente.Location = new System.Drawing.Point(63, 12);
            this.tbMittente.Name = "tbMittente";
            this.tbMittente.Size = new System.Drawing.Size(180, 20);
            this.tbMittente.TabIndex = 1;
            this.tbMittente.Text = "indirizzo@anonimail.it";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Destinatario";
            // 
            // tbDestinatario
            // 
            this.tbDestinatario.Location = new System.Drawing.Point(318, 12);
            this.tbDestinatario.Name = "tbDestinatario";
            this.tbDestinatario.Size = new System.Drawing.Size(180, 20);
            this.tbDestinatario.TabIndex = 3;
            this.tbDestinatario.Text = "destinatario@anonimail.it";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(504, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "SMTP";
            // 
            // tbSMTP
            // 
            this.tbSMTP.Location = new System.Drawing.Point(547, 12);
            this.tbSMTP.Name = "tbSMTP";
            this.tbSMTP.Size = new System.Drawing.Size(82, 20);
            this.tbSMTP.TabIndex = 5;
            // 
            // rtbText
            // 
            this.rtbText.Location = new System.Drawing.Point(12, 64);
            this.rtbText.Name = "rtbText";
            this.rtbText.Size = new System.Drawing.Size(614, 324);
            this.rtbText.TabIndex = 8;
            this.rtbText.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRemoveAllegato);
            this.groupBox1.Controls.Add(this.btnAddAllegato);
            this.groupBox1.Controls.Add(this.lbAllegati);
            this.groupBox1.Location = new System.Drawing.Point(12, 394);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 133);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Allegati";
            // 
            // btnRemoveAllegato
            // 
            this.btnRemoveAllegato.Location = new System.Drawing.Point(234, 91);
            this.btnRemoveAllegato.Name = "btnRemoveAllegato";
            this.btnRemoveAllegato.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAllegato.TabIndex = 10;
            this.btnRemoveAllegato.Text = "Rimuovi";
            this.btnRemoveAllegato.UseVisualStyleBackColor = true;
            this.btnRemoveAllegato.Click += new System.EventHandler(this.btnRemoveAllegato_Click);
            // 
            // btnAddAllegato
            // 
            this.btnAddAllegato.Location = new System.Drawing.Point(234, 19);
            this.btnAddAllegato.Name = "btnAddAllegato";
            this.btnAddAllegato.Size = new System.Drawing.Size(75, 23);
            this.btnAddAllegato.TabIndex = 9;
            this.btnAddAllegato.Text = "Aggiungi";
            this.btnAddAllegato.UseVisualStyleBackColor = true;
            this.btnAddAllegato.Click += new System.EventHandler(this.btnAddAllegato_Click);
            // 
            // lbAllegati
            // 
            this.lbAllegati.FormattingEnabled = true;
            this.lbAllegati.HorizontalScrollbar = true;
            this.lbAllegati.Location = new System.Drawing.Point(6, 19);
            this.lbAllegati.Name = "lbAllegati";
            this.lbAllegati.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbAllegati.Size = new System.Drawing.Size(222, 95);
            this.lbAllegati.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(442, 432);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(116, 52);
            this.btnSend.TabIndex = 12;
            this.btnSend.Text = "INVIA";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Oggetto";
            // 
            // tbOggetto
            // 
            this.tbOggetto.Location = new System.Drawing.Point(63, 38);
            this.tbOggetto.Name = "tbOggetto";
            this.tbOggetto.Size = new System.Drawing.Size(511, 20);
            this.tbOggetto.TabIndex = 6;
            // 
            // ofdAllegato
            // 
            this.ofdAllegato.Filter = "Tutti i file|*.*";
            this.ofdAllegato.Multiselect = true;
            this.ofdAllegato.Title = "Aggiungi un allegato";
            // 
            // cbSSL
            // 
            this.cbSSL.AutoSize = true;
            this.cbSSL.Location = new System.Drawing.Point(580, 40);
            this.cbSSL.Name = "cbSSL";
            this.cbSSL.Size = new System.Drawing.Size(46, 17);
            this.cbSSL.TabIndex = 7;
            this.cbSSL.Text = "SSL";
            this.cbSSL.UseVisualStyleBackColor = true;
            // 
            // ttMittente
            // 
            this.ttMittente.IsBalloon = true;
            // 
            // ttDestinatario
            // 
            this.ttDestinatario.IsBalloon = true;
            // 
            // ttSMTP
            // 
            this.ttSMTP.IsBalloon = true;
            // 
            // ttOggetto
            // 
            this.ttOggetto.IsBalloon = true;
            // 
            // ttSSL
            // 
            this.ttSSL.IsBalloon = true;
            // 
            // ttText
            // 
            this.ttText.IsBalloon = true;
            // 
            // ttAddAllegato
            // 
            this.ttAddAllegato.IsBalloon = true;
            // 
            // ttRemoveAllegato
            // 
            this.ttRemoveAllegato.IsBalloon = true;
            // 
            // ttAllegati
            // 
            this.ttAllegati.IsBalloon = true;
            // 
            // ttSend
            // 
            this.ttSend.IsBalloon = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 539);
            this.Controls.Add(this.cbSSL);
            this.Controls.Add(this.tbOggetto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rtbText);
            this.Controls.Add(this.tbSMTP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbDestinatario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbMittente);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "AnoniMail";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMittente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDestinatario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSMTP;
        private System.Windows.Forms.RichTextBox rtbText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRemoveAllegato;
        private System.Windows.Forms.Button btnAddAllegato;
        private System.Windows.Forms.ListBox lbAllegati;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbOggetto;
        private System.Windows.Forms.OpenFileDialog ofdAllegato;
        private System.Windows.Forms.CheckBox cbSSL;
        private System.Windows.Forms.ToolTip ttMittente;
        private System.Windows.Forms.ToolTip ttDestinatario;
        private System.Windows.Forms.ToolTip ttSMTP;
        private System.Windows.Forms.ToolTip ttOggetto;
        private System.Windows.Forms.ToolTip ttSSL;
        private System.Windows.Forms.ToolTip ttText;
        private System.Windows.Forms.ToolTip ttAddAllegato;
        private System.Windows.Forms.ToolTip ttRemoveAllegato;
        private System.Windows.Forms.ToolTip ttAllegati;
        private System.Windows.Forms.ToolTip ttSend;
    }
}

