using System;
using System.Collections.Generic;
using System.Data;
using DinoGame2.Game.Casting;
using DinoGame2.Game.Services;

namespace DinoGame2.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the dino 
    /// collides with the enemy, or the dino collides with the goal, or the game is over.
    /// </para>
    /// </summary>
    public class Handle_collision : Action
    {
        private bool isGameOver = false;
        /// <summary>
        /// Constructs a new instance of Handle_collision.
        /// </summary>
        public Handle_collision()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {
                HandleEnemyCollisions(cast);
                HandleGoalCollisions(cast);
                HandleGameOver(cast);
            }
        }

        /// <summary>
        /// Updates the score and moves the player if the Dino touches the goal.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleGoalCollisions(Cast cast)
        {
            List<Actor> enemies = cast.GetActors("emeny");
            Dino dino = (Dino)cast.GetFirstActor("dino");
            Score score = (Score)cast.GetFirstActor("score");
            Actor banner = cast.GetFirstActor("banner");
            Goal goal = (Goal)cast.GetFirstActor("goal");

            //turn score into an int
            int BannerAsINT = int.Parse(banner.GetText());
            if (dino.GetPosition().Equals(goal.GetPosition()))
            {
            //starts a new level
                //updates the score on the banner
                BannerAsINT += Constants.GoalPoints;
                string NewTotalAsString = BannerAsINT.ToString();
                banner.SetText(NewTotalAsString);

                //Moves dino back to spawn point
                dino.SetPosition(Constants.DinoSpawn);

                //delete all enemies from screen
                foreach (Actor enemy in enemies)
                {
                    cast.RemoveActor("enemy", enemy);
                }
                
                //spawn new enemies
                Enemy.SpawnEnemies();

            }
        }

        //code for if the player touches an enemy
        private void HandleEnemyCollisions(Cast cast)
        {
            List<Actor> enemies = cast.GetActors("emeny");
            Dino dino = (Dino)cast.GetFirstActor("dino");
            Score score = (Score)cast.GetFirstActor("score");
            Actor banner = cast.GetFirstActor("banner");
            Goal goal = (Goal)cast.GetFirstActor("goal");
            List<Actor> dinos = cast.GetActors("dino");

            //turn score into an int
            int BannerAsINT = int.Parse(banner.GetText());
            foreach (Actor enemy in enemies)
            {
                if (dino.GetPosition().Equals(enemy.GetPosition()))
                {
                    //initiate game over
                    isGameOver = true;
                }
            }
        }

        private void HandleGameOver(Cast cast)
        {
            Actor banner = cast.GetFirstActor("banner");
            int BannerAsINT = int.Parse(banner.GetText());

            if (isGameOver == true)
            {
                //make a game over screen and display the final score
                Actor GameOverMessage = new Actor();
                GameOverMessage.SetText($"Game Over \n Score: {BannerAsINT}");
                GameOverMessage.SetPosition(Constants.GameOverMessagePosition);
                cast.AddActor("messages", GameOverMessage);

                //for now we'll just delete the dino if it touches a bad guy. later I'd like to make a class to make it so you can start a new game.

                // not sure if this will work, but it is just deleting everything in the cast resembles a dino
                List<Actor> dinos = cast.GetActors("dino");
                foreach (Actor player in dinos)
                {
                    cast.RemoveActor("dino", player);
                }
            }
        }
    }
}