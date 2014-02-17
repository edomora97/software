using System;
using System.Diagnostics;
using JumpingJump.Classi;

/*
  Name: Jumping Jump
  Copyright: 2012 (C) Edoardo Morassutto
  Author: Edoardo Morassutto
*/

namespace JumpingJump
{
#if WINDOWS
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            try
            {
                // Se gli argomenti all'avvio sono maggiori di 0
                if (args.Length > 0)
                {
                    // Se il primo argomento è -god
                    if (Array.IndexOf<string>(args, "-god") != -1)
                    {
                        // Mostra il messaggio che la godmode è stata abilitata
                        Helper.ShowMessage("GODMODE ENABLED", "GODMODE");
                        Main game = new Main();
                        game.GodMode();
                        game.Run();
                    }
                    else if (Array.IndexOf<string>(args, "-edit") != -1)
                    {
                        using (Piattaforme.Main game = new Piattaforme.Main())
                        {
                            game.Run();
                        }
                    }
                    else
                        using (Main game = new Main())
                        {
                            game.Run();
                        }
                }
                else
                {
                    using (Main game = new Main())
                    {
                        game.Run();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
    }
#endif
}

