﻿
using System;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;



namespace LearnOpenTK
{
     class Program
    {
        static void Main(string[] args)
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new Vector2i(900, 700),
                Title = "Tarea 1 - Televisor",
            };

            using (var game = new tarea1.Game(GameWindowSettings.Default, nativeWindowSettings))


            {
                game.Run();
            }
        }
    }
}