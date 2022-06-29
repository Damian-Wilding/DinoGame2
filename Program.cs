﻿using DinoGame2.Game.Casting;
using DinoGame2.Game.Directing;
using DinoGame2.Game.Scripting;
using DinoGame2.Game.Services;

namespace DinoGame2.Game
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            //creating the cast
            Cast cast = new Cast();
            cast.AddActor("Dino", new Dino());
            cast.AddActor("Enemy", new Enemy());
            cast.AddActor("Goal", new Goal());
            cast.AddActor("Score", new Score());

            //creating a banner to show the score
            Actor banner = new Actor();
            banner.SetText("0");
            banner.SetFontSize(FONT_SIZE);
            banner.SetColor(WHITE);
            banner.SetPosition(new Point(CELL_SIZE, 0));
            cast.AddActor("banner", banner);

            //create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);

            //creating the script
            Script script = new Script();
            script.AddAction("input", new Control_actors_action(keyboardService));
            script.AddAction("update", new Handle_collision());
            script.AddAction("update", new Movement());
            script.AddAction("output", new Draw_actors(videoService));

            //start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}