using System;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using JumpingJump.Classi;

namespace JumpingJump.Piattaforme.UI
{
    public partial class Main : Form
    {
        bool isActive;
        public Main()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(790, 0);
            VariabiliCondivise.PosizioneChanged += new EventHandler(UpdateInfo);
            VariabiliCondivise.PosizioneAttualeChanged += new EventHandler(UpdateInfo);
            VariabiliCondivise.OffsetChanged += new EventHandler(UpdateInfo);
            VariabiliCondivise.NumPosizioniChanged += new EventHandler(UpdateInfo);
            VariabiliCondivise.AddTextToLog += new EventHandler(AddText);
            VariabiliCondivise.MousePositionChanged += new EventHandler(UpdateInfo);

            isActive = false;
            thread1 = new Thread(new ThreadStart(RunEditor));
            thread1.Name = "Editor grafico";

            thread2 = new Thread(new ThreadStart(RunGame));
            thread2.Name = "Test game";

            thread3 = new Thread(new ThreadStart(ThreadUpdateInfo));
            thread3.Name = "Controllo dati";

            thread4 = new Thread(new ThreadStart(ShowLog));
            thread4.Name = "LOG";

            log.AddItemWithoutTime("JumpingJump è un programma di Edoardo Morassutto");
            log.AddItemWithoutTime("è vietata la vendita, il noleggio, la distribuzione");
            log.AddItemWithoutTime("senza un esplicito permesso dell'autore.");
            log.AddItemWithoutTime("Questo programma serve a facilitare il lavoro");
            log.AddItemWithoutTime("dei colui che è addetto a posizionare i blocchi e ");
            log.AddItemWithoutTime("i nemici all'interno del gioco. ");
            log.AddItemWithoutTime("");
        }

        Log log = new Log();
        Thread thread1;
        Thread thread2;
        Thread thread3;
        Thread thread4;

        private void btnAvvia_Click(object sender, EventArgs e)
        {
            VariabiliCondivise.AddText("Premuto Editor Grafico");
            btnAvvia.Enabled = false;
            thread1.Start();
            gbInserisci.Enabled = true;

            VariabiliCondivise.difficoltà = 0;
            VariabiliCondivise.isRight = false;
            VariabiliCondivise.maxLife = 1;
            VariabiliCondivise.NumPosizioni = 0;
            VariabiliCondivise.Offset = 0;
            VariabiliCondivise.Posizione = Vector2.Zero;
            VariabiliCondivise.PosizioneAttuale = Vector2.Zero;
            VariabiliCondivise.tipoBlocco = TipoPosizione.Normale;
            
        }
        void RunEditor()
        {
            try
            {
                if (!isActive)
                {
                    JumpingJump.Piattaforme.Main game = new Piattaforme.Main();
                    game.Run();
                    isActive = true;
                }
            }
            catch (Exception ex)
            {
                Debug.Fail("Errore nell'avvio del gioco: " + ex.Message);
            }
        }
        private void btnGame_Click(object sender, EventArgs e)
        {
            VariabiliCondivise.AddText("Premuto TEST GAME");
            btnGame.Enabled = false;
            thread2.Start();
        }
        void RunGame()
        {
            try
            {
                VariabiliCondivise.AddText("Avvio di JumpingJump");
                JumpingJump.Main game = new JumpingJump.Main();
                game.Run();
            }
            catch (Exception ex)
            {
                VariabiliCondivise.AddText("Errore nell'avvio del gioco: " + ex.Message);
            }
        }

