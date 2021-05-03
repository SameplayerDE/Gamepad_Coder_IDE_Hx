using System;
using Monogame_VS2019_Hx002_Physicstest;

namespace Gamepad_Coder_IDE_Hx
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new IDE())
                game.Run();
        }
    }
}