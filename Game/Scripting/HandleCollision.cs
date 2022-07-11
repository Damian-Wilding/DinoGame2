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
    public class HandleCollision : Action
    {
        private bool isGameOver = false;
        List<List<Point>> allEnemiesHitboxList = new List<List<Point>>();
        /// <summary>
        /// Constructs a new instance of Handle_collision.
        /// </summary>
        public HandleCollision()
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
            //else
            //{
            //    HandleEnemyCollisions(cast);
            //    HandleGoalCollisions(cast);
            //}
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
            Goal goal = (Goal)cast.GetFirstActor("goal");
            

            //turn score into an int
            
            //System.Console.WriteLine(int.Parse(score.text));

            if (dino.GetPosition().GetY() <= goal.GoalsHitBoxY)
            {
                dino.SetPosition(Constants.DinoSpawn);
                foreach (Enemy enemy in enemies)
                {
                    cast.RemoveActor("enemy", enemy);
                    cast.AddActor("enemy", enemy);
                }

                int ScoreAsINT = int.Parse(score.GetText());
                System.Console.WriteLine(score.GetText());
                System.Console.WriteLine(ScoreAsINT); 
                // add the goal points
                ScoreAsINT += goal.points;

                // turn it back into a string
                string NewScore = ScoreAsINT.ToString();

                // set that new score as the score to be displayed
                score.SetText(NewScore);

            }
        }

        //code for if the player touches an enemy
        private void HandleEnemyCollisions(Cast cast)
        {
            List<Actor> enemies = cast.GetActors("enemy");
            Dino dino = (Dino)cast.GetFirstActor("dino");
            Score score = (Score)cast.GetFirstActor("score");
            Goal goal = (Goal)cast.GetFirstActor("goal");
            List<Actor> dinos = cast.GetActors("dino");
            string yeah = score.GetText();
            //turn score into an int
            // temporary fix
            //int BannerAsINT = int.Parse(yeah);
            int BannerAsINT = 0;

            allEnemiesHitboxList.Clear();
            foreach (Enemy enemy in enemies)
            {
                enemy.SetHitboxList();
                allEnemiesHitboxList.Add(enemy.GetHitboxList());
            }

            dino.SetHitboxList();
            foreach (Point DinoPoint in dino.dinoHitboxList)
            {
                foreach (Enemy enemy in enemies)
                {
                    enemy.SetHitboxList();
                    Point enemyPosition_TopLeft = enemy.enemyHitboxList[0];
                    Point enemyPosition_BottomRight = enemy.enemyHitboxList[3];
                    int enemyPosition_TopLeftX = enemyPosition_TopLeft.GetX();
                    int enemyPosition_TopLeftY = enemyPosition_TopLeft.GetY();
                    int enemyPosition_BottomRightX = enemyPosition_BottomRight.GetX();
                    int enemyPosition_BottomRightY = enemyPosition_BottomRight.GetY();

                    
                    int dinoX = DinoPoint.GetX();
                    int dinoY = DinoPoint.GetY();
                    
                    // Checks to see if any of the corners of the dino hitbox are inside the enemy.
                    if ((Enumerable.Range(enemyPosition_TopLeftX, enemy.GetFontSize() + 1).Contains(dinoX)) && (Enumerable.Range(enemyPosition_TopLeftY, enemy.GetFontSize() + 1).Contains(dinoY)))
                    {
                        isGameOver = true;
                        break;
                    }
                }
            }
        }

        private void HandleGameOver(Cast cast)
        {
            Actor score = cast.GetFirstActor("score");
            //int BannerAsINT = int.Parse(score.GetText());
            //temporary fix
            int BannerAsINT = 0;

            if (isGameOver == true)
            {
                //make a game over screen and display the final score
                Actor GameOverMessage = new Actor();
                GameOverMessage.SetText($"Game Over \n Score: {BannerAsINT}");
                GameOverMessage.SetPosition(Constants.GameOverMessagePosition);
                GameOverMessage.SetColor(Constants.WHITE);
                GameOverMessage.SetFontSize(Constants.DinoAndEnemyFont_Size);
                cast.AddActor("messages", GameOverMessage);

                //for now we'll just delete the dino if it touches a bad guy. later I'd like to make a class to make it so you can start a new game.

                // not sure if this will work, but it is just deleting everything in the cast resembles a dino
                //List<Actor> dinos = cast.GetActors("dino");
                //foreach (Actor player in dinos)
                //{
                //    cast.RemoveActor("dino", player);
                //}
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
                //add that enemy to the cast
                cast.AddActor("emeny", enemy);
            }
        
        }
    }
}