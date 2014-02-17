using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace _100
{
    public partial class Main : Form
    {
        Casella[,] caselle = new Casella[10, 10];
        State[] undoList = new State[100];
        int count = 0;
        bool isStarted = false;
        DateTime startTime;

        public Main()
        {
            Initialize();
        }

        void Initialize()
        {
            InitializeComponent();
            caselle = new Casella[10, 10];
            undoList = new State[100];
            count = 0;
            isStarted = false;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button currButton = new Button();
                    currButton.Name = "btn" + i.ToString() + j.ToString();
                    currButton.Bounds = new Rectangle(i * 50 + 10, j * 50 + 10, 50, 50);
                    currButton.BackColor = Color.White;
                    currButton.Click += new EventHandler(Button_Click);

                    Casella casella = new Casella();
                    casella.button = currButton;
                    casella.colore = Colore.Verde;
                    casella.value = -1;
                    casella.x = i;
                    casella.y = j;

                    caselle[i, j] = casella;
                    this.Controls.Add(currButton);
                }
            }

            State stato = new State();
            stato.caselle = caselle;
            stato.x = -1;
            stato.y = -1;
            undoList[count] = stato;

            btnUndo.Enabled = false;
            RefreshButtons();
        }

        void Reset()
        {
            while (count > 0)
            {
                undoList[count] = new State();
                count--;
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    caselle[i, j].colore = Colore.Verde;
                    caselle[i, j].value = -1;
                }
            }
            RefreshButtons();
            State stato = new State();
            stato.caselle = caselle;
            stato.x = -1;
            stato.y = -1;
            undoList[count] = stato;
            lblTimer.Text = "00:00";
            isStarted = false;
            btnUndo.Enabled = false;
        }

        void Button_Click(object sender, EventArgs e)
        {            
            int x = 0, y = 0;

            Button btn = (Button)sender;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i * 50 + 10 == btn.Bounds.X)
                        if (j * 50 + 10 == btn.Bounds.Y)
                        {
                            x = i;
                            y = j;
                            break;
                        }
                }
            } 
            if (isStarted == false)
            {
                isStarted = true;
                timer.Start();
                startTime = DateTime.Now;                
            }
            if (caselle[x, y].colore == Colore.Verde)
            {
                State stato = new State();
                stato.caselle = new Casella[10, 10];
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        stato.caselle[i, j] = caselle[i, j];
                    }
                }
                stato.x = x;
                stato.y = y;
                undoList[count] = stato;

                btnUndo.Enabled = true;
                int possibilità = 0;
                caselle[x, y].button.BackColor = Color.Red;
                caselle[x, y].colore = Colore.Rosso;
                count++;
                caselle[x, y].value = count;
                caselle[x, y].button.Text = count.ToString();
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (caselle[i, j].value == -1)
                        {
                            caselle[i, j].button.BackColor = Color.White;
                            caselle[i, j].colore = Colore.Bianco;
                        }
                    }
                }

                try
                {
                    if (caselle[x, y - 3].colore == Colore.Bianco)
                    {
                        caselle[x, y - 3].colore = Colore.Verde;
                        caselle[x, y - 3].button.BackColor = Color.Green;
                        possibilità++;
                    }
                }
                catch { }

                try
                {
                    if (caselle[x, y + 3].colore == Colore.Bianco)
                    {
                        caselle[x, y + 3].colore = Colore.Verde;
                        caselle[x, y + 3].button.BackColor = Color.Green;
                        possibilità++;
                    }
                }
                catch { }

                try
                {
                    if (caselle[x - 3, y].colore == Colore.Bianco)
                    {
                        caselle[x - 3, y].colore = Colore.Verde;
                        caselle[x - 3, y].button.BackColor = Color.Green;
                        possibilità++;
                    }
                }
                catch { }

                try
                {
                    if (caselle[x + 3, y].colore == Colore.Bianco)
                    {
                        caselle[x + 3, y].colore = Colore.Verde;
                        caselle[x + 3, y].button.BackColor = Color.Green;
                        possibilità++;
                    }
                }
                catch { }

                try
                {
                    if (caselle[x - 2, y - 2].colore == Colore.Bianco)
                    {
                        caselle[x - 2, y - 2].colore = Colore.Verde;
                        caselle[x - 2, y - 2].button.BackColor = Color.Green;
                        possibilità++;
                    }
                }
                catch { }

                try
                {
                    if (caselle[x + 2, y + 2].colore == Colore.Bianco)
                    {
                        caselle[x + 2, y + 2].colore = Colore.Verde;
                        caselle[x + 2, y + 2].button.BackColor = Color.Green;
                        possibilità++;
                    }
                }
                catch { }

                try
                {
                    if (caselle[x - 2, y + 2].colore == Colore.Bianco)
                    {
                        caselle[x - 2, y + 2].colore = Colore.Verde;
                        caselle[x - 2, y + 2].button.BackColor = Color.Green;
                        possibilità++;
                    }
                }
                catch { }

                try
                {
                    if (caselle[x + 2, y - 2].colore == Colore.Bianco)
                    {
                        caselle[x + 2, y - 2].colore = Colore.Verde;
                        caselle[x + 2, y - 2].button.BackColor = Color.Green;
                        possibilità++;
                    }
                }
                catch { }


                if (possibilità == 0 && count < 100)
                {
                    timer.Stop(); 
                    DateTime currentTime = DateTime.Now;
                    TimeSpan time = currentTime - startTime;
                    MessageBox.Show("Mi dispiace, hai perso!\nSei arrivato alla casella " + count.ToString() + "\nCi hai messo " + time.Minutes.ToString() + " minuti e " + time.Seconds.ToString() + " secondi");
                }
                if (count >= 100)
                {
                    timer.Stop();
                    DateTime currentTime = DateTime.Now;
                    TimeSpan time = currentTime - startTime;
                    MessageBox.Show("CONGRATULAZIONI, hai vinto!!\nCi hai messo " + time.Minutes.ToString() + " minuti e " + time.Seconds.ToString() + " secondi");
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            TimeSpan time = currentTime - startTime;
            lblTimer.Text = (time.Minutes < 10 ? "0" + time.Minutes.ToString() : time.Minutes.ToString()) + ":" + (time.Seconds < 10 ? "0" + time.Seconds.ToString() : time.Seconds.ToString());
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            //undoList.RemoveAt(undoList.Count - 1);
            undoList[count] = new State();
            count--;
            //State stato = undoList[undoList.Count - 1];
            State stato = undoList[count];
            if (stato.caselle.Equals(caselle))
                System.Diagnostics.Debug.WriteLine("Sono uguali");
            caselle = stato.caselle;
            RefreshButtons();
            //if (undoList.Count == 1)
            if (count == 0)
                btnUndo.Enabled = false;
        }

        void RefreshButtons()
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    string nome = "btn" + x.ToString() + y.ToString();
                    Controls[nome].BackColor = caselle[x, y].colore == Colore.Bianco ? Color.White : caselle[x, y].colore == Colore.Verde ? Color.Green : Color.Red;
                    Controls[nome].Text = caselle[x, y].value.ToString() == "-1" ? "" : caselle[x, y].value.ToString();
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            timer.Stop();
            Reset();
        }
        
    }
    public enum Colore
    {
        Rosso, Verde, Bianco
    }
    public struct Casella
    {
        public Colore colore;
        public Button button;
        public int x;
        public int y;
        public int value;
    }
    public struct State
    {
        public Casella[,] caselle;
        public int x, y;
    }
}
