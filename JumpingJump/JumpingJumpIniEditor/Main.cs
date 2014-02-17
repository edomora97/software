using System;
using System.Windows.Forms;
using System.IO;

namespace JumpingJump.IniEditor
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();            
        }
        ManagementINI ini;
        string path;
        
        private void btnSfoglia_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                path = openFileDialog.FileName;
            btnCarica_Click(sender, e);
        }

        private void btnCarica_Click(object sender, EventArgs e)
        {
            #region OLD VERSION
            //source = new IniConfigSource(path);
            //this.playerDefaultPositionX.Text = source.Configs["Global"].GetString("PlayerDefaultPositionX");
            //this.playerDefaultPositionY.Text = source.Configs["Global"].GetString("PlayerDefaultPositionY");

            //this.velocitaAngolarePlayer.Text = source.Configs["Game"].GetString("VelocitaAngolarePlayer");
            //this.altezzaSalto.Text = source.Configs["Game"].GetString("AltezzaSalto");
            //this.velocitaPlayerX.Text = source.Configs["Game"].GetString("VelocitaPlayerX");
            //this.limiteY.Text = source.Configs["Game"].GetString("LimiteY");
            //this.velocitaBlocchiY.Text = source.Configs["Game"].GetString("VelocitaBlocchiY");
            //this.velocitaBlocchiX.Text = source.Configs["Game"].GetString("VelocitaBlocchiX");
            //this.deltaX.Text = source.Configs["Game"].GetString("DeltaX");
            //this.velocitaAsteroide.Text = source.Configs["Game"].GetString("VelocitaAsteroide");

            //this.sfondo_main.Text = source.Configs["BasePath"].GetString("tx_sfondo_main");
            //this.sfondo_game.Text = source.Configs["BasePath"].GetString("tx_sfondo_game");
            //this.stella.Text = source.Configs["BasePath"].GetString("tx_stella");
            //this.titolo.Text = source.Configs["BasePath"].GetString("tx_titolo");
            //this.hightScores.Text = source.Configs["BasePath"].GetString("tx_hightScores");
            //this.player.Text = source.Configs["BasePath"].GetString("tx_player");
            //this.dot.Text = source.Configs["BasePath"].GetString("tx_dot");

            //this.bPlay.Text = source.Configs["ButtonsPath"].GetString("tx_btnPlay");
            //this.bHight.Text = source.Configs["ButtonsPath"].GetString("tx_btnHight");
            //this.bExit.Text = source.Configs["ButtonsPath"].GetString("tx_btnExit");
            //this.bMenu.Text = source.Configs["ButtonsPath"].GetString("tx_btnMenu");
            //this.bReset.Text = source.Configs["ButtonsPath"].GetString("tx_btnReset");
            //this.bTryAgain.Text = source.Configs["ButtonsPath"].GetString("tx_btnTryAgain");
            //this.bStats.Text = source.Configs["ButtonsPath"].GetString("tx_btnStats");

            //this.blFalso.Text = source.Configs["BlocksPath"].GetString("tx_blockFalso");
            //this.blFalsoD.Text = source.Configs["BlocksPath"].GetString("tx_blockFalsoDist");
            //this.blMovimOrriz.Text = source.Configs["BlocksPath"].GetString("tx_blockMovimOrriz");
            //this.blMovimVert.Text = source.Configs["BlocksPath"].GetString("tx_blockMovimVert");
            //this.blNormale.Text = source.Configs["BlocksPath"].GetString("tx_blockNormale");
            //this.blSaltoSingolo.Text = source.Configs["BlocksPath"].GetString("tx_blockSaltoSingolo");
            //this.blDist1.Text = source.Configs["BlocksPath"].GetString("tx_blockDistruttibile_1");
            //this.blDist2.Text = source.Configs["BlocksPath"].GetString("tx_blockDistruttibile_2");
            //this.blDist3.Text = source.Configs["BlocksPath"].GetString("tx_blockDistruttibile_3");
            //this.blDist4.Text = source.Configs["BlocksPath"].GetString("tx_blockDistruttibile_4");
            //this.blDist5.Text = source.Configs["BlocksPath"].GetString("tx_blockDistruttibile_5"); 
            #endregion
            if (path == null)
            {
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    path = openFileDialog.FileName;
            }
            if (path != null)
            {
                ini = new ManagementINI(path);
                this.playerDefaultPositionX.Text = ini.ReadKey("Global", "PlayerDefaultPositionX");
                this.playerDefaultPositionY.Text = ini.ReadKey("Global", "PlayerDefaultPositionY");

                this.velocitaAngolarePlayer.Text = ini.ReadKey("Game", "VelocitaAngolarePlayer");
                this.altezzaSalto.Text = ini.ReadKey("Game", "AltezzaSalto");
                this.velocitaPlayerX.Text = ini.ReadKey("Game", "VelocitaPlayerX");
                this.limiteY.Text = ini.ReadKey("Game", "LimiteY");
                this.velocitaBlocchiY.Text = ini.ReadKey("Game", "VelocitaBlocchiY");
                this.velocitaBlocchiX.Text = ini.ReadKey("Game", "VelocitaBlocchiX");
                this.deltaX.Text = ini.ReadKey("Game", "DeltaX");
                this.velocitaAsteroide.Text = ini.ReadKey("Game", "VelocitaAsteroide");

                this.sfondo_main.Text = ini.ReadKey("BasePath", "tx_sfondo_main");
                this.sfondo_game.Text = ini.ReadKey("BasePath", "tx_sfondo_game");
                this.stella.Text = ini.ReadKey("BasePath", "tx_stella");
                this.titolo.Text = ini.ReadKey("BasePath", "tx_titolo");
                this.hightScores.Text = ini.ReadKey("BasePath", "tx_hightScores");
                this.player.Text = ini.ReadKey("BasePath", "tx_player");
                this.dot.Text = ini.ReadKey("BasePath", "tx_dot");

                this.bPlay.Text = ini.ReadKey("ButtonsPath", "tx_btnPlay");
                this.bHight.Text = ini.ReadKey("ButtonsPath", "tx_btnHight");
                this.bExit.Text = ini.ReadKey("ButtonsPath", "tx_btnExit");
                this.bMenu.Text = ini.ReadKey("ButtonsPath", "tx_btnMenu");
                this.bReset.Text = ini.ReadKey("ButtonsPath", "tx_btnReset");
                this.bTryAgain.Text = ini.ReadKey("ButtonsPath", "tx_btnTryAgain");
                this.bStats.Text = ini.ReadKey("ButtonsPath", "tx_btnStats");

                this.blFalso.Text = ini.ReadKey("BlocksPath", "tx_blockFalso");
                this.blFalsoD.Text = ini.ReadKey("BlocksPath", "tx_blockFalsoDist");
                this.blMovimOrriz.Text = ini.ReadKey("BlocksPath", "tx_blockMovimOrriz");
                this.blMovimVert.Text = ini.ReadKey("BlocksPath", "tx_blockMovimVert");
                this.blNormale.Text = ini.ReadKey("BlocksPath", "tx_blockNormale");
                this.blSaltoSingolo.Text = ini.ReadKey("BlocksPath", "tx_blockSaltoSingolo");
                this.blDist1.Text = ini.ReadKey("BlocksPath", "tx_blockDistruttibile_1");
                this.blDist2.Text = ini.ReadKey("BlocksPath", "tx_blockDistruttibile_2");
                this.blDist3.Text = ini.ReadKey("BlocksPath", "tx_blockDistruttibile_3");
                this.blDist4.Text = ini.ReadKey("BlocksPath", "tx_blockDistruttibile_4");
                this.blDist5.Text = ini.ReadKey("BlocksPath", "tx_blockDistruttibile_5");
            }
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            #region OLD VERSION
            //source = new IniConfigSource(path);
            //source.Configs.Clear();

            //source.AddConfig("Global");
            //source.Configs["Global"].Set("PlayerDefaultPositionX", float.Parse(this.playerDefaultPositionX.Text));
            //source.Configs["Global"].Set("PlayerDefaultPositionY", float.Parse(this.playerDefaultPositionY.Text));

            //source.AddConfig("Game");
            //source.Configs["Game"].Set("VelocitaAngolarePlayer", float.Parse(this.velocitaAngolarePlayer.Text));
            //source.Configs["Game"].Set("AltezzaSalto", float.Parse(this.altezzaSalto.Text));
            //source.Configs["Game"].Set("VelocitaPlayerX", float.Parse(this.velocitaPlayerX.Text));
            //source.Configs["Game"].Set("LimiteY", float.Parse(this.limiteY.Text));
            //source.Configs["Game"].Set("VelocitaBlocchiY", float.Parse(this.velocitaBlocchiY.Text));
            //source.Configs["Game"].Set("VelocitaBlocchiX", float.Parse(this.velocitaBlocchiX.Text));
            //source.Configs["Game"].Set("DeltaX", float.Parse(this.deltaX.Text));
            //source.Configs["Game"].Set("VelocitaAsteroide", float.Parse(this.velocitaAsteroide.Text));

            //source.AddConfig("BasePath");
            //source.Configs["BasePath"].Set("tx_sfondo_main", this.sfondo_main.Text);
            //source.Configs["BasePath"].Set("tx_sfondo_game", this.sfondo_game.Text);
            //source.Configs["BasePath"].Set("tx_stella", this.stella.Text);
            //source.Configs["BasePath"].Set("tx_titolo", this.titolo.Text);
            //source.Configs["BasePath"].Set("tx_hightScores", this.hightScores.Text);
            //source.Configs["BasePath"].Set("tx_player", this.player.Text);
            //source.Configs["BasePath"].Set("tx_dot", this.dot.Text);

            //source.AddConfig("ButtonsPath");
            //source.Configs["ButtonsPath"].Set("tx_btnPlay", this.bPlay.Text);
            //source.Configs["ButtonsPath"].Set("tx_btnHight", this.bHight.Text);
            //source.Configs["ButtonsPath"].Set("tx_btnExit", this.bExit.Text);
            //source.Configs["ButtonsPath"].Set("tx_btnMenu", this.bMenu.Text);
            //source.Configs["ButtonsPath"].Set("tx_btnReset", this.bReset.Text);
            //source.Configs["ButtonsPath"].Set("tx_btnTryAgain", this.bTryAgain.Text);
            //source.Configs["ButtonsPath"].Set("tx_btnStats", this.bStats.Text);

            //source.AddConfig("BlocksPath");
            //source.Configs["BlocksPath"].Set("tx_blockFalso", this.blFalso.Text);
            //source.Configs["BlocksPath"].Set("tx_blockFalsoDist", this.blFalsoD.Text);
            //source.Configs["BlocksPath"].Set("tx_blockMovimOrriz", this.blMovimOrriz.Text);
            //source.Configs["BlocksPath"].Set("tx_blockMovimVert", this.blMovimVert.Text);
            //source.Configs["BlocksPath"].Set("tx_blockNormale", this.blNormale.Text);
            //source.Configs["BlocksPath"].Set("tx_blockSaltoSingolo", this.blSaltoSingolo.Text);
            //source.Configs["BlocksPath"].Set("tx_blockDistruttibile_1", this.blDist1.Text);
            //source.Configs["BlocksPath"].Set("tx_blockDistruttibile_2", this.blDist2.Text);
            //source.Configs["BlocksPath"].Set("tx_blockDistruttibile_3", this.blDist3.Text);
            //source.Configs["BlocksPath"].Set("tx_blockDistruttibile_4", this.blDist4.Text);
            //source.Configs["BlocksPath"].Set("tx_blockDistruttibile_5", this.blDist5.Text);

            //source.Save(); 
            #endregion

            if (path == null)
                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    path = saveFileDialog.FileName;
            if (path != null)
            {
                ini = new ManagementINI(path);
                ini.WriteFile("Global", "PlayerDefaultPositionX", this.playerDefaultPositionX.Text);
                ini.WriteFile("Global", "PlayerDefaultPositionY", this.playerDefaultPositionY.Text);

                ini.WriteFile("Game", "VelocitaAngolarePlayer", this.velocitaAngolarePlayer.Text);
                ini.WriteFile("Game", "AltezzaSalto", this.altezzaSalto.Text);
                ini.WriteFile("Game", "VelocitaPlayerX", this.velocitaPlayerX.Text);
                ini.WriteFile("Game", "LimiteY", this.limiteY.Text);
                ini.WriteFile("Game", "VelocitaBlocchiY", this.velocitaBlocchiY.Text);
                ini.WriteFile("Game", "VelocitaBlocchiX", this.velocitaBlocchiX.Text);
                ini.WriteFile("Game", "DeltaX", this.deltaX.Text);
                ini.WriteFile("Game", "VelocitaAsteroide", this.velocitaAsteroide.Text);

                ini.WriteFile("BasePath", "tx_sfondo_main", this.sfondo_main.Text);
                ini.WriteFile("BasePath", "tx_sfondo_game", this.sfondo_game.Text);
                ini.WriteFile("BasePath", "tx_stella", this.stella.Text);
                ini.WriteFile("BasePath", "tx_titolo", this.titolo.Text);
                ini.WriteFile("BasePath", "tx_hightScores", this.hightScores.Text);
                ini.WriteFile("BasePath", "tx_player", this.player.Text);
                ini.WriteFile("BasePath", "tx_dot", this.dot.Text);

                ini.WriteFile("ButtonsPath", "tx_btnPlay", this.bPlay.Text);
                ini.WriteFile("ButtonsPath", "tx_btnHight", this.bHight.Text);
                ini.WriteFile("ButtonsPath", "tx_btnExit", this.bExit.Text);
                ini.WriteFile("ButtonsPath", "tx_btnMenu", this.bMenu.Text);
                ini.WriteFile("ButtonsPath", "tx_btnReset", this.bReset.Text);
                ini.WriteFile("ButtonsPath", "tx_btnTryAgain", this.bTryAgain.Text);
                ini.WriteFile("ButtonsPath", "tx_btnStats", this.bStats.Text);

                ini.WriteFile("BlocksPath", "tx_blockFalso", this.blFalso.Text);
                ini.WriteFile("BlocksPath", "tx_blockFalsoDist", this.blFalsoD.Text);
                ini.WriteFile("BlocksPath", "tx_blockMovimOrriz", this.blMovimOrriz.Text);
                ini.WriteFile("BlocksPath", "tx_blockMovimVert", this.blMovimVert.Text);
                ini.WriteFile("BlocksPath", "tx_blockNormale", this.blNormale.Text);
                ini.WriteFile("BlocksPath", "tx_blockSaltoSingolo", this.blSaltoSingolo.Text);
                ini.WriteFile("BlocksPath", "tx_blockDistruttibile_1", this.blDist1.Text);
                ini.WriteFile("BlocksPath", "tx_blockDistruttibile_2", this.blDist2.Text);
                ini.WriteFile("BlocksPath", "tx_blockDistruttibile_3", this.blDist3.Text);
                ini.WriteFile("BlocksPath", "tx_blockDistruttibile_4", this.blDist4.Text);
                ini.WriteFile("BlocksPath", "tx_blockDistruttibile_5", this.blDist5.Text);

                btnCarica_Click(sender, e);
            }
        }
    }
}
