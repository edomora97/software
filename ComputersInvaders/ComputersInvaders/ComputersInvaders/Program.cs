using System;

namespace ComputersInvaders
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (ComputersInveders game = new ComputersInveders())
            {
                game.Run();
            }
        }
    }
#endif
}

