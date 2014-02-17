using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using System.Windows.Forms;

namespace ComputersInvaders
{
    public class Classifica
    {       
        public Classifica()
        {

        }
        public void GetClassifica()
        {
            Variabili.savegame.AvviaCaricamento();
            /*
            try
            {
                Variabili.ex.LoadXls(Variabili.path);
                try
                {
                    Variabili.s1 = Variabili.ex.Worksheets.ActiveWorksheet.Cells["A2"].Value.ToString();
                }
                catch (Exception)
                {
                    Variabili.s1 = " ";
                }
                try
                {
                    Variabili.s2 = Variabili.ex.Worksheets.ActiveWorksheet.Cells["A3"].Value.ToString();
                }
                catch (Exception)
                {
                    Variabili.s2 = " ";
                }
                try
                {
                    Variabili.s3 = Variabili.ex.Worksheets.ActiveWorksheet.Cells["A4"].Value.ToString();
                }
                catch (Exception)
                {
                    Variabili.s3 = " ";
                }
                try
                {
                    Variabili.s4 = Variabili.ex.Worksheets.ActiveWorksheet.Cells["A5"].Value.ToString();
                }
                catch (Exception)
                {
                    Variabili.s4 = " ";
                }
                try
                {
                    Variabili.s5 = Variabili.ex.Worksheets.ActiveWorksheet.Cells["A6"].Value.ToString();
                }
                catch (Exception)
                {
                    Variabili.s5 = " ";
                }
                try
                {
                    Variabili.p1 = int.Parse(Variabili.ex.Worksheets.ActiveWorksheet.Cells["B2"].Value.ToString());
                }
                catch (Exception)
                {
                    Variabili.p1 = 0;
                }
                try
                {
                    Variabili.p2 = int.Parse(Variabili.ex.Worksheets.ActiveWorksheet.Cells["B3"].Value.ToString());
                }
                catch (Exception)
                {
                    Variabili.p2 = 0;
                }
                try
                {
                    Variabili.p3 = int.Parse(Variabili.ex.Worksheets.ActiveWorksheet.Cells["B4"].Value.ToString());
                }
                catch (Exception)
                {
                    Variabili.p3 = 0;
                }
                try
                {
                    Variabili.p4 = int.Parse(Variabili.ex.Worksheets.ActiveWorksheet.Cells["B5"].Value.ToString());
                }
                catch (Exception)
                {
                    Variabili.p4 = 0;
                }
                try
                {
                    Variabili.p5 = int.Parse(Variabili.ex.Worksheets.ActiveWorksheet.Cells["B6"].Value.ToString());
                }
                catch (Exception)
                {
                    Variabili.p5 = 0;
                }

                if (Variabili.s1 == null)
                {
                    Variabili.s1 = "None";
                } 
                if (Variabili.s2 == null)
                {
                    Variabili.s2 = "None";
                }
                if (Variabili.s3 == null)
                {
                    Variabili.s3 = "None";
                }
                if (Variabili.s4 == null)
                {
                    Variabili.s4 = "None";
                }
                if (Variabili.s5 == null)
                {
                    Variabili.s5 = "None";
                }

            }
            catch (IOException)
            {
                Variabili.errore = "Errore: impossibile leggere la classifica";
                Variabili.showError = true;
                if (Variabili.s1 == null)
                {
                    Variabili.s1 = "None";
                }
                if (Variabili.s2 == null)
                {
                    Variabili.s2 = "None";
                }
                if (Variabili.s3 == null)
                {
                    Variabili.s3 = "None";
                }
                if (Variabili.s4 == null)
                {
                    Variabili.s4 = "None";
                }
                if (Variabili.s5 == null)
                {
                    Variabili.s5 = "None";
                }
            }
             * */
        }

        public void CalcClassifica(string nome, int punteggio)
        {
            GetClassifica();
            if (punteggio >= Variabili.p5 && punteggio < Variabili.p4)
            {
                Variabili.p5 = punteggio;
                Variabili.s5 = nome;
            }
            if (punteggio >= Variabili.p4 && punteggio < Variabili.p3)
            {
                Variabili.p5 = Variabili.p4;
                Variabili.s5 = Variabili.s4;
                Variabili.p4 = punteggio;
                Variabili.s4 = nome;
            }
            if (punteggio >= Variabili.p3 && punteggio < Variabili.p2)
            {
                Variabili.p5 = Variabili.p4;
                Variabili.s5 = Variabili.s4;
                Variabili.p4 = Variabili.p3;
                Variabili.s4 = Variabili.s3;
                Variabili.p3 = punteggio;
                Variabili.s3 = nome;
            }
            if (punteggio >= Variabili.p2 && punteggio < Variabili.p1)
            {
                Variabili.p5 = Variabili.p4;
                Variabili.s5 = Variabili.s4;
                Variabili.p4 = Variabili.p3;
                Variabili.s4 = Variabili.s3;
                Variabili.p3 = Variabili.p2;
                Variabili.s3 = Variabili.s2;
                Variabili.p2 = punteggio;
                Variabili.s2 = nome;
            }
            if (punteggio >= Variabili.p1)
            {
                Variabili.p5 = Variabili.p4;
                Variabili.s5 = Variabili.s4;
                Variabili.p4 = Variabili.p3;
                Variabili.s4 = Variabili.s3;
                Variabili.p3 = Variabili.p2;
                Variabili.s3 = Variabili.s2;
                Variabili.p2 = Variabili.p1;
                Variabili.s2 = Variabili.s1;
                Variabili.p1 = punteggio;
                Variabili.s1 = nome;
            }
            SetClassifica();
        }

