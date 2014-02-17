using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace AudioTest
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        SoundEffect sound;

        public Game1()
        {
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            sound = Content.Load<SoundEffect>("Sonoro");
            sound.Play();
            base.Initialize();
        }
    }
}
