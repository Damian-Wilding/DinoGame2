using DinoGame2.Game.Casting;
using DinoGame2.Game.Services;


namespace DinoGame2.Game.Scripting
{
    /// <summary>
    /// <para>An input action that controls the Dino.</para>
    /// <para>
    /// The responsibility of ControlActorsAction is to get the direction and move the Dino in that direction.
    /// </para>
    /// </summary>
    public class Control_actors_action : Action
    {
        private KeyboardService keyboardService;
        private Point direction = new Point(Constants.CELL_SIZE, 0);

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public Control_actors_action(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            // left
            if (keyboardService.IsKeyDown("left"))
            {
                direction = new Point(-Constants.CELL_SIZE, 0);
                System.Console.WriteLine("moving left");
                cast.GetFirstActor("dino").SetVelocity(direction);
            }

            // right
            if (keyboardService.IsKeyDown("right"))
            {
                direction = new Point(Constants.CELL_SIZE, 0);
                System.Console.WriteLine("moving right");
            }

            // up
            if (keyboardService.IsKeyDown("up"))
            {
                direction = new Point(0, -Constants.CELL_SIZE);
                System.Console.WriteLine("moving up");
            }

            // down
            if (keyboardService.IsKeyDown("down"))
            {
                direction = new Point(0, Constants.CELL_SIZE);
                System.Console.WriteLine("moving down");
            }
            System.Console.WriteLine(direction.GetX());
            direction = new Point(0, 0);
            cast.GetFirstActor("dino").SetVelocity(direction);
        }
    }
} 