        public void SetClassifica()
        {
            Variabili.savegame.AvviaSalvataggio();
            /*
            Variabili.ex.Worksheets.ActiveWorksheet.Cells["A1"].Value = "Nome";
            Variabili.ex.Worksheets.ActiveWorksheet.Cells["A2"].Value = Variabili.s1;
            Variabili.ex.Worksheets.ActiveWorksheet.Cells["A3"].Value = Variabili.s2;
            Variabili.ex.Worksheets.ActiveWorksheet.Cells["A4"].Value = Variabili.s3;
            Variabili.ex.Worksheets.ActiveWorksheet.Cells["A5"].Value = Variabili.s4;
            Variabili.ex.Worksheets.ActiveWorksheet.Cells["A6"].Value = Variabili.s5;
            Variabili.ex.Worksheets.ActiveWorksheet.Cells["B1"].Value = "Punteggio";
            Variabili.ex.Worksheets.ActiveWorksheet.Cells["B2"].Value = Variabili.p1;
            Variabili.ex.Worksheets.ActiveWorksheet.Cells["B3"].Value = Variabili.p2;
            Variabili.ex.Worksheets.ActiveWorksheet.Cells["B4"].Value = Variabili.p3;
            Variabili.ex.Worksheets.ActiveWorksheet.Cells["B5"].Value = Variabili.p4;
            Variabili.ex.Worksheets.ActiveWorksheet.Cells["B6"].Value = Variabili.p5;
            try
            {
                Variabili.ex.SaveXls(Variabili.path);
            }
            catch (IOException)
            {
                Variabili.showError = true;
                Variabili.errore = "Errore: impossibile salvare la cassifica";
            }
            */
        }        
        

        public string ShowTextBoxDialog()
        {
            if (!Variabili.schermo_intero)
            {
                lock (Variabili._lockForTextBox)
                {
                    Variabili.child.ShowDialog();

                    string text;
                    if (Variabili.child.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        text = Variabili.textBox.Text;
                    }
                    else
                    {
                        text = null;
                    }
                    try
                    {
                        Variabili.nome = Variabili.textBox.Text;
                    }
                    catch (Exception) { }
                    return text;
                }
            }
            return null;
        }

        void okButton_Click(object sender, EventArgs e)
        {
            if (Variabili.nome != null)
            {
                if(Variabili.textBox.Text == "")
                    Variabili.textBox.Text = " ";
                Variabili.child.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
        public void Inizialize()
        {
            Variabili.child = new System.Windows.Forms.Form();
            Variabili.child.Bounds = new System.Drawing.Rectangle(0, 0, 210, 90);
            Variabili.child.Text = "Nome";
            Variabili.child.ControlBox = false;
            Variabili.child.FormBorderStyle = FormBorderStyle.FixedSingle;
            Variabili.child.StartPosition = FormStartPosition.CenterParent;
            Variabili.child.BackColor = System.Drawing.Color.Gray;


            Variabili.child.Controls.Add(Variabili.textBox);
            Variabili.textBox.Bounds = new System.Drawing.Rectangle(10, 10, 185, 20);
            Variabili.textBox.Multiline = false;
            Variabili.textBox.BackColor = System.Drawing.Color.Gray;
            Variabili.textBox.Text = "Edoardo";

            Variabili.okButton.Bounds = new System.Drawing.Rectangle(75, 35, 50, 20);
            Variabili.okButton.Click += new EventHandler(okButton_Click);
            Variabili.okButton.Text = "OK";
            Variabili.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            Variabili.child.AcceptButton = Variabili.okButton;
            Variabili.child.Controls.Add(Variabili.okButton);
            Variabili.child.ShowInTaskbar = false;
        }
        public void DrawClassifica()
        {
            try
            {
                Variabili.sprite_batch.Begin();
                Variabili.sprite_batch.DrawString(Variabili.font1, "NOME", new Vector2(50, 50), Color.Red);
                Variabili.sprite_batch.DrawString(Variabili.font1, Variabili.s1, new Vector2(50, 70), Color.Red);
                Variabili.sprite_batch.DrawString(Variabili.font1, Variabili.s2, new Vector2(50, 90), Color.Red);
                Variabili.sprite_batch.DrawString(Variabili.font1, Variabili.s3, new Vector2(50, 110), Color.Red);
                Variabili.sprite_batch.DrawString(Variabili.font1, Variabili.s4, new Vector2(50, 130), Color.Red);
                Variabili.sprite_batch.DrawString(Variabili.font1, Variabili.s5, new Vector2(50, 150), Color.Red);
                Variabili.sprite_batch.DrawString(Variabili.font1, "PUNTEGGIO", new Vector2(150, 50), Color.Red);
                Variabili.sprite_batch.DrawString(Variabili.font1, Variabili.p1.ToString(), new Vector2(150, 70), Color.Red);
                Variabili.sprite_batch.DrawString(Variabili.font1, Variabili.p2.ToString(), new Vector2(150, 90), Color.Red);
                Variabili.sprite_batch.DrawString(Variabili.font1, Variabili.p3.ToString(), new Vector2(150, 110), Color.Red);
                Variabili.sprite_batch.DrawString(Variabili.font1, Variabili.p4.ToString(), new Vector2(150, 130), Color.Red);
                Variabili.sprite_batch.DrawString(Variabili.font1, Variabili.p5.ToString(), new Vector2(150, 150), Color.Red);
                Variabili.sprite_batch.End();
            }
            catch { }
        }
    }
}
