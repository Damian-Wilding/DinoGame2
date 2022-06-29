using System.Collections.Generic;
using DinoGame2.Casting;
using DinoGame2.Services;


namespace DinoGame2.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of Draw_actors is to draw each of the actors.</para>
    /// </summary>
    public class Draw_actors : Action
    {
        private VideoService videoService;

        /// <summary>
        /// Constructs a new instance of Contro_actor_action using the given KeyboardService.
        /// </summary>
        public Draw_actors(VideoService videoService)
        {
            this.videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Dino dino = (Dino)cast.GetFirstActor("dino");
            Score score = (Score)cast.GetFirstActor("score");
            global goal = (Goal)cast.GetFirstActor("goal");
            Enemy enemy = new Enemy();
            List<Actor> enemies = enemy.GetAllActors();
            

    
            //Actor score = cast.GetFirstActor("score");
            //Actor food = cast.GetFirstActor("food");
            //List<Actor> messages = cast.GetActors("messages");
            
            videoService.ClearBuffer();
            //videoService.DrawActors(segments);
            videoService.DrawActor(score);
            videoService.DrawActor(dino);
            videoService.DrawActor(goal);
            //videoService.DrawActor(food);
            videoService.DrawActors(enemies);
            videoService.FlushBuffer();
        }
    }
}