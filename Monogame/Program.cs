﻿using System;


class Program
{
    static void Main()
    {
        using (var game = new Monogame.Game1())
        {
            game.Run();
        }
    }
}


