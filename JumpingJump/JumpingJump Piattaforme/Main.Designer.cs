namespace JumpingJump.Piattaforme.UI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnAvvia = new System.Windows.Forms.Button();
            this.gbInserisci = new System.Windows.Forms.GroupBox();
            this.cbBonus = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbMousePosition = new System.Windows.Forms.TextBox();
            this.brnReset = new System.Windows.Forms.Button();
            this.numVelocità = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalva = new System.Windows.Forms.Button();
            this.numVite = new System.Windows.Forms.NumericUpDown();
            this.numDifficoltà = new System.Windows.Forms.NumericUpDown();
            this.tbPosSaved = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbOffset = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPosizioneAtt = new System.Windows.Forms.TextBox();
            this.tbPosizione = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbNemico = new System.Windows.Forms.RadioButton();
            this.rbBlocco = new System.Windows.Forms.RadioButton();
            this.btnGame = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.gbInserisci.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numVelocità)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDifficoltà)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAvvia
            // 
            this.btnAvvia.Location = new System.Drawing.Point(18, 12);
            this.btnAvvia.Name = "btnAvvia";
            this.btnAvvia.Size = new System.Drawing.Size(87, 23);
            this.btnAvvia.TabIndex = 0;
            this.btnAvvia.Text = "Editor grafico";
            this.btnAvvia.UseVisualStyleBackColor = true;
            this.btnAvvia.Click += new System.EventHandler(this.btnAvvia_Click);
            // 
            // gbInserisci
            // 
            this.gbInserisci.Controls.Add(this.btnUndo);
            this.gbInserisci.Controls.Add(this.cbBonus);
            this.gbInserisci.Controls.Add(this.label9);
            this.gbInserisci.Controls.Add(this.tbMousePosition);
            this.gbInserisci.Controls.Add(this.brnReset);
            this.gbInserisci.Controls.Add(this.numVelocità);
            this.gbInserisci.Controls.Add(this.label1);
            this.gbInserisci.Controls.Add(this.btnSalva);
            this.gbInserisci.Controls.Add(this.numVite);
            this.gbInserisci.Controls.Add(this.numDifficoltà);
            this.gbInserisci.Controls.Add(this.tbPosSaved);
            this.gbInserisci.Controls.Add(this.label8);
            this.gbInserisci.Controls.Add(this.tbOffset);
            this.gbInserisci.Controls.Add(this.label7);
            this.gbInserisci.Controls.Add(this.label6);
            this.gbInserisci.Controls.Add(this.label5);
            this.gbInserisci.Controls.Add(this.tbPosizioneAtt);
            this.gbInserisci.Controls.Add(this.tbPosizione);
            this.gbInserisci.Controls.Add(this.label4);
            this.gbInserisci.Controls.Add(this.label3);
            this.gbInserisci.Controls.Add(this.cbTipo);
            this.gbInserisci.Controls.Add(this.label2);
            this.gbInserisci.Controls.Add(this.rbNemico);
            this.gbInserisci.Controls.Add(this.rbBlocco);
            this.gbInserisci.Enabled = false;
            this.gbInserisci.Location = new System.Drawing.Point(12, 41);
            this.gbInserisci.Name = "gbInserisci";
            this.gbInserisci.Size = new System.Drawing.Size(214, 309);
            this.gbInserisci.TabIndex = 2;
            this.gbInserisci.TabStop = false;
            this.gbInserisci.Text = "Inserisci";
            // 
            // cbBonus
            // 
            this.cbBonus.FormattingEnabled = true;
            this.cbBonus.Items.AddRange(new object[] {
            "(nessuno)",
            "Molla",
            "JetPack",
            "Cappello",
            "Razzo"});
            this.cbBonus.Location = new System.Drawing.Point(126, 46);
            this.cbBonus.Name = "cbBonus";
            this.cbBonus.Size = new System.Drawing.Size(72, 21);
            this.cbBonus.TabIndex = 25;
            this.cbBonus.Text = "(nessuno)";
            this.cbBonus.TextChanged += new System.EventHandler(this.cbBonus_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Posizione mouse";
            // 
            // tbMousePosition
            // 
            this.tbMousePosition.Enabled = false;
            this.tbMousePosition.Location = new System.Drawing.Point(98, 125);
            this.tbMousePosition.Name = "tbMousePosition";
            this.tbMousePosition.Size = new System.Drawing.Size(100, 20);
            this.tbMousePosition.TabIndex = 23;
            this.tbMousePosition.Text = "{X:0 Y:0}";
            // 
            // brnReset
            // 
            this.brnReset.Location = new System.Drawing.Point(10, 280);
            this.brnReset.Name = "brnReset";
            this.brnReset.Size = new System.Drawing.Size(60, 23);
            this.brnReset.TabIndex = 4;
            this.brnReset.Text = "Reset";
            this.brnReset.UseVisualStyleBackColor = true;
            this.brnReset.Click += new System.EventHandler(this.brnReset_Click);
            // 
            // numVelocità
            // 
            this.numVelocità.DecimalPlaces = 1;
            this.numVelocità.Enabled = false;
            this.numVelocità.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.numVelocità.Location = new System.Drawing.Point(99, 204);
            this.numVelocità.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numVelocità.Name = "numVelocità";
            this.numVelocità.Size = new System.Drawing.Size(100, 20);
            this.numVelocità.TabIndex = 21;
            this.numVelocità.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numVelocità.ValueChanged += new System.EventHandler(this.numVelocità_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Velocità";
            // 
            // btnSalva
            // 
            this.btnSalva.Location = new System.Drawing.Point(142, 280);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(60, 23);
            this.btnSalva.TabIndex = 3;
            this.btnSalva.Text = "Salva";
            this.btnSalva.UseVisualStyleBackColor = true;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // numVite
            // 
            this.numVite.Enabled = false;
            this.numVite.Location = new System.Drawing.Point(99, 151);
            this.numVite.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numVite.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numVite.Name = "numVite";
            this.numVite.Size = new System.Drawing.Size(100, 20);
            this.numVite.TabIndex = 18;
            this.numVite.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numVite.ValueChanged += new System.EventHandler(this.numVite_ValueChanged);
            // 
            // numDifficoltà
            // 
            this.numDifficoltà.Location = new System.Drawing.Point(99, 177);
            this.numDifficoltà.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numDifficoltà.Name = "numDifficoltà";
            this.numDifficoltà.Size = new System.Drawing.Size(100, 20);
            this.numDifficoltà.TabIndex = 17;
            this.numDifficoltà.ValueChanged += new System.EventHandler(this.numDifficoltà_ValueChanged);
            // 
            // tbPosSaved
            // 
            this.tbPosSaved.Enabled = false;
            this.tbPosSaved.Location = new System.Drawing.Point(99, 255);
            this.tbPosSaved.Name = "tbPosSaved";
            this.tbPosSaved.Size = new System.Drawing.Size(100, 20);
            this.tbPosSaved.TabIndex = 16;
            this.tbPosSaved.Text = "0";
            this.tbPosSaved.TextChanged += new System.EventHandler(this.tbPosSaved_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 258);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Posizioni salvate";
            // 
            // tbOffset
            // 
            this.tbOffset.Enabled = false;
            this.tbOffset.Location = new System.Drawing.Point(99, 229);
            this.tbOffset.Name = "tbOffset";
            this.tbOffset.Size = new System.Drawing.Size(100, 20);
            this.tbOffset.TabIndex = 14;
            this.tbOffset.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 232);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Offset";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Difficoltà";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Numero di vite";
            // 
            // tbPosizioneAtt
            // 
            this.tbPosizioneAtt.Enabled = false;
            this.tbPosizioneAtt.Location = new System.Drawing.Point(98, 99);
            this.tbPosizioneAtt.Name = "tbPosizioneAtt";
            this.tbPosizioneAtt.Size = new System.Drawing.Size(100, 20);
            this.tbPosizioneAtt.TabIndex = 8;
            this.tbPosizioneAtt.Text = "{X:0 Y:0}";
            // 
            // tbPosizione
            // 
            this.tbPosizione.Enabled = false;
            this.tbPosizione.Location = new System.Drawing.Point(98, 73);
            this.tbPosizione.Name = "tbPosizione";
            this.tbPosizione.Size = new System.Drawing.Size(100, 20);
            this.tbPosizione.TabIndex = 7;
            this.tbPosizione.Text = "{X:0 Y:0}";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Posizione attuale";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Posizione";
            // 
            // cbTipo
            // 
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Items.AddRange(new object[] {
            "Normale",
            "Falso",
            "MovimOrriz",
            "Distruttibile",
            "SaltoSingolo"});
            this.cbTipo.Location = new System.Drawing.Point(35, 46);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(83, 21);
            this.cbTipo.TabIndex = 3;
            this.cbTipo.Text = "Normale";
            this.cbTipo.TextChanged += new System.EventHandler(this.cbTipo_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo";
            // 
            // rbNemico
            // 
            this.rbNemico.AutoSize = true;
            this.rbNemico.Location = new System.Drawing.Point(70, 19);
            this.rbNemico.Name = "rbNemico";
            this.rbNemico.Size = new System.Drawing.Size(61, 17);
            this.rbNemico.TabIndex = 1;
            this.rbNemico.Text = "Nemico";
            this.rbNemico.UseVisualStyleBackColor = true;
            this.rbNemico.CheckedChanged += new System.EventHandler(this.rbNemico_CheckedChanged);
            // 
            // rbBlocco
            // 
            this.rbBlocco.AutoSize = true;
            this.rbBlocco.Checked = true;
            this.rbBlocco.Location = new System.Drawing.Point(6, 19);
            this.rbBlocco.Name = "rbBlocco";
            this.rbBlocco.Size = new System.Drawing.Size(58, 17);
            this.rbBlocco.TabIndex = 0;
            this.rbBlocco.TabStop = true;
            this.rbBlocco.Text = "Blocco";
            this.rbBlocco.UseVisualStyleBackColor = true;
            this.rbBlocco.CheckedChanged += new System.EventHandler(this.rbBlocco_CheckedChanged);
            // 
            // btnGame
            // 
            this.btnGame.Location = new System.Drawing.Point(138, 12);
            this.btnGame.Name = "btnGame";
            this.btnGame.Size = new System.Drawing.Size(87, 23);
            this.btnGame.TabIndex = 3;
            this.btnGame.Text = "TEST GAME";
            this.btnGame.UseVisualStyleBackColor = true;
            this.btnGame.Click += new System.EventHandler(this.btnGame_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Enabled = false;
            this.btnUndo.Location = new System.Drawing.Point(76, 280);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(60, 23);
            this.btnUndo.TabIndex = 26;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 362);
            this.Controls.Add(this.btnGame);
            this.Controls.Add(this.gbInserisci);
            this.Controls.Add(this.btnAvvia);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(253, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(253, 375);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JumpingJump Piattaforme";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.gbInserisci.ResumeLayout(false);
            this.gbInserisci.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numVelocità)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDifficoltà)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAvvia;
        private System.Windows.Forms.GroupBox gbInserisci;
        private System.Windows.Forms.RadioButton rbNemico;
        private System.Windows.Forms.RadioButton rbBlocco;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPosizioneAtt;
        private System.Windows.Forms.TextBox tbPosizione;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbOffset;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbPosSaved;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numDifficoltà;
        private System.Windows.Forms.NumericUpDown numVite;
        private System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.Button btnGame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numVelocità;
        private System.Windows.Forms.Button brnReset;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbMousePosition;
        private System.Windows.Forms.ComboBox cbBonus;
        private System.Windows.Forms.Button btnUndo;
    }
}

