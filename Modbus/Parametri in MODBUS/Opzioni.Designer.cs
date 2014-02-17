namespace Parametri_in_MODBUS
{
    partial class Opzioni
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbParity = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbStopBits = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbBits = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbBaud = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPorta = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbRitardo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbLoop = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.rbNone = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.tbNome = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.rbHtlm = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.rbOds = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.rbCsv = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.rbXls = new System.Windows.Forms.RadioButton();
            this.rbXlsx = new System.Windows.Forms.RadioButton();
            this.btnApplica = new System.Windows.Forms.Button();
            this.btnDefoult = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.tbReadTimeout = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbWriteTimeout = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbWriteTimeout);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.tbReadTimeout);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.cbParity);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbStopBits);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbBits);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbBaud);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbPorta);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(163, 199);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Porta seriale";
            // 
            // cbParity
            // 
            this.cbParity.FormattingEnabled = true;
            this.cbParity.Location = new System.Drawing.Point(86, 121);
            this.cbParity.Name = "cbParity";
            this.cbParity.Size = new System.Drawing.Size(71, 21);
            this.cbParity.Sorted = true;
            this.cbParity.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Parità";
            // 
            // cbStopBits
            // 
            this.cbStopBits.FormattingEnabled = true;
            this.cbStopBits.Location = new System.Drawing.Point(86, 94);
            this.cbStopBits.Name = "cbStopBits";
            this.cbStopBits.Size = new System.Drawing.Size(71, 21);
            this.cbStopBits.Sorted = true;
            this.cbStopBits.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Stop bits";
            // 
            // cbBits
            // 
            this.cbBits.FormattingEnabled = true;
            this.cbBits.Location = new System.Drawing.Point(86, 66);
            this.cbBits.Name = "cbBits";
            this.cbBits.Size = new System.Drawing.Size(71, 21);
            this.cbBits.Sorted = true;
            this.cbBits.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bits";
            // 
            // cbBaud
            // 
            this.cbBaud.FormattingEnabled = true;
            this.cbBaud.Location = new System.Drawing.Point(86, 39);
            this.cbBaud.Name = "cbBaud";
            this.cbBaud.Size = new System.Drawing.Size(71, 21);
            this.cbBaud.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Baud";
            // 
            // cbPorta
            // 
            this.cbPorta.FormattingEnabled = true;
            this.cbPorta.Location = new System.Drawing.Point(86, 12);
            this.cbPorta.Name = "cbPorta";
            this.cbPorta.Size = new System.Drawing.Size(71, 21);
            this.cbPorta.Sorted = true;
            this.cbPorta.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Porta";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbRitardo);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tbLoop);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(181, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(149, 70);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ripetizioni";
            // 
            // tbRitardo
            // 
            this.tbRitardo.Location = new System.Drawing.Point(74, 39);
            this.tbRitardo.Name = "tbRitardo";
            this.tbRitardo.Size = new System.Drawing.Size(69, 20);
            this.tbRitardo.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Ritardo (ms)";
            // 
            // tbLoop
            // 
            this.tbLoop.Location = new System.Drawing.Point(74, 14);
            this.tbLoop.Name = "tbLoop";
            this.tbLoop.Size = new System.Drawing.Size(69, 20);
            this.tbLoop.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Loop";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.rbNone);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.tbNome);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.rbHtlm);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.rbOds);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.rbCsv);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.rbXls);
            this.groupBox3.Controls.Add(this.rbXlsx);
            this.groupBox3.Location = new System.Drawing.Point(181, 88);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(149, 181);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Formato";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(57, 156);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "Non salvare";
            // 
            // rbNone
            // 
            this.rbNone.AutoSize = true;
            this.rbNone.Location = new System.Drawing.Point(6, 154);
            this.rbNone.Name = "rbNone";
            this.rbNone.Size = new System.Drawing.Size(56, 17);
            this.rbNone.TabIndex = 10;
            this.rbNone.TabStop = true;
            this.rbNone.Text = "NONE";
            this.rbNone.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 9;
            this.label13.Text = "Nome:";
            // 
            // tbNome
            // 
            this.tbNome.Location = new System.Drawing.Point(47, 14);
            this.tbNome.Name = "tbNome";
            this.tbNome.Size = new System.Drawing.Size(95, 20);
            this.tbNome.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(57, 133);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "Tabella web";
            // 
            // rbHtlm
            // 
            this.rbHtlm.AutoSize = true;
            this.rbHtlm.Location = new System.Drawing.Point(6, 131);
            this.rbHtlm.Name = "rbHtlm";
            this.rbHtlm.Size = new System.Drawing.Size(55, 17);
            this.rbHtlm.TabIndex = 6;
            this.rbHtlm.TabStop = true;
            this.rbHtlm.Text = "HTML";
            this.rbHtlm.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(57, 110);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "OpenOffice";
            // 
            // rbOds
            // 
            this.rbOds.AutoSize = true;
            this.rbOds.Location = new System.Drawing.Point(6, 108);
            this.rbOds.Name = "rbOds";
            this.rbOds.Size = new System.Drawing.Size(48, 17);
            this.rbOds.TabIndex = 2;
            this.rbOds.TabStop = true;
            this.rbOds.Text = "ODS";
            this.rbOds.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(57, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "File Tabella";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(57, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Excel 2007-2010";
            // 
            // rbCsv
            // 
            this.rbCsv.AutoSize = true;
            this.rbCsv.Location = new System.Drawing.Point(6, 85);
            this.rbCsv.Name = "rbCsv";
            this.rbCsv.Size = new System.Drawing.Size(46, 17);
            this.rbCsv.TabIndex = 3;
            this.rbCsv.TabStop = true;
            this.rbCsv.Text = "CSV";
            this.rbCsv.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(57, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Excel 97-2003";
            // 
            // rbXls
            // 
            this.rbXls.AutoSize = true;
            this.rbXls.Location = new System.Drawing.Point(6, 39);
            this.rbXls.Name = "rbXls";
            this.rbXls.Size = new System.Drawing.Size(45, 17);
            this.rbXls.TabIndex = 0;
            this.rbXls.TabStop = true;
            this.rbXls.Text = "XLS";
            this.rbXls.UseVisualStyleBackColor = true;
            // 
            // rbXlsx
            // 
            this.rbXlsx.AutoSize = true;
            this.rbXlsx.Location = new System.Drawing.Point(6, 62);
            this.rbXlsx.Name = "rbXlsx";
            this.rbXlsx.Size = new System.Drawing.Size(52, 17);
            this.rbXlsx.TabIndex = 1;
            this.rbXlsx.TabStop = true;
            this.rbXlsx.Text = "XLSX";
            this.rbXlsx.UseVisualStyleBackColor = true;
            // 
            // btnApplica
            // 
            this.btnApplica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplica.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplica.Location = new System.Drawing.Point(12, 212);
            this.btnApplica.Name = "btnApplica";
            this.btnApplica.Size = new System.Drawing.Size(137, 26);
            this.btnApplica.TabIndex = 3;
            this.btnApplica.Text = "APPLICA";
            this.btnApplica.UseVisualStyleBackColor = true;
            this.btnApplica.Click += new System.EventHandler(this.btnApplica_Click);
            // 
            // btnDefoult
            // 
            this.btnDefoult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDefoult.Location = new System.Drawing.Point(12, 244);
            this.btnDefoult.Name = "btnDefoult";
            this.btnDefoult.Size = new System.Drawing.Size(137, 25);
            this.btnDefoult.TabIndex = 4;
            this.btnDefoult.Text = "Applica defoult";
            this.btnDefoult.UseVisualStyleBackColor = true;
            this.btnDefoult.Click += new System.EventHandler(this.btnDefoult_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 151);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 13);
            this.label15.TabIndex = 10;
            this.label15.Text = "Read Timeout";
            // 
            // tbReadTimeout
            // 
            this.tbReadTimeout.Location = new System.Drawing.Point(86, 148);
            this.tbReadTimeout.Name = "tbReadTimeout";
            this.tbReadTimeout.Size = new System.Drawing.Size(71, 20);
            this.tbReadTimeout.TabIndex = 4;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 177);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 13);
            this.label16.TabIndex = 11;
            this.label16.Text = "WriteTimeout";
            // 
            // tbWriteTimeout
            // 
            this.tbWriteTimeout.Location = new System.Drawing.Point(86, 173);
            this.tbWriteTimeout.Name = "tbWriteTimeout";
            this.tbWriteTimeout.Size = new System.Drawing.Size(71, 20);
            this.tbWriteTimeout.TabIndex = 12;
            // 
            // Opzioni
            // 
            this.AcceptButton = this.btnApplica;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 281);
            this.Controls.Add(this.btnDefoult);
            this.Controls.Add(this.btnApplica);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(334, 272);
            this.Name = "Opzioni";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Opzioni";
            this.Load += new System.EventHandler(this.Opzioni_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbParity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbStopBits;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbBits;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbBaud;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPorta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbRitardo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbLoop;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbCsv;
        private System.Windows.Forms.RadioButton rbOds;
        private System.Windows.Forms.RadioButton rbXlsx;
        private System.Windows.Forms.RadioButton rbXls;
        private System.Windows.Forms.Button btnApplica;
        private System.Windows.Forms.Button btnDefoult;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton rbHtlm;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbNome;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RadioButton rbNone;
        private System.Windows.Forms.TextBox tbWriteTimeout;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbReadTimeout;
        private System.Windows.Forms.Label label15;
    }
}