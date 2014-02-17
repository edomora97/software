namespace Parametri_in_MODBUS
{
    partial class MODBUS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MODBUS));
            this.label1 = new System.Windows.Forms.Label();
            this.tbIndirizzo = new System.Windows.Forms.TextBox();
            this.cbFunzione = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbStart = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCalcolated = new System.Windows.Forms.TextBox();
            this.tbValore = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDeCalcolated = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblInd = new System.Windows.Forms.Label();
            this.lblFunzione = new System.Windows.Forms.Label();
            this.lblValore = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.tbMoltiplicatore = new System.Windows.Forms.TextBox();
            this.portaSeriale = new System.IO.Ports.SerialPort(this.components);
            this.btnCalcolaEInvia = new System.Windows.Forms.Button();
            this.timerData = new System.Windows.Forms.Timer(this.components);
            this.loop = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.opzioniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.esciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.calcolaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calcolaEInviaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decalocolaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.avviaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fermaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblLoop = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Indirizzo";
            // 
            // tbIndirizzo
            // 
            this.tbIndirizzo.Location = new System.Drawing.Point(15, 40);
            this.tbIndirizzo.Name = "tbIndirizzo";
            this.tbIndirizzo.Size = new System.Drawing.Size(45, 20);
            this.tbIndirizzo.TabIndex = 1;
            this.tbIndirizzo.Text = "02";
            // 
            // cbFunzione
            // 
            this.cbFunzione.FormattingEnabled = true;
            this.cbFunzione.Items.AddRange(new object[] {
            "03",
            "06"});
            this.cbFunzione.Location = new System.Drawing.Point(66, 40);
            this.cbFunzione.Name = "cbFunzione";
            this.cbFunzione.Size = new System.Drawing.Size(43, 21);
            this.cbFunzione.TabIndex = 2;
            this.cbFunzione.Text = "03";
            this.cbFunzione.TextChanged += new System.EventHandler(this.cbFunzione_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Funzione";
            // 
            // tbStart
            // 
            this.tbStart.Location = new System.Drawing.Point(115, 40);
            this.tbStart.Name = "tbStart";
            this.tbStart.Size = new System.Drawing.Size(57, 20);
            this.tbStart.TabIndex = 4;
            this.tbStart.Text = "0";
            this.tbStart.TextChanged += new System.EventHandler(this.tbStart_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(116, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Indir. start";
            // 
            // tbCalcolated
            // 
            this.tbCalcolated.Location = new System.Drawing.Point(81, 66);
            this.tbCalcolated.Name = "tbCalcolated";
            this.tbCalcolated.Size = new System.Drawing.Size(99, 20);
            this.tbCalcolated.TabIndex = 10;
            // 
            // tbValore
            // 
            this.tbValore.Enabled = false;
            this.tbValore.Location = new System.Drawing.Point(178, 40);
            this.tbValore.Name = "tbValore";
            this.tbValore.Size = new System.Drawing.Size(57, 20);
            this.tbValore.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(175, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Valore";
            // 
            // tbDeCalcolated
            // 
            this.tbDeCalcolated.Location = new System.Drawing.Point(81, 122);
            this.tbDeCalcolated.Name = "tbDeCalcolated";
            this.tbDeCalcolated.Size = new System.Drawing.Size(99, 20);
            this.tbDeCalcolated.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Indirizzo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(102, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Funzione";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(158, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Valore";
            // 
            // lblInd
            // 
            this.lblInd.AutoSize = true;
            this.lblInd.Location = new System.Drawing.Point(51, 168);
            this.lblInd.Name = "lblInd";
            this.lblInd.Size = new System.Drawing.Size(10, 13);
            this.lblInd.TabIndex = 19;
            this.lblInd.Text = "-";
            // 
            // lblFunzione
            // 
            this.lblFunzione.AutoSize = true;
            this.lblFunzione.Location = new System.Drawing.Point(102, 168);
            this.lblFunzione.Name = "lblFunzione";
            this.lblFunzione.Size = new System.Drawing.Size(10, 13);
            this.lblFunzione.TabIndex = 20;
            this.lblFunzione.Text = "-";
            this.lblFunzione.TextChanged += new System.EventHandler(this.lblFunzione_TextChanged);
            // 
            // lblValore
            // 
            this.lblValore.AutoSize = true;
            this.lblValore.Location = new System.Drawing.Point(161, 168);
            this.lblValore.Name = "lblValore";
            this.lblValore.Size = new System.Drawing.Size(10, 13);
            this.lblValore.TabIndex = 21;
            this.lblValore.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(202, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Data";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(202, 168);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(10, 13);
            this.lblData.TabIndex = 23;
            this.lblData.Text = "-";
            // 
            // tbMoltiplicatore
            // 
            this.tbMoltiplicatore.Location = new System.Drawing.Point(208, 122);
            this.tbMoltiplicatore.Name = "tbMoltiplicatore";
            this.tbMoltiplicatore.Size = new System.Drawing.Size(44, 20);
            this.tbMoltiplicatore.TabIndex = 24;
            this.tbMoltiplicatore.Text = "0,1";
            // 
            // portaSeriale
            // 
            this.portaSeriale.ReadTimeout = 1200;
            this.portaSeriale.WriteTimeout = 1200;
            // 
            // btnCalcolaEInvia
            // 
            this.btnCalcolaEInvia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalcolaEInvia.Location = new System.Drawing.Point(70, 93);
            this.btnCalcolaEInvia.Name = "btnCalcolaEInvia";
            this.btnCalcolaEInvia.Size = new System.Drawing.Size(120, 23);
            this.btnCalcolaEInvia.TabIndex = 25;
            this.btnCalcolaEInvia.Text = "CALCOLA E INVIA";
            this.btnCalcolaEInvia.UseVisualStyleBackColor = true;
            this.btnCalcolaEInvia.Click += new System.EventHandler(this.btnCalcolaEInvia_Click);
            // 
            // timerData
            // 
            this.timerData.Interval = 1000;
            this.timerData.Tick += new System.EventHandler(this.timerData_Tick);
            // 
            // loop
            // 
            this.loop.Interval = 2000;
            this.loop.Tick += new System.EventHandler(this.loop_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(260, 25);
            this.toolStrip1.TabIndex = 28;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opzioniToolStripMenuItem,
            this.salvaToolStripMenuItem,
            this.esciToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(38, 22);
            this.toolStripSplitButton1.Text = "File";
            // 
            // opzioniToolStripMenuItem
            // 
            this.opzioniToolStripMenuItem.Name = "opzioniToolStripMenuItem";
            this.opzioniToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.opzioniToolStripMenuItem.Text = "Opzioni";
            this.opzioniToolStripMenuItem.Click += new System.EventHandler(this.opzioniToolStripMenuItem_Click);
            // 
            // salvaToolStripMenuItem
            // 
            this.salvaToolStripMenuItem.Name = "salvaToolStripMenuItem";
            this.salvaToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.salvaToolStripMenuItem.Text = "Salva";
            this.salvaToolStripMenuItem.Click += new System.EventHandler(this.salvaToolStripMenuItem_Click);
            // 
            // esciToolStripMenuItem
            // 
            this.esciToolStripMenuItem.Name = "esciToolStripMenuItem";
            this.esciToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.esciToolStripMenuItem.Text = "Esci";
            this.esciToolStripMenuItem.Click += new System.EventHandler(this.esciToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calcolaToolStripMenuItem,
            this.calcolaEInviaToolStripMenuItem,
            this.decalocolaToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(73, 22);
            this.toolStripDropDownButton1.Text = "Terminale";
            // 
            // calcolaToolStripMenuItem
            // 
            this.calcolaToolStripMenuItem.Name = "calcolaToolStripMenuItem";
            this.calcolaToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.calcolaToolStripMenuItem.Text = "Calcola";
            this.calcolaToolStripMenuItem.Click += new System.EventHandler(this.calcolaToolStripMenuItem_Click);
            // 
            // calcolaEInviaToolStripMenuItem
            // 
            this.calcolaEInviaToolStripMenuItem.Name = "calcolaEInviaToolStripMenuItem";
            this.calcolaEInviaToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.calcolaEInviaToolStripMenuItem.Text = "Calcola e invia";
            this.calcolaEInviaToolStripMenuItem.Click += new System.EventHandler(this.calcolaEInviaToolStripMenuItem_Click);
            // 
            // decalocolaToolStripMenuItem
            // 
            this.decalocolaToolStripMenuItem.Name = "decalocolaToolStripMenuItem";
            this.decalocolaToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.decalocolaToolStripMenuItem.Text = "Decalocola";
            this.decalocolaToolStripMenuItem.Click += new System.EventHandler(this.decalocolaToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.avviaToolStripMenuItem,
            this.fermaToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(47, 22);
            this.toolStripDropDownButton2.Text = "Loop";
            // 
            // avviaToolStripMenuItem
            // 
            this.avviaToolStripMenuItem.Name = "avviaToolStripMenuItem";
            this.avviaToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.avviaToolStripMenuItem.Text = "Avvia";
            this.avviaToolStripMenuItem.Click += new System.EventHandler(this.avviaToolStripMenuItem_Click);
            // 
            // fermaToolStripMenuItem
            // 
            this.fermaToolStripMenuItem.Name = "fermaToolStripMenuItem";
            this.fermaToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.fermaToolStripMenuItem.Text = "Ferma";
            this.fermaToolStripMenuItem.Click += new System.EventHandler(this.fermaToolStripMenuItem_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Da inviare:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 125);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Ricevuto:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(179, 125);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Molt:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 145);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "Loop";
            // 
            // lblLoop
            // 
            this.lblLoop.AutoSize = true;
            this.lblLoop.Location = new System.Drawing.Point(14, 168);
            this.lblLoop.Name = "lblLoop";
            this.lblLoop.Size = new System.Drawing.Size(10, 13);
            this.lblLoop.TabIndex = 33;
            this.lblLoop.Text = "-";
            // 
            // MODBUS
            // 
            this.AcceptButton = this.btnCalcolaEInvia;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 192);
            this.Controls.Add(this.lblLoop);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnCalcolaEInvia);
            this.Controls.Add(this.tbMoltiplicatore);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblValore);
            this.Controls.Add(this.lblFunzione);
            this.Controls.Add(this.lblInd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbDeCalcolated);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbValore);
            this.Controls.Add(this.tbCalcolated);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFunzione);
            this.Controls.Add(this.tbIndirizzo);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(276, 230);
            this.MinimumSize = new System.Drawing.Size(276, 230);
            this.Name = "MODBUS";
            this.Text = "Modbus";
            this.Load += new System.EventHandler(this.MODBUS_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbIndirizzo;
        private System.Windows.Forms.ComboBox cbFunzione;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCalcolated;
        private System.Windows.Forms.TextBox tbValore;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDeCalcolated;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblInd;
        private System.Windows.Forms.Label lblFunzione;
        private System.Windows.Forms.Label lblValore;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.TextBox tbMoltiplicatore;
        private System.IO.Ports.SerialPort portaSeriale;
        private System.Windows.Forms.Button btnCalcolaEInvia;
        private System.Windows.Forms.Timer timerData;
        private System.Windows.Forms.Timer loop;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem calcolaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calcolaEInviaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decalocolaToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem opzioniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salvaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem esciToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem avviaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fermaToolStripMenuItem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblLoop;
    }
}

