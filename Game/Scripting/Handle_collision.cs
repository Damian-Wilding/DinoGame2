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
            //Goal goal = (Goal)cast.GetFirstActor("goal");
            List<Actor> goal = cast.GetActors("goal");

            //turn score into an int
            int BannerAsINT = int.Parse(banner.GetText());

            
            foreach (Actor goalSegment in goal)
            {
                if (dino.GetPosition().Equals(goalSegment.GetPosition()))
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
                    SpawnEnemies();
                }
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

        private void SpawnEnemies()

        {
            //first delete all enemies from the game
            Cast cast = new Cast();
            List<Actor> enemies = cast.GetActors("emeny");
            foreach (Actor enemy in enemies)
                {
                    cast.RemoveActor("enemy", enemy);
                }

            //spawn the enemies every round
            
            //loop that will run 3 times (to spawn 3 enemies)
            for (int i = 0; i < 3; i++)
            {
                //make new enemy
                Enemy enemy = new Enemy();
                //sets the enemies color
                enemy.SetColor(Constants.RED);
                //set his position
                Random random = new Random();
                int RandomNumber = random.Next(Constants.Enemy_Min_Row, Constants.Enemy_Max_Row);
                enemy.SetPosition(new Point (Constants.MAX_X / 2,RandomNumber * Constants.CELL_SIZE));
                // gives the enemies a text
                enemy.SetText("O");
                //add that enemy to the cast
                cast.AddActor("emeny", enemy);
            }
        
        }
    }
}