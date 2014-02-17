using System;
using System.Diagnostics;
using System.IO;

/*
  Name: Jumping Jump
  Copyright: 2012 (C) Edoardo Morassutto
  Author: Edoardo Morassutto
*/

namespace JumpingJump.Classi
{
    /// <summary>
    /// Classe per l'utilizzo del file ini
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// Costruttore standard: path = "\settings.ini"
        /// </summary>
        public Configuration()
        {
            try
            {
                ini = new ManagementINI(new DirectoryInfo(".").FullName + @"\settings.ini");
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Costruttore personalizzato
        /// </summary>
        /// <param name="path">Percorso assoluto del file di configurazione</param>
        public Configuration(string path)
        {
            try
            {
                ini = new ManagementINI(path);
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }

        private ManagementINI ini;

        /* STRUTTURA DEL FILE INI
         * 
         * [Global]
         * PlayerDefaultPositionX = 105
         * PlayerDefaultPositionY = 200
         * 
         * [Game]
         * VelocitaAngolarePlayer = 1.5
         * AltezzaSalto = 2
         * VelocitaPlayerX = 2
         * LimiteY = 80
         * VelocitaBlocchiY = 1
         * VelocitaBlocchiX = 1
         * DeltaX = 150
         * VelocitaAsteroide = 3
         * VelocitaProiettile =2
         * 
         * [BasePath]
         * tx_sfondo_main = Textures\tx_sfondo_main.png
         * tx_sfondo_game = Textures\tx_sfondo_game.png
         * tx_stella = Textures\tx_stella.png
         * tx_titolo = Textures\tx_titolo.png
         * tx_hightScores = Textures\tx_hightScores.png
         * tx_player = Textures\tx_player.png
         * tx_dot = Textures\tx_dot.png
         * 
         * [ButtonsPath]
         * tx_btnPlay = Textures\Buttons\tx_btnPlay.png
         * tx_btnHight = Textures\Buttons\tx_btnHight.png
         * tx_btnExit = Textures\Buttons\tx_btnExit.png
         * tx_btnMenu = Textures\Buttons\tx_btnMenu.png
         * tx_btnReset = Textures\Buttons\tx_btnReset.png
         * tx_btnTryAgain = Textures\Buttons\tx_btnTryAgain.png
         * 
         * [BlocksPath]
         * tx_blockFalso = Textures\Blocks\tx_blockFalso.png
         * tx_blockFalsoDist = Textures\Blocks\tx_blockFalsoDist.png
         * tx_blockMovimOrriz = Textures\Blocks\tx_blockMovimOrriz.png
         * tx_blockMovimVert = Textures\Blocks\tx_blockMovimVert.png
         * tx_blockNormale = Textures\Blocks\tx_blockNormale.png
         * tx_blockSaltoSingolo = Textures\Blocks\tx_blockSaltoSingolo.png
         * tx_blockDistruttibile_1 = Textures\Blocks\tx_blockDistruttibile_1.png
         * tx_blockDistruttibile_2 = Textures\Blocks\tx_blockDistruttibile_2.png
         * tx_blockDistruttibile_3 = Textures\Blocks\tx_blockDistruttibile_3.png
         * tx_blockDistruttibile_4 = Textures\Blocks\tx_blockDistruttibile_4.png
         * tx_blockDistruttibile_5 = Textures\Blocks\tx_blockDistruttibile_5.png
         * [NemiciPath]
         * tx_nemico1=Textures\Enemy\tx_nemico1.png
         * tx_nemico2=Textures\Enemy\tx_nemico2.png
         * tx_nemico3=Textures\Enemy\tx_nemico3.png
         * tx_nemico4=Textures\Enemy\tx_nemico4.png
         * tx_nemico5=Textures\Enemy\tx_nemico5.png
         * tx_nemico6=Textures\Enemy\tx_nemico6.png
         * tx_nemico7=Textures\Enemy\tx_nemico7.png
         * [BonusPath]
         * tx_cappello=Textures\Bonus\tx_cappello.png
         * tx_cappello_player=Textures\Bonus\tx_cappello_player.png
         * tx_jetpack=Textures\Bonus\tx_jetpack.png
         * tx_jetpack_player=Textures\Bonus\tx_jetpack_player.png
         * tx_molla=Textures\Bonus\tx_molla.png
         * tx_razzo=Textures\Bonus\tx_razzo.png
         * tx_razzo_player=Textures\Bonus\tx_razzo_player.png
        */

        /// <summary>
        /// Resetta il contenuto del file ini con le impostazioni di default
        /// </summary>
        public void ResetOption()
        {
            #region OLD VERSION
            //// Sezione Global
            //Ini.IniWriteValue("Global", "PlayerDefaultPositionX", "105");
            //Ini.IniWriteValue("Global", "PlayerDefaultPositionY", "200");

            //// Sezione Game
            //Ini.IniWriteValue("Game", "VelocitaAngolarePlayer", "1.5");
            //Ini.IniWriteValue("Game", "AltezzaSalto", "2");
            //Ini.IniWriteValue("Game", "LimiteY", "80");
            //Ini.IniWriteValue("Game", "VelocitaBlocchiY", "1");
            //Ini.IniWriteValue("Game", "VelocitaBlocchiX", "1");
            //Ini.IniWriteValue("Game", "DeltaX", "150");
            //Ini.IniWriteValue("Game", "VelocitaAsteroide", "3");

            //// Sezione BasePath
            //Ini.IniWriteValue("BasePath", "tx_sfondo_main", @"Textures\tx_sfondo_main.png");
            //Ini.IniWriteValue("BasePath", "tx_sfondo_game", @"Textures\tx_sfondo_game.png");
            //Ini.IniWriteValue("BasePath", "tx_stella", @"Textures\tx_stella.png");
            //Ini.IniWriteValue("BasePath", "tx_titolo", @"Textures\tx_titolo.png");
            //Ini.IniWriteValue("BasePath", "tx_hightScores", @"Textures\tx_hightScores.png");
            //Ini.IniWriteValue("BasePath", "tx_player", @"Textures\tx_player.png");
            //Ini.IniWriteValue("BasePath", "tx_dot", @"Textures\tx_dot.png");

            //// Sezione ButtonsPath
            //Ini.IniWriteValue("ButtonsPath", "tx_btnPlay", @"Textures\Buttons\tx_btnPlay.png");
            //Ini.IniWriteValue("ButtonsPath", "tx_btnHIght", @"Textures\Buttons\tx_btnHight.png");
            //Ini.IniWriteValue("ButtonsPath", "tx_btnExit", @"Textures\Buttons\tx_btnExit.png");
            //Ini.IniWriteValue("ButtonsPath", "tx_btnMenu", @"Textures\Buttons\tx_btnMenu.png");
            //Ini.IniWriteValue("ButtonsPath", "tx_btnReset", @"Textures\Buttons\tx_btnReset.png");
            //Ini.IniWriteValue("ButtonsPath", "tx_btnTryAgain", @"Textures\Buttons\tx_btnTryAgain.png");

            //// Sezione BlocksPath
            //Ini.IniWriteValue("BlocksPath", "tx_blockFalso", @"Textures\Blocks\tx_blockFalso.png");
            //Ini.IniWriteValue("BlocksPath", "tx_blockFalsoDist", @"Textures\Blocks\tx_blockFalsoDist.png");
            //Ini.IniWriteValue("BlocksPath", "tx_blockMovimOrriz", @"Textures\Blocks\tx_blockMovimOrriz.png");
            //Ini.IniWriteValue("BlocksPath", "tx_blockMovimVert", @"Textures\Blocks\tx_blockMovimVert.png");
            //Ini.IniWriteValue("BlocksPath", "tx_blockNormale", @"Textures\Blocks\tx_blockNormale.png");
            //Ini.IniWriteValue("BlocksPath", "tx_blockSaltoSingolo", @"Textures\Blocks\tx_blockSaltoSingolo.png");
            //Ini.IniWriteValue("BlocksPath", "tx_blockDistruttibile_1", @"Textures\Blocks\tx_blockDistruttibile_1.png");
            //Ini.IniWriteValue("BlocksPath", "tx_blockDistruttibile_2", @"Textures\Blocks\tx_blockDistruttibile_2.png");
            //Ini.IniWriteValue("BlocksPath", "tx_blockDistruttibile_3", @"Textures\Blocks\tx_blockDistruttibile_3.png");
            //Ini.IniWriteValue("BlocksPath", "tx_blockDistruttibile_4", @"Textures\Blocks\tx_blockDistruttibile_4.png");
            //Ini.IniWriteValue("BlocksPath", "tx_blockDistruttibile_5", @"Textures\Blocks\tx_blockDistruttibile_5.png"); 
            #endregion
            #region NEW VERSION
            //source.Configs.Clear();
            
            //source.AddConfig("Global");
            //source.Configs["Global"].Set("PlayerDefaultPositionX", 105);
            //source.Configs["Global"].Set("PlayerDefaultPositionY", 200);

            //source.AddConfig("Game");
            //source.Configs["Game"].Set("VelocitaAngolarePlayer", 1.5f);
            //source.Configs["Game"].Set("AltezzaSalto", 2);
            //source.Configs["Game"].Set("VelocitaPlayerX", 2);
            //source.Configs["Game"].Set("LimiteY", 80);
            //source.Configs["Game"].Set("VelocitaBlocchiY", 1);
            //source.Configs["Game"].Set("VelocitaBlocchiX", 1);
            //source.Configs["Game"].Set("DeltaX", 150);
            //source.Configs["Game"].Set("VelocitaAsteroide", 3);

            //source.AddConfig("BasePath");
            //source.Configs["BasePath"].Set("tx_sfondo_main", @"Textures\tx_sfondo_main.png");
            //source.Configs["BasePath"].Set("tx_sfondo_game", @"Textures\tx_sfondo_game.png");
            //source.Configs["BasePath"].Set("tx_stella", @"Textures\tx_stella.png");
            //source.Configs["BasePath"].Set("tx_titolo", @"Textures\tx_titolo.png");
            //source.Configs["BasePath"].Set("tx_hightScores", @"Textures\tx_hightScores.png");
            //source.Configs["BasePath"].Set("tx_player", @"Textures\tx_player.png");
            //source.Configs["BasePath"].Set("tx_dot",@"Textures\tx_dot.png");

            //source.AddConfig("ButtonsPath");
            //source.Configs["ButtonsPath"].Set("tx_btnPlay", @"Textures\Buttons\tx_btnPlay.png");
            //source.Configs["ButtonsPath"].Set("tx_btnHight", @"Textures\Buttons\tx_btnHight.png");
            //source.Configs["ButtonsPath"].Set("tx_btnExit", @"Textures\Buttons\tx_btnExit.png");
            //source.Configs["ButtonsPath"].Set("tx_btnMenu", @"Textures\Buttons\tx_btnMenu.png");
            //source.Configs["ButtonsPath"].Set("tx_btnReset", @"Textures\Buttons\tx_btnReset.png");
            //source.Configs["ButtonsPath"].Set("tx_btnTryAgain", @"Textures\Buttons\tx_btnTryAgain.png");
            //source.Configs["ButtonsPath"].Set("tx_btnStats", @"Textures\Buttons\tx_btnStats.png");

            //source.AddConfig("BlocksPath");
            //source.Configs["BlocksPath"].Set("tx_blockFalso", @"Textures\Blocks\tx_blockFalso.png");
            //source.Configs["BlocksPath"].Set("tx_blockFalsoDist", @"Textures\Blocks\tx_blockFalsoDist.png");
            //source.Configs["BlocksPath"].Set("tx_blockMovimOrriz", @"Textures\Blocks\tx_blockMovimOrriz.png");
            //source.Configs["BlocksPath"].Set("tx_blockMovimVert", @"Textures\Blocks\tx_blockMovimVert.png");
            //source.Configs["BlocksPath"].Set("tx_blockNormale", @"Textures\Blocks\tx_blockNormale.png");
            //source.Configs["BlocksPath"].Set("tx_blockSaltoSingolo", @"Textures\Blocks\tx_blockSaltoSingolo.png");
            //source.Configs["BlocksPath"].Set("tx_blockDistruttibile_1", @"Textures\Blocks\tx_blockDistruttibile_1.png");
            //source.Configs["BlocksPath"].Set("tx_blockDistruttibile_2", @"Textures\Blocks\tx_blockDistruttibile_2.png");
            //source.Configs["BlocksPath"].Set("tx_blockDistruttibile_3", @"Textures\Blocks\tx_blockDistruttibile_3.png");
            //source.Configs["BlocksPath"].Set("tx_blockDistruttibile_4", @"Textures\Blocks\tx_blockDistruttibile_4.png");
            //source.Configs["BlocksPath"].Set("tx_blockDistruttibile_5", @"Textures\Blocks\tx_blockDistruttibile_5.png");

            //source.Save();
            #endregion            

            try
            {
                ini.WriteFile("Global", "PlayerDefaultPositionX", "105");
                ini.WriteFile("Global", "PlayerDefaultPositionY", "200");

                ini.WriteFile("Game", "VelocitaAngolarePlayer", "1,5");
                ini.WriteFile("Game", "AltezzaSalto", "2");
                ini.WriteFile("Game", "VelocitaPlayerX", "2");
                ini.WriteFile("Game", "LimiteY", "80");
                ini.WriteFile("Game", "VelocitaBlocchiY", "1");
                ini.WriteFile("Game", "VelocitaBlocchiX", "1");
                ini.WriteFile("Game", "DeltaX", "150");
                ini.WriteFile("Game", "VelocitaAsteroide", "3");
                ini.WriteFile("Game", "VelocitaProiettile", "2");

                ini.WriteFile("BasePath", "tx_sfondo_main", @"Textures\tx_sfondo_main.png");
                ini.WriteFile("BasePath", "tx_sfondo_game", @"Textures\tx_sfondo_game.png");
                ini.WriteFile("BasePath", "tx_stella", @"Textures\tx_stella.png");
                ini.WriteFile("BasePath", "tx_titolo", @"Textures\tx_titolo.png");
                ini.WriteFile("BasePath", "tx_hightScores", @"Textures\tx_hightScores.png");
                ini.WriteFile("BasePath", "tx_player", @"Textures\tx_player.png");
                ini.WriteFile("BasePath", "tx_dot", @"Textures\tx_dot.png");
                ini.WriteFile("BasePath", "tx_proiettile", @"Textures\tx_proiettile.png");

                ini.WriteFile("ButtonsPath", "tx_btnPlay", @"Textures\Buttons\tx_btnPlay.png");
                ini.WriteFile("ButtonsPath", "tx_btnHight", @"Textures\Buttons\tx_btnHight.png");
                ini.WriteFile("ButtonsPath", "tx_btnExit", @"Textures\Buttons\tx_btnExit.png");
                ini.WriteFile("ButtonsPath", "tx_btnMenu", @"Textures\Buttons\tx_btnMenu.png");
                ini.WriteFile("ButtonsPath", "tx_btnReset", @"Textures\Buttons\tx_btnReset.png");
                ini.WriteFile("ButtonsPath", "tx_btnTryAgain", @"Textures\Buttons\tx_btnTryAgain.png");
                ini.WriteFile("ButtonsPath", "tx_btnStats", @"Textures\Buttons\tx_btnStats.png");

                ini.WriteFile("BlocksPath", "tx_blockFalso", @"Textures\Blocks\tx_blockFalso.png");
                ini.WriteFile("BlocksPath", "tx_blockFalsoDist", @"Textures\Blocks\tx_blockFalsoDist.png");
                ini.WriteFile("BlocksPath", "tx_blockMovimOrriz", @"Textures\Blocks\tx_blockMovimOrriz.png");
                ini.WriteFile("BlocksPath", "tx_blockMovimVert", @"Textures\Blocks\tx_blockMovimVert.png");
                ini.WriteFile("BlocksPath", "tx_blockNormale", @"Textures\Blocks\tx_blockNormale.png");
                ini.WriteFile("BlocksPath", "tx_blockSaltoSingolo", @"Textures\Blocks\tx_blockSaltoSingolo.png");
                ini.WriteFile("BlocksPath", "tx_blockDistruttibile_1", @"Textures\Blocks\tx_blockDistruttibile_1.png");
                ini.WriteFile("BlocksPath", "tx_blockDistruttibile_2", @"Textures\Blocks\tx_blockDistruttibile_2.png");
                ini.WriteFile("BlocksPath", "tx_blockDistruttibile_3", @"Textures\Blocks\tx_blockDistruttibile_3.png");
                ini.WriteFile("BlocksPath", "tx_blockDistruttibile_4", @"Textures\Blocks\tx_blockDistruttibile_4.png");
                ini.WriteFile("BlocksPath", "tx_blockDistruttibile_5", @"Textures\Blocks\tx_blockDistruttibile_5.png");

                ini.WriteFile("NemiciPath", "tx_nemico1", @"Textures\Enemy\tx_nemico1.png");
                ini.WriteFile("NemiciPath", "tx_nemico2", @"Textures\Enemy\tx_nemico2.png");
                ini.WriteFile("NemiciPath", "tx_nemico3", @"Textures\Enemy\tx_nemico3.png");
                ini.WriteFile("NemiciPath", "tx_nemico4", @"Textures\Enemy\tx_nemico4.png");
                ini.WriteFile("NemiciPath", "tx_nemico5", @"Textures\Enemy\tx_nemico5.png");
                ini.WriteFile("NemiciPath", "tx_nemico6", @"Textures\Enemy\tx_nemico6.png");
                ini.WriteFile("NemiciPath", "tx_nemico7", @"Textures\Enemy\tx_nemico7.png");

                ini.WriteFile("BonusPath", "tx_cappello", @"Textures\Bonus\tx_cappello.png");
                ini.WriteFile("BonusPath", "tx_cappello_player", @"Textures\Bonus\tx_cappello_player.png");
                ini.WriteFile("BonusPath", "tx_jetpack", @"Textures\Bonus\tx_jetpack.png");
                ini.WriteFile("BonusPath", "tx_jetpack_player", @"Textures\Bonus\tx_jetpack_player.png");
                ini.WriteFile("BonusPath", "tx_molla", @"Textures\Bonus\tx_molla.png");
                ini.WriteFile("BonusPath", "tx_razzo", @"Textures\Bonus\tx_razzo.png");
                ini.WriteFile("BonusPath", "tx_razzo_player", @"Textures\Bonus\tx_razzo_player.png");
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
        /// <summary>
        /// Carica le impostazioni dal file ini
        /// </summary>
        public void LoadOption()
        {
            #region OLD VERSION
            //// Sezione Global
            //Costanti.PLAYER_DEFAULT_POSITION.X = float.Parse(Ini.IniReadValue("Global", "PlayerDefaultPositionX"));
            //Costanti.PLAYER_DEFAULT_POSITION.Y = float.Parse(Ini.IniReadValue("Global", "PlayerDefaultPositionY"));

            //// Sezione Game
            //Costanti.VELOCITA_ANGOLARE_PLAYER_Y = float.Parse(Ini.IniReadValue("Game", "VelocitaAngolarePlayer"));
            //Costanti.ALTEZZA_SALTO = float.Parse(Ini.IniReadValue("Game", "AltezzaSalto"));
            //Costanti.LIMITE_Y = float.Parse(Ini.IniReadValue("Game", "LimiteY"));
            //Costanti.VELOCITA_BLOCCHI_Y = float.Parse(Ini.IniReadValue("Game", "VelocitaBlocchiY"));
            //Costanti.VELOCITA_BLOCCHI_X = float.Parse(Ini.IniReadValue("Game", "VelocitaBlocchiX"));
            //Costanti.DELTA_X = float.Parse(Ini.IniReadValue("Game", "DeltaX"));
            //Costanti.VELOCTA_ASTEROIDE = float.Parse(Ini.IniReadValue("Game", "VelocitaAsteroide"));

            //// Sezione BasePath
            //Costanti.PATH_tx_sfondo_main = Ini.IniReadValue("BasePath", "tx_sfondo_main");
            //Costanti.PATH_tx_sfondo_game = Ini.IniReadValue("BasePath", "tx_sfondo_game");
            //Costanti.PATH_tx_stella = Ini.IniReadValue("BasePath", "tx_stella");
            //Costanti.PATH_tx_titolo = Ini.IniReadValue("BasePath", "tx_titolo");
            //Costanti.PATH_tx_hightScores = Ini.IniReadValue("BasePath", "tx_hightScores");
            //Costanti.PATH_tx_player = Ini.IniReadValue("BasePath", "tx_player");
            //Costanti.PATH_tx_dot = Ini.IniReadValue("BasePath", "tx_dot"); 
            #endregion
            #region OLD VERSION
            //Costanti.PLAYER_DEFAULT_POSITION.X = source.Configs["Global"].GetFloat("PlayerDefaultPositionX");
            //Costanti.PLAYER_DEFAULT_POSITION.Y = source.Configs["Global"].GetFloat("PlayerDefaultPositionY");

            //Costanti.VELOCITA_ANGOLARE_PLAYER_Y = source.Configs["Game"].GetFloat("VelocitaAngolarePlayer");
            //Costanti.ALTEZZA_SALTO = source.Configs["Game"].GetFloat("AltezzaSalto");
            //Costanti.VELOCITA_PLAYER_X = source.Configs["Game"].GetFloat("VelocitaPlayerX");
            //Costanti.LIMITE_Y = source.Configs["Game"].GetFloat("LimiteY");
            //Costanti.VELOCITA_BLOCCHI_Y = source.Configs["Game"].GetFloat("VelocitaBlocchiY");
            //Costanti.VELOCITA_BLOCCHI_X = source.Configs["Game"].GetFloat("VelocitaBlocchiX");
            //Costanti.DELTA_X = source.Configs["Game"].GetFloat("DeltaX");
            //Costanti.VELOCTA_ASTEROIDE = source.Configs["Game"].GetFloat("VelocitaAsteroide");

            //Costanti.PATH_tx_sfondo_main = source.Configs["BasePath"].GetString("tx_sfondo_main");
            //Costanti.PATH_tx_sfondo_game = source.Configs["BasePath"].GetString("tx_sfondo_game");
            //Costanti.PATH_tx_stella = source.Configs["BasePath"].GetString("tx_stella");
            //Costanti.PATH_tx_titolo = source.Configs["BasePath"].GetString("tx_titolo");
            //Costanti.PATH_tx_hightScores = source.Configs["BasePath"].GetString("tx_hightScores");
            //Costanti.PATH_tx_player = source.Configs["BasePath"].GetString("tx_player");
            //Costanti.PATH_tx_dot = source.Configs["BasePath"].GetString("tx_dot");

            //Costanti.PATHS_tx_btns = new string[7];
            //Costanti.PATHS_tx_btns[0] = source.Configs["ButtonsPath"].GetString("tx_btnPlay");
            //Costanti.PATHS_tx_btns[1] = source.Configs["ButtonsPath"].GetString("tx_btnHight");
            //Costanti.PATHS_tx_btns[2] = source.Configs["ButtonsPath"].GetString("tx_btnExit");
            //Costanti.PATHS_tx_btns[3] = source.Configs["ButtonsPath"].GetString("tx_btnMenu");
            //Costanti.PATHS_tx_btns[4] = source.Configs["ButtonsPath"].GetString("tx_btnReset");
            //Costanti.PATHS_tx_btns[5] = source.Configs["ButtonsPath"].GetString("tx_btnTryAgain");
            //Costanti.PATHS_tx_btns[6] = source.Configs["ButtonsPath"].GetString("tx_btnStats");

            //Costanti.PATHS_tx_blocks = new string[11];
            //Costanti.PATHS_tx_blocks[0] = source.Configs["BlocksPath"].GetString("tx_blockFalso");
            //Costanti.PATHS_tx_blocks[1] = source.Configs["BlocksPath"].GetString("tx_blockFalsoDist");
            //Costanti.PATHS_tx_blocks[2] = source.Configs["BlocksPath"].GetString("tx_blockMovimOrriz");
            //Costanti.PATHS_tx_blocks[3] = source.Configs["BlocksPath"].GetString("tx_blockMovimVert");
            //Costanti.PATHS_tx_blocks[4] = source.Configs["BlocksPath"].GetString("tx_blockNormale");
            //Costanti.PATHS_tx_blocks[5] = source.Configs["BlocksPath"].GetString("tx_blockSaltoSingolo");
            //Costanti.PATHS_tx_blocks[6] = source.Configs["BlocksPath"].GetString("tx_blockDistruttibile_1");
            //Costanti.PATHS_tx_blocks[7] = source.Configs["BlocksPath"].GetString("tx_blockDistruttibile_2");
            //Costanti.PATHS_tx_blocks[8] = source.Configs["BlocksPath"].GetString("tx_blockDistruttibile_3");
            //Costanti.PATHS_tx_blocks[9] = source.Configs["BlocksPath"].GetString("tx_blockDistruttibile_4");
            //Costanti.PATHS_tx_blocks[10] = source.Configs["BlocksPath"].GetString("tx_blockDistruttibile_5");
            #endregion

            try
            {
                Costanti.PLAYER_DEFAULT_POSITION.X = float.Parse(ini.ReadKey("Global", "PlayerDefaultPositionX"));
                Costanti.PLAYER_DEFAULT_POSITION.Y = float.Parse(ini.ReadKey("Global", "PlayerDefaultPositionY"));

                Costanti.VELOCITA_ANGOLARE_PLAYER_Y = float.Parse(ini.ReadKey("Game", "VelocitaAngolarePlayer"));
                Costanti.ALTEZZA_SALTO = float.Parse(ini.ReadKey("Game", "AltezzaSalto"));
                Costanti.VELOCITA_PLAYER_X = float.Parse(ini.ReadKey("Game", "VelocitaPlayerX"));
                Costanti.LIMITE_Y = float.Parse(ini.ReadKey("Game", "LimiteY"));
                Costanti.VELOCITA_BLOCCHI_Y = float.Parse(ini.ReadKey("Game", "VelocitaBlocchiY"));
                Costanti.VELOCITA_BLOCCHI_X = float.Parse(ini.ReadKey("Game", "VelocitaBlocchiX"));
                Costanti.DELTA_X = float.Parse(ini.ReadKey("Game", "DeltaX"));
                Costanti.VELOCTA_ASTEROIDE = float.Parse(ini.ReadKey("Game", "VelocitaAsteroide"));
                Costanti.VELOCITA_PROIETTILE = float.Parse(ini.ReadKey("Game", "VelocitaProiettile"));

                Costanti.PATH_tx_sfondo_main = ini.ReadKey("BasePath", "tx_sfondo_main");
                Costanti.PATH_tx_sfondo_game = ini.ReadKey("BasePath", "tx_sfondo_game");
                Costanti.PATH_tx_stella = ini.ReadKey("BasePath", "tx_stella");
                Costanti.PATH_tx_titolo = ini.ReadKey("BasePath", "tx_titolo");
                Costanti.PATH_tx_hightScores = ini.ReadKey("BasePath", "tx_hightScores");
                Costanti.PATH_tx_player = ini.ReadKey("BasePath", "tx_player");
                Costanti.PATH_tx_dot = ini.ReadKey("BasePath", "tx_dot");
                Costanti.PATH_tx_proiettile = ini.ReadKey("BasePath", "tx_proiettile");

                Costanti.PATHS_tx_btns = new string[7];
                Costanti.PATHS_tx_btns[0] = ini.ReadKey("ButtonsPath", "tx_btnPlay");
                Costanti.PATHS_tx_btns[1] = ini.ReadKey("ButtonsPath", "tx_btnHight");
                Costanti.PATHS_tx_btns[2] = ini.ReadKey("ButtonsPath", "tx_btnExit");
                Costanti.PATHS_tx_btns[3] = ini.ReadKey("ButtonsPath", "tx_btnMenu");
                Costanti.PATHS_tx_btns[4] = ini.ReadKey("ButtonsPath", "tx_btnReset");
                Costanti.PATHS_tx_btns[5] = ini.ReadKey("ButtonsPath", "tx_btnTryAgain");
                Costanti.PATHS_tx_btns[6] = ini.ReadKey("ButtonsPath", "tx_btnStats");

                Costanti.PATHS_tx_blocks = new string[11];
                Costanti.PATHS_tx_blocks[0] = ini.ReadKey("BlocksPath", "tx_blockFalso");
                Costanti.PATHS_tx_blocks[1] = ini.ReadKey("BlocksPath", "tx_blockFalsoDist");
                Costanti.PATHS_tx_blocks[2] = ini.ReadKey("BlocksPath", "tx_blockMovimOrriz");
                Costanti.PATHS_tx_blocks[3] = ini.ReadKey("BlocksPath", "tx_blockMovimVert");
                Costanti.PATHS_tx_blocks[4] = ini.ReadKey("BlocksPath", "tx_blockNormale");
                Costanti.PATHS_tx_blocks[5] = ini.ReadKey("BlocksPath", "tx_blockSaltoSingolo");
                Costanti.PATHS_tx_blocks[6] = ini.ReadKey("BlocksPath", "tx_blockDistruttibile_1");
                Costanti.PATHS_tx_blocks[7] = ini.ReadKey("BlocksPath", "tx_blockDistruttibile_2");
                Costanti.PATHS_tx_blocks[8] = ini.ReadKey("BlocksPath", "tx_blockDistruttibile_3");
                Costanti.PATHS_tx_blocks[9] = ini.ReadKey("BlocksPath", "tx_blockDistruttibile_4");
                Costanti.PATHS_tx_blocks[10] = ini.ReadKey("BlocksPath", "tx_blockDistruttibile_5");

                Costanti.PATHS_tx_nemici = new string[7];
                Costanti.PATHS_tx_nemici[0] = ini.ReadKey("NemiciPath", "tx_nemico1");
                Costanti.PATHS_tx_nemici[1] = ini.ReadKey("NemiciPath", "tx_nemico2");
                Costanti.PATHS_tx_nemici[2] = ini.ReadKey("NemiciPath", "tx_nemico3");
                Costanti.PATHS_tx_nemici[3] = ini.ReadKey("NemiciPath", "tx_nemico4");
                Costanti.PATHS_tx_nemici[4] = ini.ReadKey("NemiciPath", "tx_nemico5");
                Costanti.PATHS_tx_nemici[5] = ini.ReadKey("NemiciPath", "tx_nemico6");
                Costanti.PATHS_tx_nemici[6] = ini.ReadKey("NemiciPath", "tx_nemico7");

                Costanti.PATHS_tx_bonus = new string[7];
                Costanti.PATHS_tx_bonus[0] = ini.ReadKey("BonusPath", "tx_cappello");
                Costanti.PATHS_tx_bonus[1] = ini.ReadKey("BonusPath", "tx_cappello_player");
                Costanti.PATHS_tx_bonus[2] = ini.ReadKey("BonusPath", "tx_jetpack");
                Costanti.PATHS_tx_bonus[3] = ini.ReadKey("BonusPath", "tx_jetpack_player");
                Costanti.PATHS_tx_bonus[4] = ini.ReadKey("BonusPath", "tx_molla");
                Costanti.PATHS_tx_bonus[5] = ini.ReadKey("BonusPath", "tx_razzo");
                Costanti.PATHS_tx_bonus[6] = ini.ReadKey("BonusPath", "tx_razzo_player");
            }
            catch (Exception ex)
            {
                Debug.Fail("ERRORE FATALE", "\nContattare il produttore e riavviare il gioco.\nE' opportuno fare uno screenshot di questo messaggio di errore e mostrarlo al produttore\n\n\nDETTAGLI: \n\n" + ex.Message);
            }
        }
    }
}