        private void rbBlocco_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBlocco.Checked)
            {
                VariabiliCondivise.AddText("Selezionato Blocco");
                cbTipo.Items.Clear();
                cbTipo.Items.Add("Normale");
                cbTipo.Items.Add("Falso");
                cbTipo.Items.Add("MovimOrriz");
                cbTipo.Items.Add("Distruttibile");
                cbTipo.Items.Add("SaltoSingolo");
                cbTipo.Text = "Normale";
                tbPosizione.Enabled = false;
                tbPosizioneAtt.Enabled = false;
                numVite.Enabled = false;
                numDifficoltà.Enabled = true;
                tbOffset.Enabled = false;
                tbPosSaved.Enabled = false;
                cbBonus.Enabled = true;
            }
        }
        private void rbNemico_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNemico.Checked)
            {
                VariabiliCondivise.AddText("Selezionato Nemico");
                cbTipo.Items.Clear();
                cbTipo.Items.Add("Nemico1");
                cbTipo.Items.Add("Nemico2");
                cbTipo.Items.Add("Nemico3");
                cbTipo.Items.Add("Nemico4");
                cbTipo.Items.Add("Nemico5");
                cbTipo.Items.Add("Nemico6");
                cbTipo.Items.Add("Nemico7");
                cbTipo.Text = "Nemico1";
                tbPosizione.Enabled = false;
                tbPosizioneAtt.Enabled = false;
                numVite.Enabled = true;
                numDifficoltà.Enabled = true;
                tbOffset.Enabled = false;
                tbPosSaved.Enabled = false;
                cbBonus.Enabled = false;
            }
        }
        
        private void cbTipo_TextChanged(object sender, EventArgs e)
        {
            this.numVelocità.Enabled = false;
            if (rbBlocco.Checked)
            {
                if (cbTipo.Text == "Normale")
                {
                    VariabiliCondivise.AddText("Tipo cambiato in: Normale");
                    VariabiliCondivise.tipoBlocco = TipoPosizione.Normale;
                }
                else if (cbTipo.Text == "Falso")
                {
                    VariabiliCondivise.AddText("Tipo cambiato in: Falso");
                    VariabiliCondivise.tipoBlocco = TipoPosizione.Falso;
                }
                else if (cbTipo.Text == "MovimOrriz")
                {
                    VariabiliCondivise.AddText("Tipo cambiato in: MovimOrriz");
                    VariabiliCondivise.tipoBlocco = TipoPosizione.MovimOrriz;
                    this.numVelocità.Enabled = true;
                }
                else if (cbTipo.Text == "Distruttibile")
                {
                    VariabiliCondivise.AddText("Tipo cambiato in: Distruttibile");
                    VariabiliCondivise.tipoBlocco = TipoPosizione.Distruttibile;
                }
                else if (cbTipo.Text == "SaltoSingolo")
                {
                    VariabiliCondivise.AddText("Tipo cambiato in: SaltoSingolo");
                    VariabiliCondivise.tipoBlocco = TipoPosizione.SaltoSingolo;
                }
                else
                {
                    cbTipo.Text = "Normale";
                    VariabiliCondivise.tipoBlocco = TipoPosizione.Normale;
                }
            }
            else
            {
                if (cbTipo.Text == "Nemico1")
                {
                    VariabiliCondivise.AddText("Tipo cambiato in: Nemico1");
                    VariabiliCondivise.tipoBlocco = TipoPosizione.Nemico1;
                }
                else if (cbTipo.Text == "Nemico2")
                {
                    VariabiliCondivise.AddText("Tipo cambiato in: Nemico2");
                    VariabiliCondivise.tipoBlocco = TipoPosizione.Nemico2;
                }
                else if (cbTipo.Text == "Nemico3")
                {
                    VariabiliCondivise.AddText("Tipo cambiato in: Nemico3");
                    VariabiliCondivise.tipoBlocco = TipoPosizione.Nemico3;
                }
                else if (cbTipo.Text == "Nemico4")
                {
                    VariabiliCondivise.AddText("Tipo cambiato in: Nemico4");
                    VariabiliCondivise.tipoBlocco = TipoPosizione.Nemico4;
                }
                else if (cbTipo.Text == "Nemico5")
                {
                    VariabiliCondivise.AddText("Tipo cambiato in: Nemico5");
                    VariabiliCondivise.tipoBlocco = TipoPosizione.Nemico5;
                }
                else if (cbTipo.Text == "Nemico6")
                {
                    VariabiliCondivise.AddText("Tipo cambiato in: Nemico6");
                    VariabiliCondivise.tipoBlocco = TipoPosizione.Nemico6;
                }
                else if (cbTipo.Text == "Nemico7")
                {
                    VariabiliCondivise.AddText("Tipo cambiato in: Nemico7");
                    VariabiliCondivise.tipoBlocco = TipoPosizione.Nemico7;
                }
                else
                {
                    cbTipo.Text = "Nemico1";
                    VariabiliCondivise.tipoBlocco = TipoPosizione.Nemico1;
                }
            }
        }
        private void numVite_ValueChanged(object sender, EventArgs e)
        {
            VariabiliCondivise.maxLife = (int)numVite.Value;
        }
        private void numDifficoltà_ValueChanged(object sender, EventArgs e)
        {
            VariabiliCondivise.difficoltà = (int)numDifficoltà.Value;
        }
        private void numVelocità_ValueChanged(object sender, EventArgs e)
        {
            VariabiliCondivise.Speed = (float)numVelocità.Value;
        }
        private void btnSalva_Click(object sender, EventArgs e)
        {
            VariabiliCondivise.Salva();
        }
        
        delegate void UpdateInfoCallback(string text);

        void UpdateInfo(object sender, EventArgs e)
        {
            thread3 = new Thread(new ThreadStart(ThreadUpdateInfo));
            thread3.Name = "Controllo dati";
            thread3.Start();
        }
        void ShowLog()
        {
            log.ShowDialog();
        }
        void ThreadUpdateInfo()
        {
            SetText("");
        }
        void SetText(string text)
        {
            try
            {
                if (this.tbPosizione.InvokeRequired)
                {
                    UpdateInfoCallback d = new UpdateInfoCallback(SetText);
                    this.Invoke(d, new object[] { VariabiliCondivise.Posizione.ToString() });
                }
                else
                    this.tbPosizione.Text = VariabiliCondivise.Posizione.ToString();

                if (this.tbPosizioneAtt.InvokeRequired)
                {
                    UpdateInfoCallback d = new UpdateInfoCallback(SetText);
                    this.Invoke(d, new object[] { VariabiliCondivise.PosizioneAttuale.ToString() });
                }
                else
                    this.tbPosizioneAtt.Text = VariabiliCondivise.PosizioneAttuale.ToString();

                if (this.tbOffset.InvokeRequired)
                {
                    UpdateInfoCallback d = new UpdateInfoCallback(SetText);
                    this.Invoke(d, new object[] { VariabiliCondivise.Offset.ToString() });
                }
                else
                    this.tbOffset.Text = VariabiliCondivise.Offset.ToString();

                if (this.tbMousePosition.InvokeRequired)
                {
                    UpdateInfoCallback d = new UpdateInfoCallback(SetText);
                    this.Invoke(d, new object[] { VariabiliCondivise.PosizioneMouse.ToString() });
                }
                else
                    this.tbMousePosition.Text = VariabiliCondivise.PosizioneMouse.ToString();

                if (this.tbPosSaved.InvokeRequired)
                {
                    UpdateInfoCallback d = new UpdateInfoCallback(SetText);
                    this.Invoke(d, new object[] { VariabiliCondivise.NumPosizioni.ToString() });
                }
                else
                    this.tbPosSaved.Text = VariabiliCondivise.NumPosizioni.ToString();
            }
            catch { }
        }

        void AddText(object sender, EventArgs e)
        {
            log.AddItem(sender.ToString());
        }

        private void brnReset_Click(object sender, EventArgs e)
        {
            VariabiliCondivise.Reset();
            tbPosSaved.Text = "0";
            VariabiliCondivise.AddText("Reset effettuato");
        }
        private void btnPopolate_Click(object sender, EventArgs e)
        {
            VariabiliCondivise.Populate();
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!btnAvvia.Enabled)
                    VariabiliCondivise.Exit();
                if (!btnGame.Enabled)
                    Helper.Exit();
                if (!log.IsDisposed)
                    log.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossibile uscire:\n" + ex.Message, "ERRORE");
            }
        }
        private void Main_Load(object sender, EventArgs e)
        {
            thread4.Start();
        }

        private void cbBonus_TextChanged(object sender, EventArgs e)
        {
            if (cbBonus.Text == "(nessuno)")
            {
                VariabiliCondivise.Bonus = TipoBonus.Nessuno;
                VariabiliCondivise.BonusJumpHeight = 0;
                VariabiliCondivise.BonusSpeed = 0;
            }
            else if (cbBonus.Text == "Molla")
            {
                VariabiliCondivise.Bonus = TipoBonus.Molla;
                VariabiliCondivise.BonusJumpHeight = 50;
                VariabiliCondivise.BonusSpeed = 0.1f;
            }
            else if (cbBonus.Text == "JetPack")
            {
                VariabiliCondivise.Bonus = TipoBonus.JetPack;
                VariabiliCondivise.BonusJumpHeight = 200;
                VariabiliCondivise.BonusSpeed = 0.08f;
            }
            else if (cbBonus.Text == "Cappello")
            {
                VariabiliCondivise.Bonus = TipoBonus.Capellino;
                VariabiliCondivise.BonusJumpHeight = 150;
                VariabiliCondivise.BonusSpeed = 0.05f;
            }
            else if (cbBonus.Text == "Razzo")
            {
                VariabiliCondivise.Bonus = TipoBonus.Razzo;
                VariabiliCondivise.BonusJumpHeight = 450;
                VariabiliCondivise.BonusSpeed = 0.09f;
            }
            else
            {
                cbBonus.Text = "(nessuno)";
                VariabiliCondivise.BonusJumpHeight = 0;
                VariabiliCondivise.BonusSpeed = 0;
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            VariabiliCondivise.AddText("Posizione rimossa");
            VariabiliCondivise.UnDo();
        }

        private void tbPosSaved_TextChanged(object sender, EventArgs e)
        {
            if (tbPosSaved.Text == "0")
                btnUndo.Enabled = false;
            else
                btnUndo.Enabled = true;
        }       
    }
}
