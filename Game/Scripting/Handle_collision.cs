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
            Dino dino = (Dino)cast.GetFirstActor("dino");
            Score score = (Score)cast.GetFirstActor("score");
            //turn score into an int
            
            Goal goal = (Goal)cast.GetFirstActor("goal");

            if (dino.GetPosition().Equals(goal.GetPosition()))
            {
                int GoalPoints = 1;
                score += GoalPoints;

            }
        }
    }
}