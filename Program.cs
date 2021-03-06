using DinoGame2.Game.Casting;
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
            cast.AddActor("dino", new Dino());
            cast.AddActor("enemy", new Enemy());
            //cast.AddActor("enemy", new Enemy());
            cast.AddActor("score", new Score());
            cast.AddActor("goal", new Goal());

            //////////////////for (int i = 1; i <= Constants.COLUMNS; i++)
            //////////////////{
            //////////////////    Goal goal = new Goal();
            //////////////////    Point position = new Point(i * Constants.CELL_SIZE, 0);
            //////////////////    goal.SetPosition(position);
            //////////////////    
            //////////////////}
            

            //creating a banner to show the score
            //Actor banner = new Actor();
            //banner.SetText("0");
            //banner.SetFontSize(Constants.FONT_SIZE);
            //banner.SetColor(Constants.WHITE);
            //banner.SetPosition(new Point(Constants.CELL_SIZE, 0));
            //cast.AddActor("banner", banner);

            //create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);

            //creating the script
            Script script = new Script();
            script.AddAction("input", new ControlActorsAction(keyboardService));
            script.AddAction("update", new HandleCollision());
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("output", new DrawActors(videoService));

            //start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}