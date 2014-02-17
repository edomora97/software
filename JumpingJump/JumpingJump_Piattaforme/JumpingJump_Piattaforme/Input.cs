using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;


namespace JumpingJump.Piattaforme
{
    public class Input : GameComponent
    {
        private KeyboardState keyboard_pre;
        private KeyboardState keyboard;
        private MouseState mouse_pre;
        private MouseState mouse;


        public Input(Game game)
            : base(game)
        {

        }

        public override void Update(GameTime gameTime)
        {
            keyboard_pre = Keyboard.GetState();
            mouse_pre = Mouse.GetState();

            #region SWITCH TASTIERA
            if (keyboard.IsKeyDown(Keys.N) && keyboard_pre.IsKeyUp(Keys.N))
            {
                Add(Tipo.Normale);
            }

            if (keyboard.IsKeyDown(Keys.F) && keyboard_pre.IsKeyUp(Keys.F))
            {
                Add(Tipo.Falso);
            }

            if (keyboard.IsKeyDown(Keys.O) && keyboard_pre.IsKeyUp(Keys.O))
            {
                Add(Tipo.MovimOrriz);
            }
            
            if (keyboard.IsKeyDown(Keys.D) && keyboard_pre.IsKeyUp(Keys.D))
            {
                Add(Tipo.Distruttibile);
            }

            if (keyboard.IsKeyDown(Keys.R) && keyboard_pre.IsKeyUp(Keys.R))
            {
                Variabili.posizioni.Clear();
                Variabili.offset = 0;
            }

            if (keyboard.IsKeyDown(Keys.S) && keyboard_pre.IsKeyUp(Keys.S))
            {
                Add(Tipo.SaltoSingolo);
            }
            if (keyboard.IsKeyDown(Keys.F1) && keyboard_pre.IsKeyUp(Keys.F1))
            {
                Variabili.saveData.Salva("data", 0);
            }
            if (keyboard.IsKeyDown(Keys.F2) && keyboard_pre.IsKeyUp(Keys.F2))
            {
                Variabili.saveData.Salva("data", 1);
            }
            if (keyboard.IsKeyDown(Keys.F3) && keyboard_pre.IsKeyUp(Keys.F3))
            {
                Variabili.saveData.Salva("data", 2);
            }
            if (keyboard.IsKeyDown(Keys.F4) && keyboard_pre.IsKeyUp(Keys.F4))
            {
                Variabili.saveData.Salva("data", 3);
            }
            if (keyboard.IsKeyDown(Keys.F5) && keyboard_pre.IsKeyUp(Keys.F5))
            {
                Variabili.saveData.Salva("data", 4);
            }
            if (keyboard.IsKeyDown(Keys.F6) && keyboard_pre.IsKeyUp(Keys.F6))
            {
                Variabili.saveData.Salva("data", 5);
            }
            if (keyboard.IsKeyDown(Keys.F7) && keyboard_pre.IsKeyUp(Keys.F7))
            {
                Variabili.saveData.Salva("data", 6);
            } 
            if (keyboard.IsKeyDown(Keys.F8) && keyboard_pre.IsKeyUp(Keys.F8))
            {
                Variabili.saveData.Salva("data", 7);
            }
            if (keyboard.IsKeyDown(Keys.F9) && keyboard_pre.IsKeyUp(Keys.F9))
            {
                Variabili.saveData.Salva("data", 8);
            }
            if (keyboard.IsKeyDown(Keys.F10) && keyboard_pre.IsKeyUp(Keys.F10))
            {
                Variabili.saveData.Salva("data", 9);
            }
            if (keyboard.IsKeyDown(Keys.F11) && keyboard_pre.IsKeyUp(Keys.F11))
            {
                Variabili.saveData.Salva("data", 10);
            }
            #endregion
            #region SWITCH MOUSE
            if (mouse.LeftButton == ButtonState.Pressed && mouse_pre.LeftButton == ButtonState.Released && mouse.X > 0 && mouse.X < 240 && mouse.Y > 0 && mouse.Y < 320)
            {
                Add(Tipo.Normale);
            }
            Variabili.offset = mouse.ScrollWheelValue / 25;
            #endregion

            keyboard = keyboard_pre;
            mouse = mouse_pre;
            base.Update(gameTime);
        }

        private void Add(Tipo tipo)
        {

            if (tipo == Tipo.MovimOrriz)
            {
                Posizione posizione = new Posizione(new Vector2(20, mouse.Y - Variabili.offset), new Vector2(mouse.X, mouse.Y - Variabili.offset), Tipo.MovimOrriz);
                Variabili.posizioni.Add(posizione);
                Debug.WriteLine("Posizione aggiunta: X: " + posizione.X.ToString() + "\tY: " + posizione.Y.ToString() + "\t Posizione Attuale: " + posizione.PosizioneAttuale.ToString() + "\tTipo: " + posizione.Tipo.ToString());
            }
            else
            {
                Posizione posizione = new Posizione(mouse.X, mouse.Y - Variabili.offset, tipo);
                Variabili.posizioni.Add(posizione);
                Debug.WriteLine("Posizione aggiunta: X: " + posizione.X.ToString() + "\tY: " + posizione.Y.ToString() + "\tTipo: " + posizione.Tipo.ToString());
            }
        }
    }
}
